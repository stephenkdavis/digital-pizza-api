using DigitalPizzaAPI.Models;
using DigitalPizzaAPI.Models.DbModels;
using DigitalPizzaAPI.Models.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DigitalPizzaAPI.Controllers.Application
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(DataContext context, IConfiguration config) : base(context, config) { }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetDetails()
        {
            int userClaim = GetClaimAccountId();

            var user = await data.People.FindAsync(userClaim);
            if (user == null)
                return BadRequest(NewReturnMessage("Unable to load profile details. Please try again later."));

            ArrayList details = new();

            if (user.IsCustomer)
            {
                var userDetails = await data.Customers.FindAsync(userClaim);
                CustomerDto customer = new()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = new()
                    {
                        Phone = user.PhoneNumber
                    },
                    EmailAddress = new()
                    {
                        Email = user.EmailAddress
                    },
                    CustomerId = userDetails.AccountId,
                    RewardsCount = userDetails.RewardsCount
                };
                details.Add(customer);
            }

            if (!user.IsCustomer)
            {
                var userDetails = await data.Employees.FindAsync(userClaim);
                EmployeeDto employee = new()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = new()
                    {
                        Phone = user.PhoneNumber
                    },
                    EmailAddress = new()
                    {
                        Email = user.EmailAddress
                    },
                    EmployeeId = userDetails.AccountId,
                    RoleId = userDetails.RoleId,
                    HireDate = userDetails.HireDate,
                    FireDate = userDetails.FireDate,
                    IsActive = userDetails.IsActive
                };
                details.Add(employee);
            }

            var addressList = await data.Addresses.Where(a => a.AccountId.Equals(userClaim)).ToArrayAsync();
            ArrayList addresses = new();
            foreach (var e in addressList)
            {
                AddressDto dto = new()
                {
                    Label = e.Label,
                    StreetNumber = e.StreetNumber,
                    StreetName = e.StreetName,
                    UnitNumber = e.UnitNumber,
                    City = e.City,
                    Province = e.Province,
                    PostCode = e.PostCode,
                    Notes = e.Notes
                };
                addresses.Add(dto);
            }
            details.Add(addresses);

            return Ok(details);
        }

        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> PostCreate(CustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!dto.Password.New.Password.Equals(dto.Password.Confirm.Password))
                return BadRequest(NewReturnMessage("The passwords must match. Please try again."));

            string? check = CheckPhoneNumber(dto.PhoneNumber.Phone);
            if (!string.IsNullOrEmpty(check))
                return BadRequest(NewReturnMessage(check));

            string pwd = GetPasswordHash(dto.Password.New.Password);

            Person person = new()
            {
                IsCustomer = true,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EmailAddress = dto.EmailAddress.Email,
                PhoneNumber = dto.PhoneNumber.Phone,
                PwdHash = pwd
            };

            data.People.Add(person);
            await data.SaveChangesAsync();

            Address address = new()
            {
                AccountId = person.AccountId,
                Label = dto.Address.Label,
                StreetNumber = dto.Address.StreetNumber,
                StreetName = dto.Address.StreetName,
                UnitNumber = dto.Address.UnitNumber,
                City = dto.Address.City,
                Province = dto.Address.Province,
                PostCode = dto.Address.PostCode,
                Notes = dto.Address.Notes
            };

            Customer customer = new()
            {
                AccountId = person.AccountId,
                RewardsCount = 0
            };

            data.Addresses.Add(address);
            data.Customers.Add(customer);
            await data.SaveChangesAsync();

            return Ok(NewReturnMessage("Account created. Please sign in."));
        }

        [HttpPost]
        [Route("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> PostLogIn(LogInDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string pwdHash = GetPasswordHash(dto.Security.Password);

            var user = await data.People
                .Where(p => p.EmailAddress.ToLower().Equals(dto.User.Email.ToLower()))
                .Where(p => p.PwdHash.Equals(pwdHash))
                .FirstOrDefaultAsync();

            if (user == null)
                return BadRequest(NewReturnMessage("No user found with the given email address and password."));

            string role = user.IsCustomer ? "Customer" : "Employee";

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.UserData, user.AccountId.ToString()),
                new Claim(ClaimTypes.Email, user.EmailAddress.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("TokenSignature")));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: "Digital Pizza API",
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                //expires: DateTime.Now.AddYears(1),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(jwt);
        }

        [HttpPut]
        [Route("Update/Password")]
        public async Task<IActionResult> PutPassword(PasswordChangeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.Equals(dto.New.Password, dto.Confirm.Password))
                return BadRequest(NewReturnMessage("Your new passwords do not match."));

            int userClaim = GetClaimAccountId();
            if (userClaim <= 0)
                return BadRequest(NewReturnMessage("Unable to verify user. Please sign in and try again."));

            var user = await data.People.FindAsync(userClaim);
            if (user == null)
                return BadRequest(NewReturnMessage("Unable to locate user record. Please sign in and try again."));

            user.PwdHash = GetPasswordHash(dto.New.Password);
            data.People.Update(user);
            int result = await data.SaveChangesAsync();
            if (result != 1)
                return BadRequest(NewReturnMessage("Failed to update user password. Please try again."));

            return Ok(NewReturnMessage("Password Updated."));
        }

        [HttpPut]
        [Route("Update/Email")]
        public async Task<IActionResult> PutEmail(EmailAddressDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int userClaim = GetClaimAccountId();
            if (userClaim <= 0)
                return BadRequest(NewReturnMessage("Unable to verify user. Please sign in and try again."));

            var emailCheck = await data.People.Where(a => a.EmailAddress.ToLower().Equals(dto.Email.ToLower())).FirstOrDefaultAsync();

            if (emailCheck != null)
                return BadRequest(NewReturnMessage("The email address provided is already being used. Please try a different one."));

            var user = await data.People.FindAsync(userClaim);
            if (user == null)
                return BadRequest(NewReturnMessage("Unable to locate user record. Please sign in and try again."));

            user.EmailAddress = dto.Email;
            data.People.Update(user);
            int result = await data.SaveChangesAsync();
            if (result != 1)
                return BadRequest(NewReturnMessage("Failed to update user email address. Please try again."));

            return Ok(NewReturnMessage("Email Address Updated."));
        }

        [HttpPut]
        [Route("Update/Phone")]
        public async Task<IActionResult> PutPhone(PhoneNumberDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? check = CheckPhoneNumber(dto.Phone);
            if (!string.IsNullOrEmpty(check))
                return BadRequest(NewReturnMessage(check));

            int userClaim = GetClaimAccountId();
            if (userClaim <= 0)
                return BadRequest(NewReturnMessage("Unable to verify user. Please sign in and try again."));

            var phoneCheck = await data.People.Where(a => a.PhoneNumber.Equals(dto.Phone)).FirstOrDefaultAsync();

            if (phoneCheck != null)
                return BadRequest(NewReturnMessage("The phone number provided is already being used. Please try a different one."));

            var user = await data.People.FindAsync(userClaim);
            if (user == null)
                return BadRequest(NewReturnMessage("Unable to locate user record. Please sign in and try again."));

            user.PhoneNumber = dto.Phone;
            data.People.Update(user);
            int result = await data.SaveChangesAsync();
            if (result != 1)
                return BadRequest(NewReturnMessage("Failed to update user phone number. Please try again."));

            return Ok(NewReturnMessage("Phone Number Updated."));
        }

        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteAccount()
        {
            int userClaim = GetClaimAccountId();
            if (userClaim <= 0)
                return BadRequest(NewReturnMessage("Unable to verify user. Please sign in and try again."));

            var person = await data.People.FindAsync(userClaim);
            var customer = await data.Customers.FindAsync(userClaim);

            data.People.Remove(person);
            data.Customers.Remove(customer);
            int result = await data.SaveChangesAsync();
            if (result != 2)
                return BadRequest(NewReturnMessage("Failed to delete customer account. Please try again."));

            return Ok(NewReturnMessage("Customer Account Deleted."));
        }

        private string GetPasswordHash(string password)
        {
            byte[]? temp = null;

            using (HashAlgorithm algorithm = SHA256.Create())
                temp = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sb = new();

            foreach (byte b in temp)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private string? CheckPhoneNumber(string phone)
        {
            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{4}$");
            bool result = regex.IsMatch(phone);
            return result ? null : "Phone numbers must be in the following format: 123-456-7890";
        }
    }
}

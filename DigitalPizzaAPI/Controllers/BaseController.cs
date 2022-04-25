using DigitalPizzaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace DigitalPizzaAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly DataContext data;
        protected readonly IConfiguration config;

        public BaseController(DataContext data) => this.data = data;
        public BaseController(DataContext data, IConfiguration config)
        {
            this.data = data;
            this.config = config;
        }

        protected JsonObject NewReturnMessage(string message)
        {
            JsonObject json = new()
            {
                ["message"] = message
            };

            return json;
        }

        protected string GetClaimEmail() => User.Claims.First(u => u.Type.Equals(ClaimTypes.Email)).Value.ToString();

        protected string GetClaimRole() => User.Claims.First(u => u.Type.Equals(ClaimTypes.Role)).Value.ToString();

        protected int GetClaimAccountId() => int.Parse(User.Claims.First(u => u.Type.Equals(ClaimTypes.UserData)).Value.ToString());
    }
}

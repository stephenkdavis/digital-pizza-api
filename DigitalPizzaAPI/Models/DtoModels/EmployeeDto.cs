namespace DigitalPizzaAPI.Models.DtoModels
{
    public class EmployeeDto : PersonDto
    {
        public int EmployeeId { get; set; }

        public int RoleId { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? FireDate { get; set; }

        public bool IsActive { get; set; }
    }
}

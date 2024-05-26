namespace EmployeeList.Models.Entities
{
    public class Employees
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Employed { get; set; }

    }
}

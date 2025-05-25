namespace training.Models.DTO
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public Guid? DepartmentId { get; set; }
        public string CreateName { get; set; }
    }
}

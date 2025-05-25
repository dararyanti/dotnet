using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace training.Models.Domain
{
    [Table("dara_employees")]
    public class Employee
    {
        public Employee()
        {
            EmployeeId = Guid.NewGuid();
        }

        [Key]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [Required]
        [Column("first_name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Column("department_id")]
        public Guid? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Required]
        [Column("create_name")]
        [MaxLength(100)]
        public string CreateName { get; set; }
    }
}

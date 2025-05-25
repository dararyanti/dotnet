using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace training.Models.Domain
{
    [Table("dara_departments")]
    public class Department
    {
        [Key]
        [Column("department_id")]
        public Guid DepartmentId { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace IBoss.Models
{
    public class tblEmployee 
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeCode { get; set; }
        public double EmployeeSalary { get; set; }
        public int SupervisorId { get; set; }
        public List<tblEmployeeAttendance> EmployeeAttendances { get; set; }    
    }
}

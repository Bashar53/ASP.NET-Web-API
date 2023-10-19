using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IBoss.Models
{
    public class tblEmployeeAttendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
        public bool IsAbsent { get; set; }
        public bool IsOffday { get; set; }
        [JsonIgnore]
        public tblEmployee tblEmployee { get; set; }       
    }
}

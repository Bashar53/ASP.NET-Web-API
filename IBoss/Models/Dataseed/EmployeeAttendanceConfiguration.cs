using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBoss.Models.Dataseed
{
    public class EmployeeAttendanceConfiguration : IEntityTypeConfiguration<tblEmployeeAttendance>
    {

        public void Configure(EntityTypeBuilder<tblEmployeeAttendance> builder)
        {
            //builder.HasData(
            //    new tblEmployeeAttendance { Id = 1, EmployeeId = 502030, AttendanceDate = new DateTime(2023, 6, 24), IsPresent = true, IsOffday = false },
            //    new tblEmployeeAttendance { Id = 2, EmployeeId = 502030, AttendanceDate = new DateTime(2023, 6, 25), IsPresent = false, IsOffday = true },
            //    new tblEmployeeAttendance { Id = 3, EmployeeId = 502031, AttendanceDate = new DateTime(2023, 6, 25), IsPresent = true, IsOffday = false }
            //// Add more seed data as needed
            //);
        }
    }
}

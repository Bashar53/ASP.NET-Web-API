using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBoss.Models.Dataseed;

public class EmployeeConfiguration :  IEntityTypeConfiguration<tblEmployee>
{
    public void Configure(EntityTypeBuilder<tblEmployee> builder)
    {
        builder.HasData(
            new tblEmployee { EmployeeId = 502030, EmployeeName = "Mehedi Hasan", EmployeeCode = "EMP320", EmployeeSalary = 50000, SupervisorId = 502036 },
            new tblEmployee { EmployeeId = 502031, EmployeeName = "Ashikur Rahman", EmployeeCode = "EMP321", EmployeeSalary = 45000, SupervisorId = 502036 },
            new tblEmployee { EmployeeId = 502032, EmployeeName = "Rakibul Islam", EmployeeCode = "EMP322", EmployeeSalary = 52000, SupervisorId = 502030 },
            new tblEmployee { EmployeeId = 502033, EmployeeName = "Hasan Abdullah", EmployeeCode = "EMP323", EmployeeSalary = 46000, SupervisorId = 502031 },
            new tblEmployee { EmployeeId = 502034, EmployeeName = "Akib Khan", EmployeeCode = "EMP324", EmployeeSalary = 66000, SupervisorId = 502032 },
            new tblEmployee { EmployeeId = 502035, EmployeeName = "Rasel Shikder", EmployeeCode = "EMP325", EmployeeSalary = 53500, SupervisorId = 502033 },
            new tblEmployee { EmployeeId = 502036, EmployeeName = "Selim Reja", EmployeeCode = "EMP326", EmployeeSalary = 59000, SupervisorId = 502035 }
        );
    }

}

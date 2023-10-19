using IBoss.Models;
using IBoss.View_Model;

namespace IBoss.Service
{
    public interface IEmployeeRepository
    {

        Task<tblEmployee> GetByIdAsync(int id);
        Task<IList<tblEmployee>> GetAllAsync();
        Task<bool> AddAsync(tblEmployee employee);
        Task<bool> UpdateAsync(tblEmployee employee);
        Task<bool> DeleteAsync(tblEmployee employee);
        Task<tblEmployee> Get3rdHighestSalary();
        Task<List<tblEmployee>> AllEmployeeSalary();
        Task<string> EmployeeHierarchy(int EmployeeId, string val = "");
        Task<List<AttendanceReport>> CalculateAttendanceReport();
        Task<tblEmployee> UpdateEmployee(tblEmployee employee);
    }
}

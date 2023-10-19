using IBoss.Models;

namespace IBoss.Service
{
    public interface IEmployeeAttendanceRepository  
    {
        Task<tblEmployeeAttendance> GetByIdAsync(int id);
        Task<IList<tblEmployeeAttendance>> GetAllAsync();
        Task<bool> AddAsync(tblEmployeeAttendance employeeAttendance);
        Task<bool> UpdateAsync(tblEmployeeAttendance employeeAttendance);
        Task<bool> DeleteAsync(tblEmployeeAttendance employeeAttendance);
    }
}

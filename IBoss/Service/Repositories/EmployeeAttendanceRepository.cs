using IBoss.DbCon;
using IBoss.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace IBoss.Service.Repositories;

public class EmployeeAttendanceRepository : IEmployeeAttendanceRepository
{
    private readonly IBossProjectDbContext _context;

    public EmployeeAttendanceRepository(IBossProjectDbContext context)
    {
        _context = context;
    }

    


    #region CRUD functionality
    public async Task<bool> AddAsync(tblEmployeeAttendance employeeAttendance)
    {
        await _context.AddAsync(employeeAttendance);
        return true;
    }


    public async Task<IList<tblEmployeeAttendance>> GetAllAsync()
    {
        return await _context.EmployeeAttendances.ToListAsync();
    }

    public async Task<tblEmployeeAttendance> GetByIdAsync(int id)
    {
        return await _context.EmployeeAttendances.FindAsync(id);
    }

    public async Task<bool> DeleteAsync(tblEmployeeAttendance employeeAttendance)
    {
        var data = await GetByIdAsync(employeeAttendance.EmployeeId);
        if (data != null)
        {
            _context.EmployeeAttendances.Remove(data);
            //await Task.CompletedTask;
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateAsync(tblEmployeeAttendance employeeAttendance)
    {
        var data = await GetByIdAsync(employeeAttendance.EmployeeId);
        if (data != null)
        {
            _context.EmployeeAttendances.Update(data);
            //await Task.CompletedTask;
            return true;
        }
        return false;
    }
    #endregion
}
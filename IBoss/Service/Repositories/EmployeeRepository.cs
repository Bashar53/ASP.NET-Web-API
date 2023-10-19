using IBoss.DbCon;
using IBoss.Models;
using IBoss.View_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace IBoss.Service.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly IBossProjectDbContext _context;

    public EmployeeRepository(IBossProjectDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(tblEmployee employee)
    {
        await _context.Employees.AddAsync(employee);
        return true;
    }

    public async Task<IList<tblEmployee>> GetAllAsync()
    {
        return await _context.Employees
            .Include(x => x.EmployeeAttendances)
            .ToListAsync();
    }

    public async Task<tblEmployee> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<bool> DeleteAsync(tblEmployee employee)
    {
        var data = await GetByIdAsync(employee.EmployeeId);
        if (data != null)
        {
            _context.Remove(data);
            //await Task.CompletedTask;
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateAsync(tblEmployee employee)
    {
        var data = await GetByIdAsync(employee.EmployeeId);
        if (data != null)
        {
            _context.Update(data);
            //await Task.CompletedTask;
            return true;
        }
        return false;
    }
//endregion
    //public  Get3rdHighestSalary
    public async Task<tblEmployee> Get3rdHighestSalary()
    {
        var employee = (await GetAllAsync())
            .OrderByDescending(e => e.EmployeeSalary)
            .Skip(2)
            .FirstOrDefault();
        return employee;
    }

    public async Task<List<tblEmployee>> AllEmployeeSalary()
    {
        var data2 = await _context.Employees
            .Include(x => x.EmployeeAttendances)
            .ToListAsync();
        var data = data2.
            Where(e => e.EmployeeAttendances.Count > 0 && e.EmployeeAttendances.All(y => y?.IsPresent == true))
            .OrderByDescending(m => m.EmployeeSalary)
            .ToList();
        return data;
    }
    public async Task<string> EmployeeHierarchy(int EmployeeId, string val = "")
    {
        var data = await GetByIdAsync(EmployeeId);
        if (data == null || (val != null && val.Contains(data.EmployeeName)))
            return val + ".";
        val = val + data.EmployeeName + " -> ";
        return await EmployeeHierarchy(data.SupervisorId, val);
    }
    public async Task<List<AttendanceReport>> CalculateAttendanceReport()   
    {
        var data2 = _context.EmployeeAttendances.Include(x => x.tblEmployee);
        var data = data2
            .GroupBy(a => new { a.EmployeeId, a.tblEmployee.EmployeeName, a.AttendanceDate.Month })
        .Select(s => new AttendanceReport()
        {
            EmployeeName = s.Key.EmployeeName,
            MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(s.Key.Month),
            PayableSalary = s.Select(a => a.tblEmployee.EmployeeSalary).FirstOrDefault(),
            TotalPresent = s.Count(a => a.IsPresent == true),
            TotalAbsent = s.Count(a => !a.IsPresent && !a.IsOffday),
            TotalOffday = s.Count(a => a.IsOffday)
        }).ToList();
        return data;
    }
    public async Task<tblEmployee> UpdateEmployee(tblEmployee employee)
    {

        var retrive = await _context.Employees.FindAsync(employee.EmployeeId);
        retrive.EmployeeName = employee.EmployeeName;
        retrive.EmployeeCode = employee.EmployeeCode;
        try
        {
            _context.Entry(retrive).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return retrive;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (retrive == null)
            {
                return retrive;
            }
            throw;
        }
        //_context.SaveChanges();
        //return retrive;

    }
}


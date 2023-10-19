using IBoss.DbCon;
using IBoss.Models;
using IBoss.Service;
using IBoss.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace IBoss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IBossProjectDbContext _context;
        private readonly IEmployeeRepository _employeeRepo;


        //public EmployeeController(IBossProjectDbContext context)
        //{
        //    _context = context;
        //}

        public EmployeeController(IEmployeeRepository employeeRepo, IBossProjectDbContext context)
        {
            _employeeRepo = employeeRepo;
            _context = context;
        }



        [HttpPut("UpdateEmployee/{id}")]
        public async Task<ActionResult<tblEmployee>> PutAPI01(int id, tblEmployee employee)
        {
            //if (id != employee.EmployeeId)
            if (employee.EmployeeId == null)
            {
                return BadRequest();
            }
            try
            {
                var data = await _employeeRepo.UpdateEmployee(employee);
                return Ok(data);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
                throw;
            }
            //return BadRequest();
        }

        // GET api/<EmployeeController>/5
        //[HttpGet]
        //[Route("api/API02")]
        //[Route("Get3rdHighestSalary")]
        [HttpGet("Get3rdHighestSalary")]
        public async Task<ActionResult<tblEmployee>> API02()
        {
            return await _employeeRepo.Get3rdHighestSalary(); ;
        }

        //GET: api/<EmployeeController>
        //[HttpGet("All-employee-salary")]
        [HttpGet("AllEmployeeSalary")]
        public async Task<ActionResult<List<tblEmployee>>> API03()
        {
            var data = await _employeeRepo.AllEmployeeSalary();
            return data;
        }



        // POST api/<EmployeeController>
        //[HttpGet("AttendanceReport")]
        [HttpGet("AttendanceReport")]
        public async Task<ActionResult<List<AttendanceReport>>> API04()
        {
            var data = await _employeeRepo.CalculateAttendanceReport();

            if (data.Count == 0)
                return NotFound();
            return data;
        }

        [HttpGet("EmployeeHierarchy")]
        public async Task<ActionResult<string>> API05(int EmployeeId)
        {
            return await _employeeRepo.EmployeeHierarchy(EmployeeId, null);
        }







        //API02
        //[HttpGet("Get3rdHighestSalary1")]

        //public async Task<ActionResult<tblEmployee>> GetEmployee()       //control dot on student to recognize
        //{
        //   // return await _context.Employees.ToListAsync();
        //    var result = _context.Employees.OrderByDescending(e => e.employeeSalary).Skip(2).First();
        //    return result;
        //}

        //API03

        //[HttpGet("API03")]

        //public async Task<ActionResult<List<tblEmployeeAttendance>>> GetEmployeeAttendence()          //control dot on student to recognize
        //{

        //    //var result2 = _context.EmployeeAttendances();
        //    //   .Where(e => e.isAbsent ==0);

        //    var data = _context.EmployeeAttendances.ToList();
        //    var data2 = data
        //        .Where(e => e.IsAbsent = true).ToList();
        //    return data2;

        //}

        //[HttpGet("{id:int}")]

        //public async Task<ActionResult<tblEmployee>> GetEmployee(int id)    
        //{
        //     return await _context.Employees.FindAsync(id);


        //}

        //[HttpPost]

        //public async Task<ActionResult<tblEmployee>> PostEmployee(tblEmployee employee) 
        //{
        //    _context.Employees.Add(employee);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);



        //}

        ////API01

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<tblEmployee>> PutEmployee(int id, tblEmployee employee)
        //{
        //    if (id != employee.EmployeeId)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(employee).State = EntityState.Modified;
        //    _context.Entry(employee).Property("employeeSalary").IsModified = false;
        //    _context.Entry(employee).Property("supervisorId").IsModified = false;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {

        //        if (!EmployeeExist(id))
        //        {
        //            return NotFound();
        //        }

        //        throw;
        //    }
        //    return NoContent();
        //}



        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> DeleteEmployee(int id)  
        //{
        //    if (!EmployeeExist(id))
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees.FindAsync(id);

        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();


        //    return NoContent();

        //}

        //private bool EmployeeExist(int id)
        //{
        //    return _context.Employees.Any(x => x.EmployeeId == id);

        //}
    }
}

using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext:DbContext
    {


        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        //{ 
        
        //Actually this is used  if  we have multiple ApplicationDbContext the you have to write in the formate with type=ApplicationDbContex
        
        //Other wise you can write like below :
        //}

        public  ApplicationDbContext(DbContextOptions option):base(option) 
        { 

        }

        public DbSet<Employee> Employees { get; set; }
    }
}

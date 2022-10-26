using InternshipApp.Models;
using InternshipApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApp
{
    public class ApplicationContext : DbContext, IDataStore<Employee>
    {
        public ApplicationContext(string dbPath) : base()
        {
            _dbPath = dbPath;

            Database.EnsureCreated();
        }
        private string _dbPath;
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(p => p.ID);

            modelBuilder.Entity<Employee>().Property(p => p.Name).IsRequired();
        }

        #region IDataStore<Employee> start
        public async Task<Employee> GetItemAsync(string id)
        {
            var employee = await Employees.FirstOrDefaultAsync(x => x.ID == id).ConfigureAwait(false);
            return employee;
        }
        public async Task<IEnumerable<Employee>> GetItemsAsync(bool forceRefresh = false)
        {
            foreach(var employee in Employees.Local)
            {
                Employees.Add(employee);
            }
            var employees = await Employees.ToListAsync().ConfigureAwait(false);
            return employees;
        }
        public async Task<bool> AddItemAsync(Employee employee)
        {
            await Employees.AddAsync(employee).ConfigureAwait(false);
            return true;
        }
        public async Task<bool> UpdateItemAsync(Employee employee)
        {
            Employees.Update(employee);
            await SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
        public async Task<bool> DeleteItemAsync(string id)
        {
            var employeeToRemove = Employees.FirstOrDefault(x => x.ID == id);
            if (employeeToRemove != null)
            {
                Employees.Remove(employeeToRemove);
                await SaveChangesAsync().ConfigureAwait(false);
            }
            return true;
        }
        #endregion IDataStore<Employee>
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipApp.Models;

namespace InternshipApp.Services
{
    public class MockDataStore : IDataStore<Employee>
    {
        readonly List<Employee> employees;

        public MockDataStore()
        {
            employees = new List<Employee>()
            {
                new Employee 
                { 
                    ID = Guid.NewGuid().ToString(), 
                    Name = "f",
                    Surname = "f",
                    Patronymic = "f",
                    Email = "f"
                }
                
            };
        }

        public async Task<bool> AddItemAsync(Employee employee)
        {
            employees.Add(employee);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Employee employee)
        {
            var oldEmployee = employees.Where((Employee arg) => arg.ID == employee.ID).FirstOrDefault();
            employees.Remove(oldEmployee);
            employees.Add(employee);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldEmployee = employees.Where((Employee arg) => arg.ID == id).FirstOrDefault();
            employees.Remove(oldEmployee);

            return await Task.FromResult(true);
        }

        public async Task<Employee> GetItemAsync(string id)
        {
            return await Task.FromResult(employees.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Employee>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(employees);
        }
    }
}
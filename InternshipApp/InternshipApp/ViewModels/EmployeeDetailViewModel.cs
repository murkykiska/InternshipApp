using InternshipApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InternshipApp.ViewModels
{
    [QueryProperty(nameof(EmployeeID), nameof(EmployeeID))]
    public class EmployeeDetailViewModel : BaseViewModel
    {
        private string employeeID;
        private string name;
        private string surname;
        private string patronymic;
        private string email;
        public string ID { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }
        public string Patronymic
        {
            get => patronymic;
            set => SetProperty(ref patronymic, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
                LoadEmployeeId(value);
            }
        }

        public async void LoadEmployeeId(string employeeID)
        {
            try
            {
                var employee = await DataStore.GetItemAsync(employeeID);
                ID = employee.ID;
                Name = employee.Name;
                Surname = employee.Surname;
                Patronymic = employee.Patronymic;
                Email = employee.Email;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}

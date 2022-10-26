using InternshipApp.Models;
using InternshipApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InternshipApp.ViewModels
{
    public class EmployeesViewModel : BaseViewModel
    {
        private Employee _selectedEmployee;

        public ObservableCollection<Employee> Employees { get; }
        public Command LoadEmployeesCommand { get; }
        public Command AddEmployeeCommand { get; }
        public Command<Employee> EmployeeTapped { get; }

        public EmployeesViewModel()
        {
            Title = "Browse";
            Employees = new ObservableCollection<Employee>();
            LoadEmployeesCommand = new Command(async () => await ExecuteLoadEmployeesCommand());
            EmployeeTapped = new Command<Employee>(OnEmployeeSelected);
            AddEmployeeCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadEmployeesCommand()
        {
            IsBusy = true;

            try
            {
                Employees.Clear();
                var employees = await DataStore.GetItemsAsync(true);
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedEmployee = null;
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                SetProperty(ref _selectedEmployee, value);
                OnEmployeeSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewEmployeePage));
        }

        async void OnEmployeeSelected(Employee employee)
        {
            if (employee == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(EmployeeDetailPage)}?{nameof(EmployeeDetailViewModel.EmployeeID)}={employee.ID}");
        }
    }
}
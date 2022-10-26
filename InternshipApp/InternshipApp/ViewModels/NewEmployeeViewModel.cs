using InternshipApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace InternshipApp.ViewModels
{
    public class NewEmployeeViewModel : BaseViewModel
    {
        private string name;
        private string surname;
        private string patronymic;
        private string email;

        public NewEmployeeViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(surname)
                && !String.IsNullOrWhiteSpace(patronymic)
                && !String.IsNullOrWhiteSpace(email);
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Employee newEmployee = new Employee()
            {
                ID = Guid.NewGuid().ToString(),
                Name = name,
                Surname = surname,
                Patronymic = patronymic,
                Email = email
            };

            await DataStore.AddItemAsync(newEmployee);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

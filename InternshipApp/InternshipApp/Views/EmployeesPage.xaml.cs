using InternshipApp.Models;
using InternshipApp.ViewModels;
using InternshipApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternshipApp.Views
{
    public partial class EmployeesPage : ContentPage
    {
        EmployeesViewModel _viewModel;

        public EmployeesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new EmployeesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
using InternshipApp.Models;
using InternshipApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternshipApp.Views
{
    public partial class NewEmployeePage : ContentPage
    {
        public Employee Employee { get; set; }

        public NewEmployeePage()
        {
            InitializeComponent();
            BindingContext = new NewEmployeeViewModel();
        }
    }
}
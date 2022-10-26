using InternshipApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace InternshipApp.Views
{
    public partial class EmployeeDetailPage : ContentPage
    {
        public EmployeeDetailPage()
        {
            InitializeComponent();
            BindingContext = new EmployeeDetailViewModel();
        }
    }
}
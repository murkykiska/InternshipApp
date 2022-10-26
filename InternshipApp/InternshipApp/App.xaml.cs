using InternshipApp.Services;
using InternshipApp.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternshipApp
{
    public partial class App : Application
    {
        public static ApplicationContext ApplicationContext;
        public App(string dbPath)
        {
            InitializeComponent();

            ApplicationContext = new ApplicationContext(dbPath);

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

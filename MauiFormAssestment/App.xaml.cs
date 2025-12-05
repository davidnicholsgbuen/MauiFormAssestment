using MauiFormAssestment.Data;
using MauiFormAssestment.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MauiFormAssestment
{
public partial class App : Application
    {
        public App(MainPage mainPage)
        {

            InitializeComponent();

            MainPage = new NavigationPage(mainPage);
        }
    }
}
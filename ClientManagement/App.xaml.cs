using System;
using ClientManagement.viewModels;
using ClientManagement.views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientManagement
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage( new ClientsPage() { BindingContext = new ClientsViewModel()});
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

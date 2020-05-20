using System;
using ClientManagement.viewModels;
using ClientManagement.views;
using Plugin.SharedTransitions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientManagement
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new SharedTransitionNavigationPage(new ClientsPage() { BindingContext = new ClientsViewModel() })
			{
				BarTextColor = Color.FromHex("#FFAA00"),
			};
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

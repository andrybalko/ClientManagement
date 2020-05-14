using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientManagement.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientsPage : ContentPage
	{
		public ClientsPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (Clients != null)
			{
				Clients.SelectedItem = null;
			}
		}

	}
}
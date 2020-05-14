using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ClientManagement.models;
using ClientManagement.views;
using Xamarin.Forms;

namespace ClientManagement.viewModels
{
	public class DetailsViewModel : ViewModelBase
	{
		public Client Client { get; set; }

		public ICommand EditClientCommand => new Command<Client>(client =>
		{
			if (client != null)
			{
				App.Current.MainPage.Navigation.PushAsync(new AddClientPage() { BindingContext = new AddClientViewModel(client) });
			}
		});

		public DetailsViewModel(Client client)
		{
			Client = client;
		}

		public DetailsViewModel()
		{
		}
	}
}

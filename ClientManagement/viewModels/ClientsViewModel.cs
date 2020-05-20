using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using ClientManagement.models;
using ClientManagement.models.stub;
using ClientManagement.views;
using Xamarin.Forms;
using Plugin.SharedTransitions;

namespace ClientManagement.viewModels
{
	public class ClientsViewModel : ViewModelBase
	{
		private string filter;
		private ObservableCollection<Client> clients;
		private Client selectedClient;
		private string sorting;

		public ObservableCollection<Client> Clients { get; set; }
		public ICommand ChangeSortCommand => new Command(() =>
		{
			Sorting = Sorting == SortingArrow.Up ? SortingArrow.Down : SortingArrow.Up;
			UpdateClients();
		});

		public string Sorting { get => sorting; set => Set(ref sorting, value); }

		public ICommand AddClientCommand => new Command(() =>
		{
			App.Current.MainPage.Navigation.PushAsync(new AddClientPage() { BindingContext = new AddClientViewModel() });
		});

		public Client SelectedClient
		{
			get => selectedClient;
			set
			{
				selectedClient = value;
				//TODO navigate to details or add

				if (value != null)
				{
					App.Current.MainPage.Navigation.PushAsync(new DetailsPage() { BindingContext = new DetailsViewModel(selectedClient) });
				}

			}
		}

		public ClientsViewModel()
		{
			Sorting = SortingArrow.Up;
			clients = new ObservableCollection<Client>();
			for (int i = 20; i >= 0; i--)
			{
				clients.Add(Data.GetClient);
			}

			UpdateClients();
		}

		public ObservableCollection<Client> FilteredClients { get; set; }

		public string Filter
		{
			get => filter ?? string.Empty;
			set
			{
				Set(ref filter, value);

				UpdateClients();
			}
		}

		private void UpdateClients()
		{
			var l = clients.Where(x => x.FullName.ToLower().Contains(Filter.ToLower()));

			if (Sorting == SortingArrow.Down)
			{
				l = l.OrderBy(x => x.Created).ToList();
			}
			else
			{
				l = l.OrderByDescending(x => x.Created).ToList();
			}

			Clients = new ObservableCollection<Client>(l);
			RaisePropertyChanged(nameof(Clients));
		}
	}

	internal class SortingArrow
	{
		internal const string Up = "\uf30c";
		internal const string Down = "\uf309";
	}
}

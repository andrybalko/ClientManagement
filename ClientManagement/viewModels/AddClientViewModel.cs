using System;
using System.Windows.Input;
using ClientManagement.models;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace ClientManagement.viewModels
{
	public class AddClientViewModel : DetailsViewModel
	{
		public string PageTitle { get; set; }

		public AddClientViewModel()
		{
			//Client creation
			Client = Client.Empty;
			PageTitle = "Add Client";
		}

		public AddClientViewModel(Client Client) : base(Client)
		{
			//invoked in case of edit Client
			PageTitle = "Edit " + Client.FullName;
		}

		public ICommand SaveCommand => new Command(() => 
		{
			if (Validate(Client))
			{
				Client.Created = DateTime.Now;
				App.Current.MainPage.Navigation.PopToRootAsync();
			}
			else
			{
				UserDialogs.Instance.Toast("Error. Check fields and try again", TimeSpan.FromSeconds(10));
			}
		});

		private bool Validate(Client Client)
		{
			return !string.IsNullOrEmpty(Client.FirstName) && !string.IsNullOrEmpty(Client.LastName);
		}
	}
}

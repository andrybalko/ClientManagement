using GalaSoft.MvvmLight;
using System;
using System.Runtime.ConstrainedExecution;

namespace ClientManagement.models
{
	public class Client: ObservableObject
	{
		private string _firstName;

		public string FirstName
		{
			get { return _firstName; }
			set { Set(ref _firstName, value); }
		}

		private string _lastName;

		public string LastName
		{
			get { return _lastName; }
			set { Set(ref _lastName, value); }
		}

		public string FullName => FirstName + " " + LastName;

		private string _avatar;

		public string Avatar 
		{
			get { return _avatar; }
			set { Set(ref _avatar, value); }
		}

		public string Description { get; set; }

		public DateTime Created { get; set; }

		public Address Address { get; set; }

		public static Client Empty => new Client()
		{
			Address = new Address(),
		};
	}

	public class Address:ObservableObject
	{
		public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public int PostalCode { get; set; }
		public string Mobile { get; set; }
		public string Landline { get; set; }
		public string WorkPhone { get; set; }
	}
}

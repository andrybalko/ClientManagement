﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace ClientManagement.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddClientPage : ContentPage
	{
		public AddClientPage()
		{
			InitializeComponent();
			On<iOS>().SetUseSafeArea(true);
		}
	}
}
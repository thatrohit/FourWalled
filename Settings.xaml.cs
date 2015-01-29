using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace FourWalled
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (IsolatedStorageSettings.ApplicationSettings.Contains("sfw"))
            {
                lpContent.SelectedIndex = Int32.Parse(IsolatedStorageSettings.ApplicationSettings["sfw"].ToString());
            }
            else
            {
                lpContent.SelectedIndex = 1;
                IsolatedStorageSettings.ApplicationSettings.Add("sfw", 1);
            }
        }

        private void lpContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings.Remove("sfw");
            IsolatedStorageSettings.ApplicationSettings.Add("sfw", lpContent.SelectedIndex); ;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }
}
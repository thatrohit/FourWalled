using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FourWalled.Resources;
using FourWalled.Utils;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Media.Animation;
using FourWalled.Models;
using System.IO.IsolatedStorage;

namespace FourWalled
{
    public partial class MainPage : PhoneApplicationPage
    {
        ImageBrush ib = new ImageBrush();
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!IsolatedStorageSettings.ApplicationSettings.Contains("sfw"))
            {
                IsolatedStorageSettings.ApplicationSettings.Add("sfw", 1);
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
            ThumbnailScraper scraper = new ThumbnailScraper();
            await scraper.DownloadSiteHTML(CommonStuff.initParams);
            lbThumbs.ItemsSource = Utils.CommonStuff.randomImageModels = scraper.GenerateImageThumbnailClasses();
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void GoToPhotoGridPage(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PhotoGridPage.xaml", UriKind.Relative));
        }

        private void lbThumbs_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            CommonStuff.selectedImage = (ImageModel)lbThumbs.SelectedItem;
            NavigationService.Navigate(new Uri("/ImageViewer.xaml", UriKind.Relative));
        }

        private void GoToSettings(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void GoToAbout(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
    }
}
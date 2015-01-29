using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FourWalled.Utils;
using FourWalled.Models;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;

namespace FourWalled
{
    public partial class PhotoGridPage : PhoneApplicationPage
    {
        ObservableCollection<ImageModel> thumbsList;
        ImageModel loadMore;
        ThumbnailScraper scraper;

        public PhotoGridPage()
        {
            InitializeComponent();
            loadMore = new ImageModel(new System.Windows.Media.Imaging.BitmapImage(new Uri("/Assets/Images/more.png", UriKind.Relative)), new Uri("http://temprui.com"));
            scraper = new ThumbnailScraper();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            scraper = new ThumbnailScraper();
        }

        private async void LoadWalls(object sender, RoutedEventArgs e)
        {
            lbThumbs.ItemsSource = null;

            string parameters = "tags=";
            parameters += tbSearch.Text.Trim() == string.Empty ? "" : tbSearch.Text.Replace(" ", "+");
            parameters += "&board=";
            parameters += "&width_aspect=&searchstyle=exact&sfw=";
            parameters += (Int32.Parse(IsolatedStorageSettings.ApplicationSettings["sfw"].ToString()) - 1).ToString() + "&search=search";
            //0"
            await scraper.DownloadSiteHTML(parameters);
            thumbsList = new ObservableCollection<ImageModel>(scraper.GenerateImageThumbnailClasses());
            if (thumbsList.Any())
            {
                thumbsList.Add(loadMore);
            }
            else
            {
                MessageBox.Show("Nothing found for " + tbSearch.Text);
            }
            lbThumbs.ItemsSource = thumbsList;
        }

        private async void lbThumbs_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            if (((ImageModel)lbThumbs.SelectedItem).Link.OriginalString == "http://temprui.com")
            {
                thumbsList.Remove(loadMore);

                string parameters = "tags=";
                parameters += tbSearch.Text.Trim() == string.Empty ? "" : tbSearch.Text.Replace(" ", "+");
                parameters += "&board=";
                parameters += "&width_aspect=&searchstyle=exact&sfw=" + (Int32.Parse(IsolatedStorageSettings.ApplicationSettings["sfw"].ToString()) - 1).ToString();
                parameters += "&search=search&offset=" + thumbsList.Count.ToString();

                await scraper.DownloadSiteHTML(parameters);

                var offsetImages = new ObservableCollection<ImageModel>(scraper.GenerateImageThumbnailClasses());
                foreach (var image in offsetImages)
                {
                    thumbsList.Add(image);
                }
                if (offsetImages.Any()) thumbsList.Add(loadMore);

                return;
            }
            CommonStuff.selectedImage = (ImageModel)lbThumbs.SelectedItem;
            NavigationService.Navigate(new Uri("/ImageViewer.xaml", UriKind.Relative));
        }

        private void lbThumbs_ScrollStateChanged(object sender, Telerik.Windows.Controls.ScrollStateChangedEventArgs e)
        {

        }
    }
}
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
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Reactive;
using Microsoft.Phone.Tasks;

namespace FourWalled
{
    public partial class ImageViewer : PhoneApplicationPage
    {
        BitmapImage wallpaper;
        public ImageViewer()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            WallpaperScraper.dateAdded = WallpaperScraper.resolution = WallpaperScraper.tags = "";
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
            ScrapeHighResImage();
        }

        private async void ScrapeHighResImage()
        {
            wallpaper = await WallpaperScraper.ScrapeWallpaper(CommonStuff.selectedImage.Link.AbsoluteUri);
            tblockResolution.Text = WallpaperScraper.resolution;
            tblockDateAdded.Text = WallpaperScraper.dateAdded;
            tblockTags.Text = WallpaperScraper.tags;
            rsvImageViewer.Source = wallpaper;
        }

        private void SaveToMediaLibrary(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }

        private void SaveWallpaper(object sender, EventArgs e)
        {
            LoaderGrid.Visibility = Visibility.Visible;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
            Scheduler.Dispatcher.Schedule(() => { CommonStuff.SaveToMediaLibrary(new WriteableBitmap(wallpaper), DateTime.Now.ToString() + ".jpg"); }, TimeSpan.FromSeconds(.1));
            MessageBox.Show("Saved");
            LoaderGrid.Visibility = Visibility.Collapsed;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
        }

        private void rsvImageViewer_ImageOpened(object sender, RoutedEventArgs e)
        {
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
        }

        private void ShareWallpaper(object sender, EventArgs e)
        {
            ShareLinkTask share = new ShareLinkTask();
            share.LinkUri = CommonStuff.selectedImage.Link;
            share.Show();
        }
    }
}
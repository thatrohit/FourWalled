﻿#pragma checksum "C:\Users\Rohit\Documents\Visual Studio 2012\Projects\FourWalled\FourWalled\ImageViewer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E1FB5FE85CEA95A89352F4D9CCCFE780"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using Telerik.Windows.Controls.SlideView;


namespace FourWalled {
    
    
    public partial class ImageViewer : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btnSave;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btnShare;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Telerik.Windows.Controls.SlideView.PanAndZoomImage rsvImageViewer;
        
        internal System.Windows.Controls.TextBlock tblockResolution;
        
        internal System.Windows.Controls.TextBlock tblockDateAdded;
        
        internal System.Windows.Controls.TextBlock tblockTags;
        
        internal System.Windows.Controls.Grid LoaderGrid;
        
        internal System.Windows.Controls.TextBlock tblockLoaderText;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/FourWalled;component/ImageViewer.xaml", System.UriKind.Relative));
            this.btnSave = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btnSave")));
            this.btnShare = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btnShare")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.rsvImageViewer = ((Telerik.Windows.Controls.SlideView.PanAndZoomImage)(this.FindName("rsvImageViewer")));
            this.tblockResolution = ((System.Windows.Controls.TextBlock)(this.FindName("tblockResolution")));
            this.tblockDateAdded = ((System.Windows.Controls.TextBlock)(this.FindName("tblockDateAdded")));
            this.tblockTags = ((System.Windows.Controls.TextBlock)(this.FindName("tblockTags")));
            this.LoaderGrid = ((System.Windows.Controls.Grid)(this.FindName("LoaderGrid")));
            this.tblockLoaderText = ((System.Windows.Controls.TextBlock)(this.FindName("tblockLoaderText")));
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using WindowsSecurityClone;
using Windows.UI.ApplicationSettings;
using Microsoft.UI.Windowing;
using Microsoft.UI;

namespace Windows_Security_Clone
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ConfigureWindow();
            Nav.SelectedItem = NavHomePage;
            contentFrame.Navigate(typeof(HomePage));
        }

        private void ConfigureWindow()
        {
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            this.ExtendsContentIntoTitleBar = true;
            SetTitleBar(null);

            if (appWindow?.Presenter is OverlappedPresenter presenter)
            {
                presenter.SetBorderAndTitleBar(true, true);
                presenter.IsResizable = true;
            }
        }

        public void NavigateToPage(Type pageType)
        {
            contentFrame.Navigate(pageType);
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem selectedItem)
            {
                switch (selectedItem.Tag)
                {
                    case "HomePage":
                        NavigateToPage(typeof(HomePage));
                        break;
                    case "VirusThreatProtectionPage":
                        NavigateToPage(typeof(VirusThreatProtectionPage));
                        break;
                    case "AccountProtectionPage":
                        NavigateToPage(typeof(AccountProtectionPage));
                        break;
                    case "FirewallNetworkProtectionPage":
                        NavigateToPage(typeof(FirewallNetworkProtectionPage));
                        break;
                    case "AppBrowserControlPage":
                        NavigateToPage(typeof(AppBrowserControlPage));
                        break;
                    case "DeviceSecurityPage":
                        NavigateToPage(typeof(DeviceSecurityPage));
                        break;
                    case "DevicePerformanceHealthPage":
                        NavigateToPage(typeof(DevicePerformanceHealthPage));
                        break;
                    case "FamilyOptionsPage":
                        NavigateToPage(typeof(FamilyOptionsPage));
                        break;
                    case "ProtectionHistoryPage":
                        NavigateToPage(typeof(ProtectionHistoryPage));
                        break;
                    case "SettingsPage": 
                        NavigateToPage(typeof(SettingsPage)); 
                        break;
                }
            }
        }
    }
}

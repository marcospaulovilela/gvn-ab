﻿using gvn_ab_mobile.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace gvn_ab_mobile {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage() {
            Current.MainPage = new NavigationPage(new LoginPage()) {
                BarBackgroundColor = Color.SteelBlue
            };
            
            //new TabbedPage {
            //    Children = {
            //        new NavigationPage(new UsuariosPage()) {
            //            Title = "Browse",
            //            Icon = Device.OnPlatform("tab_feed.png",null,null)
            //        },
            //        new NavigationPage(new AboutPage()) {
            //            Title = "About",
            //            Icon = Device.OnPlatform("tab_about.png",null,null)
            //        },
            //    }
            //};
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePopUp : Rg.Plugins.Popup.Pages.PopupPage {
        public PagePopUp() {
            InitializeComponent();
        }
    }
}
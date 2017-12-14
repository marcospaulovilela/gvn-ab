using System;

using gvn_ab_mobile.Models;

using Xamarin.Forms;

namespace gvn_ab_mobile.Views {
    public partial class NewItemPage : ContentPage {
        public Item Item { get; set; }

        public NewItemPage() {
            InitializeComponent();

            Item = new Item {
                Text = "Item name",
                Description = "This is a nice description"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e) {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
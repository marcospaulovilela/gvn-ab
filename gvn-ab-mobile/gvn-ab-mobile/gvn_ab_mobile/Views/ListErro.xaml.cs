using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gvn_ab_mobile.ViewModels;

namespace gvn_ab_mobile.Views {
    public class ErroItem {
        public ErroItem(Tuple<object, string> data) { this.Data = data; }
        public Tuple<object, string> Data { get; set; }
        public string toString { get { return $"{this.Data.Item1.ToString()} | {this.Data.Item2}"; } }
    }

    public class ListErroViewModel : BaseViewModel {
        public List<ErroItem> Erros { get; set; }
        public ListErroViewModel(List<ErroItem> erros) {
            this.Erros = erros;
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListErro : ContentPage {
        public ListErro(ListErroViewModel viewModel) {
            InitializeComponent();
            this.BindingContext = viewModel;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
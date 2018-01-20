using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gvn_ab_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FamiliaRow : gvn_ab_mobile.Controls.TableGridPage
    {
        gvn_ab_mobile.Controls.TableGridViewModel viewModel;

        public FamiliaRow(gvn_ab_mobile.Controls.TableGridViewModel viewModel, object item) : base(viewModel, item)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

    }
}
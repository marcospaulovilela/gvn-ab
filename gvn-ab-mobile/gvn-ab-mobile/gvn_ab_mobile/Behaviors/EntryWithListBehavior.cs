using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public class EntryWithListBehavior : EntryDifferZeroBehavior {
        public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(nameof(SelectedItems), typeof(ObservableCollection<object>), typeof(EntryWithListBehavior), null);
        public ObservableCollection<object> SelectedItems {
            get { return (ObservableCollection<object>)GetValue(SelectedItemsProperty); }
        }

        public EntryWithListBehavior() {
            base.MinLength = 0;
            base.MaxLength = 2;
        }

        protected override void OnAttachedTo(Entry bindable) {
            bindable.TextChanged += OnEntryTextChanged;

            //COMO O BEHAVIOR NÃO HERDA O CONTEXTO DA VIEW QUE ELE ESTÁ, DEVE SER SETADO O MESMO CONTEXTO DO COMPONENTE QUE O INVOCA
            bindable.BindingContextChanged += (sender, _) => this.BindingContext = ((BindableObject)sender).BindingContext;
        }

        protected override void OnDetachingFrom(Entry bindable) {
            bindable.TextChanged -= OnEntryTextChanged;
        }

        public override bool isValid(object input) {
            int value;
            if(int.TryParse((string)input, out value)) {
                return value >= this.SelectedItems?.Count();
            } else {
                return true;
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public class ButtonSubmitBehavior : Behavior<Button> {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ButtonSubmitBehavior), null);

        public ICommand Command {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public string Controls { get; set; }

        protected override void OnAttachedTo(Button bindable) {
            base.OnAttachedTo(bindable);

            bindable.Clicked += OnClicked;

            //COMO O BEHAVIOR NÃO HERDA O CONTEXTO DA VIEW QUE ELE ESTÁ, DEVE SER SETADO O MESMO CONTEXTO DO COMPONENTE QUE O INVOCA
            bindable.BindingContextChanged += (sender, _) => this.BindingContext = ((BindableObject)sender).BindingContext;
        }


        protected override void OnDetachingFrom(Button bindable) {
            base.OnDetachingFrom(bindable);
            bindable.Clicked -= OnClicked;

        }

        void OnClicked(object sender, EventArgs args) {
            Element root;
            var Button = (Button)sender;
            //==========================
            if (!string.IsNullOrEmpty(this.Controls)) {
                var result = true;
                for (root = Button.Parent; root.Parent.GetType() != typeof(Xamarin.Forms.NavigationPage); root = root.Parent) ; //ACHA A PAGE ROOT

                foreach (var controlName in this.Controls.Split('|')) {
                    View Control = root.FindByName<View>(controlName);
                    bool isVisible = true;

                    for (View parent = Control; (parent.Parent is View) && (isVisible = parent.IsVisible); parent = (View)parent.Parent);
               
                    if (Control == null || !isVisible) continue;

                    foreach(IValidator v in Control.Behaviors.OfType<IValidator>()){
                        if (!v.Validate(Control)) result = false;
                    };
                };

                if (!result) return;
            };

            this.Command?.Execute(null);
        }
    }
}

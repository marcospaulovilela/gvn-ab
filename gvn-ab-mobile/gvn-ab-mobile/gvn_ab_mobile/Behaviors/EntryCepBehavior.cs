using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public class EntryCepBehavior : EntryLengthBehavior {
        public static readonly BindableProperty LogradouroProperty = BindableProperty.Create(nameof(Logradouro), typeof(Models.Logradouro), typeof(EntryCepBehavior), null, BindingMode.TwoWay);
        public static readonly BindableProperty BairroProperty = BindableProperty.Create(nameof(Bairro), typeof(Models.Bairro), typeof(EntryCepBehavior), null, BindingMode.TwoWay);
        public static readonly BindableProperty DesComplementoProperty = BindableProperty.Create(nameof(DesComplemento), typeof(string), typeof(EntryCepBehavior), null, BindingMode.TwoWay);

        public Models.Logradouro Logradouro {
            get { return (Models.Logradouro)GetValue(LogradouroProperty); }
            set { SetValue(LogradouroProperty, value); }
        }

        public Models.Bairro Bairro {
            get { return (Models.Bairro)GetValue(BairroProperty); }
            set { SetValue(BairroProperty, value); }
        }

        public string DesComplemento{
            get { return (string)GetValue(DesComplementoProperty); }
            set { SetValue(DesComplementoProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable) {
            //COMO O BEHAVIOR NÃO HERDA O CONTEXTO DA VIEW QUE ELE ESTÁ, DEVE SER SETADO O MESMO CONTEXTO DO COMPONENTE QUE O INVOCA
            bindable.BindingContextChanged += (sender, _) => this.BindingContext = ((BindableObject)sender).BindingContext;

            bindable.TextChanged += OnEntryTextChanged;
            bindable.Unfocused += OnLeave;
        }

        protected override void OnDetachingFrom(Entry bindable) {
            bindable.TextChanged -= OnEntryTextChanged;
            bindable.Unfocused -= OnLeave;
        }

        protected void OnLeave(object sender, EventArgs args) {
            var entry = (Entry)sender;

            if (entry.BackgroundColor == Color.DarkOrange) return;

            using(DAO.DAOLocalizacao DAOLocalizacao = new DAO.DAOLocalizacao()) {
                var Localizacao = DAOLocalizacao.GetLocalizacaoByCep(entry.Text).FirstOrDefault();
                if (Localizacao == null) return;

                this.Bairro = Localizacao.Bairro;
                this.Logradouro = Localizacao.Logradouro;
                this.DesComplemento = Localizacao.DesComplemento;
            }
        }

       public EntryCepBehavior() {
            base.MaxLength = base.MinLength = 8;
        }

        public override bool isValid(object input) {
            return true;
        }
        
    }
}

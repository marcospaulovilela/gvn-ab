using gvn_ab_mobile.Helpers;
using gvn_ab_mobile.Models;

using Xamarin.Forms;

namespace gvn_ab_mobile.ViewModels {
    public class BaseViewModel : ObservableObject {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        
        bool isBusy = false;
        public bool IsBusy {
            get { return isBusy; }
            set {
                SetProperty(ref isBusy, value);
                OnPropertyChanged("NotIsBusy");
            }
        }

        public virtual bool NotIsBusy {
            get { return !isBusy; }
            set {
                SetProperty(ref isBusy, !value);
                OnPropertyChanged("IsBusy");
            }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}


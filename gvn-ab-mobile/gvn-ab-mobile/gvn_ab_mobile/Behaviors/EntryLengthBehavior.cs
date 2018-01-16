using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public class EntryLengthBehavior : ValidatorEntryBehavior {
        
        public override bool isValid(object input) {
            return true;
        }
        
    }
}

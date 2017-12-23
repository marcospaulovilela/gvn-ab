using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public interface IValidator {
        bool isValid(object input);
        bool Validate(object sender);
    }

    public abstract class Validator<T> : Behavior<T>, IValidator
    where T : BindableObject {

        public abstract bool isValid(object input);
        public abstract bool Validate(object sender);
    }
}

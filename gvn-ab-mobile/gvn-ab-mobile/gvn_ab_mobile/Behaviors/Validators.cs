using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Behaviors {
    public class ValidatorsCpf : ValidatorEntryBehavior {
        
        public ValidatorsCpf() {
            base.MaxLength = 11;
        }

        private bool IsCpf(string cpf) {
            string digits = "";

            int sum = 0, aux = 0;
            for(int i = 2; i <= 10; i++) {
                sum += int.Parse(cpf[8 - (i - 2)].ToString()) * i;
            };

            digits = ((aux = sum % 11) < 2) ? "0" : (11 - aux).ToString();

            sum = 0;
            for (int i = 3; i <= 11; i++) {
                sum += int.Parse(cpf[8 - (i - 3)].ToString()) * i;
            };
            sum += int.Parse(digits) * 2;

            digits += ((aux = sum % 11) < 2) ? "0" : (11 - aux).ToString();

            return cpf.EndsWith(digits);
        }

        public override bool Validate(string input) {
            input = input.Replace(".", "").Replace(",", "").Replace("-", "");

            if (input.Length != 11) return false;
            return IsCpf(input);
        }
    }
}

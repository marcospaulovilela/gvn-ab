using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace gvn_ab_mobile.Behaviors {
    public class ValidatorEmpty : ValidatorEntryBehavior {
        public ValidatorEmpty() {
            base.Required = true;
        }
        
        public override bool isValid(object input) {
            return !string.IsNullOrEmpty((string)input);
        }
    }

    public class ValidatorCpf : ValidatorEntryBehavior {
        
        public ValidatorCpf() {
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

        public override bool isValid(object input) {
            if (input == null) return false;
            string buffer = ((string)input).Replace(".", "").Replace(",", "").Replace("-", "");
            if (buffer.Length != 11) return false;
            return this.IsCpf(buffer);
        }
    }

    public class ValidatorCns : ValidatorEntryBehavior {

        public ValidatorCns() {
            base.MaxLength = 15;
        }

        private bool IsCns(string cns) {
            string result;

            if (cns[0] == '1' || cns[0] == '2') {
                string pis = cns.Substring(0, 11);

                long sum = 0;
                for (int i = 0; i < 11; i++) {
                    sum += long.Parse(pis[i].ToString()) * (15 - i);
                };
                long rest = sum % 11;
                long checkDigit = 11 - rest;

                if (checkDigit == 11) {
                    checkDigit = 0;
                };
                if (checkDigit == 10) {
                    sum += 2;
                    rest = sum % 11;
                    checkDigit = 11 - rest; 

                    result = $"{pis}001{checkDigit}";
                } else {
                    result = $"{pis}000{checkDigit}";
                };
                return cns.Equals(result);

            } else if (cns[0] == '7' || cns[0] == '8' || cns[0] == '9') {
                long sum = 0;
                for (int i = 0; i < 15; i++) {
                    sum += long.Parse(cns[i].ToString()) * (15 - i);
                };
                long rest = sum % 11;
                return rest == 0;
            } else {
                return false;
            };
        }

        public override bool isValid(object input) {
            if (string.IsNullOrEmpty((string)input)) return true;
            string buffer = ((string)input);
            if (buffer.Length != 15) return false;
            return this.IsCns(buffer);
        }
    }

    public class ValidatorEmail : ValidatorEntryBehavior {
        public override bool isValid(object input) {
            if (string.IsNullOrEmpty((string)input)) return true;

            return Regex.IsMatch((string)input, @"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
    }
}

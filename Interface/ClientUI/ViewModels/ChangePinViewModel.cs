using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.ClientUI.ViewModels
{
    public class ChangePinViewModel : BaseViewModel
    {
        public ChangePinViewModel()
        {
        }

        public override bool CheckData()
        {
            int pinLength = 4;

            if (OldPin == null || NewPin == null || ConfirmPin == null)
                return false;

            int countOldPin = OldPin.Count(x => Char.IsDigit(x));
            if (countOldPin != pinLength)
                return false;

            int countNewPin = NewPin.Count(x => Char.IsDigit(x));
            if (countNewPin != pinLength)
                return false;

            int countConfirmPin = ConfirmPin.Count(x => Char.IsDigit(x));
            if (countConfirmPin != pinLength)
                return false;

            return true;
        }

        private string _oldPin;
        public string OldPin
        {
            get => _oldPin;
            set  
            {
                _oldPin = value;
            }
        }

        private string _newPin;
        public string NewPin
        {
            get => _newPin;
            set => _newPin = value;
        }

        private string _confirmPin;
        public string ConfirmPin
        {
            get => _confirmPin;
            set => _confirmPin = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDeviseViewModel : ConvertisseurViewModel
    {
        public ConvertisseurDeviseViewModel() : base()
        {
        }

        public override void ActionSetConversion()
        {
            string errorMessage = "";
            if (SelectedCurrency == null)
            {
                errorMessage = "Vous devez sélectionner une devise !";
                ShowAsync(errorMessage);
            }
            else
                Res = MontantEuro / SelectedCurrency.Taux;
        }
    }
}

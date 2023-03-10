using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel : ConvertisseurViewModel
    {
        public ConvertisseurEuroViewModel() : base()
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
                Res = MontantEuro * SelectedCurrency.Taux;
        }

    }
}

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
    public class ConvertisseurEuroViewModel : ObservableObject
    {
        public IRelayCommand BtnSetConversion { get; }
        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();
            //Boutons
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }
        public void ActionSetConversion()
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

        private double montantEuro;
        public double MontantEuro
        {
            get { return montantEuro; }
            set
            {
                montantEuro = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Devise> valeurs;

        public ObservableCollection<Devise> Valeurs
        {
            get { return valeurs; }
            set
            {
                valeurs = value;
                OnPropertyChanged();
            }
        }

        private Devise selectedCurrency;

        public Devise SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                OnPropertyChanged();
            }
        }

        private double res;

        public double Res
        {
            get { return res; }
            set
            {
                res = value;
                OnPropertyChanged();
            }
        }
        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7056/api/devises");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
                ShowAsync("API non disponible !");
            else
                Valeurs = new ObservableCollection<Devise>(result);
        }

        private async void ShowAsync(string errorMessage)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Erreur !",
                Content = errorMessage,
                CloseButtonText = "Ok"
            };

            noWifiDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
    }
}

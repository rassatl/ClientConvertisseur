using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public abstract class ConvertisseurViewModel : ObservableObject
    {
        public IRelayCommand BtnSetConversion { get; }

        public ConvertisseurViewModel()
        {
            GetDataOnLoadAsync();
            //Boutons
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }
        public abstract void ActionSetConversion();

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

        public async void ShowAsync(string errorMessage)
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

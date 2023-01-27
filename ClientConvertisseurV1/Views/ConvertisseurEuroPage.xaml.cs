// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }

        private double montantEuro;
        public double MontantEuro
        {
            get { return montantEuro; }
            set { montantEuro = value; }
        }

        private ObservableCollection<Devise> valeurs;

        public ObservableCollection<Devise> Valeurs
        {
            get { return valeurs; }
            set {
                valeurs = value;
                OnPropertyChanged("Valeurs");
            }
        }

        private Devise selectedCurrency;

        public Devise SelectedCurrency
        {
            get { return selectedCurrency; }
            set { selectedCurrency = value; }
        }

        private double res;

        public double Res
        {
            get { return res; }
            set
            {
                res = value;
                OnPropertyChanged("Res");
            }
        }

        private void on_Click_Convertir(object sender, RoutedEventArgs e)
        {
            Res = MontantEuro * SelectedCurrency.Taux;
        }

        private async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7056/api/devises");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
                return;
            else
                Valeurs = new ObservableCollection<Devise>(result);
        }
    }
}

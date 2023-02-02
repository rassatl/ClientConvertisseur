using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurDeviseViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurDeviseViewModelTest()
        {
            ConvertisseurDeviseViewModel convertisseurDevise = new ConvertisseurDeviseViewModel();
            Assert.IsNotNull(convertisseurDevise);
        }

        [TestMethod()]
        public void ActionSetConversionTest()
        {
            //Arrange
            ConvertisseurDeviseViewModel convertisseurDevise = new ConvertisseurDeviseViewModel();
            //Création d'un objet de type ConvertisseurEuroViewModel

            convertisseurDevise.MontantEuro = 107;

            //Création d'un objet Devise, dont Taux=1.07
            Devise laDevise = new Devise();
            laDevise.Taux = 1.07;
            convertisseurDevise.SelectedCurrency = laDevise;

            //Act
            //Appel de la méthode ActionSetConversion
            ActionSetConversionTest();

            //Assert
            //Assertion : MontantDevise est égal à la valeur espérée 107
            Assert.Equals(convertisseurDevise.Res, 100);
        }
    }
}
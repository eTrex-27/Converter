using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Converter
{

    public sealed partial class Page2 : Page
    {
        ButtonParameters parameters;
        Json jsDocument;
        public Page2()
        {
            this.InitializeComponent();
            buttonLeft.Content = "Изменить \n  валюту";
            buttonRight.Content = "Изменить \n  валюту";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            jsDocument = Parser.parseJs();
            parameters = (ButtonParameters)e.Parameter;
            textBlockValuteLeft.Text = parameters.leftText;
            textBoxLeft.Text = jsDocument.Valute[textBlockValuteLeft.Text].Value.ToString();
            textBlockValuteRight.Text = parameters.rightText;
            textBoxRight.Text = jsDocument.Valute[textBlockValuteRight.Text].Value.ToString();       
        }
        
        private void buttonLeft_Click(object sender, RoutedEventArgs e)
        {
            parameters.flag = "left";
            this.Frame.Navigate(typeof(Page3), parameters);
        }

        private void buttonRight_Click(object sender, RoutedEventArgs e)
        {
            parameters.flag = "right";
            this.Frame.Navigate(typeof(Page3), parameters);
        }

        int flagConvert;
        private void textBoxLeft_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            flagConvert = 0;
        }

        private void textBoxRight_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            flagConvert = 1;
        }

        private void buttonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (flagConvert == 0)
            {
                try
                {
                    double normalizationNominalRight = jsDocument.Valute[textBlockValuteRight.Text].Value / jsDocument.Valute[textBlockValuteRight.Text].Nominal;
                    double normalizationNominalLeft = jsDocument.Valute[textBlockValuteLeft.Text].Value / jsDocument.Valute[textBlockValuteLeft.Text].Nominal;
                    textBoxRight.Text = ((normalizationNominalLeft / normalizationNominalRight) * Convert.ToDouble(textBoxLeft.Text)).ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неправильный формат ввода, введите корректное значение!", ex.Message);
                    textBoxLeft.Text = "";
                }
            }
            else
            {
                try
                {
                    double normalizationNominalRight = jsDocument.Valute[textBlockValuteRight.Text].Value / jsDocument.Valute[textBlockValuteRight.Text].Nominal;
                    double normalizationNominalLeft = jsDocument.Valute[textBlockValuteLeft.Text].Value / jsDocument.Valute[textBlockValuteLeft.Text].Nominal;
                    textBoxLeft.Text = ((normalizationNominalRight / normalizationNominalLeft) * Convert.ToDouble(textBoxRight.Text)).ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неправильный формат ввода, введите корректное значение!", ex.Message);
                    textBoxRight.Text = "";
                }
            }

        }
    }
}

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
    public sealed partial class Page3 : Page
    {
        ButtonParameters parameters;
        Json jsDocument;
        public Page3()
        {
            this.InitializeComponent();
            jsDocument = Parser.parseJs();
            List<string> listValute = new List<string>();
            foreach (var item in jsDocument.Valute.Keys)
            {
                listValute.Add(jsDocument.Valute[item.ToString()].Name + " " + item.ToString());
            }
            listBoxValute.Items.Clear();
            foreach (var listItem in listValute)
            {
                listBoxValute.Items.Add(listItem);
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            parameters = (ButtonParameters)e.Parameter;
        }

        private void listBoxValute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listBoxValute.SelectedIndex;
            if (index != -1)
            {
                if(parameters.flag == "left")
                {
                    parameters.leftText = jsDocument.Valute.ElementAt(index).Key.ToString();
                }
                else
                {
                    parameters.rightText = jsDocument.Valute.ElementAt(index).Key.ToString();
                }
                this.Frame.Navigate(typeof(Page2), parameters);
            }
        }
    }
}

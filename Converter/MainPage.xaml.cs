using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Windows.UI.ViewManagement;

namespace Converter
{
    public sealed partial class MainPage : Page
    {
        Json jsDocument;
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(580, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            jsDocument = Parser.parseJs();
            List<string> listValute = new List<string>();
            foreach(var item in jsDocument.Valute.Keys)
            {
                listValute.Add(item.ToString() + "  " + jsDocument.Valute[item.ToString()].Value);
            }
            listBoxValute.Items.Clear();
            foreach (var listItem in listValute)
            {
                listBoxValute.Items.Add(listItem);
            }
        }
        
        private void listBoxValute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonParameters parameters = new ButtonParameters();
            
            int index = listBoxValute.SelectedIndex;
            if(index != -1)
            {
                parameters.leftText = jsDocument.Valute.ElementAt(index).Key.ToString();
                parameters.rightText = "USD";
                this.Frame.Navigate(typeof(Page2), parameters);
            }
        }
    }
}

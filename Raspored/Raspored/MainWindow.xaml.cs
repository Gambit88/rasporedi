using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Raspored
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Termini term = new Termini();
            Smer sm = new Smer("A", "ASD", "asdasdasd", DateTime.Now);
            Smerovi smerovi = new Smerovi();

            Ucionice ucionice = new Ucionice();
            Softver s = new Softver("VS2015", "Visual studio 2015", "Blablabla", "Windows", "Microsoft", "www.microsoft.com", "2014", 20000);
            Softveri so = new Softveri();
            so.Podaci.Add(s);
            Ucionica a = new Ucionica("A1", "Za HCI", 2, false, false, false, "Windows", so);
            ucionice.Podaci.Add(a);
            Ucionica a2 = new Ucionica("A2", "Za HCI", 2, false, false, false, "Windows", so);
            ucionice.Podaci.Add(a2);
            Ucionica a3 = new Ucionica("A3", "Za HCI", 2, false, false, false, "Windows", so);
            ucionice.Podaci.Add(a3);
            Ucionica a4 = new Ucionica("A4", "Za HCI", 2, false, false, false, "Windows", so);
            ucionice.Podaci.Add(a4);
            Ucionica a5 = new Ucionica("A5", "Za HCI", 2, false, false, false, "Windows", so);
            ucionice.Podaci.Add(a5);
            Ucionica a6 = new Ucionica("A6", "Za HCI", 2, false, false, false, "Windows", so);
            ucionice.Podaci.Add(a6);
            classroomList.ItemsSource = ucionice.Podaci;
        }
        //klik na dan
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            foreach(var element in daysGrid.Children)
            {
                if(element is Button)
                {
                    ((Button)element).Background = Brushes.DimGray;
                }
            }
            b.Background = Brushes.DarkGray;
            if (raspored.Visibility == Visibility.Collapsed)
                raspored.Visibility = Visibility.Visible;
            //samo pozovi za ispis boja "samo" ;.;
            //prodji kroz raspodeljene rasporede koji imaju dan/datum tog puta
            //postavi za svaki ona cuda

            
        }

        //Klik na ucionicu
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            foreach (var element in classList.Children)
            {
                ItemsControl eIc = (ItemsControl)element;
                for (int i = 0; i < eIc.Items.Count; i++)
                {
                    UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                    if (uiElement.Visibility == Visibility.Collapsed)
                        uiElement.Visibility = Visibility.Visible;
                    else
                        uiElement.Visibility = Visibility.Collapsed;
                    Console.WriteLine(uiElement);
                    var innerChild = VisualTreeHelper.GetChild(uiElement, 0);
                    if (innerChild.Equals(b))
                    {
                        uiElement.Visibility = Visibility.Visible;
                    }
                }
                
                
            }
            foreach (var element in daysGrid.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Background = Brushes.DarkGray;
                }
            }
            if (daysGrid.Visibility == Visibility.Collapsed)
                daysGrid.Visibility = Visibility.Visible;
            else
                daysGrid.Visibility = Visibility.Collapsed;
            if (raspored.Visibility == Visibility.Visible)
                raspored.Visibility = Visibility.Collapsed;
        }
    }
}

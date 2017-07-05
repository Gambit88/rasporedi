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
using System.Windows.Threading;

namespace Raspored
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point startPoint;
        DateTime pon = new DateTime();
        DateTime uto = new DateTime();
        DateTime sre = new DateTime();
        DateTime cet = new DateTime();
        DateTime pet = new DateTime();
        DateTime sub = new DateTime();
        Termini terminiAktivni = new Termini();
        Termini terminiNeaktivni = new Termini();
        Smerovi smerovi = new Smerovi();
        Ucionice ucionice = new Ucionice();
        Softveri softver = new Softveri();
        Predmeti predmeti = new Predmeti();
        string selektovanaUcionica = "";
        public MainWindow()
        {
            //ucionice
            //softver
            //smerovi
            //rasporedi ne rasporedjeni
            //rasporedi rasporedjeni
            //predmeti

            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += DispatcherTimer_Tick;
            timer.Start();

            smerovi.add("A", "ASD", "asdasdasd", DateTime.Now);
            softver.add("VS2015", "Visual studio 2015", "Blablabla", "Windows", "Microsoft", "www.microsoft.com", "2014", 20000);
            ucionice.add("A1", "Za HCI", 2, false, false, false, "Windows", softver);
            ucionice.add("A2", "Za HCI", 2, false, false, false, "Windows", softver);
            ucionice.add("A3", "Za HCI", 2, false, false, false, "Windows", softver);
            ucionice.add("A4", "Za HCI", 2, false, false, false, "Windows", softver);
            ucionice.add("A5", "Za HCI", 2, false, false, false, "Windows", softver);
            ucionice.add("A6", "Za HCI", 2, false, false, false, "Windows", softver);
            predmeti.add("P12", "Sranje", "HCI", smerovi.Podaci.ElementAt(0), 2, 2, 2, true, true, true, "Windows", softver);
            terminiNeaktivni.add(2, DateTime.Now, null, "P12");
            terminiNeaktivni.add(4, DateTime.Now, null, "P12");

            classroomList.ItemsSource = ucionice.Podaci;
            terminiZaOdraditi.ItemsSource = terminiNeaktivni.Podaci;
        }
        //klik na dan
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            foreach (var element in daysGrid.Children)
            {
                if (element is Button)
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
            selektovanaUcionica = (string)b.Content;
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (raspored.Visibility != Visibility.Visible)
            {
                return;
            }
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                // Get the dragged ListViewItem
                Button b = sender as Button;

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject(DataFormats.Text, b.Content);
                DragDrop.DoDragDrop(b, dragData, DragDropEffects.Move);
            }

        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            Console.WriteLine(((TextBlock)sender).Name);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker dp = sender as DatePicker;
            DateTime dt = dp.SelectedDate.Value;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    pon = dt;
                    uto = dt.AddDays(1);
                    sre = dt.AddDays(2);
                    cet = dt.AddDays(3);
                    pet = dt.AddDays(4);
                    sub = dt.AddDays(5);
                    break;
                case DayOfWeek.Tuesday:
                    pon = dt.AddDays(-1);
                    uto = dt;
                    sre = dt.AddDays(1);
                    cet = dt.AddDays(2);
                    pet = dt.AddDays(3);
                    sub = dt.AddDays(4);
                    break;
                case DayOfWeek.Wednesday:
                    pon = dt.AddDays(-2);
                    uto = dt.AddDays(-1);
                    sre = dt;
                    cet = dt.AddDays(1);
                    pet = dt.AddDays(2);
                    sub = dt.AddDays(3);
                    break;
                case DayOfWeek.Thursday:
                    pon = dt.AddDays(-3);
                    uto = dt.AddDays(-2);
                    sre = dt.AddDays(-1);
                    cet = dt;
                    pet = dt.AddDays(1);
                    sub = dt.AddDays(2);
                    break;
                case DayOfWeek.Friday:
                    pon = dt.AddDays(-4);
                    uto = dt.AddDays(-3);
                    sre = dt.AddDays(-2);
                    cet = dt.AddDays(-1);
                    pet = dt;
                    sub = dt.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    pon = dt.AddDays(-5);
                    uto = dt.AddDays(-4);
                    sre = dt.AddDays(-3);
                    cet = dt.AddDays(-2);
                    pet = dt.AddDays(-1);
                    sub = dt;
                    break;
                case DayOfWeek.Sunday:
                    pon = dt.AddDays(-6);
                    uto = dt.AddDays(-5);
                    sre = dt.AddDays(-4);
                    cet = dt.AddDays(-3);
                    pet = dt.AddDays(-2);
                    sub = dt.AddDays(-1);
                    break;
            }
            rasporedNoviDesniDeoPanel.Visibility = Visibility.Collapsed;
            rasporedDesniDeoPanel.Visibility = Visibility.Visible;

        }
        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.IsActive)
                    podesiBojuUcionica();
                else
                    iskljuciBoje();
            }
            catch (Exception)
            {
                Console.WriteLine('2');
            }
            // no error here..
        }
        void podesiBojuUcionica()
        {
            foreach (var element in classList.Children)
            {
                ItemsControl eIc = (ItemsControl)element;
                for (int i = 0; i < eIc.Items.Count; i++)
                {
                    UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                    try
                    {
                        Button innerChild = VisualTreeHelper.GetChild(uiElement, 0) as Button;
                        Ucionica u = ucionice.get((string)innerChild.Content);
                        if (this.terminiAktivni.slobodnaUcionica(u))
                        {
                            innerChild.Background = Brushes.LightGreen;
                        }
                        else
                        {
                            innerChild.Background = Brushes.PaleVioletRed;
                        }
                    }
                    catch (Exception) { }
                }


            }
        }
        void iskljuciBoje()
        {
            foreach (var element in classList.Children)
            {
                ItemsControl eIc = (ItemsControl)element;
                for (int i = 0; i < eIc.Items.Count; i++)
                {
                    UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                    try
                    {
                        Button innerChild = VisualTreeHelper.GetChild(uiElement, 0) as Button;
                        Ucionica u = ucionice.get((string)innerChild.Content);
                        if (this.terminiAktivni.slobodnaUcionica(u))
                        {
                            innerChild.Background = Brushes.LightGray;
                        }
                        else
                        {
                            innerChild.Background = Brushes.DarkGray;
                        }
                    }
                    catch (Exception) { }
                }
            }
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            Console.WriteLine("ukljuic");
            podesiBojuUcionica();
        }
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            Console.WriteLine("iskljuci");
            iskljuciBoje();
        }
    }
}

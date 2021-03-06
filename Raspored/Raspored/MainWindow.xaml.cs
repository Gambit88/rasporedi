﻿using System;
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
using System.Collections.ObjectModel;

namespace Raspored
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Termin selektovaniTermin = null;
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
        int selektovaniDan = 0;
		
        List<TextBlock> listaTrenutnihTermina = new List<TextBlock>();
        List<Border> listaTmpBordera = new List<Border>();

        public MainWindow()
        {
            //ucionice
            //softver
            //smerovi
            //rasporedi ne rasporedjeni
            //rasporedi rasporedjeni
            //predmeti

            InitializeComponent();
            this.DataContext = this;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += DispatcherTimer_Tick;
            timer.Start();
            
            smerovi.add("A", "ASD", "asdasdasd", DateTime.Now);
            softver.add("VS2015", "Visual studio 2015", "Blablabla", "Windows", "Microsoft", "www.microsoft.com", "2014", 20000);
            
            ucionice.add("A1", "Za HCI", 2, false, false, false, "Windows", softver);
            ucionice.add("A2", "Za HCI", 2, false, true, false, "Windows", softver);
            ucionice.add("A3", "Za HCI", 2, false, false, true, "Windows", softver);
            ucionice.add("A4", "Za HCI", 2, false, true, true, "Windows", softver);
            ucionice.add("A5", "Za HCI", 2, true, true, true, "Windows", softver);
            ucionice.add("A6", "Za HCI", 2, true, true, true, "Windows", softver);
            predmeti.add("P12", "Sranje", "HCI", smerovi.Podaci.ElementAt(0), 2, 2, 2, true, true, true, "Windows", softver);
            predmeti.add("P13", "Sranje", "HCI", smerovi.Podaci.ElementAt(0), 2, 2, 2, false, false, true, "Windows", softver);
            terminiNeaktivni.add(2, DateTime.Now, null, "P12");
            terminiNeaktivni.add(4, DateTime.Now, null, "P12");
            terminiNeaktivni.add(4, DateTime.Now, null, "P13");
            terminiAktivni.add(2, new DateTime(2017,7,7,10,30,00), ucionice.get("A5"), "P13");

            classroomList.ItemsSource = ucionice.Podaci;
            terminiZaOdraditi.ItemsSource = terminiNeaktivni.Podaci;

            dgrSoftver.ItemsSource = softver.Podaci;
            dgrUcionica.ItemsSource = ucionice.Podaci;
            dgrSmer.ItemsSource = smerovi.Podaci;
            dgrPredmet.ItemsSource = predmeti.Podaci;
        }
        //klik na dan
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            switch ((string)b.Content)
            {
                case "PON":
                    selektovaniDan = 1;
                    break;
                case "UTO":
                    selektovaniDan = 2;
                    break;
                case "SRE":
                    selektovaniDan = 3;
                    break;
                case "PET":
                    selektovaniDan = 5;
                    break;
                case "SUB":
                    selektovaniDan = 6;
                    break;
                default:
                    selektovaniDan = 4;
                    break;
            }
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
            obojiRaspored();

        }

        //Klik na ucionicu
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            selektovanaUcionica = (string)b.Content;
            if(selektovaniTermin is null) { 
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
            }
            else
            {

                foreach (var element in classList.Children)
                {
                    ItemsControl eIc = (ItemsControl)element;
                    for (int i = 0; i < eIc.Items.Count; i++)
                    {
                        UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                        Button innerChild = VisualTreeHelper.GetChild(uiElement, 0) as Button;
                        if (((Ucionica)innerChild.DataContext).podrzava(predmeti.get(selektovaniTermin.IdPredmeta)) && uiElement.Visibility==Visibility.Collapsed)
                            uiElement.Visibility = Visibility.Visible;
                        else
                            uiElement.Visibility = Visibility.Collapsed;
                        if (innerChild.Equals(b))
                        {
                            uiElement.Visibility = Visibility.Visible;
                        }
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
            try {
                if(rasporedDesniDeoPanel.Visibility == Visibility.Collapsed)
                {
                    return;
                }
                raspored.Visibility = Visibility.Collapsed;
                daysGrid.Visibility = Visibility.Collapsed;
                Termin noviTermin = (Termin)(((Button)sender).DataContext);
                if (selektovaniTermin != null && noviTermin.Broj == selektovaniTermin.Broj) { 
                    selektovaniTermin = null;
                    foreach (var element in kanvas.Children)
                    {
                        ItemsControl eIc = (ItemsControl)element;
                        for (int i = 0; i < eIc.Items.Count; i++)
                        {
                            UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                            Button innerChild = (Button)VisualTreeHelper.GetChild(uiElement, 0);
                            innerChild.Background = Brushes.LightGray;
                        }
                    }

                    foreach (var element in classList.Children)
                    {
                        ItemsControl eIc = (ItemsControl)element;
                        for (int i = 0; i < eIc.Items.Count; i++)
                        {
                            UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                            if (uiElement.Visibility == Visibility.Collapsed)
                                uiElement.Visibility = Visibility.Visible;
                        }
                    }
                }
                else
                {
                    selektovaniTermin = noviTermin;
                    foreach (var element in kanvas.Children)
                    {
                        ItemsControl eIc = (ItemsControl)element;
                        for (int i = 0; i < eIc.Items.Count; i++)
                        {
                            UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                            Button innerChild = (Button)VisualTreeHelper.GetChild(uiElement, 0);
                            innerChild.Background = Brushes.DarkGray;
                        }
                    }
                    Button b = sender as Button;
                    b.Background = Brushes.LightGray;

                    foreach (var element in classList.Children)
                    {
                        ItemsControl eIc = (ItemsControl)element;
                        for (int i = 0; i < eIc.Items.Count; i++)
                        {
                            UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                            uiElement.Visibility = Visibility.Visible;
                        }

                        for (int i = 0; i < eIc.Items.Count; i++)
                        {
                            UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                            Button innerChild = VisualTreeHelper.GetChild(uiElement, 0) as Button;
                            if (((Ucionica)innerChild.DataContext).podrzava(predmeti.get(selektovaniTermin.IdPredmeta)))
                                uiElement.Visibility = Visibility.Visible;
                            else
                                uiElement.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }
            catch(Exception ex){ Console.WriteLine(ex); }
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(raspored.Visibility!=Visibility.Visible || selektovaniTermin == null || selektovaniTermin!=(Termin)(((Button)sender).DataContext))
            {
                return;
            }
            startPoint = e.GetPosition(null);
            Button b = sender as Button;
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (raspored.Visibility != Visibility.Visible || selektovaniTermin == null || selektovaniTermin != (Termin)(((Button)sender).DataContext))
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
                DataObject dragData = new DataObject("termin", (Termin)(b.DataContext));
                DragDrop.DoDragDrop(b, dragData, DragDropEffects.Move);
            }

        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            foreach (Border bord in listaTmpBordera)
            {
                raspored.Children.Remove(bord);
            }
            listaTmpBordera.Clear();
            Termin t = (Termin)e.Data.GetData("termin");
            //nije to nego:
            TextBlock tb = (TextBlock)sender;
            DateTime dtt = t.Pocetak;
            string[] tmp = tb.Name.Split('_');
            int h = Int32.Parse(tmp[1]);
            int m = Int32.Parse(tmp[2]);
            int h1 = h - 7;
            h = h1 / 5;
            h1 = h1 % 5;
            int col = h1 * 4 + m / 15;
            int row = (h * 2) + 1;

            int dur = t.Trajanje * 3;
            if (col + dur > 20)
            {
                Border item1 = new Border();
                item1.BorderThickness = new Thickness(3);
                if (this.IsActive)
                    item1.BorderBrush = Brushes.PaleGoldenrod;
                else
                    item1.BorderBrush = Brushes.Gray;
                raspored.Children.Add(item1);
                Grid.SetRow(item1, row);
                Grid.SetColumn(item1, col);
                Grid.SetColumnSpan(item1, 20 - col);

                Border item2 = new Border();
                item2.BorderThickness = new Thickness(3);
                if (this.IsActive)
                    item2.BorderBrush = Brushes.PaleGoldenrod;
                else
                    item2.BorderBrush = Brushes.Gray;
                raspored.Children.Add(item2);
                Grid.SetRow(item2, row + 2);
                Grid.SetColumn(item2, 0);
                Grid.SetColumnSpan(item2, col + dur - 20);

                listaTmpBordera.Add(item1);
                listaTmpBordera.Add(item2);
            }
            else
            {
                Border item = new Border();
                item.BorderThickness = new Thickness(3);
                if (this.IsActive)
                    item.BorderBrush = Brushes.PaleGoldenrod;
                else
                    item.BorderBrush = Brushes.Gray;
                raspored.Children.Add(item);
                Grid.SetRow(item, row);
                Grid.SetColumn(item, col);
                Grid.SetColumnSpan(item, dur);

                listaTmpBordera.Add(item);
            }
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            foreach (Border bord in listaTmpBordera)
            {
                raspored.Children.Remove(bord);
            }
            listaTmpBordera.Clear();
            Termin t = (Termin)e.Data.GetData("termin");
            TextBlock tb = (TextBlock)sender;
            terminiNeaktivni.Podaci.Remove(t);
            DateTime dt = DateTime.Today;
            switch (selektovaniDan)
            {
                case 1:
                    dt = pon;
                    break;
                case 2:
                    dt = uto;
                    break;
                case 3:
                    dt = sre;
                    break;
                case 4:
                    dt = cet;
                    break;
                case 5:
                    dt = pet;
                    break;
                case 6:
                    dt = sub;
                    break;
            }
            string[] tmp = tb.Name.Split('_');
            int hours = Int32.Parse(tmp[1]);
            int minutes = Int32.Parse(tmp[2]);
            dt = dt.AddHours(hours);
            dt = dt.AddMinutes(minutes);
            t.Pocetak = dt;
            t.Ucionica = ucionice.get(selektovanaUcionica);
            terminiAktivni.Podaci.Add(t);
            obojiRaspored();
            selektovaniTermin = null;
            try
            {
                foreach (var element in kanvas.Children)
                {
                    ItemsControl eIc = (ItemsControl)element;
                    for (int i = 0; i < eIc.Items.Count; i++)
                    {
                        UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                        Button innerChild = (Button)VisualTreeHelper.GetChild(uiElement, 0);
                        innerChild.Background = Brushes.LightGray;
                    }
                }

                foreach (var element in classList.Children)
                {
                    ItemsControl eIc = (ItemsControl)element;
                    for (int i = 0; i < eIc.Items.Count; i++)
                    {
                        UIElement uiElement = (UIElement)eIc.ItemContainerGenerator.ContainerFromIndex(i);
                        if (uiElement.Visibility == Visibility.Collapsed)
                            uiElement.Visibility = Visibility.Visible;
                    }
                }
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
                        if ((string)((Button)innerChild).Content== selektovanaUcionica)
                        {
                            uiElement.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               
            }
            obojiRaspored();
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
            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
            podesiBojuUcionica();
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
            }
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

        private void obojiRaspored()
        {
            try
            {
                foreach (TextBlock t in listaTrenutnihTermina)
                {
                    raspored.Children.Remove(t);
                }
                listaTrenutnihTermina.Clear();


                if (selektovaniTermin is null)
                {
                    foreach (var element in raspored.Children)
                    {
                        if (element is TextBlock)
                        {
                            TextBlock tb = element as TextBlock;
                            int gr = Grid.GetRow(tb);
                            int gc = Grid.GetColumn(tb);
                            if (gr == 1 || gr == 3 || gr == 5)
                            {
                                DateTime dt = DateTime.Today;
                                switch (selektovaniDan)
                                {
                                    case 1:
                                        dt = pon;
                                        break;
                                    case 2:
                                        dt = uto;
                                        break;
                                    case 3:
                                        dt = sre;
                                        break;
                                    case 4:
                                        dt = cet;
                                        break;
                                    case 5:
                                        dt = pet;
                                        break;
                                    case 6:
                                        dt = sub;
                                        break;
                                }
                                dt = dt.AddHours(7);
                                if (gr == 3)
                                {
                                    dt = dt.AddHours(5);
                                }
                                if (gr == 5)
                                {
                                    dt = dt.AddHours(10);
                                }
                                dt = dt.AddMinutes(gc * 15);
                                if (terminiAktivni.slobodan(dt, ucionice.get(selektovanaUcionica)) && DateTime.Now <= dt)
                                {
                                    tb.AllowDrop = true;
                                    if (this.IsActive)
                                    {
                                        tb.Background = Brushes.LightGreen;
                                    }
                                    else
                                    {
                                        tb.Background = Brushes.LightGray;
                                    }
                                    
                                }
                                else
                                {
                                    tb.AllowDrop = false;
                                    if (this.IsActive)
                                    {
                                        tb.Background = Brushes.PaleVioletRed;
                                    }
                                    else
                                    {
                                        tb.Background = Brushes.DarkGray;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (var element in raspored.Children)
                    {
                        if (element is TextBlock)
                        {
                            TextBlock tb = element as TextBlock;
                            int gr = Grid.GetRow(tb);
                            int gc = Grid.GetColumn(tb);
                            if (gr == 1 || gr == 3 || gr == 5)
                            {
                                DateTime dt = DateTime.Today;
                                switch (selektovaniDan)
                                {
                                    case 1:
                                        dt = pon;
                                        break;
                                    case 2:
                                        dt = uto;
                                        break;
                                    case 3:
                                        dt = sre;
                                        break;
                                    case 4:
                                        dt = cet;
                                        break;
                                    case 5:
                                        dt = pet;
                                        break;
                                    case 6:
                                        dt = sub;
                                        break;
                                }
                                dt = dt.AddHours(7);
                                if (gr == 3)
                                {
                                    dt = dt.AddHours(5);
                                }
                                if (gr == 5)
                                {
                                    dt = dt.AddHours(10);
                                }
                                dt = dt.AddMinutes(gc * 15);
                                if (terminiAktivni.slobodanZa(dt,selektovaniTermin, ucionice.get(selektovanaUcionica)) && DateTime.Now <= dt)
                                {
                                    tb.AllowDrop = true;
                                    if (this.IsActive)
                                    {
                                        tb.Background = Brushes.LightGreen;
                                    }
                                    else
                                    {
                                        tb.Background = Brushes.LightGray;
                                    }

                                }
                                else
                                {
                                    tb.AllowDrop = false;
                                    if (this.IsActive)
                                    {
                                        tb.Background = Brushes.PaleVioletRed;
                                    }
                                    else
                                    {
                                        tb.Background = Brushes.DarkGray;
                                    }
                                }
                            }
                        }
                    }
                }
                DateTime dt2 = DateTime.Today;
                switch (selektovaniDan)
                {
                    case 1:
                        dt2 = pon;
                        break;
                    case 2:
                        dt2 = uto;
                        break;
                    case 3:
                        dt2 = sre;
                        break;
                    case 4:
                        dt2 = cet;
                        break;
                    case 5:
                        dt2 = pet;
                        break;
                    case 6:
                        dt2 = sub;
                        break;
                }
                foreach (Termin t in terminiAktivni.Podaci)
                {

                    if(t.Pocetak.Date == dt2 && selektovanaUcionica == t.Ucionica.Oznaka)
                    {
                        DateTime dtt = t.Pocetak;
                        int h = dtt.Hour;
                        int m = dtt.Minute;
                        int h1 = h - 7;
                        h = h1 / 5;
                        h1 = h1 % 5;
                        int col = h1*4 + m/15;
                        int row = (h * 2)+1;

                        int dur = t.Trajanje*3;
                        if (col + dur > 20)
                        {
                            TextBlock item1 = new TextBlock();
                            item1.TextAlignment = TextAlignment.Center;
                            item1.Text = t.Tekst;
                            if (this.IsActive)
                                item1.Background = Brushes.PaleGoldenrod;
                            else
                                item1.Background = Brushes.Gray;
                            raspored.Children.Add(item1);
                            Grid.SetRow(item1, row);
                            Grid.SetColumn(item1, col);
                            Grid.SetColumnSpan(item1, 20-col);
                            
                            TextBlock item2 = new TextBlock();
                            item2.Text = t.Tekst;
                            item2.TextAlignment = TextAlignment.Center;
                            if (this.IsActive)
                                item2.Background = Brushes.PaleGoldenrod;
                            else
                                item2.Background = Brushes.Gray;
                            raspored.Children.Add(item2);
                            Grid.SetRow(item2, row+2);
                            Grid.SetColumn(item2, 0);
                            Grid.SetColumnSpan(item2, col+dur-20);

                            listaTrenutnihTermina.Add(item1);
                            listaTrenutnihTermina.Add(item2);
                        }
                        else
                        {
                            TextBlock item = new TextBlock();
                            item.Text = t.Tekst;
                            item.TextAlignment = TextAlignment.Center;
                            if (this.IsActive)
                                item.Background = Brushes.PaleGoldenrod;
                            else
                                item.Background = Brushes.Gray;
                            raspored.Children.Add(item);
                            Grid.SetRow(item, row);
                            Grid.SetColumn(item, col);
                            Grid.SetColumnSpan(item, dur);

                            listaTrenutnihTermina.Add(item);
                        }

                        
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            podesiBojuUcionica();
            obojiRaspored();
        }
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            iskljuciBoje();
            obojiRaspored();
        }

        private void _07_00_DragLeave(object sender, DragEventArgs e)
        {
            foreach (Border bord in listaTmpBordera)
            {
                raspored.Children.Remove(bord);
            }
            listaTmpBordera.Clear();
		}
		
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            noviTerminLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaUcionicaLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSmerovaLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaPredmetaLeviDeoPanel.Visibility = Visibility.Collapsed;
            rasporedDesniDeoPanel.Visibility = Visibility.Collapsed;
            rasporedLeviDeoPanel.Visibility = Visibility.Collapsed;
            rasporedNoviDesniDeoPanel.Visibility = Visibility.Collapsed;
            noviTerminDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaUcionicaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSmerovaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaPredmetaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajPredmetDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSmerDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajUcionicuDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSoftverDesniDeoPanel.Visibility = Visibility.Collapsed;

            tabelaSoftveraLeviDeoPanel.Visibility = Visibility.Visible;
            tabelaSoftveraDesniDeoPanel.Visibility = Visibility.Visible;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            tabelaSoftveraLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSoftveraDesniDeoPanel.Visibility = Visibility.Collapsed;
            noviTerminLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSmerovaLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaPredmetaLeviDeoPanel.Visibility = Visibility.Collapsed;
            rasporedDesniDeoPanel.Visibility = Visibility.Collapsed;
            rasporedLeviDeoPanel.Visibility = Visibility.Collapsed;
            rasporedNoviDesniDeoPanel.Visibility = Visibility.Collapsed;
            noviTerminDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSmerovaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaPredmetaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajPredmetDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSmerDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajUcionicuDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSoftverDesniDeoPanel.Visibility = Visibility.Collapsed;

            tabelaUcionicaLeviDeoPanel.Visibility = Visibility.Visible;
            tabelaUcionicaDesniDeoPanel.Visibility = Visibility.Visible;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            tabelaSoftveraLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSoftveraDesniDeoPanel.Visibility = Visibility.Collapsed;
            noviTerminLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaPredmetaLeviDeoPanel.Visibility = Visibility.Collapsed;
            rasporedDesniDeoPanel.Visibility = Visibility.Collapsed;
            rasporedLeviDeoPanel.Visibility = Visibility.Collapsed;
            rasporedNoviDesniDeoPanel.Visibility = Visibility.Collapsed;
            noviTerminDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaPredmetaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaUcionicaLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaUcionicaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajPredmetDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSmerDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajUcionicuDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSoftverDesniDeoPanel.Visibility = Visibility.Collapsed;

            tabelaSmerovaDesniDeoPanel.Visibility = Visibility.Visible;
            tabelaSmerovaLeviDeoPanel.Visibility = Visibility.Visible;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            tabelaSoftveraLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSoftveraDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSmerovaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSmerovaLeviDeoPanel.Visibility = Visibility.Collapsed;
            noviTerminLeviDeoPanel.Visibility = Visibility.Collapsed;
            rasporedDesniDeoPanel.Visibility = Visibility.Collapsed;
            rasporedLeviDeoPanel.Visibility = Visibility.Collapsed;
            rasporedNoviDesniDeoPanel.Visibility = Visibility.Collapsed;
            noviTerminDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaUcionicaLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaUcionicaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajPredmetDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSmerDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajUcionicuDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSoftverDesniDeoPanel.Visibility = Visibility.Collapsed;

            tabelaPredmetaDesniDeoPanel.Visibility = Visibility.Visible;
            tabelaPredmetaLeviDeoPanel.Visibility = Visibility.Visible;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            tabelaSoftveraLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaUcionicaLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSmerovaLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaPredmetaLeviDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSoftveraDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaUcionicaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaSmerovaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaPredmetaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajPredmetDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSmerDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajUcionicuDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSoftverDesniDeoPanel.Visibility = Visibility.Collapsed;

            rasporedLeviDeoPanel.Visibility = Visibility.Visible;
            rasporedDesniDeoPanel.Visibility = Visibility.Visible;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            tabelaSoftveraDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajPredmetDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSmerDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajUcionicuDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSoftverDesniDeoPanel.Visibility = Visibility.Visible;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            tabelaUcionicaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSoftverDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajPredmetDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSmerDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajUcionicuDesniDeoPanel.Visibility = Visibility.Visible;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            tabelaSmerovaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSoftverDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajUcionicuDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajPredmetDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSmerDesniDeoPanel.Visibility = Visibility.Visible;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            tabelaPredmetaDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajUcionicuDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSoftverDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajSmerDesniDeoPanel.Visibility = Visibility.Collapsed;
            tabelaDodajPredmetDesniDeoPanel.Visibility = Visibility.Visible;
        }
    }
}

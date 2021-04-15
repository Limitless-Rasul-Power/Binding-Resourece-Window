using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp_Step_Ders_15_Aprel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>
        {
            new Car
            {
                Model = "BMW",
                Vendor = "I8",
                Year = 2021
            },

            new Car
            {
                Model = "E class",
                Vendor = "Mercedes",
                Year = 2020
            },

            new Car
            {
                Model = "Chiron",
                Vendor = "Bugatti",
                Year = 2222
            }
        };

        private string _someText;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                OnPropertyChanged();
            }
        }

        public Car MyCar { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            SomeText = "Love";


            MyCar = new Car()
            {
                Model = "Chiron",
                Vendor = "Bugatti",
                Year = 2021
            };
            
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["PrimaryColor"] = Brushes.Goldenrod;
        }

        private void BtnChanger_Click(object sender, RoutedEventArgs e)
        {
            MyCar.Model = "Best Model";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car
            {
                Model = "Ferrari",
                Vendor = "Lambo",
                Year = 3030
            };

            Cars.Add(car);

        }

        private void LstBx_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void LstBx_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var info = new Info();

            info.Car = (sender as ListBox).SelectedItem as Car;

            info.ShowDialog();
        }
    }

    public class Car : INotifyPropertyChanged
    {

        private string _model;
        private string _vendor;
        private int _year;

        public string Model
        {
            get { return _model; }
            set { _model = value; OnPropertyChanged(); }
        }

        public string Vendor
        {
            get { return _vendor; }
            set { _vendor = value; OnPropertyChanged(); }
        }


        public int Year
        {
            get { return _year; }
            set { _year = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}

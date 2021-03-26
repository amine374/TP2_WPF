using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Tp2_WPF
{
    /// <summary>
    /// Interaction logic for Exercice_2.xaml
    /// </summary>
    public partial class Exercice_2 : Window, INotifyPropertyChanged
    {
        public DataClasses1DataContext data;
        public Filiere selectedF;

        public event PropertyChangedEventHandler PropertyChanged;

        public void onItemChange(string flame)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(flame));
        }

        public Filiere SelectedF
        {
            get { return selectedF; }
            set { selectedF = value; onItemChange("SelectedF");
            }
        }
        //public int MyProperty { get ; set; }
        public  ObservableCollection<Filiere> listFiliere { get; set; }
        public Exercice_2()
        {
            data = new DataClasses1DataContext();
            listFiliere = new ObservableCollection<Filiere>(data.Filieres);
            InitializeComponent();
            this.DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Filiere f = new Filiere()
            {
                Nom_filiere = entryFiliere.Text
            };

            data.Filieres.InsertOnSubmit(f);
            data.SubmitChanges();

            listFiliere.Add(f);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            data.Filieres.DeleteOnSubmit(selectedF);
            data.SubmitChanges();
            listFiliere.Remove(selectedF);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            data.SubmitChanges();
        }
    }
}

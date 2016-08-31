using IreneAdler.Models;
using LittleBlackBook.ViewModels;
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

namespace LittleBlackBook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private MainViewModel _viewmodel = new MainViewModel();
        public MainView()
        {
            InitializeComponent();            
            DataContext = _viewmodel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.AddContact();

        }

        private void ContactsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewmodel.SetCurrentContact(ContactsDataGrid.SelectedItem);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.SaveCurrentContact();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.DeleteCurrentContact();
        }
    }
}

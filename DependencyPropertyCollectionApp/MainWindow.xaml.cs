using System.Collections.ObjectModel;
using System.Windows;
using DependencyPropertyCollectionApp.ViewModel;

namespace DependencyPropertyCollectionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel { Numbers = new ObservableCollection<int> {1,2,3}};
            InitializeComponent();
        }
    }
}

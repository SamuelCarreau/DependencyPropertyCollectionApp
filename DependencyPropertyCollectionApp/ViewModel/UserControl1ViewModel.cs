using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DependencyPropertyCollectionApp.ViewModel
{
    // INotifyPropertyChanged implementation : https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-property-change-notification
    public class UserControl1ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<int> _userControl1Numbers;

        public UserControl1ViewModel()
        {
            _userControl1Numbers = new ObservableCollection<int>();
        }

        public ObservableCollection<int> UserControl1Numbers
        {
            get => _userControl1Numbers;

            set
            {
                _userControl1Numbers = value;
                OnPropertyChanged(nameof(UserControl1Numbers));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DependencyPropertyCollectionApp.Service;

namespace DependencyPropertyCollectionApp.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<int> Numbers { get; set; }
        public ICommand AddNumberCommand { get; set; }
        public ICommand RemoveNumberCommand { get; set; }

        public MainWindowViewModel()
        {
            Numbers = new ObservableCollection<int>();
            AddNumberCommand = new DelegateCommand(AddRandomNumber);
            RemoveNumberCommand = new DelegateCommand(RemoveLastNumber);
        }

        private void RemoveLastNumber(object obj)
        {
            if (Numbers.Count == 0) return;
            Numbers.RemoveAt(Numbers.Count-1);
        }

        private void AddRandomNumber(object obj)
        {
            Random random = new Random();
            int rNumber = random.Next(0, 20);
            Numbers.Add(rNumber);
        }
    }
}

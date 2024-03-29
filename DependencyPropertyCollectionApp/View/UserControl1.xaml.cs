﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using DependencyPropertyCollectionApp.ViewModel;

namespace DependencyPropertyCollectionApp.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            DataContext = new UserControl1ViewModel();

            InitializeComponent();
        }

        // Dependency property implementation : https://www.tutorialspoint.com/wpf/wpf_dependency_properties.htm
        public static readonly DependencyProperty SetTextProperty =
            DependencyProperty.Register("SetNumber", typeof(ObservableCollection<int>), typeof(UserControl1),
                new PropertyMetadata(null, OnSetNumbersChanged));

        public string SetNumber
        {
            get => (string)GetValue(SetTextProperty);
            set => SetValue(SetTextProperty, value);
        }

        private static void OnSetNumbersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 control = (UserControl1) d;
            if (e.OldValue != null)
            {
                INotifyCollectionChanged collection = (INotifyCollectionChanged) e.OldValue;
                // Unsubscribe from CollectionChanged on the old collection
                collection.CollectionChanged -= control.Numbers_CollectionChanged;
            }

            if (e.NewValue != null)
            {
                ObservableCollection<int> numbers = (ObservableCollection<int>) e.NewValue;
                control.OnSetNumbersChanged(e);
                // Subscribe to CollectionChanged on the new collection
                numbers.CollectionChanged += control.Numbers_CollectionChanged;
            }
        }

        private void OnSetNumbersChanged(DependencyPropertyChangedEventArgs e)
        {
            // Dependency properties with MvvM : https://stackoverflow.com/questions/22247633/binding-usercontrol-dependency-property-and-mvvm
            ObservableCollection<int> numbers = ((UserControl1ViewModel)DataContext).UserControl1Numbers;
            numbers.Clear();
            foreach (int number in (ObservableCollection<int>)e.NewValue)
            {
                numbers.Add(number);
            }
        }

        // Handle Collection Change https://stackoverflow.com/questions/4362278/observablecollection-dependency-property-does-not-update-when-item-in-collection
        private void Numbers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            ObservableCollection<int> numbers = ((UserControl1ViewModel)DataContext).UserControl1Numbers;
            if (args.NewItems != null)
            {
                foreach (int number in args.NewItems)
                {
                    numbers.Add(number);
                }
            }

            if (args.OldItems != null)
            {
                foreach (int number in args.OldItems)
                {
                    numbers.Remove(number);
                }
            }
        }
    }
}

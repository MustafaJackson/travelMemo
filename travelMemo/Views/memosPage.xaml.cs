using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using travelMemo.ViewModel;
using travelMemo.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace travelMemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class memosPage : Page
    {
        private MemosViewModel vm;

        public memosPage()
        {
            this.InitializeComponent();
            vm = new MemosViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MemosListView.ItemsSource = vm.GetItems();
        }

        private void addNewMemoBtnAppBar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(addMemoPage));
        }

       
        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewMemoPage), MemosListView.SelectedItem);
        }

        private void homeAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void CreatNewButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(addMemoPage));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}

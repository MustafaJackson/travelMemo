using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using travelMemo.Model;
using travelMemo.ViewModel;
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

namespace travelMemo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewMemoPage : Page
    {
        public Memo CurrentMemo;
        private MemosViewModel vm;
        public ViewMemoPage()
        {
            this.InitializeComponent();
            vm = new MemosViewModel();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentMemo = e.Parameter as Memo;
            MemoNameTextBlock.Text = CurrentMemo.memoName;
            MemoDescriptionTextBlock.Text = CurrentMemo.memoDetails;
        }

        private void backhomeAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CurrentMemo.memoName = MemoNameTextBlock.Text;
            CurrentMemo.memoDetails = MemoDescriptionTextBlock.Text;
            vm.SaveItem(CurrentMemo);
        }
    }
}

﻿using System;
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

namespace travelMemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class addMemoPage : Page
    {
        private MemosViewModel vm;
        public addMemoPage()
        {
            this.InitializeComponent();
            vm = new MemosViewModel();
        }

        private void saveMemoBtnAppBar_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveItem(new Memo()
            {
                memoName = memoNameTextBox.Text,
                memoDetails = memoDetailsTextBox.Text
            });
            Frame.Navigate(typeof(memosPage));
        }

        private void discardMemoBtnAppBar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(memosPage));
        }
    }
}
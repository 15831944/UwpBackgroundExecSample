using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace App1
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer Timer;
        private int Count;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // GetFolderFromPathAsync() の実行例
            try
            {
                IStorageItem winFolder
                  = await StorageFolder.GetFolderFromPathAsync(@"C:\data");
                await (new Windows.UI.Popups.MessageDialog(winFolder.Path)).ShowAsync();
            }
            catch (Exception)
            {
            }

            // タイマーの実行例
            this.Timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            this.Timer.Tick += TimerTick;
            this.Timer.Start();
        }

        private void TimerTick(object sender, object e)
        {
            this.Count++;
            this.textBlock.Text = this.Count.ToString();
        }
    }
}

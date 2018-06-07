using Pyx.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pyx.Uwp.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ApiHelper _apiHelper = new ApiHelper("http://{LocalIP}:5002");
        private ThreadPoolTimer _timer;
        private int _currentId = 1;

        public MainPage()
        {
            this.InitializeComponent();

            PollForNextId();
        }

        private void PollForNextId()
        {
            TimeSpan period = TimeSpan.FromSeconds(1);

            _timer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
                
                    Dispatcher.RunAsync(CoreDispatcherPriority.High,
                    async () =>
                    {
                        try
                        {
                            var instruction = await _apiHelper.GetInstruction(_currentId);
                            this.Description.Text = instruction.Description;
                            this.Title.Text = instruction.Title;
                            this.CreatedBy.Text = instruction.CreatedBy;

                            this._timer.Cancel();
                        }
                        catch (Exception ex)
                        {
                            //retry on exception - we'll make this a bit smarter later and report any non 404 errors
                        }
                    });
        }, period);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            _currentId++;
            PollForNextId();
        }
    }
}

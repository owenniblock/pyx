using Pyx.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

        private async Task PollForNextId()
        {
            TimeSpan period = TimeSpan.FromSeconds(1);

            _timer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {

                await Dispatcher.RunAsync(CoreDispatcherPriority.High,
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

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            _currentId++;
            await PollForNextId();
        }
    }
}

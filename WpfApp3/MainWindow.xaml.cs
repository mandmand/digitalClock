using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Threading;

namespace WpfApp3
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupTimer();
        }
        private void MyTimerMethod(object sender, EventArgs e)
        {
            this.textbox.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private DispatcherTimer _timer;

        private void SetupTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(MyTimerMethod);
            _timer.Start();

            this.Closing += new CancelEventHandler(StopTimer);
        }
        private void StopTimer(object sender, CancelEventArgs e)
        {
            _timer.Stop();
        }
    }
    public class Clock
    {
        public string time { get; set; }
    }
}

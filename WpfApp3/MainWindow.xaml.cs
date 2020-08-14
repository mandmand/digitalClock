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
using System.Runtime.CompilerServices;
using MahApps.Metro.Controls;

namespace WpfApp3
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        bool Disp24h = true;

        public string UserName { get; set; } = "未設定";

        public MainWindow()
        {
            InitializeComponent();
            SetupTimer();
            this.DataContext = new { UserName = this.UserName };
        }
        private void MyTimerMethod(object sender, EventArgs e)
        {
            if (Disp24h == true)
            {
                this.textbox.Text = DateTime.Now.ToString("H:mm:ss");
            } else
            {
                this.textbox.Text = DateTime.Now.ToString("tth:mm:ss");
            }
            
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

        private void To12hDisp(object sender, EventArgs e)
        {
            Disp24h = false;
        }
        private void To24hDisp(object sender, EventArgs e)
        {
            Disp24h = true;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ChangeUsesrName changeUsesrName = new ChangeUsesrName(this);
            changeUsesrName.Owner = this;
            changeUsesrName.Show();

            //コールバック用の関数を登録しとく
            changeUsesrName.callback_UsernameChange = OnCallBack;
        }

        //
        void OnCallBack(string username )
        {
            control_textblock_username.Text = username;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using MahApps.Metro.Controls;

namespace WpfApp3
{
    /// <summary>
    /// ChangeUsesrName.xaml の相互作用ロジック
    /// </summary>
    public partial class ChangeUsesrName : MetroWindow
    {
        private MainWindow m_parent_instance = null;

        //コールバックの準備：delegateの使い方とか検索すると、ノリがわかるかも。
        public delegate void delegete_callback_string_notify(string data);
        public delegete_callback_string_notify callback_UsernameChange = null;

        public ChangeUsesrName(MainWindow mainWindow)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (callback_UsernameChange != null)
            {
                string notify_info = control_textbox_username.Text;
                callback_UsernameChange(notify_info);
            }

            this.Close();
        }
    }
}

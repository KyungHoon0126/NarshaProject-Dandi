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

namespace Dandi
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        static SettingWindow instance = null;
        static readonly object padlock = new object();
        
        public static SettingWindow Instance
        {
            get
            {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new SettingWindow();
                    }

                    return instance;
                }
            }
        }

        public SettingWindow()
        {
            instance = this;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = 150;
            this.Top = 150;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            instance = null;
        }

        private void BtnCloseClick(object sender, RoutedEventArgs e)
        {
            SettingWindow.Instance.Close();
        }
    }
}

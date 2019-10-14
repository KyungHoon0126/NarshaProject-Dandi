using Dandi.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dandi
{
    /// <summary>
    /// Interaction logic for EventControl.xaml
    /// </summary>
    public partial class ChannelEventsControl : UserControl
    {
        public ChannelEventsControl()
        {
            InitializeComponent();
            // this.DataContext에 값을 넣는것과 동일한 방법이다. DataContext에는 하나의 ViewModel만 바인딩 가능.
            // 대신 xaml코드에서 Itemsource에 값을 바인딩 시켜줘야 한다.

            ChannelEvents.ItemsSource = App.joinedChannelViewModel.AllChannelScheduleItems;

            // this.DataContext = App.joinedChannelViewModel;
            // ItemSoruce = "{Binding ChannelEvents}";
        }
    }
}
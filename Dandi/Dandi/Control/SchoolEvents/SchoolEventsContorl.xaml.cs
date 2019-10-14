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
    /// Interaction logic for SchoolEventsContorl.xaml
    /// </summary>
    public partial class SchoolEventsContorl : UserControl
    {
        public SchoolEventsContorl()
        {
            InitializeComponent();
            // this.DataContext에 넣는것과 동일한 방법. DataContext에는 하나의 ViewModel만 바인딩 가능.
            // 대신 xaml코드에서 Itemsource에 값을 바인딩 시켜줘야 한다.

            SchoolEventsItems.ItemsSource = App.schoolEventsViewModel.SchoolEventsItems;

            // this.DataContext = App.schoolEventsViewModel;
            // ItemsSource = "{Binding SchoolEventsItems}"
        }
    }
}

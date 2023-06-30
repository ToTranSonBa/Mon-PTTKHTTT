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
using BUS;
using DTO;

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for RoomManagementView.xaml
    /// </summary>
    public partial class RoomManagementView : UserControl
    {
        private readonly RoomBLL _rooms;
        public RoomManagementView()
        {
            _rooms = new RoomBLL();
            InitializeComponent();
            roomListView.ItemsSource = _rooms.GetAll();
        }
        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {

        }

        private void click_Delete(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Search Event
        private void Search_Click(object sender, RoutedEventArgs e)
        {
        }
        #endregion
    }
}

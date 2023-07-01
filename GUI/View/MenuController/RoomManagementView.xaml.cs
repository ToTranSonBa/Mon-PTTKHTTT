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
using DTO.Models;

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for RoomManagementView.xaml
    /// </summary>
    public partial class RoomManagementView : UserControl
    {
<<<<<<< Updated upstream
        private readonly RoomBLL _rooms;
        public RoomManagementView()
        {
            _rooms = new RoomBLL();
=======
        private readonly PhongBUS _rooms;
        private List<PttkPhong> pttkPhongs = new List<PttkPhong>();
        public RoomManagementView()
        {
            _rooms = new PhongBUS();
            LoaiphongBUS loaiphongBUS = new LoaiphongBUS();
>>>>>>> Stashed changes
            InitializeComponent();
            pttkPhongs = _rooms.GetAll();
            foreach(var  p in pttkPhongs)
            {
                p.KindNavigation = loaiphongBUS.GetByID(p.Kind);
            }
            roomListView.ItemsSource = pttkPhongs;
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

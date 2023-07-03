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
        private readonly PhongBUS _rooms;
        public RoomManagementView()
        {

            _rooms = new PhongBUS();
            InitializeComponent();
            loadRoomManagementView();


        }
        public void loadRoomManagementView()
        {

            LoaiphongBUS loaiphongBUS = new LoaiphongBUS();
            var pttkPhongs = _rooms.GetAll();
            foreach (var p in pttkPhongs)
            {
                p.KindNavigation = loaiphongBUS.GetByID(p.Kind);
            }
            roomListView.ItemsSource = pttkPhongs;
        }
        #region Button Event


        private void click_Detail(object sender, RoutedEventArgs e)
        {


            PttkPhong detailroom = new PttkPhong();
            detailroom = (PttkPhong)roomListView.SelectedItem;
            DetailRoomForLeTan detailRoomForLeTan = new DetailRoomForLeTan(detailroom);
            detailRoomForLeTan.ShowDialog();
            loadRoomManagementView();
        }

        private void click_Delete(object sender, RoutedEventArgs e)
        {

            PhongBUS phongbus = new PhongBUS();
            PttkPhong deleteroom = new PttkPhong();
            deleteroom = (PttkPhong)roomListView.SelectedItem;

            ThietbiPhongBUS tb_ph_bus = new ThietbiPhongBUS();

            decimal? Id_room = deleteroom.Id;

            List<PttkThietbiPhong> list_tb_ph = new List<PttkThietbiPhong>();
            PttkThietbiPhong temp = new PttkThietbiPhong();


            list_tb_ph = tb_ph_bus.GetAll().Where(tp => tp.RoomId == Id_room).ToList();
            foreach (var tp_ph in list_tb_ph)
            {
                if (tp_ph != null)
                {
                    tb_ph_bus.Remove(tp_ph);
                }
            }

            try
            {
                phongbus.Remove(deleteroom);
                MessageBox.Show("xóa thành công");
                loadRoomManagementView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoomWindow addRoomWindow = new AddRoomWindow();
            addRoomWindow.ShowDialog();
            loadRoomManagementView();
        }

        #endregion

        #region Search Event
        private void Search_Click(object sender, RoutedEventArgs e)
        {
        }
        #endregion
    }



}


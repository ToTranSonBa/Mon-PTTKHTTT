using BUS;
using DTO.Models;
using GUI.View.MenuController;
using MaterialDesignThemes.Wpf;
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

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for DetailRoomForLeTan.xaml
    /// </summary>
    public partial class DetailRoomForLeTan : Window
    {
        public PttkPhong _PttkPhong;
        public DetailRoomForLeTan(PttkPhong pttkPhong)
        {
            _PttkPhong = pttkPhong;
            InitializeComponent();
            loadDetailRoomForLeTan();
        }

        public void loadDetailRoomForLeTan()
        {
            tenphongtxt.Text = _PttkPhong.RoomNumber as string;
            giatxt.Text = _PttkPhong.Price.ToString();
            loaiphongtxt.Text = _PttkPhong.KindNavigation.Name.ToString();
            dondeptxt.Text = _PttkPhong.HygieneStatus.ToString();
            tinhtrangtxt.Text = _PttkPhong.RentStatus.ToString();

        }

        private void click_BtnExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //để kéo thả window khi set window=none
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            string selectedTinhTrangPhong = cbTinhTrangPhong.Text as string;
            string selectedTinhTrangDonDep = cbDonDep.Text as string;
            if (selectedTinhTrangPhong != "" && selectedTinhTrangDonDep != "")
            {
                _PttkPhong.RentStatus = selectedTinhTrangPhong;
                _PttkPhong.HygieneStatus = selectedTinhTrangDonDep;
                PhongBUS updateRoom = new PhongBUS();
                updateRoom.Update(_PttkPhong);
                if (updateRoom.Update(_PttkPhong))
                {
                    MessageBox.Show("cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("cập nhật thất bại");

                }
            }
            else
            {
                MessageBox.Show("cập nhật thất bại");

            }
            this.Close();
        }
    }
}

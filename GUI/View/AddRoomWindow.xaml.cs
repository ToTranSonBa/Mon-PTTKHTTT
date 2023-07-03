using BUS;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        public AddRoomWindow()
        {
            InitializeComponent();
            loadAddRoomWindow();
        }

        public void loadAddRoomWindow()
        {
            LoaiphongBUS loaiphongBUS = new LoaiphongBUS();
            List<PttkLoaiphong> loaiPhong_List = new List<PttkLoaiphong>();
            loaiPhong_List = loaiphongBUS.GetAll();
            cbloaiPhong.ItemsSource = loaiPhong_List;
        }

        private void btn_Add(object sender, RoutedEventArgs e)
        {

            if (tenphongtxt.Text != "" && cbloaiPhong.SelectedValue != null)
            {
                PttkLoaiphong LoaiPhong = cbloaiPhong.SelectedItem as PttkLoaiphong;
                PttkPhong pttkPhong = new PttkPhong();
                pttkPhong.RoomNumber = tenphongtxt.Text.ToString();
                pttkPhong.Price = LoaiPhong.Price;
                pttkPhong.Kind = LoaiPhong.Id;
                pttkPhong.KindNavigation = LoaiPhong;
                pttkPhong.RentStatus = "Vacant";
                pttkPhong.HygieneStatus = "Clean";

                PhongBUS phongbus = new PhongBUS();
                phongbus.Add(pttkPhong);
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ !");

            }
        }

        private void btn_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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


    }
}

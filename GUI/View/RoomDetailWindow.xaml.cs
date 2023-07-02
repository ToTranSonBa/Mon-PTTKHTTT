using BUS;
using DTO;
using DTO.Models;
using PTTKHTTT.View;
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
    /// Interaction logic for RoomDetailWindow.xaml
    /// </summary>
    public partial class RoomDetailWindow : Window
    {
        PhongDatphongBUS phongDatPhong = new PhongDatphongBUS();
        KhachhangBUS khachHang = new KhachhangBUS();
        DatphongBUS datPhong = new DatphongBUS();
        DatphongDichvuBUS datphongDichvu = new DatphongDichvuBUS();
        DichvuBUS dichvu = new DichvuBUS();

        private PttkPhong _room { get; set; }
        PttkPhongDatphong _phongDatphong { get; set; }
        PttkKhachhang _khachHang { get; set; }
        PttkDatphong _datPhong { get; set; }
        List<PttkDatphongDichvu> _datPhongDichvu { get; set; }
        PttkDichvu dichVu { get; set; }
        PttkNhanvien _nhanvien { get; set; }

        public RoomDetailWindow(PttkPhong room, PttkNhanvien nhanvien)
        {

            InitializeComponent();
            _nhanvien = nhanvien;
            _room = room;
            _phongDatphong = phongDatPhong.getOneByRoomID(_room.Id);
            if (_phongDatphong != null)
            {
                _datPhong = datPhong.getOneByID(_phongDatphong.OrderId);
                if (_datPhong != null)
                {
                    _khachHang = khachHang.GetByID(_datPhong.CustomerId);
                }
                _datPhongDichvu = new List<PttkDatphongDichvu>();
                _datPhongDichvu = datphongDichvu.GetAllbyOrderID(_datPhong.Id);

                foreach (var item in _datPhongDichvu)
                {
                    item.Service = dichvu.GetByID(item.ServiceId);
                    item.TotalPrice = item.Quantity * item.Service.Price;
                }

                ViewSuDungDV.ItemsSource = _datPhongDichvu;
                txbNguoithue.Text = _khachHang.Name;
                txbNgaythue.Text = _phongDatphong.ArrivalDay.ToString();
                txbNgayroi.Text = _phongDatphong.LeavingDay.ToString();
            }
            titleRoom.Text = _room.RoomNumber;
            txbTinhTrangPhong.Text = _room.RentStatus;
            txbTinhTrangDonDep.Text = _room.HygieneStatus;
        }
    

        private void click_ThemDV(object sender, RoutedEventArgs e)
        {
            var addServiceWindow = new AddService_Window(_datPhong);
            addServiceWindow.ShowDialog();
        }
        
        private void cbDonDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý sự kiện khi lựa chọn trong ComboBox thay đổi
            // Thực hiện các thao tác cần thiết
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

        private void Click_BtnTraphong(object sender, RoutedEventArgs e)
        {
            BillDetail_Window billDetail_wd = new BillDetail_Window(_nhanvien, _khachHang, _datPhong, _datPhongDichvu);
            billDetail_wd.Show();
        }
    }
}

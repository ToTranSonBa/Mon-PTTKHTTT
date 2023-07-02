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
using BUS;
using DTO;
using DTO.Models;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for BillDetail_Window.xaml
    /// </summary>
    public partial class BillDetail_Window : Window
    {
    
        private PttkNhanvien _nhanvien { get; set; }
        private PttkKhachhang _khachhang { get; set; }
        private PttkDatphong _datphong { get; set; }
        private List<PttkDatphongDichvu> _litsDpDV { get; set; }

        DichvuBUS dichvuBUS = new DichvuBUS();
        private object txbSTT;

        private int totalPrice { get; set; }

        //NhanvienBUS _nhanVienBUS = new NhanvienBUS();
        //DatphongBUS _datphongBUS = new DatphongBUS();
        public DateTime CurrentDate { get; set; }
        public BillDetail_Window(PttkNhanvien nhanvien, PttkKhachhang khachhang, PttkDatphong datphong, List<PttkDatphongDichvu> litsDpDV)
        {
            _nhanvien = new PttkNhanvien();
            _khachhang = new PttkKhachhang();
            _datphong = new PttkDatphong();
            _litsDpDV = new List<PttkDatphongDichvu>();
            InitializeComponent();
            _nhanvien = nhanvien;
            _khachhang = khachhang;
            _datphong = datphong;
            _litsDpDV = litsDpDV;
            
            lvDichVuDaSD.ItemsSource = _litsDpDV;
           
            txbSoPhong.Text = _datphong.Id.ToString();
            txbTenKH.Text = _khachhang.Name;
            txbNhanVien.Text = _nhanvien.Name;

             // lấy ngày hiện tại trên hệ thống
            CurrentDate = DateTime.Now;
            DataContext = this;

            totalPrice = (int)_litsDpDV.Sum(x => x.TotalPrice);
            txbTongTien.Text = totalPrice.ToString();
            List<String> thanhtoanCb = new List<String>();
            thanhtoanCb.Add("Thanh toán tiền mặt");
            thanhtoanCb.Add("Thanh toán chuyển khoản");
            cbThanhtoan.ItemsSource = thanhtoanCb;

            // 
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

        private void click_BtnExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CbThanhtoanChanged(object sender, SelectionChangedEventArgs e)
        {
            string? thanhtoan = cbThanhtoan.SelectedItem as string;
            if(thanhtoan == "Thanh toán tiền mặt")
            {
                GridTienhan.Visibility = Visibility.Visible;
                GridTienTra.Visibility = Visibility.Visible;
            }
            else if (thanhtoan == "Thanh toán chuyển khoản")
            {
                GridTienhan.Visibility = Visibility.Hidden;
                GridTienTra.Visibility = Visibility.Hidden;
            }    
        }

        private void txbTienNhanChanged(object sender, TextChangedEventArgs e)
        {
            if(txbTienhan.Text != "")
            {
                var tienNhan = Convert.ToInt32(txbTienhan.Text);
                if (tienNhan > totalPrice)
                {
                    txbTienTra.Text = (tienNhan - totalPrice).ToString();
                    BtnThanhtoan.IsEnabled = true;
                }
                else
                {
                    txbTienTra.Text = " ";
                    BtnThanhtoan.IsEnabled = false;
                }
            }    
                
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}

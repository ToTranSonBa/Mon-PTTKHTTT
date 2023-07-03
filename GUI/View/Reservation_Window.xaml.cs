using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for Reservation_Window.xaml
    /// </summary>
    public partial class Reservation_Window : Window
    {
        public DoanBUS doanBUS = new DoanBUS();
        public PttkNhanvien _PttkNhanvienl;
        public PttkDatphong _PttkDatphong;
        private PttkNhanvien _PttkNhanvien;
        public Reservation_Window(PttkDatphong pttkDatphong, PttkNhanvien emp)
        {
            _PttkNhanvien = emp;
            _PttkDatphong = pttkDatphong;
            NhanvienBUS nhanvienBUS = new NhanvienBUS();
            _PttkNhanvienl = nhanvienBUS.GetByID(1);
            InitializeComponent();
            OutlinedComboBox.ItemsSource = doanBUS.GetAll().Select(d => d.Name);
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

        private void ClearOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {

        }

        private void click_BtnPhanphong(object sender, RoutedEventArgs e)
        {
            var roomDivision_wd = new RoomDivision_Window(_PttkDatphong);
            if (roomDivision_wd !=  null)
            {
                roomDivision_wd.Owner = this;
                roomDivision_wd.ShowDialog();
            }
        }

        private void OutlinedComboBoxEnabledCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            addDoan.Visibility = Visibility.Hidden;
        }

        private void OutlinedComboBoxEnabledCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            addDoan.Visibility = Visibility.Visible;
        }

        private void FilledComboBoxEnabledCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ChooseDoan.Visibility = Visibility.Hidden; 
        }

        private void FilledComboBoxEnabledCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ChooseDoan.Visibility = Visibility.Visible;
        }

        private void OutlinedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tendoan = OutlinedComboBox.SelectedValue as string;
            var doan = doanBUS.GetByName(tendoan);
            var khachhangBUS = new KhachhangBUS();
            var doantruong = khachhangBUS.GetByID(doan.Leader);
            DoanTruongTextBox.Text = doantruong.Name;
        }

        private void Luu_Click(object sender, RoutedEventArgs e)
        {
            int checkdoan = 0; //0: KHONG THEO DOAN - 1: DOAN MOI - 2:DOAN DA TON TAI
            PttkDoan pttkDoan = new PttkDoan();
            if (OutlinedComboBoxEnabledCheckBox.IsChecked == true)
            {
                checkdoan = 2;
                pttkDoan = doanBUS.GetByName(OutlinedComboBox.Text);
                if(pttkDoan == null)
                {
                    MessageBox.Show("Đoàn không tồn tại");
                    return;
                }
            }
            else if (FilledComboBoxEnabledCheckBox.IsChecked == true)
            {
            
                checkdoan = 1;
                try
                {
                    pttkDoan = new PttkDoan
                    {
                        Name = TenDoanMoi.Text,
                        Amount = Convert.ToDecimal(SoluongThanhVien.Text),
                    };
                } 
                catch
                {
                    MessageBox.Show("Thông tin sai hoặc không đầy đủ.");
                    return;
                }
            }
            try
            {
                PttkKhachhang pttkKhachhang = new PttkKhachhang
                {
                    IdentifiedCard = txbCCCD.Text,
                    Name = txbHoTen.Text,
                    NumberPhone = txbSDT.Text,
                    Address = txbDiaChi.Text,
                    Birthday = dtpNgayKT.DisplayDate,
                    Sex = cbGioiTinh.Text
                };
                PttkDatphong pttkDatphong = new PttkDatphong
                {
                    CreatedDay = DateTime.Now,
                    ArrivalDay = Convert.ToDateTime(ngaytoiDP.Text),
                    LeavingDay = Convert.ToDateTime(ngaydiDP.Text),
                    EmployeeId = _PttkNhanvien.Id
                };
                DatphongBUS datphongBUS = new DatphongBUS();
                if (datphongBUS.Add(pttkDatphong, pttkDoan, pttkKhachhang, checkdoan))
                {
                    MessageBox.Show("Đặt phòng thành công");
                }
                else
                {
                    MessageBox.Show("Đặt phòng thất bại");
                }
            }
           catch
            {
                MessageBox.Show("Thông tin sai hoặc không đầy đủ!");
                return;
            }
        }
    }
}

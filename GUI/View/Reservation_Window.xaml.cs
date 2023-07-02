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
    /// Interaction logic for Reservation_Window.xaml
    /// </summary>
    public partial class Reservation_Window : Window
    {
        public DoanBUS doanBUS = new DoanBUS();
        public PttkNhanvien _PttkNhanvienl;
        public Reservation_Window()
        {
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
            var roomDivision_wd = new RoomDivision_Window();
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
            PttkDoan pttkDoan = new PttkDoan();
            if (OutlinedComboBoxEnabledCheckBox.IsChecked == true)
            {
                pttkDoan = doanBUS.GetByName(OutlinedComboBox.Name);
            } 
            else if (FilledComboBoxEnabledCheckBox.IsChecked == true) { }
            {
                pttkDoan = new PttkDoan
                {
                    Name = TenDoanMoi.Text,
                    Amount = Convert.ToDecimal(SoluongThanhVien.Text)
                };
            }
            PttkKhachhang pttkKhachhang = new PttkKhachhang
            {
                IdentifiedCard = txbCCCD.Text,
                Name = txbHoTen.Text,
                NumberPhone = txbSDT.Text,
                Address = txbDiaChi.Text,
                Birthday = dtpNgayKT.DisplayDate,
                Sex = cbGioiTinh.Text
            };
            DatphongBUS datphongBUS = new DatphongBUS();
      
        }
    }
}

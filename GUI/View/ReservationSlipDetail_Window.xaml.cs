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
using MaterialDesignThemes.Wpf;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for ReservationSlipDetail_Window.xaml
    /// </summary>
    public partial class ReservationSlipDetail_Window : Window
    {
        private PttkDatphong _reservationModel { get; set; }
        public ReservationSlipDetail_Window(PttkDatphong reservationModel)
        {
            InitializeComponent();
            KhachhangBUS khachhangBUS = new KhachhangBUS();
            _reservationModel = reservationModel;
            titleSlip.Text = _reservationModel.Id.ToString();
            if(_reservationModel.Customer == null)
            {
                _reservationModel.Customer = khachhangBUS.GetByID(_reservationModel.CustomerId);
            }
            KhachhangDoanBUS khachhangDoanBUS = new KhachhangDoanBUS();
            DoanBUS doanBUS = new DoanBUS();
            var khachhangdoan = doanBUS.GetByID(_reservationModel.DoanID);
            OutlinedComboBox.ItemsSource = doanBUS.GetAll().Select(i => i.Name);
            if (khachhangdoan != null)
            {
                OutlinedComboBoxEnabledCheckBox.IsChecked = true;
                
                OutlinedComboBox.Text = khachhangdoan.Name.ToString();
                DoanTruongTextBox.Text = doanBUS.GetLeaderByID(khachhangdoan.Id).Name;
            }
            ngaytoiDP.Text = _reservationModel.ArrivalDay.ToString();
            ngaydiDP.Text = _reservationModel.LeavingDay.ToString();

            txbHoTen.Text = _reservationModel.Customer.Name;
            txbCCCD.Text = _reservationModel.Customer.IdentifiedCard;
            txbSDT.Text = _reservationModel.Customer.NumberPhone;
            txbDiaChi.Text = _reservationModel.Customer.Address;
            cbGioiTinh.Text = _reservationModel.Customer.Sex;
            dtpNgayKT.Text = _reservationModel.Customer.Birthday.ToString();
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

        private void ClearOutlinedComboBox_Click(object sender, RoutedEventArgs e)
        {

        }

        private void click_BtnPhanphong(object sender, RoutedEventArgs e)
        {
            var roomDivision_wd = new RoomDivision_Window(_reservationModel);
            if (roomDivision_wd != null)
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
            var doanBUS = new DoanBUS();
            var doan = doanBUS.GetByName(tendoan);
            var khachhangBUS = new KhachhangBUS();
            var doantruong = khachhangBUS.GetByID(doan.Leader);
            DoanTruongTextBox.Text = doantruong.Name;
        }

        private void click_BtnExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CapNhatPhieuDatPhong(object sender, RoutedEventArgs e)
        {
            DoanBUS doanBUS = new DoanBUS();
            int checkdoan = 0;
            _reservationModel.ArrivalDay = Convert.ToDateTime(ngaytoiDP.Text);
            _reservationModel.LeavingDay = Convert.ToDateTime(ngaydiDP.Text);

            _reservationModel.Customer.Name = txbHoTen.Text;
            _reservationModel.Customer.IdentifiedCard = txbCCCD.Text;
            _reservationModel.Customer.NumberPhone = txbSDT.Text;
            _reservationModel.Customer.Sex = cbGioiTinh.Text;
            _reservationModel.Customer.Address = txbDiaChi.Text;
            _reservationModel.Customer.Birthday = Convert.ToDateTime( dtpNgayKT.Text);
            PttkDoan pttkDoan = new PttkDoan();
            if (OutlinedComboBoxEnabledCheckBox.IsChecked == true)
            {
                checkdoan = 2;
                pttkDoan = doanBUS.GetByName(OutlinedComboBox.Text);
                if (pttkDoan == null)
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
            DatphongBUS datphongBUS = new DatphongBUS();
            if(datphongBUS.Update(_reservationModel, pttkDoan, checkdoan))
            {
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }

        }
    }
}

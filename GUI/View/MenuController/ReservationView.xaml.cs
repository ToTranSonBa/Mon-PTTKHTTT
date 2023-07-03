using BUS;
using DTO;
using DTO.Models;
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


namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for ReservationView.xaml
    /// </summary>
    public partial class ReservationView : UserControl
    {
        private List<PttkDatphong> reservations { get; set; }
        private PttkNhanvien _PttkNhanvien;
        public ReservationView(PttkNhanvien pttkNhanvien)
        {
            _PttkNhanvien = pttkNhanvien;
            InitializeComponent();
            reservations = new List<PttkDatphong>();
            DatphongBUS loaiphongBUS = new DatphongBUS();
            NhanvienBUS nhanvienBUS = new NhanvienBUS();
            KhachhangBUS khachhangBUS = new KhachhangBUS();
          
            //PttkDatphong pttkDatphong = new PttkDatphong();
            //pttkDatphong.Employee.Name
            reservations = loaiphongBUS.GetAll();

            foreach(var item in reservations)
            {
                item.Employee = nhanvienBUS.GetByID(item.EmployeeId);
                item.Customer = khachhangBUS.GetByID(item.CustomerId);
            }
            orderistView.ItemsSource = reservations.Where(DP => DP != null);
        }

        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {
            PttkDatphong reservationSlipDetail = orderistView.SelectedItem as PttkDatphong;
            if (reservationSlipDetail != null)
            {
                var reservationSlipDetailsWindow = new ReservationSlipDetail_Window(reservationSlipDetail);
                reservationSlipDetailsWindow.Show();
            }
        }

        private void click_Delete(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion

        #region Search Event
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string textSearch = orderSearchTextBox.Text;
            orderistView.ItemsSource = reservations;
            if (textSearch != null)
            {
                //var resultSearch = reservations.Where(t => t.NameOrderer.Contains(textSearch));
                //orderistView.ItemsSource = resultSearch;
            }
        }
        #endregion

        private void DbClick_BtnDatPhong(object sender, RoutedEventArgs e)
        {
            var datphong = orderistView.SelectedItem as PttkDatphong;
            var reservation_wd = new Reservation_Window(datphong, _PttkNhanvien);
            reservation_wd.Show();
        }
    }
}

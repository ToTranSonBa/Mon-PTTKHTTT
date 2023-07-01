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
        public ReservationView()
        {
            InitializeComponent();
            reservations = new List<PttkDatphong>();
            LoaiphongBUS loaiphongBUS = new LoaiphongBUS();
            #region Add Data
            #endregion

            orderistView.ItemsSource = loaiphongBUS.GetAll();
        }

        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {
            PttkDatphong reservationSlipDetail = (PttkDatphong)orderistView.SelectedItem;
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
            var reservation_wd = new Reservation_Window();
            reservation_wd.Show();
        }
    }
}

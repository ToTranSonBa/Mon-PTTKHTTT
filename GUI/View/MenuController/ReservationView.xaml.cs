using DTO;
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
        private List<ReservationDTO> reservations { get; set; }
        public ReservationView()
        {
            InitializeComponent();
            reservations = new List<ReservationDTO>();
            #region Add Data
            reservations.Add(new ReservationDTO
            {
                Id = 1,
                NameOrderer = "Hello kitty 1",
                OrderDate = DateTime.UtcNow,
                EmployeeName = "Hello kitty"
            });
            reservations.Add(new ReservationDTO
            {
                Id = 1,
                NameOrderer = "Hello kitty 2",
                OrderDate = DateTime.UtcNow,
                EmployeeName = "Hello kitty"
            });
            reservations.Add(new ReservationDTO
            {
                Id = 2,
                NameOrderer = "Hello kitty 3",
                OrderDate = DateTime.UtcNow,
                EmployeeName = "Hello kitty"
            });
            reservations.Add(new ReservationDTO
            {
                Id = 3,
                NameOrderer = "Hello kitty 4",
                OrderDate = DateTime.UtcNow,
                EmployeeName = "Hello kitty"
            });
            reservations.Add(new ReservationDTO
            {
                Id = 4,
                NameOrderer = "Hello kitty 5",
                OrderDate = DateTime.UtcNow,
                EmployeeName = "Hello kitty"
            });
            reservations.Add(new ReservationDTO
            {
                Id = 5,
                NameOrderer = "Hello kitty 6",
                OrderDate = DateTime.UtcNow,
                EmployeeName = "Hello kitty"
            });
            reservations.Add(new ReservationDTO
            {
                Id = 6,
                NameOrderer = "Hello kitty 7",
                OrderDate = DateTime.UtcNow,
                EmployeeName = "Hello kitty"
            });
            reservations.Add(new ReservationDTO
            {
                Id = 7,
                NameOrderer = "Hello kitty 8",
                OrderDate = DateTime.UtcNow,
                EmployeeName = "Hello kitty"
            });
            #endregion
            orderistView.ItemsSource = reservations;
        }

        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {
            ReservationDTO reservationSlipDetail = (ReservationDTO)orderistView.SelectedItem;
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
                var resultSearch = reservations.Where(t => t.NameOrderer.Contains(textSearch));
                orderistView.ItemsSource = resultSearch;
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

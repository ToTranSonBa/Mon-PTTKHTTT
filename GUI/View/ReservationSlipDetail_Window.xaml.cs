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
using DTO;
using DTO.Models;

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
            _reservationModel = reservationModel;
            titleSlip.Text = _reservationModel.Id.ToString();

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

        private void click_BtnPhanphong(object sender, RoutedEventArgs e)
        {

        }
    }
}

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

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for Reservation_Window.xaml
    /// </summary>
    public partial class Reservation_Window : Window
    {
        public Reservation_Window()
        {
            InitializeComponent();
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
    }
}

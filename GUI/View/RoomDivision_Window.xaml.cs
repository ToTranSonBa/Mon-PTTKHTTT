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
    /// Interaction logic for RoomDivision_Window.xaml
    /// </summary>
    public partial class RoomDivision_Window : Window
    {
        public RoomDivision_Window()
        {
            InitializeComponent();
        }

        // nút thoát
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

        private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lvDanhSachPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void click_Them(object sender, RoutedEventArgs e)
        {

        }

        private void lvDanhSachPhongDaChon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void click_BtnXoa(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Click_BtnPhanphong(object sender, RoutedEventArgs e)
        {

        }
    }
}

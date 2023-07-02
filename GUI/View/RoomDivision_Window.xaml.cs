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
    /// Interaction logic for RoomDivision_Window.xaml
    /// </summary>
    public partial class RoomDivision_Window : Window
    {
        private List<PttkPhong> phongs { get; set; }
        private List<PttkPhong> ChoosePhongs { get; set; }
        private PhongBUS PhongBUS = new PhongBUS();
        private LoaiphongBUS LoaiphongBUS = new LoaiphongBUS();

        public RoomDivision_Window()
        {
            ChoosePhongs = new List<PttkPhong>();
            InitializeComponent();
            phongs = PhongBUS.GetAll();
            foreach(var item in  phongs)
            {
                item.KindNavigation = LoaiphongBUS.GetByID(item.Kind);
            }
            lvDanhSachPhong.ItemsSource = phongs;
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

        private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void click_Them(object sender, RoutedEventArgs e)
        {
            var choosephong = lvDanhSachPhong.SelectedItem as PttkPhong;
            if (choosephong != null)
            {
                ChoosePhongs.Add(choosephong);
                phongs.Remove(choosephong);
                lvDanhSachPhong.ItemsSource = phongs.Where(p => p != null);
                lvDanhSachPhongDaChon.ItemsSource = ChoosePhongs.Where(p => p != null);
            }
        }
        private void click_BtnXoa(object sender, RoutedEventArgs e)
        {
            var choosephong = lvDanhSachPhongDaChon.SelectedItem as PttkPhong;
            if (choosephong != null)
            {
                phongs.Add(choosephong);
                ChoosePhongs.Remove(choosephong);
                lvDanhSachPhong.ItemsSource = phongs.Where(p => p != null);
                lvDanhSachPhongDaChon.ItemsSource = ChoosePhongs.Where(p => p != null);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Click_BtnPhanphong(object sender, RoutedEventArgs e)
        {

        }
    }
}

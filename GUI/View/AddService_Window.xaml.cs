using BUS;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for AddService_Window.xaml
    /// </summary>


    public partial class AddService_Window : Window
    {
        public ObservableCollection<Promotion> Promotions { get; set; }
        public DichvuBUS dichvubus = new DichvuBUS();

        private List<PttkDichvu> _listDichvu { get; set; }
        private List<PttkDichvu> _listDichvuChon { get; set; }
        private PttkDatphong _datPhong { get; set; }
        public AddService_Window(PttkDatphong datphong)
        {
            _datPhong = datphong;
            _listDichvu = new List<PttkDichvu>();
            _listDichvuChon = new List<PttkDichvu>();
            InitializeComponent();
            _listDichvu = dichvubus.GetAll();
            lvDanhSachDV.ItemsSource = _listDichvu;



            // Thêm các chương trình khuyến mãi vào danh sách
            Promotions = new ObservableCollection<Promotion>();

            Promotions.Add(new Promotion { Title = "Giảm giá dịch vụ massage", Description = "Giảm giá 30% cho khách hàng lần đầu." });
            Promotions.Add(new Promotion { Title = "Thẻ tập gym 3 tháng", Description = "Giảm giá 15% cho thẻ tập gym 3 tháng." });
            Promotions.Add(new Promotion { Title = "Thẻ bơi gia đình", Description = "Mua thẻ bơi gia đình, giảm giá 20% cho trẻ em." });

            Promotions.Add(new Promotion { Title = "Khuyến mãi gia hạn thẻ tập", Description = "Khi gia hạn thẻ tập, khách hàng được giảm giá 10%." });
            Promotions.Add(new Promotion { Title = "Học bơi", Description = "Mua gói học bơi 10 buổi, tặng 2 buổi miễn phí" });
            Promotions.Add(new Promotion { Title = "Gói nghỉ dưỡng", Description = "Mua thẻ Đặt phòng 3 đêm, tặng voucher giảm giá cho dịch vụ spa" });
            DataContext = this;
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

        private void lvDanhSachDV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void click_Xoa(object sender, RoutedEventArgs e)
        {
            var dichvuChon = lvDanhSachDVChon.SelectedItem as PttkDichvu;
            if (dichvuChon != null)
            {
                _listDichvu.Add(dichvuChon);
                _listDichvuChon.Remove(dichvuChon);

                lvDanhSachDV.ItemsSource = _listDichvu.Where(p => p != null);
                lvDanhSachDVChon.ItemsSource = _listDichvuChon.Where(p => p != null);
            }
        }
        private void click_Them(object sender, RoutedEventArgs e)
        {
            var dichvuChon = lvDanhSachDV.SelectedItem as PttkDichvu;
            if (dichvuChon != null)
            {
                _listDichvuChon.Add(dichvuChon);
                _listDichvu.Remove(dichvuChon);

                lvDanhSachDV.ItemsSource = _listDichvu.Where(p => p != null);
                lvDanhSachDVChon.ItemsSource = _listDichvuChon.Where(p => p != null);
            }
        }

        private void click_BtnThemDichVu(object sender, RoutedEventArgs e)
        {
            DatphongDichvuBUS datphongDichvubus = new DatphongDichvuBUS();
            bool result = true;
            result = datphongDichvubus.AddListDatphongDichvu(_listDichvuChon, _datPhong.Id);
            if (result == true)
            {
                MessageBox.Show("Thêm dịch vụ thành công!");
            }    
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại!");
            }    
        }
    }

    public class Promotion
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

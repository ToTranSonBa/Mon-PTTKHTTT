using BUS;
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
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for BillPaidDetail_Window.xaml
    /// </summary>
    public partial class BillPaidDetail_Window : Window
    {
        private PttkNhanvien _nhanvien { get; set; }
        private PttkKhachhang _khachhang { get; set; }
        private PttkDatphong _datphong { get; set; }
        private List<PttkDatphongDichvu> _litsDpDV { get; set; }

        DichvuBUS dichvuBUS = new DichvuBUS();
        DatphongDichvuBUS datphongDichvuBUS = new DatphongDichvuBUS();
        private int totalPrice { get; set; }

        public BillPaidDetail_Window(PttkNhanvien nhanvien, PttkKhachhang khachhang, PttkDatphong datphong, DateTime? NgayThanhToan)
        {
            List<ModifiedItem> modifiedList = new List<ModifiedItem>();
            _nhanvien = new PttkNhanvien();
            _khachhang = new PttkKhachhang();
            _datphong = new PttkDatphong();
            _litsDpDV = new List<PttkDatphongDichvu>();

            InitializeComponent();
            _nhanvien = nhanvien;
            _khachhang = khachhang;
            _datphong = datphong;
            
            _litsDpDV = datphongDichvuBUS.GetAllbyOrderID(_datphong.Id);

            foreach (var item in _litsDpDV)
            {
                string name;
                int price = 0;
                
                item.Service = dichvuBUS.GetByID(item.ServiceId);

                price = Convert.ToInt16(item.Service.Price);
                name = item.Service.Name;
                var modifiedItem = new ModifiedItem
                {
                    pttkDatphongDichvu = item,
                    Name = name,
                    Price = price,
                   
                };
                modifiedList.Add(modifiedItem);
            }
            lvDichVuDaSD.ItemsSource = modifiedList;

            txbSoPhong.Text = _datphong.Id.ToString();
            txbTenKH.Text = _khachhang.Name;
            txbNhanVien.Text = _nhanvien.Name;

            // lấy ngày hiện tại trên hệ thống
            txbNgaylap.Text = NgayThanhToan.ToString();

             totalPrice = (int)_litsDpDV.Sum(x => x.TotalPrice);
             txbTongTien.Text = totalPrice.ToString();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
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
    }

    public class ModifiedItem
    {
        public PttkDatphongDichvu pttkDatphongDichvu { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}

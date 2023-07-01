using BUS;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Add_ThietBi_Phong_Window.xaml
    /// </summary>
    public partial class Add_ThietBi_Phong_Window : Window
    {
        public Add_ThietBi_Phong_Window()
        {
            InitializeComponent();
            LoadAddThietBiPhong();
        }
        public void LoadAddThietBiPhong()
        {
            PhongBUS phong=new PhongBUS();
            List<PttkPhong> room_list=new List<PttkPhong>();
            room_list=phong.GetAll();

            ThietbiBUS thietbi=new ThietbiBUS();
            List<PttkThietbi> thietbi_list=new List<PttkThietbi>();

            thietbi_list=thietbi.GetAll();  

            cbPhong.ItemsSource = room_list;
           

            cbThietBi.ItemsSource = thietbi_list;

        }
        private void btn_Add(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbtinhtrang = (ComboBoxItem)cbTinhTrang.SelectedItem;

            if(cbtinhtrang != null && cbPhong.SelectedValue != null && cbThietBi.SelectedValue != null && textSoThietBi.Text != null)
            {
                string? id_phong = cbPhong.SelectedValue.ToString();
                string? id_thietbi = cbThietBi.SelectedValue.ToString();

                string soluong = textSoThietBi.Text.ToString();
                string? tinhtrang = cbtinhtrang.Content.ToString();
                PttkThietbiPhong thietbiphong=new PttkThietbiPhong();
                thietbiphong.Tinhtrang = tinhtrang;
                thietbiphong.EquipmentId = decimal.Parse(id_thietbi);
                thietbiphong.RoomId = decimal.Parse(id_phong);
                thietbiphong.Amount = decimal.Parse(soluong);

                ThietbiPhongBUS thietbiphong_bus=new ThietbiPhongBUS();
                thietbiphong_bus.Add(thietbiphong);

                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }

        }
        public void btn_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();   
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
    }
}

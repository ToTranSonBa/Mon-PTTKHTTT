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
    /// Interaction logic for UpdateStatus_ThietBi_Phong_Window.xaml
    /// </summary>
    public partial class UpdateStatus_ThietBi_Phong_Window : Window
    {
        public PttkThietbiPhong equip_room_object { get; set; }
        public UpdateStatus_ThietBi_Phong_Window(PttkThietbiPhong tb_ph_object)
        {
            InitializeComponent();
            equip_room_object = tb_ph_object;
            LoadStatus(tb_ph_object);
        }
        private void LoadStatus(PttkThietbiPhong tb_ph_object)
        {
            DataContext = tb_ph_object;
            
        }

        private void btn_Update(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbtinhtrang = (ComboBoxItem)cbTinhTrang.SelectedItem;
            if (cbtinhtrang != null && equip_room_object!=null && textSoThietBi.Text != null)
            {
                string soluong = textSoThietBi.Text.ToString();
                string? tinhtrang = cbtinhtrang.Content.ToString();
               
                equip_room_object.Tinhtrang = tinhtrang;
                equip_room_object.Amount = decimal.Parse(soluong);
                

                ThietbiPhongBUS thietbi_ph_bus = new ThietbiPhongBUS();
                thietbi_ph_bus.Update(equip_room_object);
                

                MessageBox.Show("Cập nhật thành công");
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

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
    /// Interaction logic for Add_ThietBi_Window.xaml
    /// </summary>
    public partial class Add_ThietBi_Window : Window
    {
        public Add_ThietBi_Window()
        {
            InitializeComponent();
        }

        private void btn_Add(object sender, RoutedEventArgs e)
        {

            if (textName.Text != null)
            {

                string name = textName.Text.ToString();
                PttkThietbi thietbi = new PttkThietbi();
                thietbi.Name = name;

                ThietbiBUS thietbi_bus = new ThietbiBUS();
                thietbi_bus.Add(thietbi);

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

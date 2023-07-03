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
    /// Interaction logic for Add_Service_Window.xaml
    /// </summary>
    public partial class Add_Service_Window : Window
    {
        public Add_Service_Window()
        {
            InitializeComponent();
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

        private void btn_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_insert(object sender, RoutedEventArgs e)
        {
            if (tendichvutxt.Text != "" && giadichvutxt.Text != "" && motatxt.Text != "")
            {
                PttkDichvu pttkdichvu = new PttkDichvu();
                pttkdichvu.Name = tendichvutxt.Text.ToString();
                string giadichvu = giadichvutxt.Text.ToString();
                pttkdichvu.Price = decimal.Parse(giadichvu);
                pttkdichvu.Decsription = motatxt.Text.ToString();

                DichvuBUS dichvubus = new DichvuBUS();
                dichvubus.Add(pttkdichvu);
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ !");

            }
        }
    }
}

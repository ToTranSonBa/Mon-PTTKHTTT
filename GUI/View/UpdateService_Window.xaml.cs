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
    /// Interaction logic for UpdateService_Window.xaml
    /// </summary>
    public partial class UpdateService_Window : Window
    {
        public PttkDichvu _updatedichvu;
        public UpdateService_Window(PttkDichvu dichvu)
        {
            _updatedichvu = dichvu;
            InitializeComponent();
        }

        private void btn_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_update(object sender, RoutedEventArgs e)
        {
            if (tendichvutxt.Text != "" && giadichvutxt.Text != "")
            {
                string giadichvu = giadichvutxt.Text.ToString();
                _updatedichvu.Price = decimal.Parse(giadichvu);
                _updatedichvu.Name = tendichvutxt.Text.ToString();

                DichvuBUS dichvuBus = new DichvuBUS();
                dichvuBus.Update(_updatedichvu);
                MessageBox.Show("chỉnh sửa thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ !");

            }
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

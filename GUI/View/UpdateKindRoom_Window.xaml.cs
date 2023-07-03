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
    /// Interaction logic for UpdateKindRoom_Window.xaml
    /// </summary>
    public partial class UpdateKindRoom_Window : Window
    {
        public PttkLoaiphong _updateloaiphong;
        public UpdateKindRoom_Window(PttkLoaiphong loaiphong)
        {
            _updateloaiphong = loaiphong;
            InitializeComponent();
        }

        private void btn_update(object sender, RoutedEventArgs e)
        {

            if (tenloaiphongtxt.Text != "" && gialoaiphongtxt.Text !="")
            {
                string giaphong = gialoaiphongtxt.Text.ToString();
                _updateloaiphong.Price =decimal.Parse(giaphong);
                _updateloaiphong.Name = tenloaiphongtxt.Text.ToString();

                LoaiphongBUS loaiphongbus = new LoaiphongBUS();
                loaiphongbus.Update(_updateloaiphong);
                MessageBox.Show("chỉnh sửa thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ !");

            }
        }

        private void btn_Exit(object sender, RoutedEventArgs e)
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

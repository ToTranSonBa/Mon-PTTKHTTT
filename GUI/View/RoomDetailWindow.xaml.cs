using DTO;
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
    /// Interaction logic for RoomDetailWindow.xaml
    /// </summary>
    public partial class RoomDetailWindow : Window
    {
        private PttkPhong _roomModel { get; set; }
        public RoomDetailWindow(PttkPhong roomModel)
        {
            InitializeComponent();
            _roomModel = roomModel;
            //_roomModel = new RoomModel
            //{
            //    ID = "P102",
            //    RoomKind = "Phòng đơn",
            //    RoomRate = "100000",
            //    RoomRentStatus = RoomRentStatus.Renting,
            //    RoomCleanStatus = "Chưa dọn"
            //};
            titleRoom.Text = _roomModel.RoomNumber;
        }

        private void click_ThemDV(object sender, RoutedEventArgs e)
        {
            var addServiceWindow = new AddService_Window();
            addServiceWindow.Show();
        }
        
        private void cbDonDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý sự kiện khi lựa chọn trong ComboBox thay đổi
            // Thực hiện các thao tác cần thiết
        }

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
    }
}

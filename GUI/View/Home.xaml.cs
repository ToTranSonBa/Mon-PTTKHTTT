 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GUI.ClassForViews;
using GUI.View.MenuController;
using DTO;
using System.Xml;
using DTO.Models;
using BUS;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        #region Define variable
        public List<ItemMenuMainWindow> listMenu { get; set; }
        public readonly int CapDoQuyen = 1;
        public readonly PttkNhanvien _employee;
        #endregion
        #region Init Function
        public Home(PttkNhanvien emp)
        {
            _employee = emp;
            InitializeComponent();
            initListViewMenu();
            nameTitle.Content = _employee.Name;
        }
        private void initListViewMenu()
        {
            listMenu = new List<ItemMenuMainWindow>();
            //Khoi tao Menu
            if (CapDoQuyen == 1)
            {
                listMenu.Add(new ItemMenuMainWindow() { name = "Trang Chủ", foreColor = "Gray", kind_Icon = "Home" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Phòng", foreColor = "#FFF08033", kind_Icon = "HomeCity" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Đặt Phòng", foreColor = "Green", kind_Icon = "BookAccount" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Hóa đơn", foreColor = "#FFD41515", kind_Icon = "Receipt" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL nhân Viên", foreColor = "#FFD41515", kind_Icon = "Account" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL khách hàng", foreColor = "#FFD41515", kind_Icon = "Account" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL phòng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL loại phòng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL dịch vụ", foreColor = "Blue", kind_Icon = "FaceAgent" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL loại dịch vụ", foreColor = "Blue", kind_Icon = "FaceAgent" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL tiện nghi", foreColor = "#FFF08033", kind_Icon = "Fridge" });
                listMenu.Add(new ItemMenuMainWindow() { name = "QL chi tiết tiện nghi", foreColor = "#FFF08033", kind_Icon = "Fridge" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Thống kê", foreColor = "#FF0069C1", kind_Icon = "ChartAreaspline" });
            }
            else if (CapDoQuyen == 2)
            {
                listMenu.Add(new ItemMenuMainWindow() { name = "Trang Chủ", foreColor = "Gray", kind_Icon = "Home" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Phòng", foreColor = "#FFF08033", kind_Icon = "HomeCity" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Đặt Phòng", foreColor = "Green", kind_Icon = "BookAccount" });
                listMenu.Add(new ItemMenuMainWindow() { name = "Hóa đơn", foreColor = "#FFD41515", kind_Icon = "Receipt" });
            }
            lisviewMenu.ItemsSource = listMenu;
            lisviewMenu.SelectedValuePath = "name";
        }
        #endregion

        #region Event

        private void btnVisibleMenuBar_Click(object sender, RoutedEventArgs e)
        {
            menuBar.Visibility = Visibility.Visible;
            initListViewMenu();
        }

        private void btnHidenMenuBar_Click(object sender, RoutedEventArgs e)
        {
            menuBar.Visibility = Visibility.Hidden;
        }
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ControlMainDisplayContentHandler(object sender, MouseButtonEventArgs e)
        {
            if (lisviewMenu.SelectedValue != null)
            {
                switch (lisviewMenu.SelectedIndex)
                {
                    case 0:
                        contentDisplayMain.Content = new HomeView();
                        break;
                    case 1:
                        contentDisplayMain.Content = new RoomView(_employee);
                        break;
                    case 2:
                        contentDisplayMain.Content = new ReservationView();
                        break;
                    case 3:
                        // hoadon
                        contentDisplayMain.Content = new PaymentBillView();
                        break;
                    case 4:
                        contentDisplayMain.Content = new EmployeeManagementView();
                        break;
                    case 5:
                        contentDisplayMain.Content = new CustomerManagementView();
                        break;
                    case 6:
                        contentDisplayMain.Content = new RoomManagementView();
                        break;
                    case 7:
                        contentDisplayMain.Content = new KindRoomManagementView();
                        break;
                    case 8:
                        contentDisplayMain.Content = new ServiceManagementView();
                        break;
                    case 9:
                        contentDisplayMain.Content = new KindServiceManagementView();
                        break;
                    case 10:
                        contentDisplayMain.Content = new EquipmentManagementView();
                        break;
                    case 11:
                        contentDisplayMain.Content = new EquipmentManagerKindView();
                        break;
                }
                btnHidenMenuBar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        #endregion



    }
}

using BUS;
using DTO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for PaymentBillView.xaml
    /// </summary>
    public partial class EmployeeManagementView : UserControl
    {
        public EmployeeManagementView()
        {
            InitializeComponent();
            NhanvienBUS nhanvienBUS = new NhanvienBUS();
            employeeListView.ItemsSource = nhanvienBUS.GetAll();

        }
        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {

        }
        private void click_Delete(object sender, RoutedEventArgs e)
        {

        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fromTime = fromTimePicker.SelectedDate;
            DateTime? toTime = toTimePicker.SelectedDate;

        }
        #endregion
    }
}

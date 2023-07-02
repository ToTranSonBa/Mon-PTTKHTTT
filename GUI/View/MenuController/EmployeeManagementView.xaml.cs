using BUS;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
            employeeListView.ItemsSource = nhanvienBUS.GetAll().Where(t => t != null);

        }
        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {

        }
        private void click_Delete(object sender, RoutedEventArgs e)
        {
            PttkNhanvien n_emp = new();
            n_emp.Name = employeeListView.SelectedItem.ToString();
            if (n_emp != null)
            {
                NhanvienBUS nhanvienBUS = new NhanvienBUS();
                bool flag = nhanvienBUS.Remove(n_emp);
                if (flag)
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Fail!!!");
                }
            }
            else
            {
                MessageBox.Show("empty!!!");
            }

        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
         //DateTime? fromTime = fromTimePicker.SelectedDate;
        // DateTime? toTime = toTimePicker.SelectedDate;
            string? fromSearch = SearchTextBox.Text;
            if(fromSearch==null)
            {
                //if(employeeListView.SelectedItems != null)
                //{

                //}    
            }

        }
        private void click_Add(object sender, RoutedEventArgs e)
        {
            var addEmp_wc = new AddEmp_Window();
            addEmp_wc.ShowDialog();
        }
        #endregion
    }
}

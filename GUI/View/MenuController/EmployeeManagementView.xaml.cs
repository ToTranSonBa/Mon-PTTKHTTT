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
            load_cr();


        }
        #region Button Event
        private void click_Update(object sender, RoutedEventArgs e)
        {
            PttkNhanvien n_emp = new();
            n_emp = (PttkNhanvien)employeeListView.SelectedItem;
            n_emp.FireDay = DateTime.Now;
            Update_Emp_Window wd = new Update_Emp_Window(n_emp.Id);
            wd.ShowDialog();
            load_cr();
        }
        public void load_cr()
        {
            NhanvienBUS nhanvienBUS = new NhanvienBUS();
            employeeListView.ItemsSource = nhanvienBUS.GetAll().Where(t => t.FireDay == null);
        }
        private void click_Delete(object sender, RoutedEventArgs e)
        {
            PttkNhanvien n_emp = new();
            n_emp = (PttkNhanvien)employeeListView.SelectedItem;
            n_emp.FireDay = DateTime.Now;
            TaikhoanBUS taikhoanBUS = new TaikhoanBUS();
            PttkTaikhoan pttkTaikhoan = new();
            pttkTaikhoan = taikhoanBUS.GetByIDemploy(n_emp.Id);

            NhanvienBUS nhanvienBUS = new NhanvienBUS();
            bool flag = nhanvienBUS.Update(n_emp);
            taikhoanBUS.Remove(pttkTaikhoan);
            if (flag)
            {
                load_cr();
            }
            else
            {
                MessageBox.Show("Fail!!!");
            }
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }
        private void click_Add(object sender, RoutedEventArgs e)
        {
            var addEmp_wc = new AddEmp_Window();
            addEmp_wc.ShowDialog();
            load_cr();
        }

        #endregion
    }
}

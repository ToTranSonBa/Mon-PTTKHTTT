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
    /// Interaction logic for Update_Emp_Window.xaml
    /// </summary>
    public partial class Update_Emp_Window : Window
    {
        public decimal? id_global { get; set; }
        public Update_Emp_Window(decimal? ID)
        {
            InitializeComponent();
            LoadEmployDetail(ID);
            id_global= ID;
        }
        public void LoadEmployDetail(decimal? ID)
        {
            PttkNhanvien pttkNhanvien = new PttkNhanvien();
            NhanvienBUS nv_bus=new NhanvienBUS();

            pttkNhanvien = nv_bus.GetByID(ID);
            DataContext = pttkNhanvien;
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
        private void click_BtnExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void click_saveEmp(object sender, RoutedEventArgs e)
        {
            PttkNhanvien n_emp = new PttkNhanvien();
            n_emp.Name = empName.Text;
            n_emp.Sex = empSex.Text;
            n_emp.Birthday = empBD.SelectedDate;
            n_emp.HireDay = empHD.SelectedDate;
            n_emp.Address = empAddress.Text;
            n_emp.NumberPhone = empPhone.Text;
            n_emp.IdentifiedCard = empCCCD.Text;
            n_emp.Kind = empRole.Text;
            n_emp.Id =(decimal)id_global;
            NhanvienBUS nhanvienBUS = new();
            try
            {
                nhanvienBUS.Update(n_emp);
                MessageBox.Show(empBD.SelectedDate.ToString());
                this.Close();
            }
            catch
            {
                MessageBox.Show("fail");
            }
        }
        private void empName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //
        }
    }
}

using DTO;
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
    /// Interaction logic for AddEmp_Window.xaml
    /// </summary>
    public partial class AddEmp_Window : Window
    {
        public AddEmp_Window()
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
            n_emp.Address = empAddress.Text;
            n_emp.NumberPhone = empPhone.Text;
            n_emp.IdentifiedCard = empCCCD.Text;
            n_emp.Kind = empRole.Text;
            NhanvienBUS nhanvienBUS = new();
            bool flag = nhanvienBUS.Add(n_emp);
            if (flag == true)
            {
                MessageBox.Show("Successful");
                this.Close();
            }
                
            else
            {
                MessageBox.Show("Fail");
            }


        }

        private void empName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
   
}

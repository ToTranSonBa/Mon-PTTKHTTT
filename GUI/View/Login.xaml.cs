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
using DTO;
using BUS;
using static System.Net.Mime.MediaTypeNames;
using DTO.Models;
using DAL;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = NameTextBox.Text;
            if (username == null || PasswordBox.Password == null)
            {
                MessageBox.Show("Không được để trống tài khoản hoặc mậu khẩu!");
            }
            else
            {
                TaikhoanBUS acc = new TaikhoanBUS();
                var Acc = acc.GetByUsernamePassword(username, PasswordBox.Password);
                if (Acc != null || Acc.EmployeeId != 0 )
                {
                    NhanvienBUS nhanvienBUS = new NhanvienBUS();
                    var Emp = nhanvienBUS.GetByID(Acc.EmployeeId);
                    if (Emp.Id != 0)
                    {
                        var mainWindow = new Home(Emp);
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên không tồn tại!");
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            } 
        }
    }
}

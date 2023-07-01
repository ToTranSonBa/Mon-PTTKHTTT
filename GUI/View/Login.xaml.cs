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

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly LoginBLL _login;
        public Login()
        {
            _login = new LoginBLL();
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
                PttkNhanvienDTO Emp = _login.LoginHandler(username, PasswordBox.Password);
                if (Emp != null)
                {
<<<<<<< Updated upstream
                    var mainWindow = new Home(Emp);
                    mainWindow.Show();
                    this.Close();
=======
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
>>>>>>> Stashed changes
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            } 
        }
    }
}

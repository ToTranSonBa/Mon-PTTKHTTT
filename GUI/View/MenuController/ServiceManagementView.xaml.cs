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
using BUS;
using DTO;
using DTO.Models;

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for ServiceManagementView.xaml
    /// </summary>
    public partial class ServiceManagementView : UserControl
    {
        private readonly DichvuBUS _services;
        public ServiceManagementView()
        {
            _services = new DichvuBUS();
            InitializeComponent();
            serviceListView.ItemsSource = _services.GetAll();
        }
        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {
            PttkDichvu updateDichVu = new PttkDichvu();
            updateDichVu = (PttkDichvu)serviceListView.SelectedItem;
            UpdateService_Window updateKindRoom_Window = new UpdateService_Window(updateDichVu);
            updateKindRoom_Window.ShowDialog();
            serviceListView.ItemsSource = _services.GetAll();

        }

        private void click_Delete(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Search Event
        private void Search_Click(object sender, RoutedEventArgs e)
        {
        }
        #endregion


        private void addService_Click(object sender, RoutedEventArgs e)
        {
            Add_Service_Window addServiceWindow = new Add_Service_Window();
            addServiceWindow.ShowDialog();
            serviceListView.ItemsSource = _services.GetAll();

        }
    }
}

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
using DAL;
using DTO;
using DTO.Models;

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for EquipmentManagementView.xaml
    /// </summary>
    public partial class EquipmentManagementView : UserControl
    {
        private List<PttkThietbiPhong> _equipment { get; set; }
        private readonly ThietbiPhongBUS _ThietbiPhongBUS;
        public EquipmentManagementView()
        {
            InitializeComponent();
            _ThietbiPhongBUS = new ThietbiPhongBUS();
            _equipment = _ThietbiPhongBUS.GetAll();
            equipmentListView.ItemsSource = _equipment;
        }
        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {

        }

        private void click_Delete(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Search Event
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var textSearch = SearchTextBox.Text;
            equipmentListView.ItemsSource = _equipment;
            if (textSearch != null)
            {
            }
        }
        #endregion
    }
}

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
    /// Interaction logic for EquipmentManagementView.xaml
    /// </summary>
    public partial class EquipmentManagementView : UserControl
    {
        private List<PttkThietbiPhongDTO> _equipment { get; set; }
        private readonly Room_EquipmentBLL _room_EquipmentBLL;
        public EquipmentManagementView()
        {
            InitializeComponent();
            _room_EquipmentBLL = new Room_EquipmentBLL();
            _equipment = _room_EquipmentBLL.GetAll();
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

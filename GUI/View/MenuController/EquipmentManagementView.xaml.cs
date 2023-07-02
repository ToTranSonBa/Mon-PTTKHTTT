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
        private List<PttkThietbiPhong> _equipment { get; set; }
        private readonly ThietbiPhongBUS _room_EquipmentBLL;
        public EquipmentManagementView()
        {
            InitializeComponent();
            _room_EquipmentBLL = new ThietbiPhongBUS();
            _equipment = _room_EquipmentBLL.GetAll();
            equipmentListView.ItemsSource = _equipment;
        }
        public void LoadEquipmentManagement()
        {
            ThietbiPhongBUS _room_EquipmentBLL = new ThietbiPhongBUS();

            ThietbiBUS equiment = new ThietbiBUS();
            PhongBUS room = new PhongBUS();

            List<PttkThietbiPhong> room_equipment = new List<PttkThietbiPhong>();
            room_equipment = _room_EquipmentBLL.GetAll();

            foreach (var equip in room_equipment)
            {
                equip.Equipment = equiment.GetByID(equip.EquipmentId);
                equip.Room = room.GetByID(equip.RoomId);
            }
            equipmentListView.ItemsSource = room_equipment;
        }
        #region Button Event
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void btn_Delete(object sender, RoutedEventArgs e)
        {
            PttkThietbiPhong equip_room_object = new PttkThietbiPhong();
            equip_room_object = (PttkThietbiPhong)equipmentListView.SelectedItem;

            ThietbiPhongBUS room_equipment_bus = new ThietbiPhongBUS();
            room_equipment_bus.Remove(equip_room_object);
            LoadEquipmentManagement();
        }
        private void btn_Add(object sender, RoutedEventArgs e)
        {
            Add_ThietBi_Phong_Window add_tb_ph_window=new  Add_ThietBi_Phong_Window();
            add_tb_ph_window.ShowDialog();
            LoadEquipmentManagement();
        }
        #endregion
    }
}

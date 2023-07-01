using BUS;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for EquipmentManagerKindView.xaml
    /// </summary>
    public partial class EquipmentManagerKindView : UserControl
    {
        public class Item
        {
            public int stt { get; set; }
            public decimal? Id { get; set; }
            public string? Name { get; set; }
            public decimal? Amount { get; set; }
        }
        public EquipmentManagerKindView()
        {
            InitializeComponent();
            LoadEquipmentManagerKindView();
        }

        public void LoadEquipmentManagerKindView()
        {
            List<PttkThietbi> _equipmentKinds = new List<PttkThietbi>();
            ThietbiBUS thietbi = new ThietbiBUS();

            _equipmentKinds = thietbi.GetAll();
            ThietbiPhongBUS thietbiphong = new ThietbiPhongBUS();

            List<Item> items = new List<Item>();
            int count = 1;
            foreach (var temp in _equipmentKinds)
            {
                Item item = new Item();
                item.stt = count++;
                item.Id = temp.Id;  
                item.Name = temp.Name;
                item.Amount = thietbiphong.GetAmountofEquipment(temp.Id);
                items.Add(item);
            }
            equipmentKindListView.ItemsSource = items;

        }
        #region Button Event
        public void click_Delete(object sender, RoutedEventArgs e)
        {

            Item item=new Item();
            item = (Item)equipmentKindListView.SelectedItem;
            if(item != null )
            {
                PttkThietbi equip_object = new PttkThietbi();
                ThietbiBUS equipment_bus = new ThietbiBUS();
                equip_object = equipment_bus.GetByID(item.Id);
                equipment_bus.Remove(equip_object);
                LoadEquipmentManagerKindView();
            }
            else
            {
                MessageBox.Show("Eror!!!");
            }
            
        }
        private void btn_Add(object sender, RoutedEventArgs e)
        {
            Add_ThietBi_Window add_tb_window = new Add_ThietBi_Window();
            add_tb_window.ShowDialog();
            LoadEquipmentManagerKindView();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<PttkThietbi> _equipmentKinds = new List<PttkThietbi>();
            string textSearch = SearchTextBox.Text;
            equipmentKindListView.ItemsSource = _equipmentKinds;
            if (textSearch != null)
            {
                equipmentKindListView.ItemsSource = _equipmentKinds.Where(p => p.Name.Contains(textSearch)).ToList();
            }
        }
        #endregion
    }
}

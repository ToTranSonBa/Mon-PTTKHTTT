using DTO;
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

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for EquipmentManagerKindView.xaml
    /// </summary>
    public partial class EquipmentManagerKindView : UserControl
    {
        private List<EquipmentKindDTO> _equipmentKinds { get; set; }
        public EquipmentManagerKindView()
        {
            InitializeComponent();
            _equipmentKinds = new List<EquipmentKindDTO>();

            EquipmentKindDTO equipment1 = new EquipmentKindDTO
            {
                Id = 1,
                Name = "TV",
                Amount = "2"
            };

            EquipmentKindDTO equipment2 = new EquipmentKindDTO
            {
                Id = 2,
                Name = "Air conditioner",
                Amount = "3"
            };

            EquipmentKindDTO equipment3 = new EquipmentKindDTO
            {
                Id = 3,
                Name = "Mini fridge",
                Amount = "1"
            };

            EquipmentKindDTO equipment4 = new EquipmentKindDTO
            {
                Id = 4,
                Name = "Coffee maker",
                Amount = "2"
            };

            EquipmentKindDTO equipment5 = new EquipmentKindDTO
            {
                Id = 5,
                Name = "Safe",
                Amount = "1"
            };
            _equipmentKinds.Add(equipment1);
            _equipmentKinds.Add(equipment2);
            _equipmentKinds.Add(equipment3);
            _equipmentKinds.Add(equipment4);
            _equipmentKinds.Add(equipment5);
            equipmentKindListView.ItemsSource = _equipmentKinds;
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

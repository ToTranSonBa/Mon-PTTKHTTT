using DTO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for EquipmentManagerKindView.xaml
    /// </summary>
    public partial class EquipmentManagerKindView : UserControl
    {
        private List<PttkThietbiPhong> _equipmentKinds { get; set; }
        public EquipmentManagerKindView()
        {
            InitializeComponent();
            _equipmentKinds = new List<PttkThietbiPhong>();
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

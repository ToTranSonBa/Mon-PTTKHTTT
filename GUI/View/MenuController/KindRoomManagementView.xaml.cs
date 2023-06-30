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

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for KindRoomManagementView.xaml
    /// </summary>
    public partial class KindRoomManagementView : UserControl
    {
        private List<KindRoomManagementView> kindRoomManagements { get; set; }
        private readonly KindRoomBLL _kindRoomBLL;
        public KindRoomManagementView()
        {
            _kindRoomBLL = new KindRoomBLL();
            InitializeComponent();
            equipmentKindListView.ItemsSource = _kindRoomBLL.GetAll();
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
            equipmentKindListView.ItemsSource = kindRoomManagements;
            if (textSearch != null)
            {
                equipmentKindListView.ItemsSource = kindRoomManagements.Where(p => p.Name.Contains(textSearch)).ToList();
            }
        }
        #endregion
    }
}

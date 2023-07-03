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
    /// Interaction logic for KindRoomManagementView.xaml
    /// </summary>
    public partial class KindRoomManagementView : UserControl
    {
        private List<KindRoomManagementView> kindRoomManagements { get; set; }
        private readonly LoaiphongBUS _kindRoomBLL;
        public KindRoomManagementView()
        {
            _kindRoomBLL = new LoaiphongBUS();
            InitializeComponent();
            loadLoaiPhong();
        }

        public void loadLoaiPhong()
        {
            equipmentKindListView.ItemsSource = _kindRoomBLL.GetAll();
        }


        #region Button Event

        private void click_Update(object sender, RoutedEventArgs e)
        {
            PttkLoaiphong updateLoaiPhong = new PttkLoaiphong();
            updateLoaiPhong = (PttkLoaiphong)equipmentKindListView.SelectedItem;
            UpdateKindRoom_Window updateKindRoom_Window =   new UpdateKindRoom_Window(updateLoaiPhong);
            updateKindRoom_Window.ShowDialog();
            loadLoaiPhong();
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

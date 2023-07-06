using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO.Models;
using BUS;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : UserControl
    {
        class pttkphongImage {
            public PttkPhong phong { get; set; }
            public string imagesSource { get; set; }
            public string kindsroom { get; set; }
        }

        PttkLoaiphong loaiphong { get; set; }  
        private LoaiphongBUS  loaiphongBUS= new LoaiphongBUS();
        private PhongBUS PhongBUS { get; set; } = new PhongBUS();
        private PttkNhanvien _nhanvien { get; set; }

        public RoomView(PttkNhanvien nhanvien)
        {
            _nhanvien = nhanvien;
            InitializeComponent();
            listRoomSingle.PreviewMouseLeftButtonUp += Card_MouseDoubleClick;
            
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string guiPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(baseDir))));

            string finalImagePath = System.IO.Path.Combine(guiPath, "Res", "Phongdon.jpg");

            ImageBrush enabledBackground = new ImageBrush(new BitmapImage(new Uri(finalImagePath)));
            var listPhong = new List<pttkphongImage>();
            foreach(var item in PhongBUS.GetAll())
            {

                listPhong.Add(new pttkphongImage
                {
                    phong = item,
                    imagesSource = finalImagePath,
                    kindsroom = loaiphongBUS.GetByID(item.Kind).Name.ToString()
                }) ;
            }

            listRoomSingle.ItemsSource = listPhong;

        }
        private void PresetTimePicker_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {

        }
        private void lvPhongDon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var obj = listRoomSingle.SelectedItem as pttkphongImage;
            var roomDetail = obj.phong;
            if (roomDetail != null)
            {
                var roomDetailsWindow = new RoomDetailWindow(roomDetail, _nhanvien);
                roomDetailsWindow.ShowDialog();
            }
        }
    }
}


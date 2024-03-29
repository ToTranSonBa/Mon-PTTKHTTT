﻿using System.Collections.Generic;
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
using DAL.Models;

namespace GUI.View.MenuController
{
    /// <summary>
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : UserControl
    {
        private List<PttkPhong> listRoom = new List<PttkPhong>();
        public RoomView()
        {
            InitializeComponent();
            listRoomSingle.PreviewMouseLeftButtonUp += Card_MouseDoubleClick;
           
            listRoomSingle.ItemsSource = listRoom;

        }
        private void PresetTimePicker_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {

        }
        private void lvPhongDon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PttkPhong roomDetail = (PttkPhong)listRoomSingle.SelectedItem;
            if (roomDetail != null)
            {
                var roomDetailsWindow = new RoomDetailWindow();
                roomDetailsWindow.Show();
            }
        }
    }
}


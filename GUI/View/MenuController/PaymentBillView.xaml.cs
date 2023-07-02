using DTO;
using PTTKHTTT.View;
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
    /// Interaction logic for PaymentBillView.xaml
    /// </summary>
    public partial class PaymentBillView : UserControl
    {
        //private List<> _listPayment { get; set; }
        public PaymentBillView()
        {
            InitializeComponent();
            //_listPayment = new List<>();
            
            //equipmentListView.ItemsSource = _listPayment;
        }
        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {
            //BillDetail_Window billDetail_Window = new BillDetail_Window();
            //if(billDetail_Window != null)
            //{
            //    billDetail_Window.ShowDialog();
            //}    
        }
        private void click_Delete(object sender, RoutedEventArgs e)
        {

        }
        //private void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    DateTime? fromTime = fromTimePicker.SelectedDate;
        //    DateTime? toTime = toTimePicker.SelectedDate;

        //    equipmentListView.ItemsSource = _listPayment;
        //    if (fromTime.HasValue && toTime.HasValue)
        //    {
        //        equipmentListView.ItemsSource = _listPayment.Where(p => fromTime <= p.InvoiceDate && p.InvoiceDate <= toTime).ToList();
        //    }
        //    else
        //    {
        //        List<PaymentBillDTO> list = _listPayment.ToList();
        //        if (fromTime.HasValue)
        //        {
        //            list = _listPayment.Where(p => p.InvoiceDate.CompareTo(fromTime) > 0).ToList();
        //        }
        //        if (toTime.HasValue)
        //        {
        //            list = _listPayment.Where(p => p.InvoiceDate.CompareTo(fromTime) < 0).ToList();
        //        }
        //        equipmentListView.ItemsSource = list;
        //    }
        //}
        #endregion

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

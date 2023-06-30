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
    /// Interaction logic for PaymentBillView.xaml
    /// </summary>
    public partial class PaymentBillView : UserControl
    {
        private List<PaymentBillDTO> _listPayment { get; set; }
        public PaymentBillView()
        {
            InitializeComponent();
            _listPayment = new List<PaymentBillDTO>();
            PaymentBillDTO paymentBill1 = new PaymentBillDTO()
            {
                Id = 1,
                InvoiceDate = DateTime.Now,
                TotalAmount = 100.50,
                PersonnelID = 1,
                PersonnelName = "John Doe",
                OrderId = 12345,
                InvoiceDetailNumber = 1
            };
            PaymentBillDTO paymentBill2 = new PaymentBillDTO()
            {
                Id = 2,
                InvoiceDate = DateTime.Now.AddDays(1),
                TotalAmount = 200.75,
                PersonnelID = 2,
                PersonnelName = "Jane Smith",
                OrderId = 54321,
                InvoiceDetailNumber = 2
            };
            PaymentBillDTO paymentBill3 = new PaymentBillDTO()
            {
                Id = 3,
                InvoiceDate = DateTime.Now.AddDays(2),
                TotalAmount = 300.90,
                PersonnelID = 3,
                PersonnelName = "Alice Johnson",
                OrderId = 98765,
                InvoiceDetailNumber = 3
            };
            PaymentBillDTO paymentBill4 = new PaymentBillDTO()
            {
                Id = 4,
                InvoiceDate = DateTime.Now.AddDays(3),
                TotalAmount = 400.25,
                PersonnelID = 4,
                PersonnelName = "Bob Williams",
                OrderId = 24680,
                InvoiceDetailNumber = 4
            };
            PaymentBillDTO paymentBill5 = new PaymentBillDTO()
            {
                Id = 5,
                InvoiceDate = DateTime.Now.AddDays(4),
                TotalAmount = 500.50,
                PersonnelID = 5,
                PersonnelName = "Eva Davis",
                OrderId = 13579,
                InvoiceDetailNumber = 5
            };
            _listPayment.Add(paymentBill1);
            _listPayment.Add(paymentBill2);
            _listPayment.Add(paymentBill3);
            _listPayment.Add(paymentBill4);
            _listPayment.Add(paymentBill5);
            equipmentListView.ItemsSource = _listPayment;
        }
        #region Button Event
        private void click_Detail(object sender, RoutedEventArgs e)
        {

        }
        private void click_Delete(object sender, RoutedEventArgs e)
        {

        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fromTime = fromTimePicker.SelectedDate;
            DateTime? toTime = toTimePicker.SelectedDate;

            equipmentListView.ItemsSource = _listPayment;
            if (fromTime.HasValue && toTime.HasValue)
            {
                equipmentListView.ItemsSource = _listPayment.Where(p => fromTime <= p.InvoiceDate && p.InvoiceDate <= toTime).ToList();
            }
            else
            {
                List<PaymentBillDTO> list = _listPayment.ToList();
                if (fromTime.HasValue)
                {
                    list = _listPayment.Where(p => p.InvoiceDate.CompareTo(fromTime) > 0).ToList();
                }
                if (toTime.HasValue)
                {
                    list = _listPayment.Where(p => p.InvoiceDate.CompareTo(fromTime) < 0).ToList();
                }
                equipmentListView.ItemsSource = list;
            }
        }
        #endregion
    }
}

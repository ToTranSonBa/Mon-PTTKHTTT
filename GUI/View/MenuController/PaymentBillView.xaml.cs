using BUS;
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
    /// Interaction logic for PaymentBillView.xaml
    /// </summary>
    public partial class PaymentBillView : UserControl
    {
        List<PttkDatphong> _listDatphong { get; set; }
        List<PttkDatphongDichvu> _listDatphongDichvus { get; set; }

        DatphongBUS datphongBUS = new DatphongBUS();
        NhanvienBUS nhanvienBUS = new NhanvienBUS();
        DatphongDichvuBUS datphongDichvuBUS = new DatphongDichvuBUS();
        DichvuBUS dichvuBUS = new DichvuBUS();

        public class ModifiedItem
        {
            public PttkDatphong PttkDatphong { get; set; }
            public int TotalPrice { get; set; }
            public int BillNum { get; set; }
        }

        public PaymentBillView()
        {
            List<ModifiedItem> modifiedList = new List<ModifiedItem>();
            
            InitializeComponent();
            _listDatphong = datphongBUS.getAllPaidRoom();
            foreach (var item in _listDatphong)
            {
                 
                int price = 0;
                int sophieu = 0;
                item.Employee = nhanvienBUS.GetByID(item.EmployeeId);
                _listDatphongDichvus = datphongDichvuBUS.GetAllbyOrderID(item.Id);

                foreach (var dapphongDV in _listDatphongDichvus)
                {
                    sophieu += Convert.ToInt16(dapphongDV.Quantity);
                    price += Convert.ToInt16(dapphongDV.TotalPrice);
                }
                var modifiedItem = new ModifiedItem
                {
                    PttkDatphong = item,
                    TotalPrice = price,
                    BillNum = sophieu,
                };
                if (modifiedItem != null)
                {
                     modifiedList.Add(modifiedItem);
                }    
            }
            GridListBill.ItemsSource = modifiedList.Where(t => t != null);
        }
        #region Button Event

        private void click_Detail(object sender, RoutedEventArgs e)
        {
            ModifiedItem selectedModifiedItem = (ModifiedItem)GridListBill.SelectedValue;
            PttkDatphong _datPhong = selectedModifiedItem.PttkDatphong;
            PttkNhanvien nhanvien;
            PttkKhachhang khachhang;

            KhachhangBUS khachhangBUS = new KhachhangBUS();
            nhanvien = nhanvienBUS.GetByID(_datPhong.EmployeeId);
            khachhang = khachhangBUS.GetByID(_datPhong.CustomerId);

            BillPaidDetail_Window billDetail_Window = new BillPaidDetail_Window(nhanvien , khachhang, _datPhong, _datPhong.NgayThanhToan);
            if (billDetail_Window != null)
            {
                billDetail_Window.ShowDialog();
            }
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

using Cuoi.Models;
using Cuoi.Modelsss;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cuoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        QlbanHangContext db = new QlbanHangContext();

        public void View()
        {
            var x = from sp in db.SanPhams
                    join lsp in db.LoaiSanPhams
                    on sp.MaLoai equals lsp.MaLoai
                    select new
                    {
                        sp.MaSp,
                        sp.TenSp,
                        sp.SoLuong,
                        lsp.TenLoai,
                    };
            dataGrid.ItemsSource = x.ToList();
        }

      
        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            View();
        }

        private void Them(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(maSachtxt.Text))
            {
                MessageBox.Show("ban chua nhap ma", "thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tenSachtxt.Text))
            {
                MessageBox.Show("ban chua nhap ten ", "thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(soLuongtxt.Text))
            {
                MessageBox.Show("ban chua nhap so luong", "thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(maNXBtxt.Text))
            {
                MessageBox.Show("ban chua nhap ma NXB", "thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SanPham sp = new SanPham()
            {
                MaSp = maSachtxt.Text,
                TenSp = tenSachtxt.Text,
                SoLuong = int.Parse(soLuongtxt.Text),
                MaLoai = maNXBtxt.Text,

            };

            db.SanPhams.Add(sp);
            db.SaveChanges();
            View();
        }

        private void Xoa(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Ban co muon xoa khong", "xac nhan xoa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                var x = db.SanPhams.FirstOrDefault(sp => sp.MaSp == maSachtxt.Text);
                db.SanPhams.Remove(x);
                db.SaveChanges();
                View();
            }
        }

        private void ThongKe(object sender, RoutedEventArgs e)
        {
            var x = from sp in db.SanPhams
                    join lsp in db.LoaiSanPhams
                    on sp.MaLoai equals lsp.MaLoai
                    group sp by lsp.TenLoai into g
                    select new
                    {
                        TenNXB = g.Key,
                        TongSoDauSach = g.Sum(sp => sp.SoLuong),
                    };

            Window1 window1 = new Window1();
            window1.dataGrid1.ItemsSource = x.ToList();
            window1.Show();
        }
    }
}
//using CuoiKi_1.Models_1;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace CuoiKi_1
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//        }
//        QlbanHangContext db = new QlbanHangContext();
//        public void loaddata()
//        {
//            var sanPham = from sp in db.SanPhams
//                          join lsp in db.LoaiSanPhams
//                          on sp.MaLoai equals lsp.MaLoai
//                          select new
//                          {
//                              sp.MaSp,
//                              sp.TenSp,
//                              sp.DonGia,
//                              sp.SoLuong,
//                              sp.MaLoai,
//                              TenLoaiSP = lsp.TenLoai,
//                              ThanhTien = sp.SoLuong * sp.DonGia,
//                          };
//            dataGrid.ItemsSource = sanPham.ToList();
//        }

//        public void cleartext()
//        {
//            maLoaitxt.Clear();
//            tenSPtxt.Clear();
//            soLuongtxt.Clear();
//            donGiatxt.Clear();
//            maLoaitxt.Clear();
//        }

//        private void Window_loaded(object sender, RoutedEventArgs e)
//        {
//            loaddata();

//            var queryCombo = from lsp in db.LoaiSanPhams
//                             select lsp;
//            tenloai.ItemsSource = queryCombo.ToList();
//            tenloai.DisplayMemberPath = "TenLoai"; // hiển thị tên loại trong combobox
//            tenloai.SelectedValuePath = "MaLoai"; // chọn combobox trả về mã loại tương ứng
//        }

//        private void Them(object sender, RoutedEventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(maSPtxt.Text) ||
//                string.IsNullOrWhiteSpace(tenSPtxt.Text) ||
//                string.IsNullOrWhiteSpace(soLuongtxt.Text) ||
//                string.IsNullOrWhiteSpace(donGiatxt.Text))
//            //string.IsNullOrWhiteSpace(maLoaitxt.Text))
//            {
//                MessageBox.Show("ban cua nhap het du lieu", "loi", MessageBoxButton.OK, MessageBoxImage.Error);
//                return;
//            }

//            var sanPham = new SanPham()
//            {
//                MaSp = maSPtxt.Text,
//                TenSp = tenSPtxt.Text,
//                SoLuong = int.Parse(soLuongtxt.Text),
//                DonGia = int.Parse(donGiatxt.Text),
//                //MaLoai = maLoaitxt.Text,
//                MaLoai = tenloai.SelectedValue.ToString(),

//            };

//            db.SanPhams.Add(sanPham);
//            db.SaveChanges();

//            loaddata();
//            cleartext();

//        }

//        private void Sua(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSp == maSPtxt.Text);
//                if (sanPham == null)
//                {
//                    MessageBox.Show("khong co du lieu", "loi", MessageBoxButton.OK, MessageBoxImage.Error);
//                    return;
//                }

//                if (!int.TryParse(soLuongtxt.Text, out int soLuong) || soLuong <= 0)
//                {
//                    MessageBox.Show("soLuong > 0", "loi", MessageBoxButton.OK, MessageBoxImage.Error);
//                    return;
//                }
//                if (!int.TryParse(donGiatxt.Text, out int donGia) || donGia <= 0)
//                {
//                    MessageBox.Show("donGia > 0", "loi", MessageBoxButton.OK, MessageBoxImage.Error);
//                    return;
//                }

//                sanPham.MaSp = maSPtxt.Text;
//                sanPham.TenSp = tenSPtxt.Text;
//                sanPham.SoLuong = int.Parse(soLuongtxt.Text);
//                sanPham.DonGia = int.Parse(donGiatxt.Text);
//                //sanPham.MaSp = maLoaitxt.Text;
//                sanPham.MaLoai = tenloai.SelectedValue.ToString();

//                db.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"{ex.Message}", "loi", MessageBoxButton.OK, MessageBoxImage.Error);
//            }
//            loaddata();
//            cleartext();
//        }

//        private void Xoa(object sender, RoutedEventArgs e)
//        {
//            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSp == maSPtxt.Text);

//            if (sanPham == null)
//            {
//                MessageBox.Show("khong co du lieu", "loi", MessageBoxButton.OK, MessageBoxImage.Error);
//                return;

//            }

//            var result = MessageBox.Show("ban muon xoa khong ?", "xac nhan xoa", MessageBoxButton.YesNo, MessageBoxImage.Question);

//            if (result == MessageBoxResult.Yes)
//            {
//                db.SanPhams.Remove(sanPham);
//                db.SaveChanges();
//            }


//            loaddata();
//            cleartext();
//        }

//        private void Tim(object sender, RoutedEventArgs e)
//        {
//            var x = from sp in db.SanPhams
//                    join lsp in db.LoaiSanPhams
//                    on sp.MaLoai equals lsp.MaLoai
//                    select new
//                    {
//                        sp.MaSp,
//                        sp.TenSp,
//                        lsp.TenLoai,
//                        sp.SoLuong,
//                        TienBan = sp.DonGia * sp.SoLuong,
//                    };
//            Window1 window1 = new Window1();
//            window1.dataGrid_1.ItemsSource = x.ToList();
//            window1.Show();
//        }

//        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            if (dataGrid.SelectedItem != null)
//            {
//                var x = (dynamic)dataGrid.SelectedItem;

//                maSPtxt.Text = x.MaSp;
//                tenSPtxt.Text = x.TenSp;
//                soLuongtxt.Text = x.SoLuong.ToString();
//                donGiatxt.Text = x.DonGia.ToString();
//                maLoaitxt.Text = x.MaLoai;
//            }


//        }
//    }
//}




//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//using System.Windows;

//< Style x: Key = "label" TargetType = "Label" >
//            < Setter Property = "Margin" Value = "10,0,0,0" />
//            < Setter Property = "HorizontalAlignment" Value = "Left" />
//        </ Style >

//        < Style x: Key = "textBox" TargetType = "TextBox" >
//            < Setter Property = "Height" Value = "30" />
//            < Setter Property = "Width" Value = "200" />
//            < Setter Property = "Margin" Value = "10,0,0,0" />
//            < Setter Property = "HorizontalAlignment" Value = "Left" />
//        </ Style >

//        < Style x: Key = "DataGrid" TargetType = "DataGridColumnHeader" >
//            < Setter Property = "VerticalContentAlignment" Value = "Center" />
//            < Setter Property = "HorizontalContentAlignment" Value = "Center" />


//        </ Style >

//        < Style x: Key = "button" TargetType = "Button" >
//            < Setter Property = "Margin" Value = "30,0,0,0" />
//            < Setter Property = "HorizontalAlignment" Value = "Center" />
//            < Setter Property = "VerticalAlignment" Value = "Center" />
//            < Setter Property = "Height" Value = "30" />
//            < Setter Property = "Width" Value = "50" />
//        </ Style >

//        < Style x: Key = "textBox_maSP" TargetType = "TextBox" BasedOn = "{StaticResource textBox}" >
//            < Style.Triggers >
//                < Trigger Property = "IsMouseOver" Value = "True" >
//                    < Setter Property = "Background" Value = "Blue" />
//                    < Setter Property = "Foreground" Value = "White" />
//                </ Trigger >
//            </ Style.Triggers >
//        </ Style >



//private void Them(object sender, RoutedEventArgs e)
//{
//    // Kiểm tra tuổi hợp lệ
//    int currentYear = DateTime.Now.Year;
//    int birthYear = ngaySinh.SelectedDate.Value.Year;
//    int age = currentYear - birthYear;

//    if (age < 10 || age > 15)
//    {
//        MessageBox.Show("Tuổi học sinh phải từ 10 đến 15.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
//        return;
//    }

//    // Tạo đối tượng SinhVien mới
//    var sinhVien = new SinhVien
//    {
//        MaHs = maHs.Text, // Giá trị từ TextBox maHs
//        HoTen = hoTen.Text, // Giá trị từ TextBox hoTen
//        GioiTinh = (bool)nam.IsChecked ? "Nam" : "Nữ",
//        NgaySinh = DateOnly.FromDateTime(ngaySinh.SelectedDate.Value),
//        ConThuongBinh = abc.IsChecked == true,
//        MaLopHoc = lopSelect.SelectedValue.ToString() // Giá trị từ ComboBox lopSelect
//    };

//    // Thêm vào cơ sở dữ liệu
//    db.SinhViens.Add(sinhVien);
//    db.SaveChanges();

//    // Hiển thị lại dữ liệu
//    View();
//    MessageBox.Show("Thêm học sinh thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
//}

//private void Thongke(object sender, RoutedEventArgs e)
//{
//    var thongKe = from lop in db.LoaiLopHocs
//                  select new
//                  {
//                      MaLop = lop.MaLopHoc,
//                      TenLop = lop.TenLopHoc,
//                      SoHocSinhNu = lop.SinhViens.Count(sv => sv.GioiTinh == "Nữ")
//                  };

//    dataGrid.ItemsSource = thongKe.ToList();
//}


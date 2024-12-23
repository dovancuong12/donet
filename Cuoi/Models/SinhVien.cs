using System;
using System.Collections.Generic;

namespace Cuoi.Models;

public partial class SinhVien
{
    public string MaHs { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public bool? ConThuongBinh { get; set; }

    public string? MaLopHoc { get; set; }

    public virtual LoaiLopHoc? MaLopHocNavigation { get; set; }
}

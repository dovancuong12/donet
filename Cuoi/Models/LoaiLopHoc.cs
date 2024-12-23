using System;
using System.Collections.Generic;

namespace Cuoi.Models;

public partial class LoaiLopHoc
{
    public string MaLopHoc { get; set; } = null!;

    public string? TenLopHoc { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}

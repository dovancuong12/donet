﻿using System;
using System.Collections.Generic;

namespace Cuoi.Modelsss;

public partial class LoaiSanPham
{
    public string MaLoai { get; set; } = null!;

    public string? TenLoai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}

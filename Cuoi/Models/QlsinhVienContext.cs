﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cuoi.Models;

public partial class QlsinhVienContext : DbContext
{
    public QlsinhVienContext()
    {
    }

    public QlsinhVienContext(DbContextOptions<QlsinhVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoaiLopHoc> LoaiLopHocs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DOVANCUONG;Initial Catalog=QLSinhVien;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoaiLopHoc>(entity =>
        {
            entity.HasKey(e => e.MaLopHoc).HasName("PK__LoaiLopH__FEE05784D54E6357");

            entity.ToTable("LoaiLopHoc");

            entity.Property(e => e.MaLopHoc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenLopHoc).HasMaxLength(50);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaHs).HasName("PK__SinhVien__2725A6EF5D792A7D");

            entity.ToTable("SinhVien");

            entity.Property(e => e.MaHs)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHS");
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaLopHoc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaLopHocNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaLopHoc)
                .HasConstraintName("FK__SinhVien__MaLopH__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
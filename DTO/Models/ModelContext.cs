using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DTO.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PttkDatphong> PttkDatphongs { get; set; }

    public virtual DbSet<PttkDatphongDichvu> PttkDatphongDichvus { get; set; }

    public virtual DbSet<PttkDichvu> PttkDichvus { get; set; }

    public virtual DbSet<PttkDoan> PttkDoans { get; set; }

    public virtual DbSet<PttkKhachhang> PttkKhachhangs { get; set; }

    public virtual DbSet<PttkKhachhangDoan> PttkKhachhangDoans { get; set; }

    public virtual DbSet<PttkLoaiphong> PttkLoaiphongs { get; set; }

    public virtual DbSet<PttkNhanvien> PttkNhanviens { get; set; }

    public virtual DbSet<PttkPhong> PttkPhongs { get; set; }

    public virtual DbSet<PttkPhongDatphong> PttkPhongDatphongs { get; set; }

    public virtual DbSet<PttkQuydinh> PttkQuydinhs { get; set; }

    public virtual DbSet<PttkTaikhoan> PttkTaikhoans { get; set; }

    public virtual DbSet<PttkThietbi> PttkThietbis { get; set; }

    public virtual DbSet<PttkThietbiPhong> PttkThietbiPhongs { get; set; }

    public virtual DbSet<PttkTour> PttkTours { get; set; }

    public virtual DbSet<PttkTourKhachhang> PttkTourKhachhangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source= localhost:1521/xe;User ID=PTTK_HTTT_DBA;Password=1;Persist Security Info=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("PTTK_HTTT_DBA")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<PttkDatphong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DATPHONG");

            entity.ToTable("PTTK_DATPHONG");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDay)
                .HasColumnType("DATE")
                .HasColumnName("CREATED_DAY");
            entity.Property(e => e.CustomerId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.LeavingDay)
                .HasColumnType("DATE")
                .HasColumnName("LEAVING_DAY");
            entity.Property(e => e.ArrivalDay)
                .HasColumnType("DATE")
                .HasColumnName("ARRIVAL_DAY");

            entity.HasOne(d => d.Customer).WithMany(p => p.PttkDatphongs)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_KHACHHANG_DATPHONG");

            entity.HasOne(d => d.Employee).WithMany(p => p.PttkDatphongs)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_NHANVIEN_DATPHONG");
        });

        modelBuilder.Entity<PttkDatphongDichvu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DATPHONG_DICHVU");

            entity.ToTable("PTTK_DATPHONG_DICHVU");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.OrderId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.Quantity)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("QUANTITY");
            entity.Property(e => e.ServiceId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SERVICE_ID");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TOTAL_PRICE");

            entity.HasOne(d => d.Order).WithMany(p => p.PttkDatphongDichvus)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_PK_DATPHONG_CHITIETDICHVU");

            entity.HasOne(d => d.Service).WithMany(p => p.PttkDatphongDichvus)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_PK_DICHVU_CHITIETDICHVU");
        });

        modelBuilder.Entity<PttkDichvu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DV");

            entity.ToTable("PTTK_DICHVU");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Decsription)
                .HasMaxLength(10)
                .HasColumnName("DECSRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PRICE");
        });

        modelBuilder.Entity<PttkDoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_KHD");

            entity.ToTable("PTTK_DOAN");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Leader)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("LEADER");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");

            entity.HasOne(d => d.LeaderNavigation).WithMany(p => p.PttkDoans)
                .HasForeignKey(d => d.Leader)
                .HasConstraintName("FK_TRUONGDOAN");
        });

        modelBuilder.Entity<PttkKhachhang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_KHACHHANG");

            entity.ToTable("PTTK_KHACHHANG");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Birthday)
                .HasColumnType("DATE")
                .HasColumnName("BIRTHDAY");
            entity.Property(e => e.IdentifiedCard)
                .HasMaxLength(12)
                .HasColumnName("IDENTIFIED_CARD");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(20)
                .HasColumnName("NUMBER_PHONE");
            entity.Property(e => e.PttkDoanId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PTTK_DOAN_ID");
            entity.Property(e => e.Sex)
                .HasMaxLength(5)
                .HasColumnName("SEX");
        });

        modelBuilder.Entity<PttkKhachhangDoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_KHACHHANG_DOAN");

            entity.ToTable("PTTK_KHACHHANG_DOAN");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CustomerId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.DoanId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DOAN_ID");

            entity.HasOne(d => d.Customer).WithMany(p => p.PttkKhachhangDoans)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CHITIETDOAN_KHACHHANG");

            entity.HasOne(d => d.Doan).WithMany(p => p.PttkKhachhangDoans)
                .HasForeignKey(d => d.DoanId)
                .HasConstraintName("FK_CHITIETDOAN_DOAN");
        });

        modelBuilder.Entity<PttkLoaiphong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LOAIPHONG");

            entity.ToTable("PTTK_LOAIPHONG");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PRICE");
        });

        modelBuilder.Entity<PttkNhanvien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NHANVIEN");

            entity.ToTable("PTTK_NHANVIEN");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Birthday)
                .HasColumnType("DATE")
                .HasColumnName("BIRTHDAY");
            entity.Property(e => e.HireDay)
                .HasColumnType("DATE")
                .HasColumnName("HIRE_DAY");
            entity.Property(e => e.IdentifiedCard)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDENTIFIED_CARD");
            entity.Property(e => e.Kind)
                .HasMaxLength(20)
                .HasColumnName("KIND");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(20)
                .HasColumnName("NUMBER_PHONE");
            entity.Property(e => e.Sex)
                .HasMaxLength(5)
                .HasColumnName("SEX");
            entity.Property(e => e.FireDay)
                .HasColumnType("DATE")
                .HasColumnName("FIREDDAY");
        });

        modelBuilder.Entity<PttkPhong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PHONG");

            entity.ToTable("PTTK_PHONG");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.HygieneStatus)
                .HasMaxLength(50)
                .HasColumnName("HYGIENE_STATUS");
            entity.Property(e => e.Kind)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("KIND");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PRICE");
            entity.Property(e => e.RentStatus)
                .HasMaxLength(50)
                .HasColumnName("RENT_STATUS");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(50)
                .HasColumnName("ROOM_NUMBER");

            entity.HasOne(d => d.KindNavigation).WithMany(p => p.PttkPhongs)
                .HasForeignKey(d => d.Kind)
                .HasConstraintName("FK_PHONG_LOAIPHONG");
        });

        modelBuilder.Entity<PttkPhongDatphong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PHONG_DATPHONG");

            entity.ToTable("PTTK_PHONG_DATPHONG");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.OrderId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.RoomId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROOM_ID");

            entity.HasOne(d => d.Order).WithMany(p => p.PttkPhongDatphongs)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_PK_DATPHONG_CHITIETPHONG");

            entity.HasOne(d => d.Room).WithMany(p => p.PttkPhongDatphongs)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_PK_PHONG_CHITIETPHONG");
        });

        modelBuilder.Entity<PttkQuydinh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_QUYDINH");

            entity.ToTable("PTTK_QUYDINH");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Dieukhoan)
                .HasMaxLength(50)
                .HasColumnName("DIEUKHOAN");
            entity.Property(e => e.Noidung)
                .HasMaxLength(100)
                .HasColumnName("NOIDUNG");
        });

        modelBuilder.Entity<PttkTaikhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ACCOUNT");

            entity.ToTable("PTTK_TAIKHOAN");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("PASSWORD");

            entity.HasOne(d => d.Employee).WithMany(p => p.PttkTaikhoans)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_NHANVIEN_TAIKHOAN");
        });

        modelBuilder.Entity<PttkThietbi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_THIETBI");

            entity.ToTable("PTTK_THIETBI");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<PttkThietbiPhong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_THIETBI_PHONG");

            entity.ToTable("PTTK_THIETBI_PHONG");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.EquipmentId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EQUIPMENT_ID");
            entity.Property(e => e.RoomId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROOM_ID");
            entity.Property(e => e.Tinhtrang)
                .HasMaxLength(50)
                .HasColumnName("TINHTRANG");

            entity.HasOne(d => d.Equipment).WithMany(p => p.PttkThietbiPhongs)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK_THIETBI_CHITIETTHIETBI");

            entity.HasOne(d => d.Room).WithMany(p => p.PttkThietbiPhongs)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_PHONG_CHITIETTHIETBI");
        });

        modelBuilder.Entity<PttkTour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TOUR");

            entity.ToTable("PTTK_TOUR");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<PttkTourKhachhang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TOUR_KHACHHANG");

            entity.ToTable("PTTK_TOUR_KHACHHANG");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CustomerId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.ParticipantAmount)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PARTICIPANT_AMOUNT");
            entity.Property(e => e.StartTime)
                .HasColumnType("DATE")
                .HasColumnName("START_TIME");
            entity.Property(e => e.TourId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TOUR_ID");

            entity.HasOne(d => d.Customer).WithMany(p => p.PttkTourKhachhangs)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CHITIETTOUR_KHACHHANG");

            entity.HasOne(d => d.Tour).WithMany(p => p.PttkTourKhachhangs)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK_CHITIETTOUR_TOUR");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

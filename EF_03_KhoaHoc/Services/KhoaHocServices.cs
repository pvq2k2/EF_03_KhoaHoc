using EF_03_KhoaHoc.Helper;
using EF_03_KhoaHoc.IServices;
using EF_03_KhoaHoc.Models;
using EF_03_KhoaHoc.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03_KhoaHoc.Services
{
    public class KhoaHocServices : IKhoaHocServices
    {
        private readonly AppDbContext dbContext;
        public KhoaHocServices()
        {
            dbContext = new AppDbContext();
        }

        public LogType CapNhatHocVien(int HocVienId)
        {
            var FindHocVien = dbContext.HocVien.FirstOrDefault(x => x.HocVienId == HocVienId);
            if (FindHocVien == null) return LogType.KhongTimThayHocVien;
            HocVien hocVien = new HocVien();
            hocVien.HoTen = InputHelper.InputName(KhoaHocRes.HoTen, KhoaHocRes.ErrDoDaiHoTen, 20, KhoaHocRes.ErrSoTu);
            hocVien.NgaySinh = InputHelper.InputDateTime(KhoaHocRes.NgaySinh, KhoaHocRes.ErrNgaySinh);
            hocVien.QueQuan = InputHelper.InputString(KhoaHocRes.QueQuan);
            hocVien.DiaChi = InputHelper.InputString(KhoaHocRes.DiaChi);
            hocVien.SoDienThoai = InputHelper.InputString(KhoaHocRes.SoDienThoai, KhoaHocRes.ErrSoDienThoai, 0, 10);

            FindHocVien.HoTen = hocVien.HoTen;
            FindHocVien.NgaySinh = hocVien.NgaySinh;
            FindHocVien.QueQuan = hocVien.QueQuan;
            FindHocVien.DiaChi = hocVien.DiaChi;
            FindHocVien.SoDienThoai = hocVien.SoDienThoai;

            dbContext.HocVien.Update(FindHocVien);
            dbContext.SaveChanges();
            return LogType.ThanhCong;
        }

        public LogType ThemNgayHocVaoKhoaHoc(int KhoaHocId)
        {
            var FindKhoaHoc = dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocId == KhoaHocId);
            if (FindKhoaHoc == null) return LogType.KhongTimThayKhoaHoc;

            if (FindKhoaHoc.TenKhoaHoc.Length > 10) return LogType.ErrTenKhoaHoc;
            if (FindKhoaHoc.HocPhi > 10000000) return LogType.ErrHocPhi;

            var FindListNgayHoc = dbContext.KhoaHoc.Include(x => x.ListNgayHoc).ToList();
            if (FindKhoaHoc.ListNgayHoc.Count() >= 15) return LogType.DaDuNgayHoc;
            
            NgayHoc ngayHoc = new NgayHoc();
            Console.WriteLine("-----Them ngay hoc-----");
            ngayHoc.NoiDung = InputHelper.InputString(KhoaHocRes.NoiDung);
            ngayHoc.GhiChu = InputHelper.InputString(KhoaHocRes.GhiChu);
            ngayHoc.KhoaHocId = FindKhoaHoc.KhoaHocId;

            dbContext.NgayHoc.Add(ngayHoc);
            dbContext.SaveChanges();
            return LogType.ThanhCong;
        }

        public LogType TimKiemHocVien(string Name)
        {
            var ListHocVien = dbContext.HocVien
                .Where(y => y.HoTen.ToUpper().Contains(Name.ToUpper()))
                .ToList();

            if (ListHocVien.Count == 0) return LogType.KhongTimThayHocVien;
            Console.WriteLine($"Ket qua hoc vien co chua chuoi '{Name}'\n");
            ListHocVien.ForEach(x =>
            {
                Console.WriteLine($"Ten hoc vien: {x.HoTen}");
                var ListKhoaHoc = dbContext.KhoaHoc.Where(y => y.KhoaHocId == x.KhoaHocId).ToList();
                if (ListKhoaHoc.Count == 0)
                {
                    Console.WriteLine("Chua hoc khoa hoc nao!");
                    Console.WriteLine();
                } else
                {
                    ListKhoaHoc.ForEach(z => {
                        Console.WriteLine($"Ten khoa hoc : {z.TenKhoaHoc}");
                    });
                    Console.WriteLine();
                }
            });
            return LogType.ThanhCong;
        }

        public LogType TinhDoanhThu()
        {
            var ListHocVien = dbContext.KhoaHoc.Include(x => x.ListHocVien).ToList();
            if (ListHocVien.Count() == 0) return LogType.KhongTimThayHocVien;
            double DoanhThu;
            Console.WriteLine("-----Doanh thu-----");
            ListHocVien.ForEach(x =>
            {
                DoanhThu = 0;
                DoanhThu = x.ListHocVien.Count() * x.HocPhi;
                Console.WriteLine($"Ten khoa hoc: {x.TenKhoaHoc} co doanh thu la: {DoanhThu}");

            });
            return LogType.ThanhCong;
        }

        public LogType XoaKhoaHoc(int KhoaHocId)
        {
            var FindKhoaHoc = dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocId == KhoaHocId);
            if (FindKhoaHoc == null) return LogType.KhongTimThayKhoaHoc;

            dbContext.KhoaHoc.Remove(FindKhoaHoc);
            dbContext.SaveChanges();
            Console.WriteLine($"Da xoa khoa hoc co ten '{FindKhoaHoc.TenKhoaHoc}' co id la {FindKhoaHoc.KhoaHocId}");

            return LogType.ThanhCong;
        }
    }
}

using EF_03_KhoaHoc.Helper;
using EF_03_KhoaHoc.Models;
using EF_03_KhoaHoc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03_KhoaHoc.Controller
{
    public class KhoaHocController
    {
        KhoaHocServices services;

        public KhoaHocController()
        {
            services = new KhoaHocServices();
        }

        public void ThucThi(char c)
        {
            switch (c)
            {
                case '1':
                    int KhoaHocID_Add = InputHelper.InputInt("Nhap ID khoa hoc muon them: ", "Vui long nhap vao la mot so");
                    LogHelper.KhoaHocLog(services.ThemNgayHocVaoKhoaHoc(KhoaHocID_Add));
                    break;
                case '2':
                    int HocVienID = InputHelper.InputInt("Nhap ID hoc vien muon them: ", "Vui long nhap vao la mot so");
                    LogHelper.KhoaHocLog(services.CapNhatHocVien(HocVienID));
                    break;
                case '3':
                    int KhoaHocID_Remove = InputHelper.InputInt("Nhap ID khoa hoc muon them: ", "Vui long nhap vao la mot so");
                    LogHelper.KhoaHocLog(services.XoaKhoaHoc(KhoaHocID_Remove));
                    break;
                case '4':
                    string Name = InputHelper.InputString("Nhap ten hoc vien: ");
                    LogHelper.KhoaHocLog(services.TimKiemHocVien(Name));
                    break;
                case '5':
                    LogHelper.KhoaHocLog(services.TinhDoanhThu());
                    break;
                case '6':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Khong co chuc nang nay, vui long nhap lai!");
                    break;
            }
            Console.WriteLine("\nNhan phim bat ky de tiep tuc!");
            Console.ReadKey();
        }
    }
}

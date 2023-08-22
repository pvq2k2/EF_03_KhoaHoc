using EF_03_KhoaHoc.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03_KhoaHoc.Helper
{
    public enum LogType
    {
        Thoat,
        KhongTimThayHocVien, 
        DanhSachTrong,
        ErrTenKhoaHoc,
        ErrHocPhi,
        KhongTimThayKhoaHoc,
        DaDuNgayHoc,
        ThanhCong
    }
    public class LogHelper
    {
        public static void KhoaHocLog(LogType log)
        {
            switch (log)
            {
                case LogType.ThanhCong:
                    Console.WriteLine(KhoaHocRes.ThanhCong);
                    break;
                case LogType.KhongTimThayHocVien:
                    Console.WriteLine(KhoaHocRes.KhongTimThayHocVien);
                    break;
                case LogType.ErrTenKhoaHoc:
                    Console.WriteLine(KhoaHocRes.ErrTenKhoaHoc);
                    break;
                case LogType.ErrHocPhi:
                    Console.WriteLine(KhoaHocRes.ErrHocPhi);
                    break;
                case LogType.KhongTimThayKhoaHoc:
                    Console.WriteLine(KhoaHocRes.KhongTimThayKhoaHoc);
                    break;
                case LogType.DaDuNgayHoc:
                    Console.WriteLine(KhoaHocRes.DaDuNgayHoc);
                    break;
                case LogType.DanhSachTrong:
                    Console.WriteLine(KhoaHocRes.DanhSachTrong);
                    break;
            }
        }
    }
}

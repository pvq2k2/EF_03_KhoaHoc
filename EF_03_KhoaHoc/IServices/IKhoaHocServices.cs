using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_03_KhoaHoc.Helper;

namespace EF_03_KhoaHoc.IServices
{
    public interface IKhoaHocServices
    {
        public LogType ThemNgayHocVaoKhoaHoc(int KhoaHocId);
        public LogType CapNhatHocVien(int HocVienId);
        public LogType XoaKhoaHoc(int KhoaHocId);
        public LogType TimKiemHocVien(string Name);
        public LogType TinhDoanhThu();
    }
}

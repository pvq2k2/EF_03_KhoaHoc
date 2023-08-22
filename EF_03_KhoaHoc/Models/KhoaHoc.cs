using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03_KhoaHoc.Models
{
    public class KhoaHoc
    {
        public int KhoaHocId { get; set; }
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        public int HocPhi { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public List<NgayHoc> ListNgayHoc { get; set; }
        public List<HocVien> ListHocVien { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03_KhoaHoc.Models
{
    public class NgayHoc
    {
        public int NgayHocId { get; set; }
        public string NoiDung { get; set; }
        public string GhiChu { get; set; }

        public int KhoaHocId { get; set; }
        public KhoaHoc khoaHoc { get; set; }
    }
}

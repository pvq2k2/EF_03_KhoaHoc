using EF_03_KhoaHoc.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_03_KhoaHoc.View
{
    public class KhoaHocView
    {
        KhoaHocController controller;

        public KhoaHocView()
        {
            controller = new KhoaHocController();
        }

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------Menu----------");
                Console.WriteLine("1. Them ngay hoc vao vao khoa hoc");
                Console.WriteLine("2. Sua thong tin hoc vien");
                Console.WriteLine("3. Xoa hoc vien");
                Console.WriteLine("4. Tim kiem hoc vien");
                Console.WriteLine("5. Tinh doanh thu");
                Console.WriteLine("6. Thoat");
                Console.Write("Chon chuc nang: ");
                char c = Console.ReadKey().KeyChar;
                Console.WriteLine();
                controller.ThucThi(c);
            }
        }
    }
}

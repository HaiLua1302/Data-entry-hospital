using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class nhanvienBUS
    {
        public static bool ThemNhanVien(CLASS.nhanvien nv)
        {
            bool kq = DB.NhanVienDB.ThemNhanVien(nv);
            return kq;
        }


        //Cập nhật thông tin người dùng
        public static bool SuaNhanVien(CLASS.nhanvien nv)
        {
            bool kq = DB.NhanVienDB.CapNhatNhanVien(nv);
            return kq;
        }

        //Xóa người dùng
        public static bool XoaNhanVien(int maNV)
        {
            bool kq = DB.NhanVienDB.xoaNV(maNV);
            return kq;
        }
    }
}

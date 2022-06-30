using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class NhanVienDB
    {

        //them nhan vien
        public static bool ThemNhanVien(CLASS.nhanvien nhanvien)
        {
            bool kq;
            string sql = string.Format("insert into nhanvien(tenNV,gtNV,tuoiNV,chucvu,ngaynhap,idPB) values (N'{0}', N'{1}',{2}, N'{3}', N'{4}', N'{5}')", nhanvien.tenNV, nhanvien.gtNV,nhanvien.tuoiNV, nhanvien.chucvu, nhanvien.ngaynhap, nhanvien.idPB);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa nhan vien
        public static bool xoaNV(int idNV)
        {
            bool kq;
            string sql = string.Format("delete from nhanvien where idNV = {0}", idNV);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //capnhat nhan vien
        public static bool CapNhatNhanVien(CLASS.nhanvien nv)
        {
            bool kq;
            string sql = string.Format("update nhanvien " +
                "set tenNV = N'{0}', gtNV = N'{1}', tuoiNV = {2}, chucvu = N'{3}', ngaynhap = N'{4}', idPB = N'{5}' " +
                "where idNV = {6};", nv.tenNV, nv.gtNV,nv.tuoiNV, nv.chucvu, nv.ngaynhap, nv.idPB, nv.idNV);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
       
    }

}

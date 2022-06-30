using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class bieumau4DB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ(int cmt)
        {
            string sql = string.Format("SELECT right('0000' + convert(varchar(4),idBM4), 4) as IDBM,nhomBenh,slNguoi,phanTram,tongNgay,tbNgay,thang,nam,idLD " +
                "from bieumau4 " +
                "where idLD = {0} order by nhomBenh,thang",cmt);
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        //them bieu mau 
        public static bool ThemBM(CLASS.bieumau4 bm)
        {
            bool kq;
            string sql = string.Format("insert into bieumau4(nhomBenh,slNguoi,phanTram,tongNgay,tbNgay,thang,nam,idLD) " +
                "values (N'{0}', {1}, {2}, {3}, {4}, N'{5}', (select nam from nguoiLD where idLD = {6}), {7} );",
                bm.nhomBenh,bm.sl,bm.phanTram,bm.slNgay,bm.tbSoNgay,bm.thang,bm.idLD,bm.idLD);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa 
        public static bool xoaData(int idBM)
        {
            bool kq;
            string sql = string.Format("delete from bieumau4 where idBM4 = {0}", idBM);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }

        //cap nhat
        public static bool CapNhatLD(CLASS.bieumau4 bm)
        {
            bool kq;
            string sql = string.Format("update bieumau4 " +
                "set slNguoi = {0} , tongNgay = {1} ,phanTram = {2}, tbNgay = {3}" +
                "where idBM4 = {4};", bm.sl,bm.slNgay,bm.phanTram,bm.tbSoNgay,bm.idBM);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }

        //cap nhat phieu
        public static bool CapNhatLD_Duplicate(string cmt)
        {
            bool kq;
            string sql = string.Format("update nguoiLD " +
                "set {0} ;", cmt);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //
    }
}

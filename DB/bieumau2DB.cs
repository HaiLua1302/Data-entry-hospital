using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class bieumau2DB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "SELECT right('0000' + convert(varchar(4),idBM2), 4) as IDBM,ngaythang,sumNam,sumNu,sumTong,sumSK1,sumSK2,sumSK3,sumSK4,sumSK5 " +
                "from bieumau2 order by ngaythang desc;";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        //them bieu mau 
        public static bool ThemBM(CLASS.bieumau2 bm2)
        {
            bool kq;
            string sql = string.Format("insert into bieumau2(ngaythang,sumNam,sumNu,sumTong,sumSK1,sumSK2,sumSK3,sumSK4,sumSK5) " +
                "values (N'{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8} );",
                bm2.ngaythang, bm2.sumNam, bm2.sumNu, bm2.sumTong, bm2.sumSK1, bm2.sumSK2, bm2.sumSK3, bm2.sumSK4, bm2.sumSK5);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa phieu
        public static bool xoaDataBM(int idBM)
        {
            bool kq;
            string sql = string.Format("delete from bieumau2 where idBM2 = {0}", idBM);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //cap nhat phieu
        public static bool CapNhatbm2(CLASS.bieumau2 bm2)
        {
            bool kq;
            string sql = string.Format("update bieumau2 " +
                "set ngaythang = N'{0}', sumNam = {1}, sumNu = {2}, sumTong = {3}, sumSK1 = {4},sumSK2 = {5},sumSK3 = {6},sumSK4 = {7},sumSK5 = {8} " +
                "where idBM2 = {9};", bm2.ngaythang, bm2.sumNam, bm2.sumNu, bm2.sumTong, bm2.sumSK1, bm2.sumSK2, bm2.sumSK3, bm2.sumSK4, bm2.sumSK5, bm2.idBM2);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
    }
}

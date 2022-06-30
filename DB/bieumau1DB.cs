using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class bieumau1DB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "SELECT right('0000' + convert(varchar(4),idBM1), 4) as IDBM,ngaythang,sumNam,sumNu,sumTong,PLSK " +
                "from bieumau1 order by idBM1 desc;";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        //them bieu mau 
        public static bool ThemBM(CLASS.bieumau1 bm1)
        {
            bool kq;
            string sql = string.Format("insert into bieumau1(ngaythang,sumNam,sumNu,sumTong,PLSK) " +
                "values (N'{0}', {1}, {2}, {3}, N'{4}' );",
                bm1.ngaythang,bm1.sumNam,bm1.sumNu,bm1.sumTong,bm1.PLSK );
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa phieu
        public static bool xoaDataBM(int idBM)
        {
            bool kq;
            string sql = string.Format("delete from bieumau1 where idBM1 = {0}", idBM);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //cap nhat phieu
        public static bool CapNhatBM1(CLASS.bieumau1 bm1)
        {
            bool kq;
            string sql = string.Format("update bieumau1 " +
                "set ngaythang = N'{0}', sumNam = {1}, sumNu = {2}, sumTong = {3}, PLSK = N'{4}' " +
                "where idBM1 = {5};", bm1.ngaythang, bm1.sumNam, bm1.sumNu, bm1.sumTong, bm1.PLSK,bm1.idBM1);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
    }
}

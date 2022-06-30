using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class bieumau3DB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "SELECT right('0000' + convert(varchar(4),idBM3), 4) as IDBM ," +
                " bm3.T1, bm3.T2, bm3.T3, bm3.T4, bm3.T5, bm3.T6, bm3.T7, bm3.T8, bm3.T9, bm3.T10, bm3.T11, bm3.T12, " +
                "bm3.nam, bm3.TongNam, bm3.TimeRec, bm3.maBenh , nb.tenBenh " +
                "From bieumau3 bm3 " +
                "left join nhombenh nb on bm3.maBenh = nb.maBenh " +
                "order by bm3.timeRec desc;";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        public static DataTable getDSKQ_duplicate(CLASS.bieumau3 bm3)
        {
            string sql =string.Format("SELECT right('0000' + convert(varchar(4),idBM3), 4) as IDBM ," +
                " bm3.T1, bm3.T2, bm3.T3, bm3.T4, bm3.T5, bm3.T6, bm3.T7, bm3.T8, bm3.T9, bm3.T10, bm3.T11, bm3.T12, " +
                "bm3.nam, bm3.TongNam, bm3.TimeRec, bm3.maBenh , nb.tenBenh " +
                "From bieumau3 bm3 " +
                "left join nhombenh nb on bm3.maBenh = nb.maBenh " +
                "where bm3.maBenh = '{0}' and bm3.nam = {1}" +
                "order by bm3.timeRec desc;",bm3.maBenh,bm3.nam); 
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        // filter
        public static DataTable getDSKQ_filter(CLASS.bieumau3 bm3)
        {
            string sql = string.Format("SELECT right('0000' + convert(varchar(4),idBM3), 4) as IDBM ," +
                " bm3.T1, bm3.T2, bm3.T3, bm3.T4, bm3.T5, bm3.T6, bm3.T7, bm3.T8, bm3.T9, bm3.T10, bm3.T11, bm3.T12, " +
                "bm3.nam, bm3.TongNam, bm3.TimeRec, bm3.maBenh , nb.tenBenh " +
                "From bieumau3 bm3 " +
                "left join nhombenh nb on bm3.maBenh = nb.maBenh " +
                "where bm3.nam = {0}" +
                "order by bm3.timeRec desc;",bm3.nam);
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        //them bieu mau 
        public static bool ThemBM(CLASS.bieumau3 BM3)
        {
            bool kq;
            string sql = string.Format("insert into bieumau3(bm3.T1, bm3.T2, bm3.T3, bm3.T4, bm3.T5, bm3.T6, bm3.T7, " +
               "bm3.T8, bm3.T9, bm3.T10, bm3.T11, bm3.T12,bm3.nam,bm3.tongNam ,bm3.TimeRec,bm3.maBenh) " +
               "values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},(select convert(varchar, getdate(), 20)),'{14}'); ",
               BM3.thang1, BM3.thang2, BM3.thang3, BM3.thang4, BM3.thang5, BM3.thang6, BM3.thang7, BM3.thang8, BM3.thang9,
               BM3.thang10, BM3.thang11, BM3.thang12, BM3.nam, BM3.tongNam, BM3.maBenh);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        /*//upadte doi tuong co cung mabenh va nam
        public static bool ThemBM_Duplicate(CLASS.bieumau3 BM3)
        {
            bool kq;
            string sql = string.Format("declare @id1 int  " +
                "set @id1 = (select idBM3 from bieumau3 where maBenh = '{0}' and nam = {1}) " +
                "update bieumau3 set T1 = {2}, T2 = {3}, T3 = {4}, T4 = {5}, T5 = {6}, T6 = {7}, T7 = {8}, T8 = {9}, T9 = {10}, " +
                "T10 = {11}, T11 = {12}, T12 = {13} " +
                "where idBM3 = @id1 ;" ,
                BM3.maBenh,BM3.nam,BM3.thang1, BM3.thang2, BM3.thang3, BM3.thang4, BM3.thang5, BM3.thang6, BM3.thang7, BM3.thang8, BM3.thang9, BM3.thang10, BM3.thang11, BM3.thang12, BM3.nam, BM3.maBenh);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }*/
        //xoa phieu
        public static bool xoaDataBM(int idBM)
        {
            bool kq;
            string sql = string.Format("delete from bieumau3 where idBM3 = {0}", idBM);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //cap nhat phieu
        public static bool CapNhatbm(CLASS.bieumau3 BM3)
        {
            bool kq;
            string sql = string.Format("update bieumau3 " +
                "set T1 = {0} ,T2 = {1} ,T3 = {2} ,T4 = {3} ,T5 = {4} ,T6 = {5} ,T7 = {6} ,T8 = {7} ,T9 = {8} ,T10 = {9} ,T11 = {10} ,T12 = {11} , " +
                "nam = {12} ,tongNam = {13} ,timeRec = (select convert(varchar, getdate(), 20)) , maBenh = '{14}' " +
                "where idBM3 = {15};", BM3.thang1, BM3.thang2, BM3.thang3, BM3.thang4, BM3.thang5, BM3.thang6, BM3.thang7, BM3.thang8, BM3.thang9,BM3.thang10, BM3.thang11, BM3.thang12, BM3.nam, BM3.tongNam, BM3.maBenh,BM3.idBM3);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
    }
}

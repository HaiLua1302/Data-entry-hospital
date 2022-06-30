using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class bieumau7DB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "SELECT right('0000' + convert(varchar(4),idBM7), 4) as IDBM," +
                "tenBenh,ngaythang,tsSK,SKnu ,tsCD,CDnu ,tsGD,GDnu,tsless5,nuless5,tsless31,nuless31,tsmore30,numore30  " +
                "from bieumau7 bm7 " +
                "left join nhombenh nb on bm7.maBenh = nb.maBenh " +
                "order by ngaythang desc;";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        //them bieu mau 
        public static bool ThemBM(CLASS.bieumau7 bm)
        {
            bool kq;
            string sql = string.Format("insert into bieumau7(maBenh,ngaythang,tsSK,SKnu ,tsCD,CDnu ,tsGD,GDnu,tsless5,nuless5,tsless31,nuless31,tsmore30,numore30) " +
                "values('{0}', N'{1}',{2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13})",
                bm.maBenh, bm.ngaythang, bm.sl_kham, bm.sln_kham, bm.sl_cd, bm.sln_cd, bm.sl_gd, bm.sln_gd, bm.sl_15, bm.sln_15,
                bm.sl_15_31,bm.sln_15_31,bm.sl_31,bm.sl_31);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa 
        public static bool xoaData(int idBM)
        {
            bool kq;
            string sql = string.Format("delete from bieumau7 where idBM7 = {0}", idBM);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }

        //cap nhat
        public static bool CapNhatLD(CLASS.bieumau7 bm)
        {
            bool kq;
            string sql = string.Format("update bieumau7 " +
                "set ngaythang = '{0}',tsSK = {1},SKnu  = {2},tsCD = {3},CDnu = {4},tsGD = {5},GDnu = {6}," +
                "tsless5 = {7},nuless5 = {8},tsless31 = {9},nuless31 = {10},tsmore30 = {11},numore30 = {12}" +
                "where idBM7 = {13};", bm.ngaythang, bm.sl_kham, bm.sln_kham, bm.sl_cd, bm.sln_cd, bm.sl_gd, bm.sln_gd, bm.sl_15, bm.sln_15,
                bm.sl_15_31, bm.sln_15_31, bm.sl_31, bm.sl_31,bm.idBM7);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }

    }
}

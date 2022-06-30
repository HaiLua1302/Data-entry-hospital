using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class nguoiLDDB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "SELECT right('0000' + convert(varchar(4),idLD), 4) as IDLD,tongLD,tongLDSX,tongLDTX,nam " +
                "from nguoiLD order by nam desc;";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        //select data_duplicae
        public static DataTable getDSKQ_duplicate(int nam)
        {
            string sql = string.Format("SELECT right('0000' + convert(varchar(4),idLD), 4) as IDLD,tongLD,tongLDSX,tongLDTX,nam " +
                "from nguoiLD where nam = {0};",nam);
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        //them bieu mau 
        public static bool ThemLD(CLASS.nguoiLD LD)
        {
            bool kq;
            string sql = string.Format("insert into nguoiLD(tongLD,tongLDSX,tongLDTX,nam) " +
                "values ({0}, {1}, {2}, {3});",
                LD.tongLD, LD.tongLDSX, LD.tongLDTX, LD.nam);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa 
        public static bool xoaDataLD(int idLD)
        {
            bool kq;
            string sql = string.Format("delete from nguoiLD where idLD = {0}", idLD);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa data bieu mau
        public static bool xoaData_bm4(int idLD)
        {
            bool kq;
            string sql = string.Format("delete from bieumau4 where idLD = {0} ", idLD);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //cap nhat
        public static bool CapNhatLD(CLASS.nguoiLD LD)
        {
            bool kq;
            string sql = string.Format("update nguoiLD " +
                "set tongLD = {0},tongLDSX = {1},tongLDTX = {2} ,nam = {3}" +
                "where idLD = {4};", LD.tongLD, LD.tongLDSX, LD.tongLDTX, LD.nam, LD.idLD);
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
        //get sl tong nguoi lao dong
        public static string getSLLD(int idLD)
        {
            //lay ma pb
            string sql = string.Format("select tongLD from nguoiLD where idLD = {0};", idLD);
            string idPB = getDB.get_valueSQL(sql);
            return idPB;
        }
        //get sl tong nguoi lao dong truc tiep san xuat
        public static string getSLLD_SX(int idLD)
        {
            //lay ma pb
            string sql = string.Format("select tongLDSX from nguoiLD where idLD = {0};", idLD);
            string idPB = getDB.get_valueSQL(sql);
            return idPB;
        }
        //get sl tong nguoi lao dong tiep xuc chat doc hai
        public static string getSLLD_TX(int idLD)
        {
            //lay ma pb
            string sql = string.Format("select tongLDTX from nguoiLD where idLD = {0};", idLD);
            string idPB = getDB.get_valueSQL(sql);
            return idPB;
        }
    }
}

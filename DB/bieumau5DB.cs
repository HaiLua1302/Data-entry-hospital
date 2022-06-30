using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class bieumau5DB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "select right('0000' + convert(varchar(4),idBN), 4) as IDBN,tenBN,gioitinh,tuoi,tuoinghe,khuvuc,tinhTrang,phuongPhap,luuY,timeRec,nhombenh.tenBenh " +
                "from benhnhan " +
                "left join nhombenh on benhnhan.maBenh = nhombenh.maBenh " +
                "order by benhnhan.timeRec desc";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        //them bieu mau 
        public static bool ThemBN(CLASS.benhnhan bn)
        {
            bool kq;
            string sql = string.Format("insert into benhnhan(tenBN ,gioitinh ,tuoi ,tuoinghe ,khuvuc ,tinhTrang ,phuongPhap ,luuY ,timeRec ,maBenh) " +
                "values(N'{0}', N'{1}', {2}, {3}, N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}')",
               bn.tenBN,bn.gioitinh,bn.tuoi,bn.tuoinghe,bn.khuvuc,bn.tinhTrang,bn.phuongPhap,bn.luuY,bn.timeRec,bn.maBenh);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa phieu
        public static bool xoaDataBN(int idBN)
        {
            bool kq;
            string sql = string.Format("delete from benhnhan where idBN = {0}", idBN);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //cap nhat phieu
        public static bool CapNhatBN(CLASS.benhnhan bn)
        {
            bool kq;
            string sql = string.Format("update benhnhan " +
                "set tenBN = N'{0}' ,gioitinh = N'{1}' ,tuoi = {2} ,tuoinghe = {3} ,khuvuc = N'{4}' ,tinhTrang = N'{5}' ,phuongPhap = N'{6}' ,luuY = N'{7}' ,timeRec = N'{8}' ,maBenh = '{9}' " +
                "where idBN = {10};", bn.tenBN, bn.gioitinh, bn.tuoi, bn.tuoinghe, bn.khuvuc, bn.tinhTrang, bn.phuongPhap, bn.luuY, bn.timeRec, bn.maBenh,bn.idBN);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
    }
}

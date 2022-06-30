using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class bieumau8DB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "SELECT right('0000' + convert(varchar(4),idBM8), 4) as IDBM, " +
                "right('0000' + convert(varchar(4),bm8.idBN), 4) as IDBN," +
                "bn.tenBN,bn.gioitinh,bn.tuoi,bm8.cvTruocBNN,bm8.tuoiNghe,bm8.ngayPhatHien,bm8.tenBNN,bm8.phuongPhap,bm8.tyleLD,bm8.cvHienNay,bm8.luuY,bm8.timeRec " +
                "from bieumau8 bm8 " +
                "left join benhnhan bn on bm8.idBN = bn.idBN " +
                "order by bm8.timeRec desc";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        //them bieu mau 
        public static bool ThemBM(CLASS.bieumau8 bm,CLASS.benhnhan bn)
        {
            bool kq;
            string sql = string.Format("insert into benhnhan(tenBN ,gioitinh ,tuoi) " +
                "values(N'{0}', N'{1}', {2}) " +
                "insert into bieumau8(bm8.idBN, bm8.cvTruocBNN, bm8.tuoiNghe, bm8.ngayPhatHien, bm8.tenBNN, bm8.phuongPhap, bm8.tyleLD, bm8.cvHienNay, bm8.luuY, bm8.timeRec) " +
                "values((SELECT IDENT_CURRENT('benhnhan') as idBN), N'{3}', {4}, N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}')",
               bn.tenBN,bn.gioitinh,bn.tuoi,bm.nghe_before,bm.tuoiNghe,bm.ngayPhatHien,bm.tenBNN,bm.phuongPhap,bm.tyLyld,bm.cvHienNay,bm.luuY,bm.timeRec);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //them bieu mau co idBN
        public static bool ThemBM_has_idBN(CLASS.bieumau8 bm, CLASS.benhnhan bn)
        {
            bool kq;
            string sql = string.Format("insert into bieumau8(bm8.idBN, bm8.cvTruocBNN, bm8.tuoiNghe, bm8.ngayPhatHien, bm8.tenBNN, bm8.phuongPhap, bm8.tyleLD, bm8.cvHienNay, bm8.luuY, bm8.timeRec) " +
                "values({0}, N'{1}', {2}, N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}')",
              bn.idBN, bm.nghe_before, bm.tuoiNghe, bm.ngayPhatHien, bm.tenBNN, bm.phuongPhap, bm.tyLyld, bm.cvHienNay, bm.luuY, bm.timeRec);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa 
        public static bool xoaData(int idBM)
        {
            bool kq;
            string sql = string.Format("delete from bieumau8 where idBM8 = {0}", idBM);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa bn
        public static bool xoaData_bn(int idBN)
        {
            bool kq;
            string sql = string.Format("delete from benhnhan where idBN = {0}", idBN);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }

        //cap nhat
        public static bool CapNhat_data(CLASS.bieumau8 bm, CLASS.benhnhan bn)
        {
            bool kq;
            string sql = string.Format("update benhnhan set tenBN = N'{0}', gioitinh = N'{1}', tuoi = {2} " +
                "where idBN = {3} " +
                "update bieumau8 set cvTruocBNN = N'{4}', tuoiNghe = {5}, ngayPhatHien = N'{6}', tenBNN = N'{7}', " +
                "phuongPhap = N'{8}', tyleLD = N'{9}', cvHienNay = N'{10}', luuY = N'{11}', timeRec = N'{12}' " +
                "where idBN = {13}", 
                bn.tenBN,bn.gioitinh,bn.tuoi,bn.idBN,
                bm.nghe_before,bm.tuoiNghe, bm.ngayPhatHien, bm.tenBNN, 
                bm.phuongPhap, bm.tyLyld, bm.cvHienNay, bm.luuY, bm.timeRec,bm.idBN);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
    }
}

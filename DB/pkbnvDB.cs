using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class pkbnvDB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "SELECT right('0000' + convert(varchar(4),nv.idNV), 4) as IDNV," +
                    "right('0000' + convert(varchar(4),pk.idPKT), 4) as IDKQ," +
                    "nv.tenNV,nv.gtNV,pb.tenPB,nv.tuoiNV,nv.chucvu,pk.kL,pk.ghichu,nv.ngaynhap," +
                    "pk.chieucao,pk.cannang,pk.BMI,pk.mach,pk.huyetAp,pk.theLuc,pk.noiK,pk.ngoaiK,pk.phuK,pk.mat," +
                    "pk.TMH,pk.daLieu,pk.RHM,pk.ptTBMau,pk.ptNTieu,pk.duongHuyet,pk.sgot,pk.sgpt,pk.ure,pk.creatinin,pk.xQuang,pk.sieuAm,pk.plSK " +
                    "FROM nhanvien nv " +
                    "left join dbo.kqKT pk ON nv.idNV = pk.idNV " +
                    "left join dbo.phongban pb ON nv.idPB = pb.idPB " +
                    "order by nv.ngaynhap desc;";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        //them phieu 
        public static bool ThemPKB(CLASS.kqKTCLS pkb)
                {
                    pkb.idPKT = MaTuTang();
                    pkb.idNV = idNVlast();
                    bool kq;
                    string sql = string.Format("insert into kqKT values ({0}, N'{1}',N'{2}', N'{3}', N'{4}', N'{5}',N'{6}',N'{7}',N'{8}',N'{9}'," +
                                "N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}',N'{19}'," +
                                "N'{20}',N'{21}',N'{22}',N'{23}',N'{24}',N'{25}',{26})",
                                pkb.idPKT, pkb.chieucao, pkb.cannang, pkb.BMI, pkb.mach, pkb.huyetAp, pkb.theLuc, pkb.noiK, pkb.ngoaiK, pkb.phuK,
                                pkb.mat, pkb.TMH, pkb.daLieu, pkb.RHM, pkb.ptTBMau, pkb.ptNTieu, pkb.duongHuyet, pkb.sgot, pkb.sgpt, pkb.ure,
                                pkb.creatinin, pkb.xQuang, pkb.sieuAm, pkb.plSK, pkb.kL, pkb.ghiChu, pkb.idNV);
            kq = getDB.ExecuteNonQuery(sql);
                    return kq;
                }
        //them phieu ThemPKBcoID
        public static bool ThemPKBcoID(CLASS.kqKTCLS pkb)
        {
            pkb.idPKT = MaTuTang();
            bool kq;
            string sql = string.Format("insert into kqKT values ({0}, N'{1}',N'{2}', N'{3}', N'{4}', N'{5}',N'{6}',N'{7}',N'{8}',N'{9}'," +
                "N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}',N'{19}'," +
                "N'{20}',N'{21}',N'{22}',N'{23}',N'{24}',N'{25}',{26})",
               pkb.idPKT, pkb.chieucao, pkb.cannang, pkb.BMI, pkb.mach, pkb.huyetAp, pkb.theLuc, pkb.noiK, pkb.ngoaiK, pkb.phuK,
               pkb.mat, pkb.TMH, pkb.daLieu, pkb.RHM, pkb.ptTBMau, pkb.ptNTieu, pkb.duongHuyet, pkb.sgot, pkb.sgpt, pkb.ure,
               pkb.creatinin, pkb.xQuang, pkb.sieuAm, pkb.plSK, pkb.kL, pkb.ghiChu, pkb.idNV);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //get id vua duoc them vao kieu identity
        public static int idNVlast()
        {
           // string sql = "SELECT idNV FROM nhanvien WHERE idNV = SCOPE_IDENTITY();";
            string sql = "SELECT MAX(idNV) FROM nhanvien";
            string getidNV = getDB.get_valueSQL(sql);
            int getInt = int.Parse(getidNV);
            return getInt;
        }
        public static int MaTuTang()
        {
            string sql = "select * from kqKT";
            DataTable dt = getDB.ExecuteQuery(sql);
            int maTuTang = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i][0].ToString()) != maTuTang)
                {
                    return maTuTang;
                }
                maTuTang++;
            }
            return maTuTang;
        }
        //xoa phieu
        public static bool xoaPKTNV(int idPKT)
        {
            bool kq;
            string sql = string.Format("delete from kqKT where idPKT = {0}", idPKT);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //cap nhat phieu
        public static bool CapNhatPKB(CLASS.kqKTCLS pkb)
        {
            bool kq;
            string sql = string.Format("update kqKT " +
                "set chieucao = N'{0}', cannang = N'{1}' ,BMI = N'{2}',mach = N'{3}'," +
                "huyetAp = N'{4}', theLuc = N'{5}', noiK = N'{6}', ngoaiK = N'{7}'," +
                "phuK = N'{8}', mat = N'{9}', TMH = N'{10}', daLieu = N'{11}'," +
                "RHM = N'{12}', ptTBMau = N'{13}', ptNTieu = N'{14}', duongHuyet = N'{15}'," +
                "sgot = N'{16}', sgpt = N'{17}', ure = N'{18}', creatinin = N'{19}', xQuang = N'{20}'," +
                "sieuAm = N'{21}', plSK = N'{22}', kL = N'{23}', ghiChu = N'{24}', idNV = {25}" +
                "Where idPKT = {26}",pkb.chieucao, pkb.cannang, pkb.BMI, pkb.mach, 
                pkb.huyetAp, pkb.theLuc, pkb.noiK, pkb.ngoaiK, pkb.phuK,
                pkb.mat, pkb.TMH, pkb.daLieu, pkb.RHM, pkb.ptTBMau, pkb.ptNTieu,
                pkb.duongHuyet, pkb.sgot, pkb.sgpt, pkb.ure, pkb.creatinin, pkb.xQuang,
                pkb.sieuAm, pkb.plSK, pkb.kL, pkb.ghiChu,pkb.idNV,pkb.idPKT);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
    }
}

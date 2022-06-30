using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKBNV.DB
{
    class timkiemDB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQTK(string tenNV)
        {  
            string sql = string.Format("SELECT right('0000' + convert(varchar(4),nv.idNV), 4) as IDNV," +
                    "right('0000' + convert(varchar(4),pk.idPKT), 4) as IDKQ," +
                    "nv.tenNV,nv.gtNV,pb.tenPB,nv.tuoiNV,nv.chucvu,pk.kL,pk.ghichu,nv.ngaynhap," +
                    "pk.chieucao,pk.cannang,pk.BMI,pk.mach,pk.huyetAp,pk.theLuc,pk.noiK,pk.ngoaiK,pk.phuK,pk.mat," +
                    "pk.TMH,pk.daLieu,pk.RHM,pk.ptTBMau,pk.ptNTieu,pk.duongHuyet,pk.sgot,pk.sgpt,pk.ure,pk.creatinin,pk.xQuang,pk.sieuAm,pk.plSK " +
                    "FROM nhanvien nv " +
                    "left join dbo.kqKT pk ON nv.idNV = pk.idNV " +
                    "left join dbo.phongban pb ON nv.idPB = pb.idPB " +
                    "Where nv.tenNV LIKE N'%" + tenNV +"%'" +
                    "order by nv.ngaynhap desc");
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        public static DataTable getDSKQbyDATE(string from,string to)
        {
            string sql = string.Format("SELECT right('0000' + convert(varchar(4),nv.idNV), 4) as IDNV," +
                    "right('0000' + convert(varchar(4),pk.idPKT), 4) as IDKQ," +
                    "nv.tenNV,nv.gtNV,pb.tenPB,nv.tuoiNV,nv.chucvu,pk.kL,pk.ghichu,nv.ngaynhap," +
                    "pk.chieucao,pk.cannang,pk.BMI,pk.mach,pk.huyetAp,pk.theLuc,pk.noiK,pk.ngoaiK,pk.phuK,pk.mat," +
                    "pk.TMH,pk.daLieu,pk.RHM,pk.ptTBMau,pk.ptNTieu,pk.duongHuyet,pk.sgot,pk.sgpt,pk.ure,pk.creatinin,pk.xQuang,pk.sieuAm,pk.plSK " +
                    "FROM nhanvien nv " +
                    "left join dbo.kqKT pk ON nv.idNV = pk.idNV " +
                    "left join dbo.phongban pb ON nv.idPB = pb.idPB " +
                    "Where nv.ngaynhap BETWEEN '" + from + "' AND '" + to + "'");
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        //tim kiem bm1
        public static DataTable getDSKQbyDATEBM1(string from, string to)
        {
            string sql = string.Format("SELECT right('0000' + convert(varchar(4),idBM1), 4) as IDBM,ngaythang,sumNam,sumNu,sumTong,PLSK from bieumau1 " +
                    "Where ngaythang BETWEEN '" + from + "' AND '" + to + "'");
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        //tim kiem bm2
        public static DataTable getDSKQbyDATEBM2(string from, string to)
        {
            string sql = string.Format("SELECT right('0000' + convert(varchar(4),idBM2), 4) as IDBM,ngaythang,sumNam,sumNu,sumTong,sumSK1,sumSK2,sumSK3,sumSK4,sumSK5 from bieumau2 " +
                    "Where ngaythang BETWEEN '" + from + "' AND '" + to + "'");
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        //tim kiem bm7
        public static DataTable getDSKQ_condition_bm7(string cmt)
        {
            string sql = string.Format("SELECT right('0000' + convert(varchar(4),idBM7), 4) as IDBM," +
                "tenBenh,ngaythang,tsSK,SKnu ,tsCD,CDnu ,tsGD,GDnu,tsless5,nuless5,tsless31,nuless31,tsmore30,numore30  " +
                "from bieumau7 bm7 " +
                "left join nhombenh nb on bm7.maBenh = nb.maBenh " +
                "where {0} " +
                "order by ngaythang desc;", cmt);
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        //kiem tra trung du lieu mabenh vs nam
        public static int checkDuplicateBM3(string maBenh,string nam)
        {
            string sql = string.Format("select count(*) from bieumau3 where maBenh = '{0}' And nam = {1};", maBenh, nam);
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }

        //kiem tra trung du lieu nguoi lao dong nam
        public static int checkDuplicateLD(int nam)
        {
            string sql = string.Format("select count(*) from nguoiLD where nam = {0};", nam);
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }
        //kiem tra xoá du lieu nguoi bieu mau 4
        public static int checkDuplicateLD_delete(int idLD)
        {
            string sql = string.Format("select count(*) from bieumau4 where idLD = {0};", idLD);
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }
        //kiem tra trung thang bieu mau 4
        public static int checkDuplicateLD_BM4_by_Thang(CLASS.bieumau4 BM)
        {
            string sql = string.Format("select count(*) from bieumau4 where thang = N'{0}' AND nhomBenh = N'{1}' AND nam = {2}", BM.thang,BM.nhomBenh,BM.nam);
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }
        //kiem tra trung data bieu mau 7
        public static int checkDuplicateLD_bm7(CLASS.bieumau7 BM)
        {
            string sql = string.Format("select count(*) from bieumau7 where ngaythang = N'{0}' AND maBenh = N'{1}'", BM.ngaythang, BM.maBenh);
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }
        //kiem tra trung data bieu mau 8
        public static int checkDuplicateLD_bm8(int idBN)
        {
            string sql = string.Format("select count(*) from bieumau8 where idBN = {0}",idBN);
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }
        //kiem tra data benh nhan co hay khong bieu mau 8
        public static int checkData_bn_null(int idBN)
        {
            string sql = string.Format("select count(*) from benhnhan where idBN = {0}", idBN);
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }
        //kiem tra trung data nhom benh
        public static int checkDuplicateLD_nb(string maBenh)
        {
            string sql = string.Format("select count(*) from nhombenh where maBenh = N'{0}'", maBenh);
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }
        //kiem tra trung data phong ban
        public static int checkDuplicateLD_pb(string maPhong)
        {
            string sql = string.Format("select count(*) from phongban where idPB = N'{0}'", maPhong);
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }
        //kiem tra trung data chuc danh
        public static int checkDuplicateLD_cd(string maCD)
        {
            string sql = "select count(*) from chucdanh where tenCD LIKE N'%" + maCD + "%'";
            int kq = getDB.checkDuplicate(sql);
            return kq;
        }
        //Rút trích dữ liêu: bm5 co dieu kien
        public static DataTable getDSKQ_by_filter(string condition)
        {
            string sql = "select right('0000' + convert(varchar(4),idBN), 4) as IDBN,tenBN,gioitinh,tuoi,tuoinghe,khuvuc,tinhTrang,phuongPhap,luuY,timeRec,nhombenh.tenBenh " +
                "from benhnhan " +
                "left join nhombenh on benhnhan.maBenh = nhombenh.maBenh " +
                "where " + condition +
                " order by benhnhan.timeRec desc";
            Console.WriteLine(sql);
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
        //Rút trích dữ liêu: bm5 co dieu kien
        public static DataTable getDSKQ_by_filter_bm8(string condition)
        {
            string sql = "SELECT right('0000' + convert(varchar(4),idBM8), 4) as IDBM, " +
                "right('0000' + convert(varchar(4),bm8.idBN), 4) as IDBN," +
                "bn.tenBN,bn.gioitinh,bn.tuoi,bm8.cvTruocBNN,bm8.tuoiNghe,bm8.ngayPhatHien,bm8.tenBNN,bm8.phuongPhap,bm8.tyleLD,bm8.cvHienNay,bm8.luuY,bm8.timeRec " +
                "from bieumau8 bm8 " +
                "left join benhnhan bn on bm8.idBN = bn.idBN " +
                "where " + condition + " " +
                "order by bm8.timeRec desc";
            Console.WriteLine(sql);
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }
    }
}

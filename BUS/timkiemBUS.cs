using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class timkiemBUS
    {
        //Rút trích dữ liệu: select 
        public static DataTable getDSKQ(string tenNV)
        {
            DataTable _ds = DB.timkiemDB.getDSKQTK(tenNV);
            return _ds;
        }
        public static DataTable getDSKQbyDate(string From, string To)
        {
            DataTable _ds = DB.timkiemDB.getDSKQbyDATE(From,To);
            return _ds;
        }

        //bm1 tk
        public static DataTable getDSKQbyDateBM1(string From, string To)
        {
            DataTable _ds = DB.timkiemDB.getDSKQbyDATEBM1(From, To);
            return _ds;
        }

        //bm2 tk
        public static DataTable getDSKQbyDateBM2(string From, string To)
        {
            DataTable _ds = DB.timkiemDB.getDSKQbyDATEBM2(From, To);
            return _ds;
        }
        //bm7 tk
        public static DataTable getDSKQ_condition_BM7(string cmt)
        {
            DataTable _ds = DB.timkiemDB.getDSKQ_condition_bm7(cmt);
            return _ds;
        }
        //kiem tra trung du lieu mabenh vs nam
        public static int checkDuplicateBM3(string maBenh, string nam)
        {
            int kq = DB.timkiemDB.checkDuplicateBM3(maBenh, nam);
            return kq;
        }

        //kiem tra trung du lieu nam
        public static int checkDuplicate_LD(int nam)
        {
            int kq = DB.timkiemDB.checkDuplicateLD(nam);
            return kq;
        }
        //kiem tra trung du lieu nam
        public static int checkDuplicate_delete(int idLD)
        {
            int kq = DB.timkiemDB.checkDuplicateLD_delete(idLD);
            return kq;
        }
        //kiem tra trung du lieu thang bm4
        public static int checkDuplicate_thang_BM4(CLASS.bieumau4 bm)
        {
            int kq = DB.timkiemDB.checkDuplicateLD_BM4_by_Thang(bm);
            return kq;
        }
        //kiem tra trung du lieu thang bieu mau 7
        public static int checkDuplicate_bm7(CLASS.bieumau7 bm)
        {
            int kq = DB.timkiemDB.checkDuplicateLD_bm7(bm);
            return kq;
        }
        //kiem tra trung du lieu thang bieu mau 8
        public static int checkDuplicate_bm8(int idBN)
        {
            int kq = DB.timkiemDB.checkDuplicateLD_bm8(idBN);
            return kq;
        }
        //kiem tra trung du lieu nhom benh
        public static int checkDuplicate_nb(string maBenh)
        {
            int kq = DB.timkiemDB.checkDuplicateLD_nb(maBenh);
            return kq;
        }
        //kiem tra trung du lieu nhom benh
        public static int checkDuplicate_pb(string maPhong)
        {
            int kq = DB.timkiemDB.checkDuplicateLD_pb(maPhong);
            return kq;
        }
        //kiem tra data benh nhan
        public static int checkData_bn_null(int idBN)
        {
            int kq = DB.timkiemDB.checkData_bn_null(idBN);
            return kq;
        }
        //kiem tra data chuc danh
        public static int checkData_cd_null(string maCD)
        {
            int kq = DB.timkiemDB.checkDuplicateLD_cd(maCD);
            return kq;
        }

        //filter bm5
        public static DataTable search_by_filter(string condition)
        {
            DataTable _ds = DB.timkiemDB.getDSKQ_by_filter(condition);
            return _ds;
        }
        //filter bm8
        public static DataTable search_by_filter_bm8(string condition)
        {
            DataTable _ds = DB.timkiemDB.getDSKQ_by_filter_bm8(condition);
            return _ds;
        }
    }
}

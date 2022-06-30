using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class bieumau3BUS
    {
        //get data

        public static DataTable getDSBM()
        {
            DataTable _ds = DB.bieumau3DB.getDSKQ();
            return _ds;
        }
        public static DataTable getDSBM_duplicate(CLASS.bieumau3 bm3)
        {
            DataTable _ds = DB.bieumau3DB.getDSKQ_duplicate(bm3);
            return _ds;
        }
        public static DataTable getDSBM_filter(CLASS.bieumau3 bm3)
        {
            DataTable _ds = DB.bieumau3DB.getDSKQ_filter(bm3);
            return _ds;
        }
        //them data bieu mau
        public static bool ThemBM(CLASS.bieumau3 BM3)
        {
            bool kq = DB.bieumau3DB.ThemBM(BM3);
            return kq;
        } 
       /* //them data bieu mau duplicate
        public static bool ThemBM_duplicate(CLASS.bieumau3 BM3)
        {
            bool kq = DB.bieumau3DB.ThemBM_Duplicate(BM3);
            return kq;
        }*/

        //Cập nhật data bieu mau
        public static bool SuaBM(CLASS.bieumau3 BM3)
        {
            bool kq = DB.bieumau3DB.CapNhatbm(BM3);
            return kq;
        }

        //Xóa data bieu mau
        public static bool XoaBM(int idBM)
        {
            bool kq = DB.bieumau3DB.xoaDataBM(idBM);
            return kq;
        }
    }
}

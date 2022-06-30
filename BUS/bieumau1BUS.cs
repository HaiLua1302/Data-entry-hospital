using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class bieumau1BUS
    {
        //get data
        public static DataTable getDSBM1()
        {
            DataTable _ds = DB.bieumau1DB.getDSKQ();
            return _ds;
        }
        //them data bieu mau 1
        public static bool ThemBM(CLASS.bieumau1 bm1)
        {
            bool kq = DB.bieumau1DB.ThemBM(bm1);
            return kq;
        }


        //Cập nhật data bieu mau 1
        public static bool SuaBM(CLASS.bieumau1 bm1)
        {
            bool kq = DB.bieumau1DB.CapNhatBM1(bm1);
            return kq;
        }

        //Xóa data bieu mau 1
        public static bool XoaBM(int idBM1)
        {
            bool kq = DB.bieumau1DB.xoaDataBM(idBM1);
            return kq;
        }
    }
}

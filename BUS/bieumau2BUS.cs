using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class bieumau2BUS
    {
        //get data
        public static DataTable getDSBM2()
        {
            DataTable _ds = DB.bieumau2DB.getDSKQ();
            return _ds;
        }
        //them data bieu mau 2
        public static bool ThemBM(CLASS.bieumau2 BM2)
        {
            bool kq = DB.bieumau2DB.ThemBM(BM2);
            return kq;
        }


        //Cập nhật data bieu mau 2
        public static bool SuaBM(CLASS.bieumau2 BM2)
        {
            bool kq = DB.bieumau2DB.CapNhatbm2(BM2);
            return kq;
        }

        //Xóa data bieu mau 2
        public static bool XoaBM(int idBM2)
        {
            bool kq = DB.bieumau2DB.xoaDataBM(idBM2);
            return kq;
        }
    }
}

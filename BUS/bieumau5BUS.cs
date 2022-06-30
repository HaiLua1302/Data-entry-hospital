using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class bieumau5BUS
    {
        //get data
        public static DataTable getDSBN()
        {
            DataTable _ds = DB.bieumau5DB.getDSKQ();
            return _ds;
        }
        //them data 
        public static bool ThemBN(CLASS.benhnhan BN)
        {
            bool kq = DB.bieumau5DB.ThemBN(BN);
            return kq;
        }


        //Cập nhật data 
        public static bool SuaBN(CLASS.benhnhan BN)
        {
            bool kq = DB.bieumau5DB.CapNhatBN(BN);
            return kq;
        }

        //Xóa data 
        public static bool XoaBN(int idBN)
        {
            bool kq = DB.bieumau5DB.xoaDataBN(idBN);
            return kq;
        }
    }
}

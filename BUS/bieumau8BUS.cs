using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class bieumau8BUS
    {
        //get data
        public static DataTable getDSKQ_SQL()
        {
            DataTable _ds = DB.bieumau8DB.getDSKQ();
            return _ds;
        }
        //them data 
        public static bool insertDATA(CLASS.bieumau8 bm,CLASS.benhnhan bn)
        {
            bool kq = DB.bieumau8DB.ThemBM(bm,bn);
            return kq;
        }
        //them data co idBN
        public static bool insertDATA_has_idBN(CLASS.bieumau8 bm, CLASS.benhnhan bn)
        {
            bool kq = DB.bieumau8DB.ThemBM_has_idBN(bm, bn);
            return kq;
        }
        //Cập nhật data 
        public static bool updateDATA(CLASS.bieumau8 bm, CLASS.benhnhan bn)
        {
            bool kq = DB.bieumau8DB.CapNhat_data(bm,bn);
            return kq;
        }
        //Xóa data 
        public static bool deleteDATA(int idBM)
        {
            bool kq = DB.bieumau8DB.xoaData(idBM);
            return kq;
        }
        //Xóa data bn
        public static bool deleteDATA_BN(int idBN)
        {
            bool kq = DB.bieumau8DB.xoaData_bn(idBN);
            return kq;
        }
    }
}

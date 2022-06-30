using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class bieumau7BUS
    {
        //get data
        public static DataTable getDSKQ_SQL()
        {
            DataTable _ds = DB.bieumau7DB.getDSKQ();
            return _ds;
        }
        //them data 
        public static bool insertDATA(CLASS.bieumau7 bm)
        {
            bool kq = DB.bieumau7DB.ThemBM(bm);
            return kq;
        }
        //Cập nhật data 
        public static bool updateDATA(CLASS.bieumau7 bm)
        {
            bool kq = DB.bieumau7DB.CapNhatLD(bm);
            return kq;
        }
        //Xóa data 
        public static bool deleteDATA(int idBM)
        {
            bool kq = DB.bieumau7DB.xoaData(idBM);
            return kq;
        }

    }
}

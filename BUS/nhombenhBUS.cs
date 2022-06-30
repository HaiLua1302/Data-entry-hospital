using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class nhombenhBUS
    {
        //get data
        public static DataTable getDSKQ_SQL()
        {
            DataTable _ds = DB.nhombenhDB.getDSKQ();
            return _ds;
        }
        //them data 
        public static bool insertDATA(CLASS.nhombenh nb)
        {
            bool kq = DB.nhombenhDB.ThemBM(nb);
            return kq;
        }
        //Cập nhật data 
        public static bool updateDATA(CLASS.nhombenh nb)
        {
            bool kq = DB.nhombenhDB.CapNhatLD(nb);
            return kq;
        }
        //Xóa data 
        public static bool deleteDATA(string maBenh)
        {
            bool kq = DB.nhombenhDB.xoaData(maBenh);
            return kq;
        }
    }
}

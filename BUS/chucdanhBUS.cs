using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class chucdanhBUS
    {
        //Rút trích dữ liệu: select
        public static List<CLASS.chucdanh> getChucDanh()
        {
            List<CLASS.chucdanh> _chucdanhs;
            _chucdanhs = DB.chucdanhDB.getChucDanh();
            return _chucdanhs;
        }
        //get data
        public static DataTable getDSKQ_SQL()
        {
            DataTable _ds = DB.chucdanhDB.getDSKQ();
            return _ds;
        }
        //them data 
        public static bool insertDATA(CLASS.chucdanh nb)
        {
            bool kq = DB.chucdanhDB.insert_data(nb);
            return kq;
        }
        //Cập nhật data 
        public static bool updateDATA(CLASS.chucdanh nb)
        {
            bool kq = DB.chucdanhDB.update_data(nb);
            return kq;
        }
        //Xóa data 
        public static bool deleteDATA(string maCD)
        {
            bool kq = DB.chucdanhDB.delete_data(maCD);
            return kq;
        }
    }
}

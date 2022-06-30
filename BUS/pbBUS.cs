using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class pbBUS
    {
        //Rút trích dữ liệu: select
        public static List<CLASS.phongban> getPB()
        {
            List<CLASS.phongban> _dspb;
            _dspb = DB.pbDB.getPB();
            return _dspb;
        }
        public static string LayidPBtuTenPB(string tenPBtheoID)
        {
            string idPB = DB.pbDB.LayidPBtuTenPB(tenPBtheoID);
            return idPB;
        }
        //get data
        public static DataTable getDSKQ_SQL()
        {
            DataTable _ds = DB.pbDB.getDSKQ();
            return _ds;
        }
        //them data 
        public static bool insertDATA(CLASS.phongban pb)
        {
            bool kq = DB.pbDB.insert_data(pb);
            return kq;
        }
        //Cập nhật data 
        public static bool updateDATA(CLASS.phongban pb)
        {
            bool kq = DB.pbDB.update_data(pb);
            return kq;
        }
        //Xóa data 
        public static bool deleteDATA(string maPhong)
        {
            bool kq = DB.pbDB.delete_data(maPhong);
            return kq;
        }
    }
}

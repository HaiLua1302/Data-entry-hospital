using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class bieumau4BUS
    {
        //get data
        public static DataTable getDSKQ_SQL(int cmt)
        {
            DataTable _ds = DB.bieumau4DB.getDSKQ(cmt);
            return _ds;
        }
       /* //get data duplocate
        public static DataTable getDSKQ_SQL_duplicate(int nam)
        {
            DataTable _ds = DB.bieumau4DB.getDSKQ_duplicate(nam);
            return _ds;
        }*/
        //them data 
        public static bool insertDATA(CLASS.bieumau4 bm)
        {
            bool kq = DB.bieumau4DB.ThemBM(bm);
            return kq;
        }


        //Cập nhật data 
        public static bool updateDATA(CLASS.bieumau4 bm)
        {
            bool kq = DB.bieumau4DB.CapNhatLD(bm);
            return kq;
        }
/*        //Cập nhật data duplocate
        public static bool SuaLD_duplicate(string cmt)
        {
            bool kq = DB.nguoiLDDB.CapNhatLD_Duplicate(cmt);
            return kq;
        }*/

        //Xóa data 
        public static bool deleteDATA(int idBM)
        {
            bool kq = DB.bieumau4DB.xoaData(idBM);
            return kq;
        }
/*        //Xóa data bieu mau co idLD da xoa
        public static bool XoaBM4_LD(int idLD)
        {
            bool kq = DB.nguoiLDDB.xoaData_bm4(idLD);
            return kq;
        }*/
        //lay thong so
        public static string LayidPBtuTenPB(string tenPB)
        {
            //lay ma pb
            string sql = string.Format("select {0} from phongban where tenPB = N'{1}';", tenPB);
            string idPB = getDB.get_valueSQL(sql);
            return idPB;
        }
    }
}

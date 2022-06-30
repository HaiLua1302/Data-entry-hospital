using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class kqBUS
    {
        //Rút trích dữ liệu: select 
        public static DataTable getDSKQ()
        {
            DataTable _ds = DB.pkbnvDB.getDSKQ();
            return _ds;
        }
        //them pkb
        public static bool themPKB(CLASS.kqKTCLS pkb)
        {
            bool kq = DB.pkbnvDB.ThemPKB(pkb);
            return kq;
        }
        public static bool themPKBcoIDNV(CLASS.kqKTCLS pkb)
        {
            bool kq = DB.pkbnvDB.ThemPKBcoID(pkb);
            return kq;
        }
        //Xóa phieu
        public static bool xoaPKTNV(int idPKT)
        {
            bool kq = DB.pkbnvDB.xoaPKTNV(idPKT);
            return kq;
        }
        //sua phieu
        public static bool suaPKB(CLASS.kqKTCLS pkb)
        {
            bool kq = DB.pkbnvDB.CapNhatPKB(pkb);
            return kq;
        }
    }
}

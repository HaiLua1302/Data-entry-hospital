using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.BUS
{
    class nguoiLDBUS
    {
        //get data
        public static DataTable getDSKQ_SQL()
        {
            DataTable _ds = DB.nguoiLDDB.getDSKQ();
            return _ds;
        }
        //get data duplocate
        public static DataTable getDSKQ_SQL_duplicate(int nam)
        {
            DataTable _ds = DB.nguoiLDDB.getDSKQ_duplicate(nam);
            return _ds;
        }
        //them data 
        public static bool ThemLD(CLASS.nguoiLD LD)
        {
            bool kq = DB.nguoiLDDB.ThemLD(LD);
            return kq;
        }


        //Cập nhật data 
        public static bool SuaLD(CLASS.nguoiLD LD)
        {
            bool kq = DB.nguoiLDDB.CapNhatLD(LD);
            return kq;
        }
        //Cập nhật data duplocate
        public static bool SuaLD_duplicate(string cmt)
        {
            bool kq = DB.nguoiLDDB.CapNhatLD_Duplicate(cmt);
            return kq;
        }

        //Xóa data 
        public static bool XoaLD(int idLD)
        {
            bool kq = DB.nguoiLDDB.xoaDataLD(idLD);
            return kq;
        }
        //Xóa data bieu mau co idLD da xoa
        public static bool XoaBM4_LD(int idLD)
        {
            bool kq = DB.nguoiLDDB.xoaData_bm4(idLD);
            return kq;
        }
        //lay so luong nguoiw lao dong
        public static int getSLLD(int idLD)
        {
            int kq = int.Parse(DB.nguoiLDDB.getSLLD(idLD));
            return kq;
        }
        //lay so luong nguoiw lao dong san xuat
        public static int getSLLD_SX(int idLD)
        {
            int kq = int.Parse(DB.nguoiLDDB.getSLLD_SX(idLD));
            return kq;
        }
        //lay so luong nguoiw lao dong
        public static int getSLLD_TX(int idLD)
        {
            int kq = int.Parse(DB.nguoiLDDB.getSLLD_TX(idLD));
            return kq;
        }
    }
}

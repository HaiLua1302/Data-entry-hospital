using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class nhombenhDB
    {
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "Select maBenh,tenBenh  from nhombenh order by maBenh;";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        //
        public static bool ThemBM(CLASS.nhombenh nb)
        {
            bool kq;
            string sql = string.Format("insert into nhombenh(maBenh,tenBenh) " +
                "values(N'{0}', N'{1}')",nb.maBenh,nb.tenBenh);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa 
        public static bool xoaData(string maBenh)
        {
            bool kq;
            string sql = string.Format("delete from nhombenh where maBenh = N'{0}'", maBenh);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }

        //cap nhat
        public static bool CapNhatLD(CLASS.nhombenh nb)
        {
            bool kq;
            string sql = string.Format("update nhombenh " +
                "set maBenh = N'{0}',tenBenh = N'{1}'" +
                "where maBenh = N'{2}';",nb.maBenh,nb.tenBenh,nb.maBenh);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
    }
}

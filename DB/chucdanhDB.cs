using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class chucdanhDB
    {
        //rút trích dữ liệu: select 
        public static List<CLASS.chucdanh> getChucDanh()
        {
            List<CLASS.chucdanh> _dsCD = new List<CLASS.chucdanh>();
            string sql = "select * from chucdanh";
            DataTable dt = getDB.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CLASS.chucdanh CD = new CLASS.chucdanh();
                CD.idCD = dt.Rows[i]["idCD"].ToString();
                CD.tenCD = dt.Rows[i]["tenCD"].ToString();
                _dsCD.Add(CD);
            }
            return _dsCD;
        }
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "Select idCD,tenCD  from chucdanh order by idCD;";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        //
        public static bool insert_data(CLASS.chucdanh cd)
        {
            bool kq;
            string sql = string.Format("insert into chucdanh(tenCD) " +
                "values(N'{0}')", cd.tenCD);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa 
        public static bool delete_data(string maCD)
        {
            bool kq;
            string sql = string.Format("delete from chucdanh where idCD = N'{0}'", maCD);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }

        //cap nhat
        public static bool update_data(CLASS.chucdanh cd)
        {
            bool kq;
            string sql = string.Format("update chucdanh " +
                "set tenPB = N'{0}'" +
                "where idPB = N'{1}';",cd.tenCD,cd.idCD);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
    }
}

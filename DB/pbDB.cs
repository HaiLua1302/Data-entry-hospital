using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKBNV.DB
{
    class pbDB
    {
        //rút trích dữ liệu: select 
        public static List<CLASS.phongban> getPB()
        {
            List<CLASS.phongban> _dspb = new List<CLASS.phongban>();
            string sql = "select * from phongban";
            DataTable dt = getDB.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CLASS.phongban tenPB = new CLASS.phongban();
                tenPB.idPB = dt.Rows[i]["idPB"].ToString();
                tenPB.tenPB = dt.Rows[i]["tenPB"].ToString();
                _dspb.Add(tenPB);
            }
            return _dspb;
        }
        //Rút trích dữ liêu: select 
        public static DataTable getDSKQ()
        {
            string sql = "Select idPB,tenPB  from phongban order by idPB;";
            DataTable dt = getDB.ExecuteQuery(sql);
            return dt;
        }

        //
        public static bool insert_data(CLASS.phongban pb)
        {
            bool kq;
            string sql = string.Format("insert into phongban(idPB,tenPB) " +
                "values(N'{0}', N'{1}')", pb.idPB,pb.tenPB);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        //xoa 
        public static bool delete_data(string maPhong)
        {
            bool kq;
            string sql = string.Format("delete from phongban where idPB = N'{0}'", maPhong);
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }

        //cap nhat
        public static bool update_data(CLASS.phongban pb)
        {
            bool kq;
            string sql = string.Format("update phongban " +
                "set idPB = N'{0}',tenPB = N'{1}'" +
                "where idPB = N'{2}';", pb.idPB, pb.tenPB,pb.idPB
                );
            kq = getDB.ExecuteNonQuery(sql);
            return kq;
        }
        public static string LayidPBtuTenPB(string tenPB)
        {
            //lay ma pb
            string sql = string.Format("select idPB from phongban where tenPB = N'{0}';", tenPB);
            string idPB = getDB.get_valueSQL(sql);
            return idPB;
        }
    }
}

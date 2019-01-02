using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// WebService2 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {
        public static string ConnStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int GetAllUser()
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            string sql =
            "declare @activities int"+ " "+
            "declare @datestart datetime" +" "+
            "declare @dateend datetime" + " "+
            "declare @datetype nvarchar(max)"+" "+
            "set @activities = (select Count(*) from AbpAuditLogs where datediff(week, ExecutionTime, getdate()) = 1 and MethodName = 'Login')" + "set @datestart = (select top 1 ExecutionTime from AbpAuditLogs where MethodName = 'Login' and datediff(week, ExecutionTime, getdate())= 1)" +" "+
            "set @dateend = (select top 1 ExecutionTime from AbpAuditLogs where MethodName = 'Login' and datediff(week, ExecutionTime, getdate())= 1 order by ExecutionTime desc)" + " " +
            "set @datetype = 'week'" +" "+
            "insert into SFUserActivity values(@activities,@datestart,@dateend,@datetype)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Clear();
            int rel = cmd.ExecuteNonQuery();
            conn.Close();
            return rel;
        }
        [WebMethod]
        public string GetLogin()
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            string sql = "select  DATEPART(MONTH,CreationTime) as LonDate,COUNT(*) as LonCount from AbpUsers where CreationTime between dateadd(mm,-10,getdate()) and getdate()"
+"group by DATEPART(MONTH, CreationTime) ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return null;

        }
        [WebMethod]
        public void GetAll(string dateStart, string dateEnd)
        {
            DateTime dateTime = DateTime.Now;
            int week = Convert.ToInt32(dateTime.DayOfWeek);
            ////本周第一天
            int dayspan = (-1) * week;
            //本周最后一天
            int daydiff = (-1) * week + 6;
            dateStart = dateTime.AddDays(dayspan).ToShortDateString();
            dateEnd = dateTime.AddDays(daydiff).ToShortDateString();

            //链接数据库
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            string sql = "SELECT * FROM AbpAuditLogs WHERE ExecutionTime > @dateStart AND" +
                " ExecutionTime < @dateEnd AND MethodName='Login'";
            //声明起始时间
            SqlParameter DateStart = new SqlParameter("@dateStart", SqlDbType.DateTime);
            DateStart.Value = dateStart;
            //声明结束时间
            SqlParameter DateEnd = new SqlParameter("@dateEnd", SqlDbType.DateTime);
            DateEnd.Value = dateEnd;
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(DateStart);
            command.Parameters.Add(DateEnd);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dt);
            //数据总数
            int Activities = dt.Rows.Count;

            string query = "select * from SFUserActivity where DateStart=@dateStart AND DateType='week'";
            SqlParameter StartDate = new SqlParameter("@dateStart", SqlDbType.DateTime);
            StartDate.Value = dateStart;
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.Add(StartDate);
            DataTable table = new DataTable();
            SqlDataAdapter sqlData = new SqlDataAdapter(comm);
            SqlCommandBuilder sb1 = new SqlCommandBuilder(sqlData);
            sqlData.Fill(table);
            //一行数据
            if (table.Rows.Count > 0)
            {
                //更新数据
                DataRow dr = table.NewRow();
                dr.BeginEdit();
                dr["Activities"] = Activities;
                dr["DateStart"] = dateStart;
                dr["DateEnd"] = dateEnd;
                dr["DateType"] = "week";
                dr.EndEdit();
                sqlData.Update(table);
            }
            else
            {

                //数据类型,week/month
                string dateType = "week";
                string sqlin = "insert into SFUSerActivity values(@Activities,@dateStart,@dateEnd,@dateType)";
                SqlCommand cmd = new SqlCommand(sqlin, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@Activities", Activities));
                cmd.Parameters.Add(new SqlParameter("@dateStart", dateStart));
                cmd.Parameters.Add(new SqlParameter("@dateEnd", dateEnd));
                cmd.Parameters.Add(new SqlParameter("@dateType", dateType));
                cmd.ExecuteNonQuery();
            }
            

        }
        [WebMethod]
        public string Test(DateTime dateStart, DateTime dateEnd)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            string sql = "SELECT * FROM AbpAuditLogs WHERE ExecutionTime > @dateStart AND" +
                " ExecutionTime < @dateEnd AND MethodName='Login'";

            SqlParameter DateStart = new SqlParameter("@dateStart", SqlDbType.DateTime);
            DateStart.Value = dateStart;
            SqlParameter DateEnd = new SqlParameter("@dateEnd", SqlDbType.DateTime);
            DateEnd.Value = dateEnd;

            SqlCommand command = new SqlCommand(sql, conn);

            command.Parameters.Add(DateStart);
            command.Parameters.Add(DateEnd);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dt);
            int a = dt.Rows.Count;
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();  //实例化一个参数集合
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary); //ArrayList集合中添加键值
            }
            //string sqlselrct = "select * from SFUserActivity where DateStart>=@dateStart and DateEnd<=@dateEnd";
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlselrct, conn);
            //SqlCommandBuilder sqlcmd = new SqlCommandBuilder(dataAdapter);
            //DataTable tableDt = new DataTable();
            //if (tableDt.Rows.Count != 0)
            //{
            //    DataRow ar = tableDt.NewRow();
            //    ar["Activity"] = ar["Activity"];
            //    tableDt.Rows.Add(ar);
            //    dataAdapter.Update(tableDt);
            //}
            return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SelectDB
{
    /// <summary>
    /// SelectService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class SelectService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int LoginCount()
        {
            NxShufWebEntities db = new NxShufWebEntities();
            int loncount = db.AbpAuditLogs.Where(o => o.MethodName == "Login").Count();
            return loncount;
        }
        [WebMethod]
        public int lonCount()
        {
            return 3;
        }
        [WebMethod]
        public string GetUserCount()
        {
            NxShufWebEntities db = new NxShufWebEntities();
            int count = db.AbpAuditLogs.Where(o => o.MethodName == "Login").Where(n => n.ExecutionTime > DateTime.Now.AddDays(-Convert.ToInt32(DateTime.Now.Date.DayOfWeek))).Count();
            var datesatrt = db.AbpAuditLogs.Where(o => o.MethodName == "Login").Where(n => n.ExecutionTime > DateTime.Now.AddDays(-Convert.ToInt32(DateTime.Now.Date.DayOfWeek))).OrderBy(o => o.ExecutionTime).FirstOrDefault();
            AbpAuditLogs dateend = db.AbpAuditLogs.Where(o => o.MethodName == "Login").OrderByDescending(o => o.ExecutionTime).First();
            return datesatrt.ToString();
        }
    }
}

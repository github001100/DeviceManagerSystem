using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace CAYA.API.Controllers
{
    public class UserLoginController : Controller
    {
        //
        // GET: /UserLogin/

        public ActionResult Index()
        {
            return View();
        }
        public string CheckUserLogin()
        {
            return JsonConvert.SerializeObject("{\"Table\":[{\"Id\":5,\"LoginName\":\"CAYA0001\"]}");
        }
        public string GetUserInfo()
        {
            try
            {
                SqlConnection sqlConnection =
                    new SqlConnection(
                        "Data Source=FUSANJIE;Initial Catalog=CMES_Sys;Persist Security Info=True;User ID=sa;Password=kyjj1234");
                sqlConnection.Open();
                string sql = "select* from Sys_Account";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);        //将数据填充进dataset               
                return JsonConvert.SerializeObject(dataSet);   //将数据转换成json格式
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}

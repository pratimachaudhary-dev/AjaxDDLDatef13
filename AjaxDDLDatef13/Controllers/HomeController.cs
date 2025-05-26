using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxDDLDatef13.Models;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AjaxDDLDatef13.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DMIM4MFN;Initial Catalog=Ajax;Integrated Security=True;Encrypt=False");
        public ActionResult Index()
        {
            SqlCommand cmd = new SqlCommand("selectstatess", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return View(dt);
        }

        public JsonResult selectcity(int sid)
        {
            SqlCommand cmd = new SqlCommand("seletsids", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid",sid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //string job = JsonConvert.SerializeObject(dt);
            var job = JsonConvert.SerializeObject(dt);
            //List<CityModel> cities  = new List<CityModel>();


            //foreach (DataRow row in dt.Rows)
            //{
            //    CityModel city  = new CityModel();
            //    city.id = Convert.ToInt32(row["id"]);
            //    city .cityname= Convert.ToString(row["cname"]);
            //    cities.Add(city);
            //}


            return Json(job, JsonRequestBehavior.AllowGet);
           
        }



        public ActionResult BlendingReport()
        {
            string result = string.Empty;

            //SqlParameter[] param = new SqlParameter[]
            //{
            //new SqlParameter("@MODE", "BlendingReports"),
            //new SqlParameter("@CardLotNo", CardLotNo)
            //};

            SqlCommand cmd = new SqlCommand("Ragistration", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            
            if (ds.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<style>.headtr{height: 50px; font-size:14px;};.headtd{width: 25%;};.endtd{width: 11.1111%;}</style>");
                sb.Append("<div style='width:80%;margin:auto;'><table style='border-collapse: collapse; width: 100%; height: 50px;' border='1'>");
                sb.Append("<tbody>");
                sb.Append("<tr style='height: 50px;'><td style='font-size:25px;' colspan='8' rowspan='2'>");
                sb.Append("<p style='text-align: center;'><strong>ARORA TEXTILES PVT.LTD.</strong></p></td>");
                sb.Append("<td rowspan='2' style='width:200px;text-align: center'>Doc. No: " + ds.Rows[0]["CARDLOTNO"] + "</br>Issue No: </br>Rev.No:</td><td><p style='text-align: center;'><strong>DATE</strong></p></td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td style='width:200px;height:50px;text-align: center;'>" + ds.Rows[0]["ISSUEDATE"] + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td colspan='10' style='height:50px; font-size:25px'><p style='text-align: center;'><strong>BLENDING INSPECTION REPORT.</strong></p></td></tr>");
                sb.Append("<tr><td colspan='10' style='height:50px; font-size:25px'><p>Inspector's  Name:" + ds.Rows[0]["INSPECTOR_NAME"] + "</p></td></tr>");
                sb.Append("<tr>");
                sb.Append("<td><p style='text-align: center;'>Buyer(Supplier)</p></td>");
                sb.Append("<td><p style='text-align: center;'>Color</p></td>");
                sb.Append("<td><p style='text-align: center;'>Blend Quantity</p></td>");
                sb.Append("<td><p style='text-align: center;'>Layer Of The Blend</p></td>");
                sb.Append("<td colspan='3' style='text-align: center;'><p style='text-align: center;'>Composition Of Blend</p></td>");
                sb.Append("<td><p style='text-align: center;'>Layer Cutting</p></td>");
                sb.Append("<td><p style='text-align: center;'>Impurities(like twine Vegetable Matter)</p></td>");
                sb.Append("<td><p style='text-align: center;'>Remarks(Pass/Fail)</p></td>");
                sb.Append("</tr>");
                //sb.Append("<tr>");
                //sb.Append("<td style='text-align: center;' rowspan='" + ds.Tables[1].Rows.Count + 1 + "'>" + ds.Tables[0].Rows[0]["CustomerName"] + "</td>");
                //sb.Append("<td style='text-align: center;' rowspan='" + ds.Tables[1].Rows.Count + 1 + "'>" + ds.Tables[0].Rows[0]["ProductName"] + "</td>");
                //sb.Append("<td style='text-align: center;' rowspan='" + ds.Tables[1].Rows.Count + 1 + "'>" + ds.Tables[0].Rows[0]["CARDLOT_QTY"] + "</td>");
                //sb.Append("<td style='text-align: center;' rowspan='" + ds.Tables[1].Rows.Count + 1 + "'>" + ds.Tables[0].Rows[0]["BLENDLAYER"] + "</td>");
                //sb.Append("<td> <p style='text-align: center;'>ITEM TYPE</p></td>");
                //sb.Append("<td style='text-align: center;'><p>ITEM NAME</p></td>");
                //sb.Append("<td><p style='text-align: center;'>PERCENTAGE</p></td>");
                //sb.Append("<td style='text-align: center;' rowspan='" + ds.Tables[1].Rows.Count + 1 + "'>" + ds.Tables[0].Rows[0]["LAYERCUTTING"] + "</td>");
                //sb.Append("<td style='text-align: center;' rowspan='" + ds.Tables[1].Rows.Count + 1 + "'>" + ds.Tables[0].Rows[0]["IMPURTIES"] + "</td>");
                //sb.Append("<td style='text-align: center;' rowspan='" + ds.Tables[1].Rows.Count + 1 + "'>" + ds.Tables[0].Rows[0]["REMARKS"] + "</td>");
                //sb.Append("</tr>");
                //for (var i = 0; i < ds.Tables[1].Rows.Count; i++)
                //{
                //    sb.Append("<tr>");
                //    sb.Append("<td style='text-align: center;'>" + ds.Tables[1].Rows[i]["ItemType"] + "</td>");
                //    sb.Append("<td style='text-align: center;'>" + ds.Tables[1].Rows[i]["ITEM_NAME"] + "</td>");
                //    sb.Append("<td style='text-align: center;'>" + ds.Tables[1].Rows[i]["ITEM_PERCENTAGE"] + "</td>");
                //    sb.Append("</tr>");
                //}
                sb.Append("</tbody>");
                sb.Append("</table></div>");
                HttpContext.Session["HtmlReport"] = sb.ToString();
                result = "1#Report Generated";
                var JSON=JsonConvert.SerializeObject(result);
                return Json(JSON,JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = "0#No Record Found.";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

    }
}
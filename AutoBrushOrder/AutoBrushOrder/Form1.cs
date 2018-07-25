using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Web.Script.Serialization;
namespace AutoBrushOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {


            string url = "http://localhost:1777/api/OTCAPI/Post";
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("VER", "1.0");
            parameters.Add("AppID", "YHOTC");
            parameters.Add("Token", "fafdafaf");
            parameters.Add("Language", "zh-cn");
            parameters.Add("ModuleID", "0");
            parameters.Add("MsgID", "2");
            parameters.Add("Digest", "消息校验码");
            parameters.Add("IsEncrypted", "false");
            parameters.Add("IsSuccess", "false");
            parameters.Add("Data", "{'UserID':'8','PaymentMethodID':'1','AccountName':'阿斯蒂芬','AccountNo':'02938410923840123','BankName':'','BranchBankName':'','QRCodeBase64':''}");
            string json = "{'VER':'1.0','AppID':'YHOTC','Token':'fafdafaf','Language':'zh-cn','ModuleID':0,'MsgID':2,'Digest':'消息校验码','IsEncrypted':false,'IsSuccess':false,'Data':{'GetType':1,'AreaCode':'86','VeriflyTypeID':1,'EmailOrPhone':'18682448162'}}"; ///(new JavaScriptSerializer()).Serialize(parameters);                                                                                                                                                                                                                                                                                                                  ///
            //string json ='"{"VER":"1.0","AppID":"YHOTC","Token":"fafdafaf","Language":"zh-cn","ModuleID":0,"MsgID":2,"Digest":"消息校验码","IsEncrypted":false,"IsSuccess":false,"Data":{"GetType":1,"AreaCode":"86","VeriflyTypeID":1,"EmailOrPhone":"18682448162"}}"';

            //var str = HttpHelper.HttpApi(url, json, "POST");

            HttpHelper.GetHtml(url, json, true, null, null, Encoding.UTF8, null);

            // string strMsg = string.Empty;
            // #region

            // IDictionary<string, string> parameters = new Dictionary<string, string>();
            // parameters.Add("VER", "1.0");
            // parameters.Add("AppID", "YHOTC");
            // parameters.Add("Token", "fafdafaf");
            // parameters.Add("Language", "zh-cn");
            // parameters.Add("ModuleID", "0");
            // parameters.Add("MsgID", "2");
            // parameters.Add("Digest", "消息校验码");
            // parameters.Add("IsEncrypted", "false");
            // parameters.Add("IsSuccess", "false");
            // parameters.Add("Data", "{ 'GetType': 1, 'AreaCode': ddlAreaCode, 'VeriflyTypeID': 1, 'EmailOrPhone': phone }");
            // StringBuilder buffer = new StringBuilder();
            // //如果需要POST数据  
            // if (!(parameters == null || parameters.Count == 0))
            // {

            //     int i = 0;
            //     foreach (string key in parameters.Keys)
            //     {
            //         if (i > 0)
            //         {
            //             buffer.AppendFormat("&{0}={1}", key, parameters[key]);
            //         }
            //         else
            //         {
            //             buffer.AppendFormat("{0}={1}", key, parameters[key]);
            //         }
            //         i++;
            //     }
            // }

            // string token = "";
            // string strUrl = "http://localhost:1777/" + @"api/OTCAPI/Post?" + buffer.ToString();
            // Dictionary<string, string> header = new Dictionary<string, string>()
            //{
            //    {"Token",token},
            //};
            // try
            // {
            //     var ret = HttpHelper.GetHtml(strUrl, null, true, null, null, Encoding.UTF8, header);
            //     if (ret != null)
            //     {
            //         strMsg = ret;
            //     }
            //     else
            //     {
            //         strMsg = "获取报表数据出错！消息：" + ret;
            //     }
            // }
            // catch (Exception ex)
            // {
            //     strMsg = "获取报表数据出错！消息：" + (ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            // }
            // #endregion
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leaf.xNet;
using Newtonsoft.Json;
using System.Threading;

namespace Facebook_Group_Manager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridViewGroup.Rows.Clear();
            string data = Clipboard.GetText();
            var dataSplit = data.Split('\n');
            foreach (var item in dataSplit)
            {
                DataGridViewAdd(item);
            }
        }


        void DataGridViewAdd(string data)
        {
            if (data != null)
            {
                dataGridViewGroup.RowTemplate.Height = 30;
                int a = dataGridViewGroup.Rows.Add();
                dataGridViewGroup.Rows[a].Cells["cIndex"].Value = a + 1;
                dataGridViewGroup.Rows[a].Cells["cId"].Value = data.Replace("\r", "");
                dataGridViewGroup.Rows[a].Cells["cLink"].Value = "https://www.facebook.com/"+ data.Replace("\r", "");
                dataGridViewGroup.Rows[a].Cells["cName"].Value = "";
                dataGridViewGroup.Rows[a].Cells["cMember"].Value = "";
                dataGridViewGroup.Rows[a].Cells["cStatus"].Value = "";
            }
        }

        private void textBoxCookie_TextChanged(object sender, EventArgs e)
        {
            SettingsTool.Default.FacebookCookie = textBoxCookie.Text;
            SettingsTool.Default.Save();
        }

        private void textBoxToken_TextChanged(object sender, EventArgs e)
        {
            SettingsTool.Default.FacebookToken = textBoxToken.Text;
            SettingsTool.Default.Save();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            textBoxCookie.Text = SettingsTool.Default.FacebookCookie;
            textBoxToken.Text = SettingsTool.Default.FacebookToken;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string token = SettingsTool.Default.FacebookToken;
            string cookie = SettingsTool.Default.FacebookCookie;
            Thread threadBig = new Thread(() =>
            {
                //string tokenPage = GetPageToken(token, cookie);

                foreach (DataGridViewRow row in dataGridViewGroup.Rows)
                {
                    //Thread thread = new Thread(() =>
                    //{
                        AuraeColor auraeColor = new AuraeColor(AuraeColorEnum.Info);
                        row.DefaultCellStyle.ForeColor = auraeColor.AuraeForeColor;
                        row.DefaultCellStyle.BackColor = auraeColor.AuraeBackColor;
                        string id = row.Cells["cId"].Value.ToString();

                        GroupFacebook groupFacebook = CheckInfoGroup(token, cookie, id);

                        groupFacebook.Status = CheckGroupStatus(cookie, id);

                        row.Cells["cLink"].Value = groupFacebook.Link;
                        row.Cells["cName"].Value = groupFacebook.Name;
                        row.Cells["cMember"].Value = groupFacebook.Member;
                        row.Cells["cStatus"].Value = groupFacebook.Status;


                        if (groupFacebook.Status == "Xanh")
                        {
                            auraeColor = new AuraeColor(AuraeColorEnum.Success);
                        }
                        if (groupFacebook.Status == "Vàng")
                        {
                            auraeColor = new AuraeColor(AuraeColorEnum.Warning);
                        }
                        if (groupFacebook.Status == "Đỏ")
                        {
                            auraeColor = new AuraeColor(AuraeColorEnum.Danger);
                        }
                        row.DefaultCellStyle.ForeColor = auraeColor.AuraeForeColor;
                        row.DefaultCellStyle.BackColor = auraeColor.AuraeBackColor;

                    //});
                    //thread.IsBackground = true;
                    //thread.Start();
                }
            });
            threadBig.IsBackground = true;
            threadBig.Start();

        }


        public string GetPageToken(string token, string cookie)
        {
            try
            {
                #region Khai báo request
                HttpRequest request = new HttpRequest();
                request.KeepAlive = false;
                request.Cookies = new CookieStorage();

                request.AddHeader(HttpHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                request.AddHeader(HttpHeader.AcceptLanguage, "en-US,en;q=0.5");
                request.AddHeader("origin", "https://www.facebook.com");
                request.AddHeader("sec-fetch-dest", "empty");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-origin");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36";

                cookie = cookie.Replace(" ", "");
                var temp = cookie.Split(';');
                foreach (var item in temp)
                {
                    var temp2 = item.Split('=');
                    if (temp2.Count() > 1)
                    {
                        Cookie cookieTemp = new Cookie(temp2[0], temp2[1]) { Domain = ".facebook.com" };
                        request.Cookies.Add(cookieTemp);
                    }
                }
                #endregion


                string json = request.Get("https://graph.facebook.com/v18.0/me?fields=accounts.limit(10)%7Bname%2Cid%2Caccess_token%7D&access_token=" + token).ToString();

                dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

                foreach (var account in data.accounts.data)
                {
                    string name = account.name;
                    string id = account.id;
                    string tokenPage = account.access_token;

                    if (id == "215658238292867")
                    {
                        return tokenPage;
                    }
                }
            }
            catch
            {

            }
            return "";

        }


        public GroupFacebook CheckInfoGroup(string token, string cookie, string groupId)
        {
            GroupFacebook groupFacebook = new GroupFacebook();
            groupFacebook.Id = groupId;

            try
            {
                #region Khai báo request
                HttpRequest request = new HttpRequest();
                request.KeepAlive = false;
                request.Cookies = new CookieStorage();

                request.AddHeader(HttpHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                request.AddHeader(HttpHeader.AcceptLanguage, "en-US,en;q=0.5");
                request.AddHeader("origin", "https://www.facebook.com");
                request.AddHeader("sec-fetch-dest", "empty");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-origin");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36";

                cookie = cookie.Replace(" ", "");
                var temp = cookie.Split(';');
                foreach (var item in temp)
                {
                    var temp2 = item.Split('=');
                    if (temp2.Count() > 1)
                    {
                        Cookie cookieTemp = new Cookie(temp2[0], temp2[1]) { Domain = ".facebook.com" };
                        request.Cookies.Add(cookieTemp);
                    }
                }
                #endregion


                string json = request.Get($"https://graph.facebook.com/v18.0/{groupId}?fields=member_count%2Cid%2Cname%2Cprivacy&access_token=" + token).ToString();

                dynamic data = JsonConvert.DeserializeObject<dynamic>(json);

                groupFacebook.Name = data.name;
                groupFacebook.Member = data.member_count;
                groupFacebook.Link = "https://www.facebook.com/groups/" + groupId;


            }
            catch
            {

            }
            return groupFacebook;

        }

        public string CheckGroupStatus(string cookie, string groupId)
        {
            GroupFacebook groupFacebook = new GroupFacebook();
            groupFacebook.Id = groupId;

            try
            {
                #region Khai báo request
                HttpRequest request = new HttpRequest();
                request.KeepAlive = false;
                request.Cookies = new CookieStorage();

                request.AddHeader(HttpHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                request.AddHeader(HttpHeader.AcceptLanguage, "en-US,en;q=0.5");
                request.AddHeader("origin", "https://www.facebook.com");
                request.AddHeader("sec-fetch-dest", "empty");
                request.AddHeader("sec-fetch-mode", "cors");
                request.AddHeader("sec-fetch-site", "same-origin");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36";

                cookie = cookie.Replace(" ", "");
                var temp = cookie.Split(';');
                foreach (var item in temp)
                {
                    var temp2 = item.Split('=');
                    if (temp2.Count() > 1)
                    {
                        Cookie cookieTemp = new Cookie(temp2[0], temp2[1]) { Domain = ".facebook.com" };
                        request.Cookies.Add(cookieTemp);
                    }
                }
                #endregion


                string data = request.Get($"https://www.facebook.com/groups/{groupId}/group_quality/?referrer=group_admin_tab").ToString();

                if (data.Contains(@"Nh\u00f3m kh\u00f4ng c\u00f3 v\u1ea5n \u0111\u1ec1"))
                {
                    return "Xanh";
                }
                if (data.Contains(@"Nh\u00f3m c\u00f3 m\u1ed9t s\u1ed1 v\u1ea5n \u0111\u1ec1"))
                {
                    return "Vàng";
                }
                if (data.Contains(@"Nh\u00f3m g\u1eb7p r\u1ee7i ro"))
                {
                    return "Đỏ";
                }

                

            }
            catch
            {

            }
            return "Không rõ!";

        }
    }
}

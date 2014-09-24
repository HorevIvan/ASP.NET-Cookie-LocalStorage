using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET_Cookie_LocalStorage
{
    public partial class Cookie : System.Web.UI.Page
    {
        public static readonly String UserCookie = "user";

        public static readonly String UserNameCookie = "name";

        public Boolean IsKnownUser { private set; get; }

        public String UserName { private set; get; }

        public DateTime UserCookieExpiries { private set; get; }

        protected void Page_Load(Object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                ReadCookie();
            }
        }

        protected void EnterButton_Click(object sender, EventArgs e)
        {
            WriteCookie();
        }
        
        private void ReadCookie()
        {
            var userCookie = Request.Cookies["user"];

            if (userCookie != null && userCookie.HasKeys)
            {
                IsKnownUser = true;

                UserName = userCookie["name"];

                UserCookieExpiries = userCookie.Expires;
            }
            else
            {
                IsKnownUser = false;

                UserName = null;

                UserCookieExpiries = DateTime.MinValue;
            }
        }

        private void WriteCookie()
        {
            if (NameTextBox.Text.Length > 0)
            {
                var userCookie = Response.Cookies["user"];

                userCookie["name"] = NameTextBox.Text;

                userCookie.Expires = DateTime.Now.AddDays(1);
            }
        }
    }
}
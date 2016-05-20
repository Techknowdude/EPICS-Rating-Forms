using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DOC_Forms
{
    internal static class LoginHandler
    {
        private static string _currentUser = "";
        public static bool IsAdmin { get { return _currentUser == "admin"; } }

        public static bool IsLoggedIn
        {
            get { return _currentUser != ""; }
        }

        public static string CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public static bool TryLogin(String username, SecureString securePassword)
        {
            bool successful = false;
            try
            {
                successful = UserHandler.VerifyPass(username, securePassword);
                if (successful)
                {
                    _currentUser = username;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return successful;
        }

        public static void Logout()
        {
            CurrentUser = "";
        }
    }
}

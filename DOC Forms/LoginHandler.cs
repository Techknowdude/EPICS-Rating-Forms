using System;
using System.Collections.Generic;
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
    static class LoginHandler
    {
        private static string saveFile = "configurationData.xml";
        private static string _currentUser = "";


        public static bool IsLoggedIn { get { return _currentUser != ""; } }
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
                XDocument doc = CheckSaveFileExists();

                var users = doc.Element("users");

                foreach (var xElement in users.Elements())
                {
                    var name = xElement.Attribute("username").Value;
                    var pass = xElement.Attribute("pass").Value;

                    var hashedPass = Authenticator.ToInsecureString(Authenticator.DecryptString(pass));

                    if (username == name)
                    {
                        var enteredPass = Authenticator.ToInsecureString(securePassword);

                        if (enteredPass == hashedPass)
                        {
                            CurrentUser = name;
                            successful = true;
                        }
                        break;
                    }
                }
            }
            catch (Exception e)
            {

            }

            return successful;
        }

        public static void Logout()
        {
            CurrentUser = "";
        }

        public static void AddUser(String username, SecureString pass)
        {
            CheckSaveFileExists();
            XDocument doc = CheckSaveFileExists();

            XElement users = doc.Element("users");
            users.Add(new XElement("user",
                new XAttribute("username", username),
                new XAttribute("pass", Authenticator.EncryptString(pass))));
            doc.Save(saveFile);
           
        }

        public static void SetPassword(String username, SecureString newpass)
        {
            
            // open xml doc
            XDocument doc = CheckSaveFileExists();

            // get the list of users
            XElement users = doc.Element("users");

            // Search for a user with a matching name.
            var user = users.Elements().FirstOrDefault(x => x.Attribute("username").Value == username);

            // if that user exists, update the password
            if (user != null)
            {
                user.Attribute("pass").Value = Authenticator.EncryptString(newpass);

                doc.Save(saveFile);
            }
        }

        private static XDocument CheckSaveFileExists()
        {
            XDocument doc;

            try
            {
                doc = XDocument.Load(saveFile);
            }
            catch (Exception e)
            {
                doc = new XDocument();
                doc.Add(new XElement("users",
                    new XElement("user",new XAttribute("username","admin"),new XAttribute("pass",Authenticator.EncryptString( Authenticator.ToSecureString("password"))))));
                doc.Save(new FileStream(saveFile, FileMode.Create));
            }

            return doc;
        }
    }
}

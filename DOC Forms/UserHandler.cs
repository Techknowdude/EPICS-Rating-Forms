using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace DOC_Forms
{
    static class UserHandler
    {
        #region Fields

        private static string defaultPass = "password";
        private static string saveFile = "configurationData.xml";
        #endregion

        #region Properties
        public static string SaveFile
        {
            get { return saveFile; }
            set { saveFile = value; }
        }
        #endregion

        #region User Modifications
        public static void AddUser(String username, SecureString pass = null)
        {
            if (pass == null)
                pass = GetDefaultPass();
            XDocument doc = GetXMLFile();

            XElement users = doc.Element("users");
            users.Add(new XElement("user",
                new XAttribute("username", username),
                new XAttribute("pass", Authenticator.EncryptString(pass))));
            doc.Save(saveFile);

        }

        private static SecureString GetDefaultPass()
        {
            SecureString pass;
            pass = new SecureString();
            Array.ForEach(defaultPass.ToArray(), pass.AppendChar);
            return pass;
        }

        public static void RemoveUser(String username)
        {
            XDocument doc = GetXMLFile();

            XElement users = doc.Element("users");
            foreach (var xElement in users.Elements())
            {
                if (xElement.Attribute("username").Value == username)
                {
                    xElement.Remove();
                    break;
                }
            }

            doc.Save(saveFile);
        }

        public static void SetPassword(String username, SecureString newpass)
        {

            // open xml doc
            XDocument doc = GetXMLFile();

            // get the list of users
            XElement users = doc.Element("users");

            // Search for a user with a matching name.
            var user = users.Elements().FirstOrDefault(x => x.Attribute("username").Value == username);

            // if that user exists, update the password
            if (user != null)
            {
                var insecure = Authenticator.ToInsecureString(newpass);
                var encryptedPass = Authenticator.EncryptString(newpass);
                user.Attribute("pass").Value = encryptedPass;

                doc.Save(saveFile);
            }
        }

        public static bool VerifyPass(string username, SecureString securePassword)
        {
            bool isVerified = false;
            XDocument doc = GetXMLFile();

            var users = doc.Element("users");

            foreach (var xElement in users.Elements().Where(x => x.Attribute("username").Value == username))
            {
                var pass = xElement.Attribute("pass").Value;

                var decrypted = Authenticator.DecryptString(pass);

                isVerified = Authenticator.MatchPasswords(decrypted, securePassword);
                break;
            }

            return isVerified;
        }
        #endregion
        

        /// <summary>
        /// A safe retrieval of the XML file that contains the user login info.
        /// Creates a new XML file if none exists.
        /// </summary>
        /// <returns></returns>
        internal static XDocument GetXMLFile()
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
                    new XElement("user", new XAttribute("username", "admin"), new XAttribute("pass", Authenticator.EncryptString(Authenticator.ToSecureString("password"))))));
                doc.Save(new FileStream(saveFile, FileMode.Create));
            }

            return doc;
        }

    }

    public class UserList : ObservableObject
    {
        private ObservableCollection<User> _users;
        private string _newUsername;
        private SecureString _newPassword;

        public static UserList Refresh()
        {
            return new UserList(UserHandler.GetXMLFile());
        }

        public UserList(XDocument doc = null)
        {
            if (doc == null)
                doc = UserHandler.GetXMLFile();

            _users = new ObservableCollection<User>();
            var docUsers = doc.Element("users");
            foreach (var xElement in docUsers.Elements())
            {
                _users.Add(User.CreateUser(xElement.Attribute("username").Value));
            }
        }
        public UserList()
        {
            XDocument doc = UserHandler.GetXMLFile();

            _users = new ObservableCollection<User>();
            var docUsers = doc.Element("users");
            foreach (var xElement in docUsers.Elements())
            {
                _users.Add(User.CreateUser(xElement.Attribute("username").Value));
            }
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public String NewUsername
        {
            get { return _newUsername; }
            set
            {
                _newUsername = value;
                RaisePropertyChangedEvent();
            }
        }

        public ICommand AddUserCommand
        {
            get { return new DelegateCommand(AddUser); }
        }

        public ICommand SetPasswordCommand
        {
            get { return new DelegateCommand(SetPassword);}
        }

        public ICommand DeleteCommand { get { return new DelegateCommand(Delete); } }

        private void SetPassword(object pass)
        {
            if(pass is SecureString)
                UserHandler.SetPassword("admin",(SecureString)pass);
        }

        private void AddUser()
        {
            if (Users.All(x => x.Username != NewUsername))
            {
                UserHandler.AddUser(NewUsername);
                Users.Add(User.CreateUser(NewUsername));
            }
            else
            {
                MessageBox.Show("User already exists!");
            }
            NewUsername = "";
        }

        public void Delete(object obj)
        {
            var username = obj as String;
            if (username != "admin")
            {
                UserHandler.RemoveUser(username);
                Users.Remove(User.CreateUser(username));
            }
            else
            {
                MessageBox.Show("Cannot delete the admin");
            }
        }
    }

    public class User : ObservableObject
    {
        private String _username;

        public static User CreateUser(string username)
        {
            return new User(username);
        }

        User(string username)
        {
            _username = username;
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChangedEvent();
            }
        }

        public ICommand ResetCommand
        {
            get { return new DelegateCommand(Reset); }
        }

        private void Reset()
        {
            string pass = "password";
            SecureString defaultPass = new SecureString();
            Array.ForEach(pass.ToArray(), defaultPass.AppendChar);

            UserHandler.SetPassword(_username, defaultPass);

            MessageBox.Show("Password reset");
        }

        public override bool Equals(object obj)
        {
            var otherUser = obj as User;
            if(otherUser != null)
                return Equals(otherUser);

            return base.Equals(obj);
        }

        protected bool Equals(User other)
        {
            return string.Equals(_username, other._username);
        }

        public override int GetHashCode()
        {
            return (_username != null ? _username.GetHashCode() : 0);
        }
    }
}

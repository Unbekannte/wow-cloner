using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace copyWoWtoVM
{
    class QSnode
    {
        public string proxyIP;
        public string emailFull;
        public string WoWX;
        public string Password;
        public string Nick;
        public string Realm;

        private string fullPath;

        public QSnode(string emailfull, string wowx, string password, string nick, string realm, string ip = null)
        {
            emailFull = emailfull;
            WoWX = wowx;
            Password = password;
            Nick = nick;
            Realm = realm;
            proxyIP = ip;
        }

        public QSnode(string FullPath)
        {
            fullPath = FullPath;
            LoadQSfromFile(fullPath);
        }

        public void Delete()
        {
            File.Delete(fullPath);
        }

        public void LoadQSfromFile(string fullPath)
        {
            var doc = XDocument.Load(fullPath);

            if (doc.Root == null)
            {
                Logg.Log("Не удалось загрузить настройки из файла, файл пуст.");
                return;
            }

            if (doc.Root.Element("emailFull") != null)
                this.emailFull = doc.Root.Element("emailFull").Value;
            if (doc.Root.Element("WoWX") != null)
                this.WoWX = doc.Root.Element("WoWX").Value;
            if (doc.Root.Element("Password") != null)
                this.Password = doc.Root.Element("Password").Value;
            if (doc.Root.Element("Nick") != null)
                this.Nick = doc.Root.Element("Nick").Value;
            if (doc.Root.Element("Realm") != null)
                this.Realm = doc.Root.Element("Realm").Value;
            if (doc.Root.Element("proxyIP").Value != null)
                this.proxyIP = doc.Root.Element("proxyIP").Value;

        }
    }
}

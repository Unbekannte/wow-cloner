using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static copyWoWtoVM.Logg;

namespace copyWoWtoVM
{
    class myProxy
    {
        public string Adress;
        public string Port;
        public string ProxyType;
        public bool Auth;
        public string Login;
        public string Password;

        public myProxy(string adress, string port = "1080", string proxyType = "SOCKS5", bool auth = true, string login = "k_20096", string password = "segdj5rydrfg5")
        {
            if (string.IsNullOrEmpty(adress))
            {
                MessageBox.Show("Адресс не может быть пустым");
                return;
            }
            Adress = adress;
            Port = port;
            ProxyType = proxyType;
            Auth = auth;
            Login = login;
            Password = password;
        }

        public myProxy() { }

        static public void SaveProxyList(List<myProxy> proxyList, string path)
        {
            XDocument doc = new XDocument();
            XElement library = new XElement("proxyList");
            doc.Add(library);
            foreach (var prox in proxyList)
            {
                //создаем элемент "track"
                XElement proxy = new XElement("proxy");
                //добавляем необходимые атрибуты
                proxy.Add(new XAttribute("Adress", prox.Adress));
                proxy.Add(new XAttribute("Port", prox.Port));
                proxy.Add(new XAttribute("ProxyType", prox.ProxyType));
                proxy.Add(new XAttribute("Login", prox.Auth));
                proxy.Add(new XAttribute("Login", prox.Login));
                proxy.Add(new XAttribute("Password", prox.Password));

                library.Add(proxy);
            }
            doc.Save(path);
            Log("proxyList сохранен.");
        }

        static public List<myProxy> LoadProxyList(string path)
        {
            List<myProxy> proxyList = new List<myProxy>();
            //читаем данные из файла
            XDocument doc = XDocument.Load(path);
            //проходим по каждому элементу в найшей library
            //(этот элемент сразу доступен через свойство doc.Root)
            foreach (XElement el in doc.Root.Elements())
            {
                myProxy prox = new myProxy();
                prox.Adress = el.Attribute("Adress").Value;
                prox.Port = el.Attribute("Port").Value;
                prox.ProxyType = el.Attribute("ProxyType").Value;
                if (el.Attribute("Auth").Value == "false")
                    prox.Auth = false;
                else prox.Auth = true;
                prox.Login = el.Attribute("Login").Value;
                prox.Password = el.Attribute("Password").Value;

                proxyList.Add(prox);
            }
            Log("proxyList загружен.");
            return proxyList;
        }

        static public void addProxy(List<myProxy> proxyList, string adress, string port, string proxytype, bool auth, string login, string password)
        {
            if (proxyList.Any(a => a.Adress == adress))
            {
                //есть такие, ниче не делаем
            }
            else
            {
                proxyList.Add(new myProxy(adress, port, proxytype, auth, login, password));
            }
        }

        static public myProxy FindProxyInListByAdress(List<myProxy> proxList, string adress)
        {
            foreach (var prox in proxList)
            {
                if (prox.Adress == adress)
                {
                    return prox;
                }
            }
            MessageBox.Show("Нужного прокси нет в списке");
            return null;
        }
    }
}

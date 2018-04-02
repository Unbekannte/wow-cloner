using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using copyWoWtoVM;
using static copyWoWtoVM.Logg;
using static copyWoWtoVM.myProxy;

namespace copyWoWtoVM
{
    class ReadWrite_ProxyXML
    {
        static public void deleteTop_Rule_Ever_and_hisProxy(XDocument doc)
        {
            if (checkTop_Rule_Ever(doc))
            {
                IEnumerable<XElement> rules = doc.Root.Elements("RuleList").Descendants("Rule").Where(t => t.Element("Name").Value == "Top_Rule_Ever").ToList();
                foreach (XElement t in rules)
                {
                    try
                    {
                        XElement prox = doc.Root.Element("ProxyList").Elements("Proxy").Where(a => a.Attribute("id").Value == t.Element("Action").Value).First();
                        prox.Remove();
                    }
                    catch (Exception)
                    {
                        Log("связанные с этим правилом прокси не найдены");
                    }
                    t.Remove();
                }
                deleteCrap_Defaults(doc);
                //doc.Save(path);
            }
        }

        static public void deleteProxyes777(XDocument doc)
        {
            IEnumerable<XElement> rules = doc.Root.Elements("ProxyList").Descendants("Proxy").Where(t => t.Attribute("id").Value == "777").ToList();
            foreach (XElement t in rules)
            {
                t.Remove();
            }
            //doc.Save(path);
        }

        static public void deleteTop_Rule_Ever(XDocument doc)
        {
            if (checkTop_Rule_Ever(doc))
            {
                IEnumerable<XElement> rules = doc.Root.Elements("RuleList").Descendants("Rule").Where(t => t.Element("Name").Value == "Top_Rule_Ever").ToList();
                foreach (XElement t in rules)
                {
                    t.Remove();
                }
                deleteCrap_Defaults(doc);
                //doc.Save(path);
            }
        }

        static public void deleteCrap_Defaults(XDocument doc)
        {
            IEnumerable<XElement> rules = doc.Root.Elements("RuleList").Descendants("Rule").Where(t => t.Element("Name").Value == "Default").ToList();
            foreach (XElement t in rules)
            {
                try
                {
                    t.Remove();
                }
                catch (Exception)
                {

                    //throw;
                }
            }
        }


        static public void printNameId_value(XDocument doc)
        {
            // richTextBox1.Clear();
            //XDocument doc = XDocument.Load(path);
            Log("Proxies :");
            foreach (XElement el in doc.Root.Elements("ProxyList").Elements("Proxy"))
            {
                //   var sss = el.FirstNode.ToString();
                Log($"id = {el.Attribute("id").Value} \t {el.Element("Address").Value} \t" + findRules(doc, el.Attribute("id").Value));
            }
            /*log("Rules :");
            foreach (XElement el in doc.Root.Elements("RuleList").Elements("Rule"))
            {
                try { log($"id = {el.Element("Action").Value} \t <{el.Element("Name").Value}> \t {el.Element("Applications").Value}"); }
                catch (Exception) {}
            }*/
        }

        static public string findRules(XDocument doc, string _id)
        {
            var result = "";
            var rulesARR = doc.Root.Elements("RuleList").Elements("Rule");
            foreach (var el in rulesARR)
            {
                if (el.Element("Action").Value == _id)
                {
                    result += "\t>> ";
                    if (!string.IsNullOrEmpty(result))
                        result += "  ";
                    result += el.Element("Applications").Value;
                }

            }
            return result;
        }

        static public bool checkTop_Rule_Ever(XDocument doc)
        {
            //XDocument doc = XDocument.Load(path);

            foreach (XElement el in doc.Root.Elements("RuleList").Elements("Rule"))
            {
                if (el.Element("Name").Value == "Top_Rule_Ever")
                    return true;
            }
            return false;
        }

        static public bool checkProxyServerByAdress(XDocument doc, string address)      //true если существует
        {
            //XDocument doc = XDocument.Load(path);

            foreach (XElement el in doc.Root.Elements("ProxyList").Elements("Proxy"))
            {
                if (el.Element("Address").Value == address)
                    return true;
            }
            return false;
        }

        static public myProxy GetProxyByAddress(string address, List<myProxy> proxyList)
        {
            return proxyList.First(a => a.Adress == address);
        }

        static public string getProxyID_byAddress(XDocument doc, string address)
        {
            return doc.Root.Element("ProxyList").Elements("Proxy").Where(a => a.Element("Address").Value == address).First().Attribute("id").Value;
        }

        static public void ChangeEncryptionMode_Disabled(XDocument doc)
        {
            try
            {
                if (doc.Root.Element("Options").Element("Encryption").Attribute("mode").Value != "disabled")
                {
                    doc.Root.Element("Options").Element("Encryption").Attribute("mode").Value = "disabled";
                }
            }
            catch (Exception ex)
            {
                //throw;
            }

        }

        //true - если добавил, false - если уже существует
        static public bool addProxyToProxyfier(XDocument doc, myProxy proxx, string _id = "777", string options = "48")
        {
            if (!checkProxyServerByAdress(doc, proxx.Adress))
            {
                // XDocument doc = XDocument.Load(path);
                XElement proxList = doc.Root.Element("ProxyList"); // new XElement("ProxyList");
                //int maxId = doc.Root.Elements("track").Max(t => Int32.Parse(t.Attribute("id").Value));
                XElement prox = new XElement("Proxy",
                    new XAttribute("id", _id),
                    new XAttribute("type", proxx.ProxyType),
                    new XElement("Address", proxx.Adress),
                    new XElement("Port", proxx.Port),
                    new XElement("Options", options),
                    new XElement("Authentication", new XAttribute("enabled", proxx.Auth),
                        new XElement("Username", proxx.Login), new XElement("Password", proxx.Password)));
                proxList.Add(prox);
                //doc.Root.Add();.Elements("ProxyList").Add();
                // doc.Save(path);
                return true;
            }
            else return false;
        }

        static public int GetMinId(XDocument doc)
        {
            int minId = 1;
            try
            {
                minId = doc.Root.Element("ProxyList").Elements("Proxy").Min(t => Int32.Parse(t.Attribute("id").Value));
            }
            catch (Exception)
            {
                //throw;
            }
            return minId;
        }

        static public int GetMaxId(XDocument doc)
        {
            int maxId = 100;
            try
            {
                maxId = doc.Root.Element("ProxyList").Elements("Proxy").Max(t => Int32.Parse(t.Attribute("id").Value));
            }
            catch (Exception)
            {
                //throw;
            }
            return maxId;
        }

        static bool ruleAlreadyExists(XDocument doc, string progName, string idProxy, string profileName)
        {
            if (doc.Root.Element("RuleList").Elements("Rule").Any(a =>
                    a.Attribute("enabled").Value == "true" &&
                    a.Element("Name").Value == profileName &&
                    a.Element("Applications").Value.ToLower() == progName.ToLower() &&
                    a.Element("Action").Value == idProxy))
            {
                Log("Proxifier Rule уже существует.");
                return true;
            }
            else if (doc.Root.Element("RuleList").Elements("Rule").Any(a =>
                    a.Attribute("enabled").Value == "true" &&
                    a.Element("Name").Value == profileName &&
                    a.Element("Applications").Value.ToLower() == progName.ToLower()))
            {
                MessageBox.Show(
                    $"ВНИМАНИЕ!\r\nУже существует правило с таким же именем \r\nи идентичными целевыми программами. Проверьте профиль\r\n{profileName} для {progName}\r\nпосле завершения настройки");
                return false;
            }
            else
            {
                return false;
            }
        }

        static public bool addRuleToProxyfier(XDocument doc, string progName = "chrome.exe", string idProxy = "777", string profileName = "Top_Rule_Ever")  //true если правило было дбавлено
        {
            //  XDocument doc = XDocument.Load(path);

            if (!ruleAlreadyExists(doc, progName, idProxy, profileName))
            {
                XElement ruleList = doc.Root.Element("RuleList");// new XElement("ProxyList");
                                                                 //int maxId = doc.Root.Elements("track").Max(t => Int32.Parse(t.Attribute("id").Value));
                XElement rule = new XElement("Rule",
                    new XAttribute("enabled", "true"),
                    new XElement("Name", profileName),
                    new XElement("Applications", progName),
                    new XElement("Action", new XAttribute("type", "Proxy"), idProxy));
                ruleList.Add(rule);
                //doc.Root.Add();.Elements("ProxyList").Add();
                // doc.Save(path);
                Log("Правило добавлено в файл.");
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}

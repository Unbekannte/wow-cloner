using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace copyWoWtoVM
{
    class PathSettings
    {
        public string StartTab;
        public string Mini_pathSource;
        public string Mini_pathDest;
        public string Mini_pathHB;
        public string Mini_pathVM;
        public string Full_pathSource;
        public string Full_pathDest;
        public string Full_pathHB;
        public string Full_pathVM;
        public string settingsPath;
        private XDocument doc;

        static public Form form1 = new Form1();

        public PathSettings() { }

        public PathSettings(string fileFullPath)
        {
            Load(fileFullPath);
        }

        private void CreateDefaultFile()
        {
            settingsPath = @"WoWCloner_SETTINGS.xml";

            if (!File.Exists(settingsPath) || File.ReadAllText(settingsPath).Length < 50)
            {
                XDocument doc = new XDocument(new XElement("QS_PathSetting"));
                doc.Root.Add(new XElement("StartTab", "Mini"));
                doc.Root.Add(new XElement("Mini_pathSource", @"Z:\VM\wow1"));
                doc.Root.Add(new XElement("Mini_pathDest", @"C:\wow"));
                doc.Root.Add(new XElement("Mini_pathHB", @"Z:\VM\zzzx"));
                doc.Root.Add(new XElement("Mini_pathVM", @"Z:\VM"));
                doc.Root.Add(new XElement("Full_pathSource", @"D:\VM\wow1"));
                doc.Root.Add(new XElement("Full_pathDest", @"D:\GAMES\wow"));
                doc.Root.Add(new XElement("Full_pathHB", @"D:\VM\zzzx"));
                doc.Root.Add(new XElement("Full_pathVM", @"D:\VM"));

                doc.Save(settingsPath);
                Logg.Log($"Стандартный {settingsPath} файл создан.");
            }
            else
            {
                Logg.Log("Файл настроек существует.");
            }
        }

        public void Save(string startTab, string Mini_pathSource, string Mini_pathDest, string Mini_pathHB, string Mini_pathVM, string Full_pathSource, string Full_pathDest, string Full_pathHB, string Full_pathVM)
        {

            XDocument doc = new XDocument(new XElement("QS_PathSetting"));
            doc.Root.Add(new XElement("StartTab", startTab));
            doc.Root.Add(new XElement("Mini_pathSource", Mini_pathSource));
            doc.Root.Add(new XElement("Mini_pathDest", Mini_pathDest));
            doc.Root.Add(new XElement("Mini_pathHB", Mini_pathHB));
            doc.Root.Add(new XElement("Mini_pathVM", Mini_pathVM));
            doc.Root.Add(new XElement("Full_pathSource", Full_pathSource));
            doc.Root.Add(new XElement("Full_pathDest", Full_pathDest));
            doc.Root.Add(new XElement("Full_pathHB", Full_pathHB));
            doc.Root.Add(new XElement("Full_pathVM", Full_pathVM));

            doc.Save(settingsPath);
            Logg.Log($"{settingsPath} файл создан.");

        }

        public void Load(string fullPath)
        {
            settingsPath = fullPath;

            if (!File.Exists(settingsPath))
            {
                CreateDefaultFile();    
            }

            Thread.Sleep(50);

            doc = XDocument.Load(settingsPath);

            if (doc.Root == null)
            {
                Logg.Log("Не удалось загрузить настройки из файла, файл пуст.");
                return;
            }

            if (doc.Root.Element("StartTab") != null)
                this.StartTab = doc.Root.Element("StartTab").Value;
            if (doc.Root.Element("Mini_pathSource") != null)
                this.Mini_pathSource = doc.Root.Element("Mini_pathSource").Value;
            if (doc.Root.Element("Mini_pathDest") != null)
                this.Mini_pathDest = doc.Root.Element("Mini_pathDest").Value;
            if (doc.Root.Element("Mini_pathHB") != null)
                this.Mini_pathHB = doc.Root.Element("Mini_pathHB").Value;
            if (doc.Root.Element("Mini_pathVM") != null)
                this.Mini_pathVM = doc.Root.Element("Mini_pathVM").Value;
            if (doc.Root.Element("Full_pathSource") != null)
                this.Full_pathSource = doc.Root.Element("Full_pathSource").Value;
            if (doc.Root.Element("Full_pathDest") != null)
                this.Full_pathDest = doc.Root.Element("Full_pathDest").Value;
            if (doc.Root.Element("Full_pathHB") != null)
                this.Full_pathHB = doc.Root.Element("Full_pathHB").Value;
            if (doc.Root.Element("Full_pathVM") != null)
                this.Full_pathVM = doc.Root.Element("Full_pathVM").Value;

        }
    }
}

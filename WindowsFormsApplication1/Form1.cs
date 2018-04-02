using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using copyWoWtoVM;
using static copyWoWtoVM.Logg;
using static copyWoWtoVM.myProxy;
using static copyWoWtoVM.ReadWrite_ProxyXML;
using static copyWoWtoVM.PathSettings;
using static copyWoWtoVM.CharSettings;

namespace copyWoWtoVM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Logg.richTB = richTextBox_Log_mini;
            PathSettings.form1 = this;
        }

        //private string _diskName;       //откуда будем копировать вов, аддоны, конфиги, настроки
        //string[] _pathes = new string[4];        //0-откуда  1-куда  2-гдехб  3-папка Z:\VM
        List<QSnode> _QSnodes = new List<QSnode>();
        ProgressBar _progressBar = new ProgressBar();
        Label _statusLabel = new Label();
        PathSettings _pathSettings = new PathSettings();


        private void Form1_Load(object sender, EventArgs e)
        {
            //tabControl1.SelectedTab = tab_full;
            listViewEx1.View = View.Details;

            _pathSettings.Load(@"WoWCloner_SETTINGS.xml");
            string temp1 = _pathSettings.Mini_pathSource;
            string temp2 = _pathSettings.Mini_pathDest;
            string temp3 = _pathSettings.Mini_pathHB;
            string temp4 = _pathSettings.Mini_pathVM;
            string temp5 = _pathSettings.Full_pathSource;
            string temp6 = _pathSettings.Full_pathDest;
            string temp7 = _pathSettings.Full_pathHB;
            string temp8 = _pathSettings.Full_pathVM;

            textBox_Source_mini.Text = temp1;
            textBox_Dest_mini.Text = temp2;
            textBox_PathHB_mini.Text = temp3;
            textBox_PathVM_mini.Text = temp4;
            textBox_Source_full.Text = temp5;
            textBox_Dest_full.Text = temp6;
            textBox_PathHB_full.Text = temp7;
            textBox_PathVM_full.Text = temp8;

            if (_pathSettings.StartTab == "Full")
                tabControl1.SelectedTab = tab_full;
            else
                tabControl1.SelectedTab = tab_mini;
            tabControl1_SelectedIndexChanged(sender, e);
            Log("Пути загружены.");


            string PathQSDirectory = "";
            string d = @"D:\VM\Dropbox\AccManager\QuickSettings";
            string z = @"Z:\VM\Dropbox\AccManager\QuickSettings";
            string c = @"C:\VM\Dropbox\AccManager\QuickSettings";
            if (Directory.Exists(d))
                PathQSDirectory = d;
            else if (Directory.Exists(z))
                PathQSDirectory = z;
            else if (Directory.Exists(c))
                PathQSDirectory = c;
            LoadQuickSettings(PathQSDirectory);

        }

        #region EVENTS_etc

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pathSettings.Save(tabControl1.SelectedTab.Text, textBox_Source_mini.Text.Trim(), textBox_Dest_mini.Text.Trim(),
                textBox_PathHB_mini.Text.Trim(), textBox_PathVM_mini.Text.Trim(), textBox_Source_full.Text.Trim(),
                textBox_Dest_full.Text.Trim(), textBox_PathHB_full.Text.Trim(), textBox_PathVM_full.Text.Trim());
            Thread.Sleep(100);
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_mini)
            {
                this.Size = new Size(400, 520);
                checkBox_mini_CheckedChanged(sender, e);
                // _progressBar = progressBar_Status_mini;
                // _statusLabel = label_Status_mini;
                Logg.richTB = richTextBox_Log_mini;
            }
            else if (tabControl1.SelectedTab == tab_full)
            {
                //this.Size = new Size(505, 700);
                checkBox_full_ProxyAndRelog_CheckedChanged(sender, e);

                // _progressBar = progressBar_Status_full;
                // _statusLabel = label_Status_full;
                Logg.richTB = richTextBox_Log_full;
            }
        }

        private string selectPath(string startSelectedPath)
        {
            _progressBar.Value = 0;
            _statusLabel.Text = "Cостояние";
            _statusLabel.ForeColor = Color.Black;
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (Directory.Exists(startSelectedPath))
            {
                dialog.SelectedPath = startSelectedPath;
            }
            else if (Directory.Exists(@"Z:\"))
            {
                dialog.SelectedPath = @"Z:\VM";
            }
            else if (Directory.Exists(@"D:\"))
            {
                dialog.SelectedPath = @"D:\VM";
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return startSelectedPath;
        }

        #endregion EVENTS_etc




        #region MINI_TAB
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////    MINI START    ////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region EVENTS_etc


        private void textBox_Source_mini_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_Source_mini.Text = selectPath(textBox_Source_mini.Text);
        }
        private void textBox_Dest_mini_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_Dest_mini.Text = selectPath(textBox_Dest_mini.Text);
        }
        private void textBox_PathHB_mini_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_PathHB_mini.Text = selectPath(textBox_PathHB_mini.Text);
        }
        private void textBox_PathVM_mini_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_PathVM_mini.Text = selectPath(textBox_PathVM_mini.Text);
        }


        private void checkBox_mini_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Proxifier_mini.Checked || checkBox_Relogger_mini.Checked)
            {
                comboBox_QS_mini.Visible = true;
                checkBox_225_15_mini.Visible = true;
            }
            else
            {
                comboBox_QS_mini.Visible = false;
                checkBox_225_15_mini.Visible = false;
            }
        }

        private void comboBox_QS_mini_SelectedIndexChanged(object sender, EventArgs e)
        {
            // --------------------------
        }

        private void richTextBox_Log_mini_TextChanged(object sender, EventArgs e)
        {
            scrollDown(richTextBox_Log_mini);
        }

        private void textBox_TextChanged_mini(object sender, EventArgs e)
        {
            _pathSettings.Mini_pathSource = textBox_Source_mini.Text.Trim();
            _pathSettings.Mini_pathDest = textBox_Dest_mini.Text.Trim();
            _pathSettings.Mini_pathHB = textBox_PathHB_mini.Text.Trim();
            _pathSettings.Mini_pathVM = textBox_PathVM_mini.Text.Trim();
            //button_Delete_mini.Text = "удалить " + _pathSettings.Mini_pathDest;
            string name = Regex.Match(_pathSettings.Mini_pathDest, @"\\(\w+)$").Groups[1].Value;
            button_Delete_mini.Text = $"Удалить \r\n{_pathSettings.Mini_pathDest}\\";
            button_Copy_mini.Text = $"Копировать \r\n{_pathSettings.Mini_pathDest}\\";
        }

        #endregion

        private void button_Delete_mini_Click(object sender, EventArgs e)      //detele wow
        {
            DeleteFolder(_pathSettings.Mini_pathDest);
        }

        private void button_Postal_mini_Click(object sender, EventArgs e)          //postal
        {
            try
            {
                InstallPostal(_pathSettings.Mini_pathVM + @"\Dropbox\InstallPack\addons\Postal", _pathSettings.Mini_pathDest, _statusLabel, _progressBar);
            }
            catch (Exception ex)
            {
                _statusLabel.Text = "Не удалось установить.";
                Log("Не удалось установить.");
                _statusLabel.ForeColor = Color.Red;
                MessageBox.Show(ex.Message);
            }
        }


        private void button_Auctinator_mini_Click(object sender, EventArgs e)
        {
            try
            {
                InstallAuctinator(_pathSettings.Mini_pathVM + @"\Dropbox\InstallPack\addons\Auctinator", _pathSettings.Mini_pathDest, _statusLabel, _progressBar);
            }
            catch (Exception ex)
            {
                label_Status_full.Text = "Не удалось установить.";
                Log("Не удалось установить.");
                label_Status_full.ForeColor = Color.Red;
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Copy_mini_Click(object sender, EventArgs e)          //copy wow
        {
            string WowexeFullPath = "wow.exe";
            try
            {
                WowexeFullPath = _pathSettings.Mini_pathDest + "\\Wow.exe";

                CopyWoW(_pathSettings.Mini_pathSource, _pathSettings.Mini_pathDest, _pathSettings.Mini_pathVM, _progressBar, _statusLabel);

                if (checkBox_Relogger_mini.Checked || checkBox_Proxifier_mini.Checked)
                {
                    QSnode selectedNode = _QSnodes.First(a => $"{a.Nick}-{a.Realm}" == Regex.Match(comboBox_QS_mini.SelectedItem.ToString(), @"^(\w*-\w*\s*\w*) \(").Groups[1].Value);
                    MakeSettings_Single(new Character(selectedNode.Nick, "", selectedNode.Realm, false), _pathSettings.Mini_pathHB);

                    if (checkBox_Relogger_mini.Checked)
                    {
                        try
                        {
                            AddHBRelogProfile(WowexeFullPath, _pathSettings.Mini_pathHB, selectedNode, checkBox_225_15_mini.Checked);
                        }
                        catch (Exception)
                        {
                            Log("ошибка при добавлении профиля");
                            // throw;
                        }
                    }

                    if (checkBox_Proxifier_mini.Checked)
                    {
                        string wowname = Regex.Match(WowexeFullPath, @"\\(\w+).exe").Groups[1].Value;
                        addProxifierProfile(_pathSettings.Mini_pathVM, wowname, selectedNode.proxyIP);
                    }

                }

            }
            catch (Exception ex)
            {
                _statusLabel.Text = "Ошибка при копировании";
                Log("Ошибка при копировании");
                _statusLabel.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(ex.Message);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////    MINI END    ////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
        #endregion MINI_TAB



        #region FULL_TAB
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////    FULL START    ////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region EVENTS_etc
        private void richTextBox_Log_full_TextChanged(object sender, EventArgs e)
        {
            scrollDown(richTextBox_Log_full);
        }

        private void textBox_Source_full_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_Source_full.Text = selectPath(textBox_Source_full.Text);
        }

        private void textBox_Dest_full_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_Dest_full.Text = selectPath(textBox_Dest_full.Text);
        }

        private void textBox_PathHB_full_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_PathHB_full.Text = selectPath(textBox_PathHB_full.Text);
        }
        private void textBox_PathVM_full_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_PathVM_full.Text = selectPath(textBox_PathVM_full.Text);
        }

        private void listBox_Available_full_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox_Available_full.SelectedIndex < 0) return;
            /*
            string line = listBox_Available_full.SelectedItem.ToString();
            string emailfull = Regex.Match(line, @"\((.+@.+)\s\|").Groups[1].Value;
            string wowx = Regex.Match(line, @"(WoW\d)").Groups[1].Value;
            var neededQS = _QSnodes.First(a => a.emailFull == emailfull && a.WoWX == wowx);
            listBox_Available_full.Items.RemoveAt(listBox_Available_full.SelectedIndex);
            listViewEx1.Items.Add($@"{neededQS.Nick}-{neededQS.Realm} ({neededQS.emailFull} | {neededQS.WoWX})");
            */
            CreateLineEx(listBox_Available_full.SelectedItem.ToString());
            //listViewEx1.Items.Add(listBox_Available_full.SelectedItem.ToString());
            listBox_Available_full.Items.RemoveAt(listBox_Available_full.SelectedIndex);
        }

        private void textBox_TextChanged_full(object sender, EventArgs e)
        {
            _pathSettings.Full_pathSource = textBox_Source_full.Text.Trim();
            _pathSettings.Full_pathDest = textBox_Dest_full.Text.Trim();
            _pathSettings.Full_pathHB = textBox_PathHB_full.Text.Trim();
            _pathSettings.Full_pathVM = textBox_PathVM_full.Text.Trim();
            string from = textBox_from_full.Text.Trim();
            string to = textBox_to_full.Text.Trim();
            string name = Regex.Match(_pathSettings.Full_pathDest, @"\\(\w+)$").Groups[1].Value;
            button_DeleteSome_full.Text = $"Удалить \r\n{_pathSettings.Full_pathDest}\\{name}{from}\\\r\n - \\{name}{to}\\";
            string parentFolder = "";
            if (_pathSettings.Full_pathDest.Length > 4 && new DirectoryInfo(_pathSettings.Full_pathDest).Parent != null)
                parentFolder = new DirectoryInfo(_pathSettings.Full_pathDest).Parent.Name;
            else
                parentFolder = "";
            button_DeleteAll_full.Text = $"Удалить все из \r\n\\{parentFolder}\\";
            button_CopySome_full.Text = $"Копировать \r\n{_pathSettings.Full_pathDest}\\{name}{from}\\\r\n - \\{name}{to}\\";
        }

        private void checkBox_full_ProxyAndRelog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Proxifier_full.Checked || checkBox_Relogger_full.Checked)
            {
                this.Size = new Size(750, 850);
                listViewEx1.Visible = true;
                listBox_Available_full.Visible = true;
               // richTextBox_Log_full.Location = new Point(4, 297);
                richTextBox_Log_full.Size = new Size(270, 203);// было 250, 173 ???
                richTextBox_Log_full.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            }
            else
            {
                this.Size = new Size(635, 700);
                listViewEx1.Visible = false;
                listBox_Available_full.Visible = false;
                //richTextBox_Log_full.Location = new Point(4, 297);
                richTextBox_Log_full.Size = new Size(this.Size.Width - 40, this.Height - richTextBox_Log_full.Location.Y - 80);
                richTextBox_Log_full.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

            }
        }

        private void checkBox_full_PostalAndAuc_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void radioButton_full_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void listViewEx1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewEx1.SelectedItems[0].Index < 0) return;
            listBox_Available_full.Items.Add(listViewEx1.SelectedItems[0].Text.ToString());
            listViewEx1.Items.RemoveAt(listViewEx1.SelectedItems[0].Index);
        }



        #endregion EVENTS_etc






        private void button_DeleteAll_full_Click(object sender, EventArgs e)
        {

            DirectoryInfo folder = new DirectoryInfo(_pathSettings.Full_pathDest).Parent;

            if (folder != null && folder.FullName.Length > 4)
            {
                foreach (var dir in folder.GetDirectories())
                {
                    dir.Delete();
                }
                //DeleteFolder(folder.FullName);
            }
            
        }

        private void button_DeleteSome_full_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox_from_full.Text);
            int b = Convert.ToInt32(textBox_to_full.Text);
            // 5 и 6
            List<DirectoryInfo> deleteList = new List<DirectoryInfo>();
            DirectoryInfo folder = new DirectoryInfo(_pathSettings.Full_pathDest).Parent;
            
            foreach (var dir in folder.GetDirectories())
            {
                for (int i = a; i <= b; i++)
                {
                    if (dir.FullName == _pathSettings.Full_pathDest + i.ToString())
                    {
                        deleteList.Add(dir);
                    }
                }
            }
            foreach (var dir in deleteList)
            {
                dir.Delete(true);
            }
            //
        }


        private void button_CopySome_full_Click(object sender, EventArgs e)          //clone wow
        {
            string WowexeFullPath = "";
            try
            {
                int a = Convert.ToInt32(textBox_from_full.Text);
                int b = Convert.ToInt32(textBox_to_full.Text);

                DirectoryInfo destDirectoryInfo = new DirectoryInfo(_pathSettings.Full_pathDest);

                List<Character> characters = new List<Character>();



                if ((checkBox_Relogger_full.Checked || checkBox_Proxifier_full.Checked) && listViewEx1.Items.Count > 0)
                {
                    for (int i = 0; i < listViewEx1.Items.Count; i++)
                    {
                        string str1 = Regex.Match(listViewEx1.Items[i].Text, @"^(\w*-\w*\s*\w*) \(").Groups[1].Value;
                        QSnode selectedNode = _QSnodes.First(o => $"{o.Nick}-{o.Realm}" == str1);
                        characters.Add(new Character(selectedNode.Nick, "", selectedNode.Realm, (listViewEx1.GetEmbeddedControl(1, i) as RadioButton).Checked));
                    }
                }

                MakeSettings_Multiple(characters, _pathSettings.Full_pathHB);

                for (int i = a; i <= b; i++)
                {
                    string wowname = destDirectoryInfo.Name + i;

                    CopyWoW(_pathSettings.Full_pathSource, (_pathSettings.Full_pathDest + i.ToString()), _pathSettings.Full_pathVM, _progressBar, _statusLabel);
                    File.Move(_pathSettings.Full_pathDest + i.ToString() + "\\Wow.exe", _pathSettings.Full_pathDest + i.ToString() + "\\" + wowname + ".exe");
                    File.Move(_pathSettings.Full_pathDest + i.ToString() + "\\Wow-64.exe", _pathSettings.Full_pathDest + i.ToString() + "\\" + wowname + "-64.exe");

                    if ((checkBox_Relogger_full.Checked || checkBox_Proxifier_full.Checked) && listViewEx1.Items.Count > 0)
                    {
                        //var egwgw = (listViewEx1.GetEmbeddedControl(1, 0) as ComboBox).Items;   // 2 столбец 1 строки, комбобокс для роли.
                        string str1 = Regex.Match(listViewEx1.Items[0].Text, @"^(\w*-\w*\s*\w*) \(").Groups[1].Value;
                        QSnode selectedNode = _QSnodes.First(o => $"{o.Nick}-{o.Realm}" == str1);
                        bool isLeader = (listViewEx1.GetEmbeddedControl(1, 0) as RadioButton).Checked;
                        bool tasks_255_15 = (listViewEx1.GetEmbeddedControl(2, 0) as CheckBox).Checked;

                        if (checkBox_Relogger_full.Checked)
                        {
                            try
                            {
                                WowexeFullPath = _pathSettings.Full_pathDest + i.ToString() + "\\" + wowname + ".exe";
                                AddHBRelogProfile(WowexeFullPath, _pathSettings.Full_pathHB, selectedNode, tasks_255_15);
                            }
                            catch (Exception)
                            {
                                Log("ошибка при добавлении профиля");
                                // throw;
                            }
                        }
                        if (checkBox_Proxifier_full.Checked)
                        {
                            addProxifierProfile(_pathSettings.Full_pathVM, wowname, selectedNode.proxyIP);
                        }
                        listViewEx1.Items[0].Remove();

                    }
                    else
                    {
                        if (checkBox_Relogger_full.Checked)
                        {
                            try
                            {
                                WowexeFullPath = _pathSettings.Full_pathDest + i.ToString() + "\\" + wowname + ".exe";
                                AddHBRelogProfile(WowexeFullPath, _pathSettings.Full_pathHB, new QSnode("@@@@@@@BATTLE.NET", "WoW", "qwer1234", "", "Ревущий фьорд"), false);
                            }
                            catch (Exception)
                            {
                                Log("ошибка при добавлении профиля");
                                // throw;
                            }
                        }
                        if (checkBox_Proxifier_full.Checked)
                        {
                            Log($"Закончились QSnodes.\r\nБыли созданы \\{_pathSettings.Full_pathDest + a.ToString()}\\ - \\{_pathSettings.Full_pathDest + (i - 1).ToString()}\\\r\n и пуской конфиг для \\{_pathSettings.Full_pathDest + i.ToString()}\\");
                            MessageBox.Show(
                                $"Закончились QSnodes.\r\nБыли созданы \\{_pathSettings.Full_pathDest + a.ToString()}\\ - \\{_pathSettings.Full_pathDest + (i - 1).ToString()}\\ и пуской конфиг для \\{_pathSettings.Full_pathDest + i.ToString()}\\");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                label_Status_full.Text = "Ошибка при копировании";
                Log("Ошибка при копировании");
                label_Status_full.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(ex.Message);
                //throw;
            }
        }




        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////    FULL END    ////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
        #endregion FULL_TAB

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        void DeleteFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                try
                {
                    _progressBar.Value = 0;
                    _statusLabel.Text = "Cостояние";
                    _statusLabel.ForeColor = Color.Black;
                    Directory.Delete(folderPath, true);
                    _progressBar.PerformStep();
                    _statusLabel.Text = "Удалено.";
                    Log("Удалено.");
                    _statusLabel.ForeColor = Color.Green;
                    Thread.Sleep(50);
                    _progressBar.Value = _progressBar.Maximum;
                }
                catch (Exception ex)
                {
                    _statusLabel.Text = "Не удалось удалить";
                    Log("Не удалось удалить");
                    _statusLabel.ForeColor = Color.Red;
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Log("Папки для удаления не существует.");
            }
        }

        void InstallPostal(string postal_FolderPath, string wow_FolderPath, Label statusLabel, ProgressBar progressBar)
        {
            //_diskName = Regex.Match(PATHES[1], @"(\w:\\)").Groups[1].Value;
            if (!Directory.Exists(postal_FolderPath) || !Directory.Exists(wow_FolderPath))
            {
                Log("Папки не существует!");
                return;
            }
            progressBar.Value = 0;
            statusLabel.Text = "Cостояние";
            statusLabel.ForeColor = Color.Black;
            progressBar.PerformStep();
            if (!Directory.Exists(wow_FolderPath + "\\Interface"))
            {
                Directory.CreateDirectory(wow_FolderPath + "\\Interface");
            }
            progressBar.PerformStep();
            if (!Directory.Exists(wow_FolderPath + "\\Interface\\AddOns"))
            {
                Directory.CreateDirectory(wow_FolderPath + "\\Interface\\AddOns");
            }
            progressBar.PerformStep();
            DirectoryCopy(postal_FolderPath, wow_FolderPath + "\\Interface\\AddOns\\Postal", true);
            progressBar.Value = progressBar.Maximum;
            statusLabel.Text = "Postal установлен.";
            Log("Postal установлен.");
            statusLabel.ForeColor = Color.Green;
        }



        void InstallAuctinator(string auctinator_FolderPath, string wow_FolderPath, Label statusLabel, ProgressBar progressBar)
        {
            if (!Directory.Exists(auctinator_FolderPath) || !Directory.Exists(wow_FolderPath))
            {
                Log("Папки не существует!");
                return;
            }
            progressBar.Value = 0;
            statusLabel.Text = "Cостояние";
            statusLabel.ForeColor = Color.Black;
            progressBar.PerformStep();
            if (!Directory.Exists(wow_FolderPath + "\\Interface"))
            {
                Directory.CreateDirectory(wow_FolderPath + "\\Interface");
            }
            progressBar.PerformStep();
            if (!Directory.Exists(wow_FolderPath + "\\Interface\\AddOns"))
            {
                Directory.CreateDirectory(wow_FolderPath + "\\Interface\\AddOns");
            }
            progressBar.PerformStep();
            DirectoryCopy(auctinator_FolderPath, wow_FolderPath + "\\Interface\\AddOns\\Auctionator", true);
            progressBar.Value = progressBar.Maximum;
            statusLabel.Text = "Auctionator установлен.";
            Log("Auctionator установлен.");
            statusLabel.ForeColor = System.Drawing.Color.Green;
        }

        void deleteFirstLineInRichTB(RichTextBox TB)
        {   //удаляем использованную строку
            if (!string.IsNullOrEmpty(TB.Text))
            {
                int start_index = TB.GetFirstCharIndexFromLine(0);
                int count = TB.Lines[0].Length;
                // Eat new line chars
                if (0 < TB.Lines.Length - 1)
                {
                    count += TB.GetFirstCharIndexFromLine(0 + 1) -
                             ((start_index + count - 1) + 1);
                }
                TB.Text = TB.Text.Remove(start_index, count);
            }
        }

        void addProxifierProfile(string path_VM, string wowName, string proxyAddress)
        {

            if (!Directory.Exists(path_VM))
            {
                Log("Папки не существует!");
                return;
            }
            // myProxy neededProxy = FindProxyInListByAdress(proxList, richTextBox_proxlist.Lines[0].Trim());

            try
            {
                List<myProxy> proxList = LoadProxyList(path_VM + @"\Dropbox\AccManager\proxyList.xml");
                myProxy neededProxy = GetProxyByAddress(proxyAddress, proxList);

                string Proxifier_Settings_File = $@"C:\Users\{Environment.UserName}\AppData\Roaming\Proxifier\Profiles\Default.ppx";
                XDocument doc = XDocument.Load(Proxifier_Settings_File);

                int maxId = GetMaxId(doc);
                string newId_str = (maxId + 1).ToString();

                ChangeEncryptionMode_Disabled(doc);

                if (!checkProxyServerByAdress(doc, proxyAddress))
                {//если такого еще нет, то делем новый ид+1
                    addProxyToProxyfier(doc, neededProxy, newId_str);
                }
                else
                {//если прокси уже есть в списке то запонимаем его ИД
                    newId_str = getProxyID_byAddress(doc, neededProxy.Adress);
                }

                if (addRuleToProxyfier(doc, $"{wowName}.exe ; {wowName}-32.exe; {wowName}-64.exe", newId_str, wowName) == false)
                {
                    Log("Файл профилей Proxifier не менялся, применять настройки не будем.");
                    return;
                }

                deleteCrap_Defaults(doc);

                doc.Save(Proxifier_Settings_File);

                Log("файл с настройками проксифайера сохранен");

                Process.Start($@"C:\Users\{Environment.UserName}\AppData\Roaming\Proxifier\Profiles\Default.ppx");

                Click_OK_Proxifier();   //принимает изменение настроек

                Log("настройки проксифайера применены");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                //throw;
            }

        }


        private void CopyWoW(string path_Source, string path_Dest, string path_VM, ProgressBar progressBar, Label statusLabel)
        {
            if (!Directory.Exists(path_Source) || !Directory.Exists(Directory.GetParent(path_Dest).FullName) || !Directory.Exists(path_VM))
            {
                Log("Путь не существует!");
                return;
            }
            //_diskName = Regex.Match(path_Source, @"(\w:\\)").Groups[1].Value;
            progressBar.Value = 0;
            statusLabel.Text = "Cостояние";
            statusLabel.ForeColor = Color.Black;
            if (!Directory.Exists(path_Dest))
            {
                Directory.CreateDirectory(path_Dest);
            }
            else
            {
                Log($"Папка {path_Dest} уже существует. Сначала удалите ее.");
                DialogResult result1 = MessageBox.Show($"Папка {path_Dest} уже сущуствует.\r\n Удалить ее или прервать копирование?", "Dialog", MessageBoxButtons.OKCancel);
                if (result1 == DialogResult.OK)
                {
                    DeleteFolder(path_Dest);
                    Thread.Sleep(50);
                    Directory.CreateDirectory(path_Dest);
                }
                else
                    return;
            }
            progressBar.PerformStep();


            DirectoryInfo dir = new DirectoryInfo(path_Source);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(path_Dest, file.Name);
                file.CopyTo(temppath, false);
            }
            progressBar.PerformStep();


            DirectoryCopy(path_Source + "\\Utils", path_Dest + "\\Utils", true);
            DirectoryCopy(path_Source + "\\Data\\config", path_Dest + "\\Data\\config", true);
            DirectoryCopy(path_Source + "\\Data\\indices", path_Dest + "\\Data\\indices", true);
            progressBar.PerformStep();


            if (!Directory.Exists(path_Dest + "\\Data\\data"))
            {
                Directory.CreateDirectory(path_Dest + "\\Data\\data");
            }
            DirectoryInfo data_dir = new DirectoryInfo(path_Source + "\\Data\\data");
            foreach (FileInfo file in data_dir.GetFiles("*.idx"))
            {
                string temppath = Path.Combine(path_Dest + "\\Data\\data", file.Name);
                file.CopyTo(temppath, true);
            }
            /*  foreach (FileInfo file in data_dir.GetFiles("data.*"))
              {
                  string temppath = Path.Combine(path_Source + "\\Data\\data", file.Name);
                  string temppathlink = Path.Combine(path_Dest + "\\Data\\data", file.Name);
              }*/
            File.Copy(path_Source + "\\Data\\data\\shmem", path_Dest + "\\Data\\data\\shmem");

            Log("папочки скопированы.");

            progressBar.PerformStep();


            StreamWriter myfile = new StreamWriter("C:\\datacopy.bat", true);
            foreach (FileInfo file in data_dir.GetFiles("data.*"))
            {
                myfile.WriteLine("MKLINK " + path_Dest + "\\Data\\data\\" + file.Name + " " + path_Source + "\\Data\\data\\" + file.Name);
            }
            myfile.Close();

            Process prc = new Process();
            prc = Process.Start("C:\\datacopy.bat");
            prc.WaitForExit();//ожидание завершения процесса
            File.Delete("C:\\datacopy.bat");

            Thread.Sleep(50);
            Log("линки созданы");
            progressBar.PerformStep();


            Directory.CreateDirectory(path_Dest + "\\WTF");
            if (tabControl1.SelectedTab == tab_mini && radioButton_CopyWTF_mini.Checked || tabControl1.SelectedTab == tab_full && radioButton_CopyWTF_full.Checked)
            {
                if (Directory.Exists(path_Dest + "\\WTF"))
                {
                    File.Copy(path_Source + "\\WTF\\Config.wtf", path_Dest + "\\WTF\\Config.wtf");
                }
            }
            if (tabControl1.SelectedTab == tab_mini && radioButton_RU_mini.Checked || tabControl1.SelectedTab == tab_full && radioButton_RU_full.Checked)
            {
                if (Directory.Exists(path_Dest + "\\WTF"))
                {
                    File.Copy(path_VM + "\\Dropbox\\InstallPack\\config_ru\\Config.wtf", path_Dest + "\\WTF\\Config.wtf");
                }
            }
            if (tabControl1.SelectedTab == tab_mini && radioButton_EU_mini.Checked || tabControl1.SelectedTab == tab_full && radioButton_EU_full.Checked)
            {
                if (Directory.Exists(path_Dest + "\\WTF"))
                {
                    File.Copy(path_VM + "\\Dropbox\\InstallPack\\config_eu\\Config.wtf", path_Dest + "\\WTF\\Config.wtf");
                }
            }

            Log("Config.wtf создан.");
            progressBar.Value = progressBar.Maximum;

            statusLabel.Text = "Скопировано.";
            statusLabel.ForeColor = Color.Green;
        }

        void AddHBRelogProfile(string WowexeFullPath, string path_FolderHB, QSnode QuickSettigs, bool checked_225_15)
        {
            //XDocument doc;

            if (!Directory.Exists($@"C:\Users\{Environment.UserName}\AppData\Roaming"))
            {
                Directory.CreateDirectory($@"C:\Users\{Environment.UserName}\AppData\Roaming");
            }
            if (!Directory.Exists($@"C:\Users\{Environment.UserName}\AppData\Roaming\HighVoltz"))
            {
                Directory.CreateDirectory($@"C:\Users\{Environment.UserName}\AppData\Roaming\HighVoltz");
            }
            if (!Directory.Exists($@"C:\Users\{Environment.UserName}\AppData\Roaming\HighVoltz\HBRelog"))
            {
                Directory.CreateDirectory($@"C:\Users\{Environment.UserName}\AppData\Roaming\HighVoltz\HBRelog");
            }

            if (!File.Exists($@"C:\Users\{Environment.UserName}\AppData\Roaming\HighVoltz\HBRelog\Settings.xml"))
            {
                XDocument doc = new XDocument(new XElement("BotManager"));
                doc.Root.Add(new XElement("AutoStart", "false"));
                doc.Root.Add(new XElement("WowDelay", "60"));
                doc.Root.Add(new XElement("HBDelay", "25"));
                doc.Root.Add(new XElement("LoginDelay", "6"));
                doc.Root.Add(new XElement("UseDarkStyle", "true"));
                doc.Root.Add(new XElement("CheckRealmStatus", "false"));
                doc.Root.Add(new XElement("CheckHbResponsiveness", "true"));
                doc.Root.Add(new XElement("CheckWowResponsiveness", "false"));
                doc.Root.Add(new XElement("MinimizeHbOnStart", "false"));
                doc.Root.Add(new XElement("AutoUpdateHB", "false"));
                doc.Root.Add(new XElement("AutoAcceptTosEula", "true"));
                if (tabControl1.SelectedTab == tab_full && checkBox_Relogger_full.Checked)
                {
                    doc.Root.Add(new XElement("SetGameWindowTitle", "true"));
                }
                else
                {
                    doc.Root.Add(new XElement("SetGameWindowTitle", "false"));
                }
                doc.Root.Add(new XElement("GameWindowTitle", "{name}-{pid}"));
                doc.Root.Add(new XElement("EncryptSettings", "false"));
                doc.Root.Add(new XElement("WowVersion", ""));
                doc.Root.Add(new XElement("GameStateOffset", "0"));
                doc.Root.Add(new XElement("FocusedWidgetOffset", "0"));
                doc.Root.Add(new XElement("LuaStateOffset", "0"));
                doc.Root.Add(new XElement("LoadingScreenEnableCountOffset", "0"));
                doc.Root.Add(new XElement("CharacterProfiles"));

                doc.Save($@"C:\Users\{Environment.UserName}\AppData\Roaming\HighVoltz\HBRelog\Settings.xml");
                Log("HBRelog файл создан.");
            }

            Thread.Sleep(100);

            if (File.Exists($@"C:\Users\{Environment.UserName}\AppData\Roaming\HighVoltz\HBRelog\Settings.xml"))
            {
                XDocument doc = XDocument.Load($@"C:\Users\{Environment.UserName}\AppData\Roaming\HighVoltz\HBRelog\Settings.xml");

                if (doc.Root.Element("CharacterProfiles").Elements("CharacterProfile").Any(a =>
                    a.Element("Settings").Element("WowSettings").Element("LoginData").Value == QuickSettigs.emailFull &&
                    a.Element("Settings").Element("WowSettings").Element("AcountName").Value == QuickSettigs.WoWX &&
                    a.Element("Settings").Element("WowSettings").Element("CharacterName").Value == QuickSettigs.Nick &&
                    a.Element("Settings").Element("WowSettings").Element("ServerName").Value == QuickSettigs.Realm))
                {
                    Log("Идентичный профиль в HBRelog уже существует, не будем добавлять");
                    return;
                }

                XElement characterprofile = new XElement("CharacterProfile");

                XElement settings = new XElement("Settings");
                settings.Add(new XElement("ProfileName", Regex.Match(WowexeFullPath, @"\\(\w+).exe").Groups[1].Value));
                settings.Add(new XElement("IsEnabled", "true"));

                XElement wowsettings = new XElement("WowSettings");
                wowsettings.Add(new XElement("LoginData", QuickSettigs.emailFull));
                wowsettings.Add(new XElement("PasswordData", QuickSettigs.Password));
                wowsettings.Add(new XElement("AcountName", QuickSettigs.WoWX));
                wowsettings.Add(new XElement("CharacterName", QuickSettigs.Nick));
                wowsettings.Add(new XElement("ServerName", QuickSettigs.Realm));
                wowsettings.Add(new XElement("AuthenticatorSerialData", ""));
                wowsettings.Add(new XElement("AuthenticatorRestoreCodeData", ""));
                wowsettings.Add(new XElement("Region", "Auto"));
                wowsettings.Add(new XElement("WowPath", WowexeFullPath));
                wowsettings.Add(new XElement("WowArgs", "-noautolaunch64bit"));

                string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
                string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
                if (screenWidth == "1920" && screenHeight == "1080")
                {
                    wowsettings.Add(new XElement("WowWindowWidth", "400"));
                    wowsettings.Add(new XElement("WowWindowHeight", "300"));
                }
                else if (screenWidth == "1600" && screenHeight == "900")
                {
                    wowsettings.Add(new XElement("WowWindowWidth", "320"));
                    wowsettings.Add(new XElement("WowWindowHeight", "180"));
                }
                else if (screenWidth == "1280" && screenHeight == "1024")
                {
                    wowsettings.Add(new XElement("WowWindowWidth", "320"));
                    wowsettings.Add(new XElement("WowWindowHeight", "256"));
                }
                else if (screenWidth == "800" && screenHeight == "600")
                {
                    wowsettings.Add(new XElement("WowWindowWidth", "480"));
                    wowsettings.Add(new XElement("WowWindowHeight", "360"));
                }
                else if (screenWidth == "1024" && screenHeight == "768")
                {
                    wowsettings.Add(new XElement("WowWindowWidth", "505"));
                    wowsettings.Add(new XElement("WowWindowHeight", "400"));
                }
                else
                {
                    wowsettings.Add(new XElement("WowWindowWidth", "640"));
                    wowsettings.Add(new XElement("WowWindowHeight", "480"));
                }

                wowsettings.Add(new XElement("WowWindowX", "0"));
                wowsettings.Add(new XElement("WowWindowY", "0"));

                settings.Add(wowsettings);

                XElement hbsettings = new XElement("HonorbuddySettings");
                hbsettings.Add(new XElement("HonorbuddyKeyData", ""));
                hbsettings.Add(new XElement("CustomClass", "singular"));
                hbsettings.Add(new XElement("HonorbuddyArgs", ""));
                hbsettings.Add(new XElement("BotBase", ""));
                hbsettings.Add(new XElement("HonorbuddyProfile", ""));
                hbsettings.Add(new XElement("HonorbuddyPath", path_FolderHB + "\\Honorbuddy.exe"));
                hbsettings.Add(new XElement("UseHBBeta", "false"));

                settings.Add(hbsettings);

                characterprofile.Add(settings);

                XElement tasks = new XElement("Tasks");
                if (checked_225_15)
                {
                    tasks.Add(new XElement("WaitTask",
                        new XAttribute("Minutes", "225"),
                        new XAttribute("RandomMinutes", "15")));
                    tasks.Add(new XElement("IdleTask",
                        new XAttribute("Minutes", "14"),
                        new XAttribute("RandomMinutes", "3")));
                }
                characterprofile.Add(tasks);

                doc.Root.Element("CharacterProfiles").Add(characterprofile);

                doc.Save($@"C:\Users\{Environment.UserName}\AppData\Roaming\HighVoltz\HBRelog\Settings.xml");
                Log("HBRelog профиль создан.");
            }
        }


        void CreateLineEx(string name)
        {
            int maxIndex = listViewEx1.Items.Count - 1;
            int newIndex = maxIndex + 1;
            listViewEx1.Items.Add(name);
            /*
            ComboBox cmbBox = new ComboBox();
            cmbBox.Items.Add("DD");
            cmbBox.Items.Add("Tank");
            cmbBox.Items.Add("Heal");
            cmbBox.SelectedIndex = 0;
            listViewEx1.AddEmbeddedControl(cmbBox, 1, newIndex);
            */
            RadioButton radioButton_IsLeader = new RadioButton();
            radioButton_IsLeader.Checked = false;
            radioButton_IsLeader.Padding = new Padding(10, 2, 10, 2);
            listViewEx1.AddEmbeddedControl(radioButton_IsLeader, 1, newIndex);

            CheckBox chBox_Tasks = new CheckBox();
            chBox_Tasks.Checked = false;
            chBox_Tasks.Padding = new Padding(15, 2, 15, 2);
            listViewEx1.AddEmbeddedControl(chBox_Tasks, 2, newIndex);

        }

        static public void scrollDown(RichTextBox TB)
        {
            // set the current caret position to the end
            TB.SelectionStart = richTB.Text.Length;
            // scroll it automatically
            TB.ScrollToCaret();
        }


        void LoadQuickSettings(string PathQSDirectory)
        {
            DirectoryInfo dir = new DirectoryInfo(PathQSDirectory);

            //var files1 = dir.GetFiles("*.xml");
            var files = dir.GetFiles("*.xml").OrderBy(f => f.LastWriteTime).ToList();
            files.Reverse();

            foreach (var file in files)
            {
                QSnode node = new QSnode(file.FullName);    //заружаем настройки из файла

                _QSnodes.Add(node);
            }

            foreach (var node in _QSnodes)
            {
                listBox_Available_full.Items.Add($@"{node.Nick}-{node.Realm} ({node.emailFull} | {node.WoWX})");
                comboBox_QS_mini.Items.Add($@"{node.Nick}-{node.Realm} ({node.emailFull} | {node.WoWX})");
            }

        }

    }
}
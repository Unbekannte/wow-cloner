using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace copyWoWtoVM
{
    class Character
    {
        public string Nick;
        public string ClassSpec;
        public string Realm;
        public bool IsLeader;

        public Character(string nick, string classSpec, string realm, bool isLeader)
        {
            Nick = nick;
            ClassSpec = classSpec;
            Realm = realm;
            IsLeader = isLeader;
        }
    }

    class CharSettings
    {

        //private string PathHB = "";

        static public void MakeSettings_Single(Character character, string pathHB)
        {
            pathHB = pathHB + "\\";
            Create_CharacterSettings(character, pathHB);
            Create_SingularSettings(character, pathHB);
            Create_DungeonBuddySettings(character, pathHB, character.IsLeader);
            Logg.Log("Character Settings добавлен.");
        }

        static public void MakeSettings_Multiple(List<Character> membersList, string pathHB)
        {
            pathHB = pathHB + "\\";
            foreach (var member in membersList)
            {
                Create_CharacterSettings(member, pathHB);
                Create_SingularSettings(member, pathHB);
                
                string leaderName = null;
                string member2 = null;
                string member3 = null;
                string member4 = null;
                string member5 = null;
                if (member.IsLeader)
                {
                    List<Character> membs = new List<Character>();
                    foreach (var memb in membersList)
                    {
                        if (member.Nick != memb.Nick)
                        {
                            membs.Add(memb);
                        }

                    }

                    leaderName = null;
                    if (membs.Count > 0)
                    {
                        if (member.Realm != membs.First().Realm)
                        {
                            member2 = $"{membs.First().Nick}-{membs.First().Realm.Replace(" ", "")}";
                        }
                        else
                        {
                            member2 = membs.First().Nick;
                        }
                        membs.RemoveAt(0);
                    }
                    if (membs.Count > 0)
                    {
                        if (member.Realm != membs.First().Realm)
                        {
                            member3 = $"{membs.First().Nick}-{membs.First().Realm.Replace(" ", "")}";
                        }
                        else
                        {
                            member3 = membs.First().Nick;
                        }
                        membs.RemoveAt(0);
                    }
                    if (membs.Count > 0)
                    {
                        if (member.Realm != membs.First().Realm)
                        {
                            member4 = $"{membs.First().Nick}-{membs.First().Realm.Replace(" ", "")}";
                        }
                        else
                        {
                            member4 = membs.First().Nick;
                        }
                        membs.RemoveAt(0);
                    }
                    if (membs.Count > 0)
                    {
                        if (member.Realm != membs.First().Realm)
                        {
                            member5 = $"{membs.First().Nick}-{membs.First().Realm.Replace(" ", "")}";
                        }
                        else
                        {
                            member5 = membs.First().Nick;
                        }
                        membs.RemoveAt(0);
                    }
                }
                else if (membersList.Any(a => a.IsLeader))
                {
                    Character leaderCharacter = membersList.First(a => a.IsLeader);
                    if (member.Realm != leaderCharacter.Realm)
                        leaderName = $"{leaderCharacter.Nick}-{leaderCharacter.Realm.Replace(" ", "")}";
                    else
                        leaderName = leaderCharacter.Nick;
                }
                Create_DungeonBuddySettings(member, pathHB, member.IsLeader, leaderName, member2, member3, member4, member5);
            }
            
           Logg.Log("Character Settings добавлены.");
        }

        static void Create_CharacterSettings(Character character, string PathHB)
        {
            if (File.Exists(PathHB + $@"Settings\{character.Realm}\{character.Nick}\CharacterSettings.xml"))
            {
                Logg.Log("CharacterSettings.xml уже существует.");
                return;
            }

            XDocument doc = new XDocument();
            XElement root = new XElement("CharacterSettings");
            doc.Add(root);

            //добавляем необходимые значения
            root.Add(new XElement("SelectTalents", "True"));
            root.Add(new XElement("ClassProfileName", "")); //character.ClassSpec
            root.Add(new XElement("RollOnItems", "True"));
            root.Add(new XElement("RollDisenchantWhenGreed", "False"));
            root.Add(new XElement("TicksPerSecond", "12"));
            root.Add(new XElement("FoodAmount", "0"));
            root.Add(new XElement("DrinkAmount", "0"));
            root.Add(new XElement("SellGrey", "True"));
            root.Add(new XElement("SellWhite", "True"));
            root.Add(new XElement("SellGreen", "True"));
            root.Add(new XElement("SellBlue", "True"));
            root.Add(new XElement("SellPurple", "False"));
            root.Add(new XElement("Use", "Questing"));
            root.Add(new XElement("UseFlightPaths", "True"));
            root.Add(new XElement("FindMountAutomatically", "True"));
            root.Add(new XElement("UseRandomMount", "True"));
            root.Add(new XElement("LootMobs", "True"));
            root.Add(new XElement("SkinMobs", "True"));
            root.Add(new XElement("NinjaSkin", "True"));
            root.Add(new XElement("LootChests", "True"));
            root.Add(new XElement("HarvestMinerals", "True"));
            root.Add(new XElement("HarvestHerbs", "True"));
            root.Add(new XElement("UseMount", "True"));
            root.Add(new XElement("PullDistance", "30"));
            root.Add(new XElement("LootRadius", "40"));
            root.Add(new XElement("LastUsedPath", PathHB + @"Default Profiles\Questing Profile Pack\Auto Loader - v2.xml"));
            root.Add(new XElement("RessAtSpiritHealers", "False"));

            /*
            *остальные элементы добавляем по аналогии
            */

            //сохраняем наш документ
            if (!Directory.Exists(PathHB + $@"Settings"))
            {
                Directory.CreateDirectory(PathHB + $@"Settings");
            }
            if (!Directory.Exists(PathHB + $@"Settings\{character.Realm}"))
            {
                Directory.CreateDirectory(PathHB + $@"Settings\{character.Realm}");
            }
            if (!Directory.Exists(PathHB + $@"Settings\{character.Realm}\{character.Nick}"))
            {
                Directory.CreateDirectory(PathHB + $@"Settings\{character.Realm}\{character.Nick}");
            }
            doc.Save(PathHB + $@"Settings\{character.Realm}\{character.Nick}\CharacterSettings.xml");

        }

       static void Create_SingularSettings(Character character, string PathHB)
        {
            if (File.Exists(PathHB + $@"Settings\{character.Realm}\{character.Nick}\SingularSettings.xml"))
            {
                Logg.Log("SingularSettings.xml уже существует.");
                return;
            }

            XDocument doc = new XDocument();
            XElement root = new XElement("SingularSettings");
            doc.Add(root);

            //добавляем необходимые значения
            root.Add(new XElement("MoveToTargetTimeout", "15"));
            root.Add(new XElement("MinHealth", "40"));
            root.Add(new XElement("MinMana", "30"));
            root.Add(new XElement("PotionHealth", "30"));
            root.Add(new XElement("PotionMana", "20"));
            root.Add(new XElement("KiteAllow", "False"));
            root.Add(new XElement("KiteHealth", "60"));
            root.Add(new XElement("KiteMobCount", "4"));

            /*
            *остальные элементы добавляем по аналогии
            */

            //сохраняем наш документ
            if (!Directory.Exists(PathHB + $@"Settings"))
            {
                Directory.CreateDirectory(PathHB + $@"Settings");
            }
            if (!Directory.Exists(PathHB + $@"Settings\{character.Realm}"))
            {
                Directory.CreateDirectory(PathHB + $@"Settings\{character.Realm}");
            }
            if (!Directory.Exists(PathHB + $@"Settings\{character.Realm}\{character.Nick}"))
            {
                Directory.CreateDirectory(PathHB + $@"Settings\{character.Realm}\{character.Nick}");
            }
            doc.Save(PathHB + $@"Settings\{character.Realm}\{character.Nick}\SingularSettings.xml");

        }

        void Create_ClassFile_inSingularFolder(Character character, string PathHB)
        {
            string CLASS = Regex.Match(character.ClassSpec, $@"(\w+)").Groups[1].Value;
            if (CLASS == "Druid")
            {
                string SPEC = Regex.Match(character.ClassSpec, $@"- (\w+)").Groups[1].Value;

                XDocument doc = new XDocument();
                XElement root = new XElement($"{CLASS}Settings");
                doc.Add(root);

                //добавляем необходимые значения
                root.Add(new XElement("UseAquaticForm", "True"));
                root.Add(new XElement("UseTravelForm", "True"));
                root.Add(new XElement("DisorientingRoarCount", "3"));
                root.Add(new XElement("DisorientingRoarHealth", "30"));
                root.Add(new XElement("SelfRejuvInFormHealth", "80"));
                root.Add(new XElement("SelfRejuvenationHealth", "60"));
                root.Add(new XElement("SelfHealingTouchHealth", "45"));
                root.Add(new XElement("SelfRenewalHealth", "35"));
                root.Add(new XElement("Rejuvenation", "97"));
                root.Add(new XElement("FeralSpellPriority", "Noxxic"));
                root.Add(new XElement("ProwlAlways", "False"));
                root.Add(new XElement("Prowl", "Never"));

                /*
                *остальные элементы добавляем по аналогии
                */

                //сохраняем наш документ
                if (!Directory.Exists(PathHB + $@"Settings"))
                {
                    Directory.CreateDirectory(PathHB + $@"Settings");
                }
                if (!Directory.Exists(PathHB + $@"Settings\{character.Realm}"))
                {
                    Directory.CreateDirectory(PathHB + $@"Settings\{character.Realm}");
                }
                if (!Directory.Exists(PathHB + $@"Settings\{character.Realm}\{character.Nick}"))
                {
                    Directory.CreateDirectory(PathHB + $@"Settings\{character.Realm}\{character.Nick}");
                }
                if (!Directory.Exists(PathHB + $@"Settings\{character.Realm}\{character.Nick}\Singular"))
                {
                    Directory.CreateDirectory(PathHB + $@"Settings\{character.Realm}\{character.Nick}\Singular");
                }
                doc.Save(PathHB + $@"Settings\{character.Realm}\{character.Nick}\Singular\{CLASS}.xml");
            }
        }

      static  void Create_DungeonBuddySettings(Character character, string PathHB, bool IsLeader, string LeaderName = null, string member2 = null, string member3 = null, string member4 = null, string member5 = null)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("DungeonBuddySettings");
            doc.Add(root);

            //добавляем необходимые значения
            if (IsLeader)
            {
                root.Add(new XElement("PartyMode", "Leader"));

                XElement PartyMembers = new XElement("PartyMembers");
                if (!string.IsNullOrEmpty(member2))
                    PartyMembers.Add(new XElement("Entry", member2));
                if (!string.IsNullOrEmpty(member3))
                    PartyMembers.Add(new XElement("Entry", member3));
                if (!string.IsNullOrEmpty(member4))
                    PartyMembers.Add(new XElement("Entry", member4));
                if (!string.IsNullOrEmpty(member5))
                    PartyMembers.Add(new XElement("Entry", member5));
                root.Add(PartyMembers);
            }
            else
            {
                root.Add(new XElement("PartyMode", "Follower"));
                root.Add(new XElement("LeaderName", LeaderName));
            }
            root.Add(new XElement("PortOutsideOnGhostSighting", "False"));
            root.Add(new XElement("LootMode", "BossesOnly"));
            root.Add(new XElement("GroupLootMode", "Personal"));
            root.Add(new XElement("SellItemQuality", "Epic"));
            root.Add(new XElement("DungeonType", "RandomDungeon"));
            root.Add(new XElement("SelectedRandomDungeonId", "0"));
            root.Add(new XElement("KillOptionalBosses", "True"));
            root.Add(new XElement("AbandonLowLevelQuests", "True"));
            root.Add(new XElement("PickupQuests", "True"));
            root.Add(new XElement("HearthOnVendorRun", "False"));
            root.Add(new XElement("FollowingDistance", "7"));
            root.Add(new XElement("CombatMovement", "True"));
            root.Add(new XElement("Role", "Auto"));
            root.Add(new XElement("TankInRandomGroups", "False"));
            root.Add(new XElement("InsideInstanceRepairPercent", "10"));
            root.Add(new XElement("OutsideInstanceRepairPercent", "50"));
            root.Add(new XElement("InsideInstanceMinFreeBagSlots", "2"));
            root.Add(new XElement("OutsideInstanceMinFreeBagSlots", "12"));
            root.Add(new XElement("PortOutsideInstanceToSell", "True"));
            root.Add(new XElement("PortOutsideInstanceToBuy", "False"));

            /*
            *остальные элементы добавляем по аналогии
            */

            //сохраняем наш документ
            if (!Directory.Exists(PathHB + $@"Settings"))
            {
                Directory.CreateDirectory(PathHB + $@"Settings");
            }
            if (!Directory.Exists(PathHB + $@"Settings\{character.Realm}"))
            {
                Directory.CreateDirectory(PathHB + $@"Settings\{character.Realm}");
            }
            if (!Directory.Exists(PathHB + $@"Settings\{character.Realm}\{character.Nick}"))
            {
                Directory.CreateDirectory(PathHB + $@"Settings\{character.Realm}\{character.Nick}");
            }
            doc.Save(PathHB + $@"Settings\{character.Realm}\{character.Nick}\DungeonBuddySettings.xml");

        }
    }
}

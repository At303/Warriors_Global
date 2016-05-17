using UnityEngine;
using System.Collections;
using gamedata;
using System.Collections.Generic;

namespace gamedata_weapon
{

    // Weapon Struct
    public struct Weapon_struct
    {
        public int enable;
        public int level;
        public ulong damage;
        public ulong upgrade_cost;
        public string skill;
        public popup_window_button_mgr.NPC_INDEX equiped_this_weapon_npc_index;

        public GameObject lvup_button;
        public GameObject weapon_enable_gameobject;

    }

    public struct Bow_struct
    {
        public int enable;
        public int level;
        public ulong damage;
        public ulong upgrade_cost;
        public string skill;
        public popup_window_button_mgr.NPC_INDEX equiped_this_weapon_npc_index;

        public GameObject lvup_button;
        public GameObject bow_enable_gameobject;

    }

    public struct Wing_struct
    {
        public int enable;
        public GameObject wing_enable_gameobject;
        public GameObject wing_buy_button;

        public ulong plus_gold;
        public ulong upgrade_cost;
        public string skill;

    }

    public struct Armor_struct
    {
        public int enable;
        public GameObject armor_enable_gameobject;
        public GameObject armor_buy_button;

        public ulong plus_gold;
        public ulong upgrade_cost;
        public string skill;

    }

    public class GameData_weapon : MonoBehaviour
    {
        public static GameObject test_obj;

        public static bool check_toggle4_active = false;
        public static bool check_toggle6_active = false;

        // 처음 시작시 weapon struct 초기화.
        public static Weapon_struct[] weapon_struct_object = new Weapon_struct[25];
        static int weapon_MAX = 0;

        // 처음 시작시 bow struct 초기화.
        public static Bow_struct[] bow_struct_object = new Bow_struct[25];
        static int bow_MAX = 0;

        // 처음 시작시 wing struct 초기화.
        public static Wing_struct[] wing_struct_object = new Wing_struct[20];

        // 처음 시작시 Armor struct 초기화.
        public static Armor_struct[] armor_struct_object = new Armor_struct[41];

        //Define a string to int dictionary in C#
        public static Dictionary<string, int> armorDIC = new Dictionary<string, int>();

        public static Dictionary<string, int> wingDIC = new Dictionary<string, int>();
        
        public static Dictionary<string, int> weaponDIC = new Dictionary<string, int>();
        public static Dictionary<string, int> bowDIC = new Dictionary<string, int>();


        void amorDIC_Init()
        {
            armorDIC["steel-a00"] = 0;
            armorDIC["steel-a10"] = 1;
            armorDIC["steel-a20"] = 2;

            armorDIC["hood-a00"] = 3;
            armorDIC["hood-a01"] = 4;
            armorDIC["hood-a02"] = 5;
            armorDIC["hood-a03"] = 6;
            armorDIC["hood-a04"] = 7;
            armorDIC["hood-a10"] = 8;
            armorDIC["hood-a11"] = 9;
            armorDIC["hood-a12"] = 10;
            armorDIC["hood-a13"] = 11;
            armorDIC["hood-a14"] = 12;
            armorDIC["hood-a20"] = 13;
            armorDIC["hood-a21"] = 14;
            armorDIC["hood-a22"] = 15;
            armorDIC["hood-a23"] = 16;
            armorDIC["hood-a24"] = 17;

            armorDIC["robe-a00"] = 18;
            armorDIC["robe-a01"] = 19;
            armorDIC["robe-a02"] = 20;
            armorDIC["robe-a03"] = 21;
            armorDIC["robe-a04"] = 22;

            armorDIC["robe-a10"] = 23;
            armorDIC["robe-a11"] = 24;
            armorDIC["robe-a12"] = 25;
            armorDIC["robe-a13"] = 26;
            armorDIC["robe-a14"] = 27;

            armorDIC["uniform-a00"] = 28;
            armorDIC["uniform-a01"] = 29;
            armorDIC["uniform-a02"] = 30;
            armorDIC["uniform-a03"] = 31;
            armorDIC["uniform-a10"] = 32;
            armorDIC["uniform-a12"] = 33;
            armorDIC["uniform-a13"] = 34;

            armorDIC["ancient-b00"] = 35;
            armorDIC["ancient-b10"] = 36;
            armorDIC["ancient-b20"] = 37;
            armorDIC["mithril-a00"] = 38;
            armorDIC["mithril-a10"] = 39;
            armorDIC["mithril-a20"] = 40;

            // not equiped.
            armorDIC["00"] = 100;

        }

        void wingDIC_Init()
        {
            wingDIC["cape-a0"] = 0;
            wingDIC["cape-a1"] = 1;
            wingDIC["cape-a2"] = 2;
            wingDIC["cape-a3"] = 3;
            wingDIC["cape-a4"] = 4;
            wingDIC["cape-a5"] = 5;
            wingDIC["cape-a6"] = 6;
            wingDIC["cape-a7"] = 7;
            wingDIC["cape-a8"] = 8;
            wingDIC["cape-a9"] = 9;
            wingDIC["cape-a10"] = 10;
            wingDIC["cape-a11"] = 11;

            wingDIC["wing-a0"] = 12;
            wingDIC["wing-a1"] = 13;
            wingDIC["wing-a2"] = 14;
            wingDIC["wing-a3"] = 15;
            wingDIC["wing-a4"] = 16;
            wingDIC["wing-a5"] = 17;
            wingDIC["wing-a6"] = 18;
            wingDIC["wing-a7"] = 19;

            // not equiped.
            wingDIC["0"] = 100;

        }


        void weaponDIC_Init()
        {
             weaponDIC["dagger-a0"] = 0;
             weaponDIC["dagger-a1"] = 1;
             weaponDIC["blunt-a0"] = 2;
             weaponDIC["blunt-a1"] = 3;
             weaponDIC["blunt-a3"] = 4;
             weaponDIC["blunt-a4"] = 5;
             weaponDIC["sword-a2"] = 6;
             weaponDIC["axe-a1"] = 7;
             weaponDIC["sword-a1"] = 8;
             weaponDIC["axe-a2"] = 9;
             weaponDIC["axe-a3"] = 10;
             weaponDIC["axe-a4"] = 11;
             weaponDIC["sword-a5"] = 12;
             weaponDIC["sword-a6"] = 13;
             weaponDIC["sword-a7"] = 14;
             weaponDIC["axe-a6"] = 15;
             weaponDIC["blunt-a9"] = 16;
             weaponDIC["sword-a8"] = 17;
             weaponDIC["sword-a11"] = 18;
             weaponDIC["sword-a12"] = 19;
             weaponDIC["sword-a13"] = 20;
             weaponDIC["sword-a16"] = 21;
             weaponDIC["blunt-a10"] = 22;
             weaponDIC["sword-a9"] = 23;
             weaponDIC["sword-a17"] = 24;

        }
        
        void bowDIC_Init()
        {
            bowDIC["bow-a0"] = 0;
            bowDIC["bow-a1"] = 1;
            bowDIC["bow-a2"] = 2;
            bowDIC["bow-a3"] = 3;
            bowDIC["bow-a4"] = 4;
            bowDIC["bow-a5"] = 5;
            bowDIC["bow-a6"] = 6;
            bowDIC["bow-a7"] = 7;
            bowDIC["bow-a8"] = 8;
            bowDIC["bow-a9"] = 9;
            bowDIC["bow-a10"] = 10;
            bowDIC["bow-a11"] = 11;
            bowDIC["bow-a12"] = 12;
            bowDIC["bow-a13"] = 13;
            bowDIC["bow-a14"] = 14;
            bowDIC["bow-a15"] = 15;            
            bowDIC["bow-a16"] = 16;
            bowDIC["bow-a17"] = 17;
            bowDIC["bow-a18"] = 18;
            bowDIC["bow-a19"] = 19;
            bowDIC["bow-a20"] = 20;
            bowDIC["bow-a21"] = 21;
            bowDIC["bow-a22"] = 22;
            bowDIC["bow-a23"] = 23;
            bowDIC["bow-a24"] = 24;

        }
        // Use this for initialization
        void Start()
        {
            // 보스씬 갔다가 다시 Main 씬왔을때 아래 변수들은 static이므로 0으로 resetting.
            bow_MAX = 0;
            weapon_MAX = 0;

            // Dictornary init.
            amorDIC_Init();
            wingDIC_Init();
            weaponDIC_Init();
            bowDIC_Init();
            
            // ************************************************************************  weapon init ************************************************************************ //

            // 무기 데이터 초기화.
            for (int i = 0; i < 25; i++)
            {
                // 처음 시작시에는 무기 lock sprite를 on 시키기 위해 check할 변수를 false시켜줌.
                // 나중에 아래 변수는 playerprefas로 가져와야함.
                string get_weapon_enable = "weapon" + i.ToString() + "_enable";
                weapon_struct_object[i].enable = PlayerPrefs.GetInt(get_weapon_enable, 1);

                // unlock sprite가 ON되어 있어도 그 밑에있는 버튼들이 클릭되어지는 것을 방지하기 위함.
                string weapon_status_enable = "_weapon" + i.ToString() + "_enable_obj";
                weapon_struct_object[i].weapon_enable_gameobject = GameObject.Find(weapon_status_enable);
                weapon_struct_object[i].weapon_enable_gameobject.SetActive(false);

                // 해당 무기 레벨을 setting해줌.
                string get_weapon_level = "weapon" + i.ToString() + "_level";
                weapon_struct_object[i].level = PlayerPrefs.GetInt(get_weapon_level, 1);

                if (weapon_struct_object[i].enable == 0)
                {
                    // 해당 무기를 가지고 있기 때문에 unlock_sprite를 false시켜줌.
                    string weapon_lock_sp = "_weapon" + i.ToString() + "_unlock_sprite";
                    GameObject.Find(weapon_lock_sp).SetActive(false);

                    //unlock sprite가 ON되어 있어도 그 밑에있는 버튼들이 클릭되어지는 것을 방지하기 위함.
                    weapon_struct_object[i].weapon_enable_gameobject.SetActive(true);
                    weapon_MAX++;

                    // 무기 레벨 up 버튼 GameObject Setting.
                    weapon_struct_object[i].lvup_button = GameObject.Find("_weapon" + i.ToString() + "_lvup_button");

                    // 가져온 무기의 레벨값으로 해당 무기 data struct에 setting.
                    weapon_data_struct_update(i, weapon_struct_object[i].level);
                    update_weapon_data_label(i);
                }


            }

            // ************************************************************************  bow init ************************************************************************ //

            // 활 데이터 초기화.
            for (int i = 1; i < 25; i++)
            {
                // 처음 시작시에는 무기 lock sprite를 on 시키기 위해 check할 변수를 false시켜줌.
                // 나중에 아래 변수는 playerprefas로 가져와야함.
                string get_bow_enable = "bow" + i.ToString() + "_enable";
                bow_struct_object[i].enable = PlayerPrefs.GetInt(get_bow_enable, 1);

                // unlock sprite가 ON되어 있어도 그 밑에있는 버튼들이 클릭되어지는 것을 방지하기 위함.
                string bow_status_enable = "_bow" + i.ToString() + "_enable_obj";
                bow_struct_object[i].bow_enable_gameobject = GameObject.Find(bow_status_enable);
                bow_struct_object[i].bow_enable_gameobject.SetActive(false);

                // 해당 무기 레벨을 setting해줌.
                string get_bow_level = "bow" + i.ToString() + "_level";
                bow_struct_object[i].level = PlayerPrefs.GetInt(get_bow_level, 1);

                if (bow_struct_object[i].enable == 0)
                {
                    // 해당 무기를 가지고 있기 때문에 unlock_sprite를 false시켜줌.
                    string bow_lock_sp = "_bow" + i.ToString() + "_unlock_sprite";
                    GameObject.Find(bow_lock_sp).SetActive(false);

                    //unlock sprite가 ON되어 있어도 그 밑에있는 버튼들이 클릭되어지는 것을 방지하기 위함.
                    bow_struct_object[i].bow_enable_gameobject.SetActive(true);
                    bow_MAX++;

                    // 무기 레벨 up 버튼 GameObject Setting.
                    bow_struct_object[i].lvup_button = GameObject.Find("_bow" + i.ToString() + "_lvup_button");

                    // 가져온 무기의 레벨값으로 해당 무기 data struct에 setting.
                    bow_data_struct_update(i, bow_struct_object[i].level);
                    update_bow_data_label(i);

                }


            }

            // ************************************************************************  armor init ************************************************************************ //                     

            // Armor Button All disable except 0.
            for (int i = 1; i < 41; i++)
            {
                // 게임 시작시 모든 Armor 구매 버튼은 비활성화 시켜줌 아래 for문에 있는 함수에서 Local 변수를 보고 활성화 할지 결정.
                GameObject.Find("_armor" + i.ToString() + "_lvup_button").GetComponent<UIButton>().isEnabled = false;
            }

            // 아머 데이터 초기화.
            for (int i = 0; i < 41; i++)
            {
                // Armor 레벨 up 버튼 GameObject Setting.
                armor_struct_object[i].armor_buy_button = GameObject.Find("_armor" + i.ToString() + "_lvup_button");

                // unlock sprite가 있음에도 그 밑에 있는 버튼이 클릭 되어지는걸 방지하기 위해 밑에 있는  object들을 비활성화 시켜줌.
                armor_struct_object[i].armor_enable_gameobject = GameObject.Find("_armor" + i.ToString() + "_enable");
                armor_struct_object[i].armor_enable_gameobject.SetActive(false);


                Armor_data_struct_update(i);
            }

            // ************************************************************************  wing init ************************************************************************ //

            // Wing Button All disable.
            for (int i = 0; i < 20; i++)
            {
                // 게임 시작시 모든 Armor 구매 버튼은 비활성화 시켜줌 아래 for문에 있는 함수에서 Local 변수를 보고 활성화 할지 결정.
                GameObject.Find("_wing" + i.ToString() + "_lvup_button").GetComponent<UIButton>().isEnabled = false;
            }

            // wing gameobject 데이터 초기화.
            for (int i = 0; i < 20; i++)
            {
                // Armor 레벨 up 버튼 GameObject Setting.
                wing_struct_object[i].wing_buy_button = GameObject.Find("_wing" + i.ToString() + "_lvup_button");

                // unlock sprite가 있음에도 그 밑에 있는 버튼이 클릭 되어지는걸 방지하기 위해 밑에 있는  object들을 비활성화 시켜줌.
                wing_struct_object[i].wing_enable_gameobject = GameObject.Find("_wing" + i.ToString() + "_enable");
                wing_struct_object[i].wing_enable_gameobject.SetActive(false);
            }

            for (int i = 0; i < 20; i++)
            {
                Wing_data_struct_update(i);
            }

            check_wing_buttons_is_enable_or_not();

        }



        // ************************************************************************  Weapon Functions ************************************************************************ //

        public static void weapon_data_struct_update(int _weapon_index, int _level)
        {
            weapon_struct_object[_weapon_index].level = _level;

            weapon_struct_object[_weapon_index].damage = 0;
             
            // 무기 데미지는 레벨에 따라서 누적.
            weapon_struct_object[_weapon_index].damage = 0;
            for (int i=1;i< _level+1;i++)
            {
                weapon_struct_object[_weapon_index].damage = (ulong)(weapon_struct_object[_weapon_index].damage + Mathf.Round(8 * (_level + 1) * (Mathf.Pow(1.875f, _weapon_index))));
            }


            // =1000*POWER(1.375,A2) + 1000*POWER(1.775,C2)+ 5000*A2
            weapon_struct_object[_weapon_index].upgrade_cost = (ulong)Mathf.Round((1000 * (Mathf.Pow(1.275f, weapon_struct_object[_weapon_index].level)) + ((10000 * _weapon_index) + 5000 * weapon_struct_object[_weapon_index].level)));

            // 무기가 어떤 npc에 장착되어 있는지 Local변수를 가져옴.
            // NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
            string get_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";

            switch (PlayerPrefs.GetInt(get_weapon_to_npc_str, 100))
            {

                case 1:
                    NPC01_make.NPC01_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC01_make.NPC01_struct.add_damage);
                    break;

                case 2:
                    NPC02_make.NPC02_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC02_make.NPC02_struct.add_damage);
                    break;

                case 3:
                    NPC03_make.NPC03_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC03_make.NPC03_struct.add_damage);
                    break;

                case 7:
                    NPC07_make.NPC07_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC07_make.NPC07_struct.add_damage);
                    break;

                case 8:
                    NPC08_make.NPC08_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC08_make.NPC08_struct.add_damage);
                    break;

                case 9:
                    NPC09_make.NPC09_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC09_make.NPC09_struct.add_damage);
                    break;
                default:
                    //print("해당 무기는 npc가 가지고 있지 않음.");
                    break;
            }

        }

        // 무기 레벨 UP && Data Update.
        public static void levelup_weapon_data_struct(int _weapon_index)
        {
            int _Level = weapon_struct_object[_weapon_index].level;
            // 무기 레벨업 공식.
            weapon_struct_object[_weapon_index].level = weapon_struct_object[_weapon_index].level + 1;

            // 무기 데미지는 레벨에 따라서 누적.
            weapon_struct_object[_weapon_index].damage = 0;
            for (int i=1;i< weapon_struct_object[_weapon_index].level+1;i++)
            {
                weapon_struct_object[_weapon_index].damage = (ulong)(weapon_struct_object[_weapon_index].damage + Mathf.Round(8 * (weapon_struct_object[_weapon_index].level + 1) * (Mathf.Pow(1.875f, _weapon_index))));
            }      
                  
            // =ROUND((2000*1)*POWER(1.275,C3),0)+100000*C3
            weapon_struct_object[_weapon_index].upgrade_cost = (ulong)Mathf.Round((1000 * (Mathf.Pow(1.275f, weapon_struct_object[_weapon_index].level)) + ((10000 * _weapon_index) + 5000 * weapon_struct_object[_weapon_index].level)));

            // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
            string set_weapon_level_str = "weapon" + _weapon_index.ToString() + "_level";
            PlayerPrefs.SetInt(set_weapon_level_str, weapon_struct_object[_weapon_index].level);
            PlayerPrefs.Save();

            // 무기가 어떤 npc에 장착되어 있는지 Local변수를 가져옴.
            // NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
            string get_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";

            switch (PlayerPrefs.GetInt(get_weapon_to_npc_str, 100))
            {
                case 1:
                    NPC01_make.NPC01_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC01_make.NPC01_struct.add_damage);
                    break;

                case 2:
                    NPC02_make.NPC02_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC02_make.NPC02_struct.add_damage);
                    break;

                case 3:
                    NPC03_make.NPC03_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC03_make.NPC03_struct.add_damage);
                    break;

                case 7:
                    NPC07_make.NPC07_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC07_make.NPC07_struct.add_damage);
                    break;

                case 8:
                    NPC08_make.NPC08_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC08_make.NPC08_struct.add_damage);
                    break;

                case 9:
                    NPC09_make.NPC09_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC09_make.NPC09_struct.add_damage);
                    break;

                default:
                    print("해당 무기는 npc가 가지고 있지 않음.");
                    break;

            }
        }

        // 무기 버튼 && 라벨 Update.
        public static void update_weapon_data_label(int _weapon_index)
        {
            string level_label = "_weapon" + _weapon_index.ToString() + "_level_label";
            string damage_label = "_weapon" + _weapon_index.ToString() + "_damage_label";
            string lvup_cost_label = "_weapon" + _weapon_index.ToString() + "_upgrade_cost_label";

            GameObject.Find(level_label).GetComponent<UILabel>().text = weapon_struct_object[_weapon_index].level.ToString();
            GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].damage);
            GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format_won(weapon_struct_object[_weapon_index].upgrade_cost);
        }


        public static void equip_the_weapon(int _weapon_index, popup_window_button_mgr.NPC_INDEX _npc_index)
        {

            string set_weapon_to_npc_str;

            // NPC에 Damage 추가 && NPC Damage 추가 Label Update.
            switch (_npc_index)
            {
                case popup_window_button_mgr.NPC_INDEX.NPC01:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC01;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수 Save.
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 1);                                                    // 1 -> NPC01
                    PlayerPrefs.Save();

                    NPC01_make.NPC01_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC01_make.NPC01_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC02:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC02;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 2);                                                    // 2 -> NPC02
                    PlayerPrefs.Save();

                    NPC02_make.NPC02_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC02_make.NPC02_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC03:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC03;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 3);                                                    // 3 -> NPC03
                    PlayerPrefs.Save();

                    NPC03_make.NPC03_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC03_make.NPC03_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC07:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC07;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 7);                                                    // 7 -> NPC07
                    PlayerPrefs.Save();

                    NPC07_make.NPC07_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC07_make.NPC07_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC08:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC08;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 8);                                                    // 8 -> NPC08
                    PlayerPrefs.Save();

                    NPC08_make.NPC08_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC08_make.NPC08_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC09:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC09;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 9);                                                    // 9 -> NPC09
                    PlayerPrefs.Save();

                    NPC09_make.NPC09_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC09_make.NPC09_struct.add_damage);
                    break;
            }
        }



        // ************************************************************************  bow Functions ************************************************************************ //

        // 활 레벨 UP && Data Update.
        public static void bow_data_struct_update(int _weapon_index, int _level)
        {
            bow_struct_object[_weapon_index].level = _level;

            bow_struct_object[_weapon_index].damage = 0;

           // 무기 데미지는 레벨에 따라서 누적.
            bow_struct_object[_weapon_index].damage = 0;
            for (int i=1;i< _level+1;i++)
            {
                bow_struct_object[_weapon_index].damage = (ulong)(bow_struct_object[_weapon_index].damage + Mathf.Round(8 * (_level + 1) * (Mathf.Pow(1.875f, _weapon_index))));
            }
            
            // =ROUND((2000*1)*POWER(1.275,C3),0)+100000*C3
            bow_struct_object[_weapon_index].upgrade_cost = (ulong)Mathf.Round((1000 * (Mathf.Pow(1.275f, bow_struct_object[_weapon_index].level)) + ((10000 * _weapon_index) + 5000 * bow_struct_object[_weapon_index].level)));

            // 무기가 어떤 npc에 장착되어 있는지 Local변수를 가져옴.
            // NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
            string get_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                                    
            switch (PlayerPrefs.GetInt(get_bow_to_npc_str, 100))
            {

                case 4:
                    NPC04_make.NPC04_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC04_make.NPC04_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC04_make.NPC04_struct.add_damage);
                    break;

                case 5:
                    NPC05_make.NPC05_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC05_make.NPC05_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC05_make.NPC05_struct.add_damage);
                    break;

                case 6:
                    NPC06_make.NPC06_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC06_make.NPC06_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC06_make.NPC06_struct.add_damage);
                    break;

                case 10:
                    NPC10_make.NPC10_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC10_make.NPC10_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC10_make.NPC10_struct.add_damage);
                    break;

                case 11:
                    NPC11_make.NPC11_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC11_make.NPC11_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC11_make.NPC11_struct.add_damage);
                    break;

                case 12:
                    NPC12_make.NPC12_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC12_make.NPC12_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC12_make.NPC12_struct.add_damage);
                    break;
                default:
                    //print("해당 무기는 npc가 가지고 있지 않음.");
                    break;
            }
        }

        // 무기 레벨 UP && Data Update.
        public static void levelup_bow_data_struct(int _weapon_index)
        {
            int _Level = bow_struct_object[_weapon_index].level;
            // 무기 레벨업 공식.
            bow_struct_object[_weapon_index].level = bow_struct_object[_weapon_index].level + 1;

           // 무기 데미지는 레벨에 따라서 누적.
            bow_struct_object[_weapon_index].damage = 0;
            for (int i=1;i< bow_struct_object[_weapon_index].level+1;i++)
            {
                bow_struct_object[_weapon_index].damage = (ulong)(bow_struct_object[_weapon_index].damage + Mathf.Round(8 * (bow_struct_object[_weapon_index].level + 1) * (Mathf.Pow(1.875f, _weapon_index))));
            }  
            
            
            // =ROUND((2000*1)*POWER(1.275,C3),0)+100000*C3
            bow_struct_object[_weapon_index].upgrade_cost = (ulong)Mathf.Round((1000 * (Mathf.Pow(1.275f, bow_struct_object[_weapon_index].level)) + ((10000 * _weapon_index) + 5000 * bow_struct_object[_weapon_index].level)));

            // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
            string set_bow_level_str = "bow" + _weapon_index.ToString() + "_level";
            PlayerPrefs.SetInt(set_bow_level_str, bow_struct_object[_weapon_index].level);
            PlayerPrefs.Save();

            // 무기가 어떤 npc에 장착되어 있는지 Local변수를 가져옴.
            // NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
            string get_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
            switch (PlayerPrefs.GetInt(get_bow_to_npc_str, 100))
            {
                case 4:
                    NPC04_make.NPC04_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC04_make.NPC04_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC04_make.NPC04_struct.add_damage);
                    break;

                case 5:
                    NPC05_make.NPC05_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC05_make.NPC05_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC05_make.NPC05_struct.add_damage);
                    break;

                case 6:
                    NPC06_make.NPC06_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC06_make.NPC06_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC06_make.NPC06_struct.add_damage);
                    break;

                case 10:
                    NPC10_make.NPC10_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC10_make.NPC10_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC10_make.NPC10_struct.add_damage);
                    break;

                case 11:
                    NPC11_make.NPC11_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC11_make.NPC11_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC11_make.NPC11_struct.add_damage);
                    break;

                case 12:
                    NPC12_make.NPC12_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC12_make.NPC12_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC12_make.NPC12_struct.add_damage);
                    break;

                default:
                    print("해당 무기는 npc가 가지고 있지 않음.");
                    break;

            }
        }

        public static void equip_the_bow(int _weapon_index, popup_window_button_mgr.NPC_INDEX _npc_index)
        {


            string set_bow_to_npc_str;
            // NPC에 Damage 추가 && NPC Damage 추가 Label Update.

            switch (_npc_index)
            {
                case popup_window_button_mgr.NPC_INDEX.NPC04:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC04;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 4);
                    PlayerPrefs.Save();

                    NPC04_make.NPC04_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC04_make.NPC04_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC04_make.NPC04_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC05:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC05;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 5);
                    PlayerPrefs.Save();

                    NPC05_make.NPC05_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC05_make.NPC05_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC05_make.NPC05_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC06:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC06;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 6);
                    PlayerPrefs.Save();

                    NPC06_make.NPC06_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC06_make.NPC06_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC06_make.NPC06_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC10:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC10;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 10);
                    PlayerPrefs.Save();

                    NPC10_make.NPC10_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC10_make.NPC10_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC10_make.NPC10_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC11:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC11;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 11);
                    PlayerPrefs.Save();

                    NPC11_make.NPC11_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC11_make.NPC11_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC11_make.NPC11_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC12:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC12;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 12);
                    PlayerPrefs.Save();

                    NPC12_make.NPC12_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC12_make.NPC12_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC12_make.NPC12_struct.add_damage);
                    break;
            }

        }

        // 활 버튼 && 라벨 Update.
        public static void update_bow_data_label(int _weapon_index)
        {
            string level_label = "_bow" + _weapon_index.ToString() + "_level_label";
            string damage_label = "_bow" + _weapon_index.ToString() + "_damage_label";
            string lvup_cost_label = "_bow" + _weapon_index.ToString() + "_upgrade_cost_label";

            GameObject.Find(level_label).GetComponent<UILabel>().text = bow_struct_object[_weapon_index].level.ToString();
            GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(bow_struct_object[_weapon_index].damage);
            GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format_won(bow_struct_object[_weapon_index].upgrade_cost);
        }

        // ************************************************************************  wing Functions ************************************************************************ //

        /// Wing data init 함수.
		public static void Wing_data_struct_update(int _wing_index)
        {
            // Wing Data 능력치 부여 공식.
            wing_struct_object[_wing_index].plus_gold = (ulong)(_wing_index * 2 + 2);

            // =POWER(2.145,B7)*50000000+POWER(2.425,B7)*1000000
            wing_struct_object[_wing_index].upgrade_cost = (ulong) Mathf.Round( Mathf.Pow(2.145f, (_wing_index+9))*50000000 + Mathf.Pow(2.425f, (_wing_index + 9)) * 1000000);

            // Wing is enable 되어 있는지 확인. ( 0 : false, 1 : true)
            int check_armor_enable = PlayerPrefs.GetInt("wing_" + _wing_index.ToString() + "_enable", 0);
            if (check_armor_enable == 1)
            {
                // Armor is enable 해당 Armor status창 enable시켜줌.
                Wing_enable(_wing_index);
            }
            else
            {
                string lvup_cost_label = "_wing" + _wing_index.ToString() + "_upgrade_cost_label";
                GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format_won(wing_struct_object[_wing_index].upgrade_cost);
            }

        }


        /// <summary>
        /// wing 레벨 UP && Data Update.
        /// </summary>
        /// <param name="_wing_index"></param>
        public static void Wing_enable(int _wing_index)
        {
            // unlock되어 있는 wing object enable시킴.
            wing_struct_object[_wing_index].wing_enable_gameobject.SetActive(true);

            // Wing 구매시 Wing enable상태를 Local에 저장. ( 0 : false, 1 : true)
            string set_wing_enable_str = "wing" + _wing_index.ToString() + "_enable";
            PlayerPrefs.SetInt(set_wing_enable_str, 1);
            PlayerPrefs.Save();

            // unlock sprite 제거해줌.
            string unlock_armor_sprite = "_wing" + _wing_index.ToString() + "_unlock_sprite";
            GameObject.Find(unlock_armor_sprite).SetActive(false);

        }

        /// <summary>
        /// 캐릭터 index와 wing index를 받아서 해당 캐릭터 attack speed를 변경해 줄 함수.
        /// </summary>
        /// <param name="_wing_index_skill"></param>
        /// <param name="_npc_inde"></param>
        public static void get_wing_skill_func(int _wing_index_skill, popup_window_button_mgr.NPC_INDEX _npc_index)
        {
            Animator anim;

            // wing index에 따라서 공격속도 달리 설정해 줄 변수 선언.
            float animation_speed = 0f;
            float attack_speed = 0f;

            print("To Save wing index :: " + _wing_index_skill);
            print("To Save npc index :: " + (int)_npc_index);

            // 해당 wing이 어떤 npc에 저장되어 있는지 판별할 Local 변수에 저장해줌
            // Ex) NPC01 : 1 , NPC02 : 2.... 임. enum값때문.
            PlayerPrefs.SetInt("wing" + _wing_index_skill + "_npc", (int)_npc_index);
            PlayerPrefs.Save();

            // Wing index별 스킬 추가.
            // Wing index에 해당하는 스킬을 할당해줌.
            switch (_wing_index_skill)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    // 속도 Level 1
                    animation_speed = 1f;
                    attack_speed = 0.9f;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    // 속도 Level 2
                    animation_speed = 1f;
                    attack_speed = 0.8f;
                    break;

                case 10:
                    // 속도 Level 3
                    animation_speed = 1f;
                    attack_speed = 0.7f;
                    break;

                case 11:
                    // 속도 Level 4
                    animation_speed = 1.5f;
                    attack_speed = 0.6f;
                    break;

                case 12:
                case 13:
                    // 속도 level 5
                    animation_speed = 1.5f;
                    attack_speed = 0.5f;
                    break;

                case 14:
                case 15:
                    // 속도 Level 6
                    animation_speed = 1.7f;
                    attack_speed = 0.4f;
                    break;

                case 16:
                    // 속도 Level 7
                    animation_speed = 2.3f;
                    attack_speed = 0.3f;
                    break;

                case 17:
                case 18:
                    // 속도 Level 8
                    animation_speed = 3.2f;
                    attack_speed = 0.2f;
                    break;

                case 19:
                    // 속도 Level MAX
                    animation_speed = 6f;
                    attack_speed = 0.1f;
                    break;

                default:
                    print("wing index error!!!");
                    break;
            }


            // 해당 NPC에 wing skill 속도를 setting해줌.
            switch(_npc_index)
            {
                case popup_window_button_mgr.NPC_INDEX.NPC01:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();
                    npc01.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC01_make.NPC01_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1-attack_speed)*100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC02:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();
                    npc02.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC02_make.NPC02_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC03:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();
                    npc03.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC03_make.NPC03_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC04:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();
                    npc04.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC04_make.NPC04_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC05:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();
                    npc05.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC05_make.NPC05_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC06:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();
                    npc06.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC06_make.NPC06_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC07:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();
                    npc07.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC07_make.NPC07_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC08:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    anim = GameObject.Find("Impl8").GetComponent<Animator>();
                    print("npc8 speed :::" + anim.speed.ToString());
                    anim.speed = animation_speed;

                    // 캐릭터 공격속도 변경.
                    NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();
                    npc08.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC08_make.NPC08_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC09:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    anim = GameObject.Find("Impl9").GetComponent<Animator>();
                    print("npc9 speed :::" + anim.speed.ToString());
                    anim.speed = animation_speed;

                    // 캐릭터 공격속도 변경.
                    NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();
                    npc09.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC09_make.NPC09_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC10:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();
                    npc10.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC10_make.NPC10_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC11:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC11_make npc11= NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();
                    npc11.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC11_make.NPC11_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC12:
                    // 캐릭터 공격 애니메이션 속도 변경.
                    // 캐릭터 공격속도 변경.
                    NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();
                    npc12.change_attack_speed(attack_speed,animation_speed);

                    // 캐릭터 state창에서 공격속도증가 Label에 update해줘야함.
                    NPC12_make.NPC12_struct.add_speed_label.GetComponent<UILabel>().text = "+" + ((1 - attack_speed) * 100) + "%";
                    break;

                default:
                    print("To accept wing skill,npc index error");
                    break;
            }
        }

        // ************************************************************************  Armor Functions ************************************************************************ //



        /// Armor data init 함수.
        public static void Armor_data_struct_update(int _armor_index)
        {
            // Armor Data 능력치 부여 공식.
            // =POWER(1.925,A4)*5000000+POWER(2.125,A4)*1000000
            armor_struct_object[_armor_index].upgrade_cost = (ulong)(Mathf.Round( Mathf.Pow(1.925f, _armor_index)* 5000000 + Mathf.Pow(2.125f, _armor_index)* 1000000));

            // Armor가 enable 되어 있는지 확인. ( 0 : false, 1 : true)
            int check_armor_enable = PlayerPrefs.GetInt("armor" + _armor_index.ToString() + "_enable", 0);
            if (check_armor_enable == 1)
            {
                // unlock sprite 제거해줌.
                string unlock_armor_sprite = "_armor" + _armor_index.ToString() + "_unlock_sprite";
                GameObject.Find(unlock_armor_sprite).SetActive(false);
                // unlock되어 있는 armor object enable시킴.
                armor_struct_object[_armor_index].armor_enable_gameobject.SetActive(true);
            }
            else
            {
                // 해당 armor는 아직 구입전 상태로 구매비용 label에 update해줘야 함. 
                string lvup_cost_label = "_armor" + _armor_index.ToString() + "_upgrade_cost_label";
                GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format_won(armor_struct_object[_armor_index].upgrade_cost);
            }
        }

        /// <summary>
        ///  캐릭터 init시 참조 함수 && 캐릭터 선택창 popup window시 호출 함수.
        /// </summary>
        /// <param name="_armor_index"></param>
        /// <param name="_npx_index"></param>
        public static void get_armor_skill_func(int _armor_index, int _npx_index)
        {
            print("_npx_index : "+ _npx_index + "_armor_index ::: " + _armor_index);

            string set_armor_to_npc_str;

            // Armor index별 스킬 추가.
            // Armor index에 해당하는 스킬을 할당해줌.
            switch (_armor_index)
            {
                case 0:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 1 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash1 gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.1f;
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 "+ (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 10% 증가");
                    break;

                case 1:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash1 gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.1f;
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 10% 증가");
                    break;
                    
                case 2:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash1 gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.15f;
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 15% 증가");
                    break;

                case 3:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash1 gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.15f;
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 15% 증가");
                    break;

                case 4:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 0.15f;
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 15% 증가");
                    break;

                case 5:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.19f;
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 19% 증가");
                    break;

                case 6:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.19f;
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 19% 증가");
                    break;

                case 7:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 0.19f;
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 19% 증가");
                    break;

                case 8:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent + 0.19f;
                    // slash skill label update
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "위아래베기 골드 획득량 19% 증가");
                    break;

                case 9:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.25f;
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 25% 증가");
                    break;

                case 10:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.25f;
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 25% 증가");
                    break;

                case 11:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 0.25f;
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 25% 증가");
                    break;

                case 12:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent + 0.25f;
                    // slash skill label update
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "위아래베기 골드 획득량 25% 증가");
                    break;

                case 13:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent + 0.25f;
                    // slash skill label update
                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "3연속베기 골드 획득량 25% 증가");
                    break;

                case 14:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 50% 증가");
                    break;

                case 15:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 50% 증가");
                    break;

                case 16:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 50% 증가");
                    break;

                case 17:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "위아래베기 골드 획득량 50% 증가");
                    break;

                case 18:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "3연속베기 골드 획득량 50% 증가");
                    break;

                case 19:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[5].add_gold_percent = GameData.slash_struct_object[5].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[5].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[5].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "번개베기 골드 획득량 50% 증가");
                    break;

                case 20:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[6].add_gold_percent = GameData.slash_struct_object[6].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[6].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[6].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "겹쳐베기 골드 획득량 50% 증가");
                    break;

                case 21:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[7].add_gold_percent = GameData.slash_struct_object[7].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[7].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[7].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "동전베기 골드 획득량 50% 증가");
                    break;

                case 22:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[8].add_gold_percent = GameData.slash_struct_object[8].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[8].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[8].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "전자베기 골드 획득량 50% 증가");
                    break;

                case 23:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[9].add_gold_percent = GameData.slash_struct_object[9].add_gold_percent + 0.5f;
                    // slash skill label update
                    GameData.slash_struct_object[9].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[9].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "울버베기 골드 획득량 50% 증가");
                    break;

                case 24:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 100% 증가");
                    break;

                case 25:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 100% 증가");
                    break;

                case 26:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 100% 증가");
                    break;

                case 27:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "위아래베기 골드 획득량 100% 증가");
                    break;

                case 28:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "3연속베기 골드 획득량 100% 증가");
                    break;

                case 29:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[5].add_gold_percent = GameData.slash_struct_object[5].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[5].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[5].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "번개베기 골드 획득량 100% 증가");
                    break;


                case 30:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[6].add_gold_percent = GameData.slash_struct_object[6].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[6].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[6].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "겹쳐베기 골드 획득량 100% 증가");
                    break;

                case 31:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[7].add_gold_percent = GameData.slash_struct_object[7].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[7].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[7].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "동전베기 골드 획득량 100% 증가");
                    break;
                    
                case 32:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[8].add_gold_percent = GameData.slash_struct_object[8].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[8].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[8].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "전자베기 골드 획득량 100% 증가");
                    break;

                case 33:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[9].add_gold_percent = GameData.slash_struct_object[9].add_gold_percent + 1f;
                    // slash skill label update
                    GameData.slash_struct_object[9].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[9].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "울버베기 골드 획득량 100% 증가");
                    break;

                case 34:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for(int i=0;i<10;i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 0.5f;
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 50% 증가");
                    break;

                case 35:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        print("i : " + i);
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 1f;
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 100% 증가");

                    break;

                case 36:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 2f;
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 200% 증가");

                    break;

                case 37:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 3f;
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 300% 증가");
                    break;

                case 38:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 5f;
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 500% 증가");
                    break;

                case 39:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 7f;
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 700% 증가");
                    break;

                case 40:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 10f;
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 1000% 증가");
                    break;

                default:
                    print("_armor_index error!!!!!");
                    break;
                    // To do.....
                    // 남은 armor 스킬 추가.


            }

        }

        /// <summary>
        /// Armor 장착 해제시 slash 추가 공격력 빠지게 할 함수.
        /// </summary>
        /// <param name="_armor_index"></param>
        /// <param name="_npx_index"></param>
        public static void reset_armor_skill_func(int _armor_index)
        {
            print("reset armor index ::: " + _armor_index);
            // Armor index에 해당하는 스킬을 없애줌.
            switch (_armor_index)
            {
                case 0:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.1f;
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";

                    break;

                case 1:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.1f;
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 2:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.15f;
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 3:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.15f;
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 4:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 0.15f;
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 5:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.19f;
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 6:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.19f;
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 7:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 0.19f;
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 8:
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent - 0.19f;
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 9:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 10:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 11:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 12:
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 13:
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 14:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 15:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 16:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 17:
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 18:
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 19:
                    GameData.slash_struct_object[5].add_gold_percent = GameData.slash_struct_object[5].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[5].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[5].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 20:
                    GameData.slash_struct_object[6].add_gold_percent = GameData.slash_struct_object[6].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[6].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[6].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 21:
                    GameData.slash_struct_object[7].add_gold_percent = GameData.slash_struct_object[7].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[7].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[7].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 22:
                    GameData.slash_struct_object[8].add_gold_percent = GameData.slash_struct_object[8].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[8].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[8].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 23:
                    GameData.slash_struct_object[9].add_gold_percent = GameData.slash_struct_object[9].add_gold_percent - 0.5f;

                    GameData.slash_struct_object[9].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[9].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 24:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 1f;
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 25:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 1f;
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 26:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 1f;
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 27:
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent - 1f;
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 28:
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent - 1f;
                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 29:
                    GameData.slash_struct_object[5].add_gold_percent = GameData.slash_struct_object[5].add_gold_percent - 1f;
                    GameData.slash_struct_object[5].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[5].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 30:
                    GameData.slash_struct_object[6].add_gold_percent = GameData.slash_struct_object[6].add_gold_percent - 1f;
                    GameData.slash_struct_object[6].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[6].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 31:
                    GameData.slash_struct_object[7].add_gold_percent = GameData.slash_struct_object[7].add_gold_percent - 1f;
                    GameData.slash_struct_object[7].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[7].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 32:
                    GameData.slash_struct_object[8].add_gold_percent = GameData.slash_struct_object[8].add_gold_percent - 1f;
                    GameData.slash_struct_object[8].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[8].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 33:
                    GameData.slash_struct_object[9].add_gold_percent = GameData.slash_struct_object[9].add_gold_percent - 1f;
                    GameData.slash_struct_object[9].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[9].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 34:
                    for(int i=0;i<10;i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 0.5f;
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 35:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 1f;
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 36:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 2f;
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 37:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 3f;
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 38:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 5f;
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 39:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 7f;
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 40:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 10f;
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;
                default:
                    print("Armor index error!!!");
                    break;


            }
        }
        public static void set_npc_skill_label(int get_npc_index , string skill_str)
        {
            
            switch(get_npc_index)
            {

                case 0:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC01_make.NPC01_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 1:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC02_make.NPC02_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 2:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC03_make.NPC03_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 3:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC04_make.NPC04_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 4:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC05_make.NPC05_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 5:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC06_make.NPC06_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 6:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC07_make.NPC07_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 7:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC08_make.NPC08_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 8:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC09_make.NPC09_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 9:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC10_make.NPC10_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 10:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC11_make.NPC11_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 11:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC12_make.NPC12_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
            }
        }

        // ************************************************************************  common Functions ************************************************************************ //

        //check whether upgrade buttons are possiable or not
        public static void check_weapon_buttons_is_enable_or_not()
        {
            // 무기 버튼 체크.
            for (int i = 0; i < weapon_MAX; i++)
            {
                if (GameData.coin_struct.gold >= weapon_struct_object[i].upgrade_cost)
                {
                    weapon_struct_object[i].lvup_button.GetComponent<UIButton>().isEnabled = true;
                }
                else
                {
                    weapon_struct_object[i].lvup_button.GetComponent<UIButton>().isEnabled = false;
                }
            }

            // 활 버튼 체크.
            for (int i = 1; i < bow_MAX; i++)
            {
                if (GameData.coin_struct.gold >= bow_struct_object[i].upgrade_cost)
                {
                    bow_struct_object[i].lvup_button.GetComponent<UIButton>().isEnabled = true;
                }
                else
                {
                    bow_struct_object[i].lvup_button.GetComponent<UIButton>().isEnabled = false;
                }
            }
        }

        public static void check_armor_buttons_is_enable_or_not()
        {
            // Armor 버튼 체크.
            for (int i = 0; i < 41; i++)
            {
                if (GameData.coin_struct.gold >= armor_struct_object[i].upgrade_cost)
                {
                    armor_struct_object[i].armor_buy_button.GetComponent<UIButton>().isEnabled = true;
                }
                else
                {
                    armor_struct_object[i].armor_buy_button.GetComponent<UIButton>().isEnabled = false;
                }
            }
        }

        public static void check_wing_buttons_is_enable_or_not()
        {
            // Wing 버튼 체크.
            for (int i = 0; i < 20; i++)
            {
                if (GameData.coin_struct.gold >= wing_struct_object[i].upgrade_cost)
                {
                    wing_struct_object[i].wing_buy_button.GetComponent<UIButton>().isEnabled = true;
                }
                else
                {
                    wing_struct_object[i].wing_buy_button.GetComponent<UIButton>().isEnabled = false;
                }
            }
        }
    }
}

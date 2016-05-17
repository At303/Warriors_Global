using UnityEngine;
using System.Collections;



namespace gamedata 
{
	// Touch Slash Type enum value.
    public enum SLASH_TYPE
    {
        SLASH1,
        SLASH2,
        SLASH3,
        SLASH4,
        SLASH5,
        SLASH6,
        SLASH7,
        SLASH8,
        SLASH9,
        SLASH10,

    }


    // slash struct
    public struct slash_struct
    {
        public int Level;
        public float damage;
        public float add_gold_percent;

        public ulong add_gemstone;
        public ulong upgrade_cost;

        public GameObject slash_locking_sprite;
        public GameObject slash_lv_label;
        public GameObject slash_lvup_cost_label;
        public GameObject slash_damage_label;
        public GameObject slash_bonus_label;
        public GameObject slash_lvup_btn;
        public GameObject slash_enable;
    }



    public class GameData : MonoBehaviour {

        // **************************************    Game data Struct    ************************************************ //

        // Coin Struct
        public struct coin_struct
		{
			public static ulong gold;
			public static int gemstone;
		}

        // Boss Monster Struct
        public struct boss_monster_struct
		{
			public static float HP;
			public static float _HP;
		}

		// Treasure Chest struct
		public struct chest_struct
		{
			public static int Level;
			public static float HP;
			public static float _HP;										// to save the current chest HP

			//public static float drop_gold;
			public static ulong attacked_gold;
			public static ulong attacked_plus_gold;

			public static ulong attacked_gemstone;
            public static ulong attacked_plus_gemstone;

            public static ulong upgrade_cost;
		}
  


        // 처음 시작시 slash struct 초기화.
        public static slash_struct[] slash_struct_object = new slash_struct[10];
        public static int number_of_slash;

        // 캐릭터 무기 바꿀 시 사용하는 구조체.
        public struct to_change_npc_struct
        {
            public static int weapon_index;
            public static string To_Change_Weapon_type;
            public static int armor_index;
            public static int armor_color;
            public static string To_Change_Armor_type;
            public static int bow_index;
            public static string To_Change_bow_type;
			public static int wing_index;
			public static string To_Change_wing_type;

        }

        // **************************************    GameObject data    ************************************************ //
        public static bool sound_on_off;
        public static GameObject debug_label2;

        // Popup Window object
        public static GameObject weapon_sel_popup_window_obj;
        public static GameObject clothes_sel_popup_window_obj;
        public static GameObject bow_sel_popup_window_obj;
		public static GameObject wing_sel_popup_window_obj;
        public static GameObject boss_sel_popup_window_obj;
        public static GameObject setting_popup_window_obj;
        public static GameObject quit_popup_window;
        public static GameObject Ads_popup_window;
        public static GameObject Skill_popup_window;
        public static GameObject Store_popup_window;

        // label object
        public static GameObject gold_total_label;					// gold total label
		public static GameObject gemstone_total_label;				// gemstone total label

		// chest && slashes object
		public static GameObject chest_lv_label;
		public static GameObject chest_dropgold_label;
        public static GameObject chest_dropgemstone_label;

        public static GameObject chest_lvup_cost_label;
		public static GameObject chest_animator;

        // sound object
        public static GameObject sound_on_object;
        public static GameObject sound_off_object;

        public static GameObject slash_effect_sound_object;
        public static GameObject npc_arrow_sound_object;
        public static GameObject npc_sword_sound_object;
        public static GameObject sound_object;


        // boss object
        public static GameObject boss_hp_value;
        public static bool boss_kill_retry_enable;
        public static bool boss_kill_retry_enable_when_timeover;

		// sprite object
		public static GameObject chest_sprite;

		// HUD object
		public static GameObject chest_HUDText_control;

		// animation object
		public static GameObject slash_animation;

		// button Object
		public static GameObject chest_lvup_btn;
        public static GameObject ads_icon_clicked;

        public static UIButton skill1_button_object;
        public static UIButton skill2_button_object;
        public static UIButton skill3_button_object;
        public static UIButton skill4_button_object;

        public static GameObject skill_object;


        // Submenu check 
        public static bool menu1_clicked;
        public static bool menu2_clicked;
        public static bool menu3_clicked;
        public static bool menu4_clicked;
        public static bool menu5_clicked;
        public static bool menu6_clicked;


        // ************************************************************************************************************* //


        // Use this for initialization
        void Awake () {
            menu1_clicked = true;
            menu2_clicked = false;
            menu3_clicked = false;
            menu4_clicked = false;
            menu5_clicked = false;
            menu6_clicked = false;

            // 첫 게임 시작시에는 default로 Sound ON시킴.
            sound_on_off = true;
            boss_kill_retry_enable = true;
            boss_kill_retry_enable_when_timeover = true;

            weapon_sel_popup_window_obj = GameObject.Find("_select_npc_weapon_popup_window");
            clothes_sel_popup_window_obj = GameObject.Find("_select_npc_clothes_popup_window");
            bow_sel_popup_window_obj = GameObject.Find("_select_npc_bow_popup_window");
			wing_sel_popup_window_obj = GameObject.Find ("_select_npc_wing_popup_window");
            boss_sel_popup_window_obj = GameObject.Find("_select_boss_popup_window");
            setting_popup_window_obj = GameObject.Find("popup_setting");
            quit_popup_window = GameObject.Find("popup_quit");
            Ads_popup_window = GameObject.Find("ads_popup_window");
            Skill_popup_window = GameObject.Find("skill_popup_window");
            Store_popup_window = GameObject.Find("store_popup_window");

            gold_total_label = GameObject.Find ("_gold_total_label");
			gemstone_total_label = GameObject.Find ("_gemstone_total_label");
				
			chest_sprite = GameObject.Find ("chest_sprite");
			chest_HUDText_control = GameObject.Find ("chest_HUDText");
			chest_animator = GameObject.Find("chest_sprite_anim");
			
			chest_lvup_btn = GameObject.Find ("chest_levelup_btn");
			chest_lv_label = GameObject.Find ("_chest_lv_label");
			chest_lvup_cost_label = GameObject.Find ("_chest_levelup_cost_label");
			chest_dropgold_label = GameObject.Find ("_chest_drop_gold_label");
            chest_dropgemstone_label = GameObject.Find("_chest_drop_gemstone_label");

            skill1_button_object = GameObject.Find("skill1_button").GetComponent<UIButton>();
            skill2_button_object = GameObject.Find("skill2_button").GetComponent<UIButton>();
            skill3_button_object = GameObject.Find("skill3_button").GetComponent<UIButton>();
            skill4_button_object = GameObject.Find("skill4_button").GetComponent<UIButton>();
            skill_object = GameObject.Find("skill_boost_time_progressbar");
            skill_object.SetActive(false);
                
            // slash struct init.
            for (int i=0;i < 10;i++)
            {
                 
                if(i != 0)
                {
                    // slash1은 unlock sprite가 없기 때문에 제외해줌.
                    slash_struct_object[i].slash_locking_sprite = GameObject.Find("_slash" + i.ToString() + "_locking_sprite");

                    slash_struct_object[i].slash_enable = GameObject.Find("_slash" + i.ToString() + "_enable");
                }

                slash_struct_object[i].slash_lvup_btn = GameObject.Find("_slash" + i.ToString() + "_levelup_btn");
                slash_struct_object[i].slash_lv_label = GameObject.Find("_slash" + i.ToString() + "_lv_label");
                slash_struct_object[i].slash_lvup_cost_label = GameObject.Find("_slash"+ i.ToString() + "_levelup_cost_label");
                slash_struct_object[i].slash_damage_label = GameObject.Find("_slash" + i.ToString() + "_damage_label");
                slash_struct_object[i].slash_bonus_label = GameObject.Find("_slash"+ i.ToString() + "_bonus_label");

                
            }		

            // ads_icon clicked되었을 때 enable해줄 object.
            ads_icon_clicked = GameObject.Find("ads_icon_cliecked");
            ads_icon_clicked.SetActive(false);

            sound_on_object = GameObject.Find("select_music_on_icon");
            sound_off_object = GameObject.Find("select_music_off_icon");
          
            slash_effect_sound_object = GameObject.Find("slash_sound_object");
            npc_arrow_sound_object = GameObject.Find("npc_arrow_sound");
            npc_sword_sound_object = GameObject.Find("npc_sword_sound");
            sound_object = GameObject.Find("sound_objects");

            // **************************************   BOSS GameObject init    ************************************************ //
            boss_hp_value = GameObject.Find ("Boss_Sprite");

			chest_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
            slash_struct_object[0].slash_lvup_btn.GetComponent<UIButton> ().isEnabled = false;

            // **************************************    GameObject init    ************************************************ //
            // Total Gold && gemstone 초기화.
			coin_struct.gold = 0;
			coin_struct.gemstone = 0;

            // Touch Slash 개수 초기화.
            number_of_slash = 1;

            // 보물상자 init and update label //
			chest_struct.attacked_plus_gold = 0;

            // 보물상자 Level 데이터를 가져온 후 해당 값으로 Data Setting.
            if(PlayerPrefs.HasKey("chest_level"))
            {
                int get_chest_level = PlayerPrefs.GetInt("chest_level");
                levelup_chest_data_struct(get_chest_level);
                update_chest_data_label();
            }
            else
            {
                GameData.chest_struct.Level = 1;
               levelup_chest_data_struct(GameData.chest_struct.Level);
                update_chest_data_label();
            }

            // 첫번째 slash는 default로 enable.
            string slash1_level = "slash0_level";
            int slash1_level_value = PlayerPrefs.GetInt(slash1_level,1);
            slash_data_struct_update(0, slash1_level_value);
            update_slash_data_label(0);

            // slash Level 데이터를 가져온 후 해당 값으로 Data Setting.
            for (int i=1;i<10;i++)
            {
                string get_slash_enalbe = "slash" + i.ToString() + "_enable";

                if (PlayerPrefs.HasKey(get_slash_enalbe))
                {

                    // 해당 slash 
                    slash_struct_object[i].slash_enable.SetActive(true);

                    string get_slash_level = "slash" + i.ToString() +"_level";
                    int get_slash_level_value = PlayerPrefs.GetInt(get_slash_level,1);
                    slash_data_struct_update(i,get_slash_level_value);
                    update_slash_data_label(i);

                    slash_struct_object[i].slash_locking_sprite.SetActive(false);                 // Next Slash Object 활성화.
                    number_of_slash++;
                }
                else
                {
                    slash_struct_object[i].slash_enable.SetActive(false);
                }
            }      


        }
		

        void Start()
        {
            string sound_on_off_str = PlayerPrefs.GetString("sound_on_off","ON");
            if (sound_on_off_str == "ON")
            {
                sound_on_off = true;
                sound_on_object.SetActive(true);
                sound_off_object.SetActive(false);

            }
            else
            {
                sound_on_off = false;
                sound_on_object.SetActive(false);
                sound_off_object.SetActive(true);
            }
        }
		// **************			chest function 					************** //

		// **************  Update Chest button all labels
		public static void update_chest_data_label()
		{
			chest_lv_label.GetComponent<UILabel> ().text = chest_struct.Level.ToString ();

			chest_dropgold_label.GetComponent<UILabel> ().text = int_to_label_format_won (chest_struct.attacked_gold);
            chest_lvup_cost_label.GetComponent<UILabel>().text = int_to_label_format_won(chest_struct.upgrade_cost);

            //chest_dropgold_plus_label.GetComponent<UILabel> ().text = int_to_label_format_ea(chest_struct.attacked_plus_gold);

        }

        // 보물상자 구조체에 Level에 따라 data 저장.
        public static void levelup_chest_data_struct(int Level)
		{
            chest_struct.Level = Level;
            // 보물상자 HP , 공격시 얻는 골드,보석 Level 증가 cost 공식.
            chest_struct.HP = 1234 * Mathf.Pow(1.275f, Level);
            chest_struct._HP = 1234 * Mathf.Pow(1.275f, Level);

            // 보물상자 공격시 얻는 골드는 누적.
            chest_struct.attacked_gold = factorial((ulong)chest_struct.Level);

            // =ROUND(9.5751*EXP(0.0487*C3),0)
            chest_struct.upgrade_cost = (ulong)Mathf.Round((Mathf.Exp(0.0487f*Level)) * 9.5751f);     // =ROUND(15.5*C5^1.98,0)     
        }

        public static ulong factorial(ulong n)
        {
            if (n <= 1) return 1;
            return n + factorial(n - 1);
        }

		// **************			slash1 function 					************** //

		// Update slash1 button all labels
		public static void update_slash_data_label(int _slash_index)
		{
            slash_struct_object[_slash_index].slash_lv_label.GetComponent<UILabel> ().text = slash_struct_object[_slash_index].Level.ToString ();
            slash_struct_object[_slash_index].slash_lvup_cost_label.GetComponent<UILabel> ().text = int_to_label_format_won(slash_struct_object[_slash_index].upgrade_cost);

            slash_struct_object[_slash_index].slash_damage_label.GetComponent<UILabel> ().text = int_to_label_format((ulong)slash_struct_object[_slash_index].damage);
        }

        // Slash1 데이터를 해당 레벨에 맞게 Setting해줄 함수.
		public static void slash_data_struct_update(int _slash_index, int Level)
		{
            slash_struct_object[_slash_index].Level = Level;

            // slash 데미지는 레벨에 따라서 누적.
            slash_struct_object[_slash_index].damage = 0;
            for (int i=1;i< Level+1;i++)
            {
                slash_struct_object[_slash_index].damage = slash_struct_object[_slash_index].damage + Mathf.Round(8 * (_slash_index + 1) * (Mathf.Pow(1.175f, i)) + 10);
            }

            // = ROUND((1500*(slash_index+1))*POWER(1.275,Level),0)+ (slash_index+1) * 10000*Level
            slash_struct_object[_slash_index].upgrade_cost = (ulong)Mathf.Round((1500 * (_slash_index+1)) * (Mathf.Pow(1.275f, Level)) + (_slash_index + 1) * 10000 * Level);
        }


        // Slash 레벨업시 Call할 함수.
        public static void slash_data_struct_levelup(int _slash_index, int Level)
        {
            slash_struct_object[_slash_index].Level = Level;

            // slash 데미지는 레벨에 따라서 누적.
            slash_struct_object[_slash_index].damage = 0;
            // slash 데미지는 레벨에 따라서 누적.
            for (int i = 1; i < Level + 1; i++)
            {
                slash_struct_object[_slash_index].damage = slash_struct_object[_slash_index].damage + Mathf.Round(8 * (_slash_index + 1) * (Mathf.Pow(1.175f, i)) + 10);
            }
            slash_struct_object[_slash_index].upgrade_cost = (ulong)Mathf.Round((1500 * (_slash_index + 1)) * (Mathf.Pow(1.275f, Level)) + (_slash_index + 1) * 10000 * Level);


            // slash UnLock.
            if (slash_struct_object[_slash_index].Level == 20 && _slash_index != 9) // max일때는 다음 slash가 없음.
            {
                slash_struct_object[_slash_index+1].slash_enable.SetActive(true);

                string To_set_slash = "slash" + (_slash_index+1).ToString() + "_enable";
                PlayerPrefs.SetInt(To_set_slash, 1);
                PlayerPrefs.Save();

                slash_struct_object[_slash_index+1].Level = 1;
                slash_data_struct_update(_slash_index+1, slash_struct_object[_slash_index+1].Level);
                update_slash_data_label(_slash_index+1);

                slash_struct_object[_slash_index+1].slash_locking_sprite.SetActive(false);                 // Next unlock slash sprite Object 활성화.
                number_of_slash++;
            }
        }

                
        // ********************************************************			etc.. functions 					******************************************************** //

        



        //check whether upgrade buttons are possiable or not
        public static void check_lvup_button_is_enable_or_not()
		{
			// 보물상자 버튼 체크.
			if (coin_struct.gold > chest_struct.upgrade_cost) {
				chest_lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else 
			{
				chest_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

            for (int i = 0; i < 10; i++)
            {
                bool slash_enable_check = true;
                string get_slash_enalbe = "slash" + i.ToString() + "_enable";

                // slash index가 0이 아니고, slash enable이 false일때.
                if ((i != 0) && !(PlayerPrefs.HasKey(get_slash_enalbe)))
                {
                    slash_enable_check = false;
                }

                if (slash_enable_check)
                {
                    // slash1 button check
                    if (coin_struct.gold > slash_struct_object[i].upgrade_cost)
                    {
                        slash_struct_object[i].slash_lvup_btn.GetComponent<UIButton>().isEnabled = true;
                    }
                    else
                    {
                        slash_struct_object[i].slash_lvup_btn.GetComponent<UIButton>().isEnabled = false;
                    }
                }
            
            }
           
			// NPC01 button check
			if (coin_struct.gold > NPC01_make.NPC01_struct.upgrade_cost) {
				NPC01_make.NPC01_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC01_make.NPC01_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC02 enable check
			// NPC02 button check
			if (coin_struct.gold > NPC02_make.NPC02_struct.upgrade_cost) {
				NPC02_make.NPC02_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC02_make.NPC02_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC03 enable check
			// NPC03 button check
			if (coin_struct.gold > NPC03_make.NPC03_struct.upgrade_cost) {
				NPC03_make.NPC03_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC03_make.NPC03_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC04 enable check
			// NPC04 button check
			if (coin_struct.gold > NPC04_make.NPC04_struct.upgrade_cost) {
				NPC04_make.NPC04_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC04_make.NPC04_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC05 enable check
			// NPC05 button check
			if (coin_struct.gold > NPC05_make.NPC05_struct.upgrade_cost) {
				NPC05_make.NPC05_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC05_make.NPC05_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC06 enable check
			// NPC06 button check
			if (coin_struct.gold > NPC06_make.NPC06_struct.upgrade_cost) {
				NPC06_make.NPC06_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC06_make.NPC06_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC07 enable check
			// NPC07 button check
			if (coin_struct.gold > NPC07_make.NPC07_struct.upgrade_cost) {
				NPC07_make.NPC07_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC07_make.NPC07_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC08 enable check
			// NPC08 button check
			if (coin_struct.gold > NPC08_make.NPC08_struct.upgrade_cost) {
				NPC08_make.NPC08_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC08_make.NPC08_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}		

			// NPC09 enable check
			// NPC09 button check
			if (coin_struct.gold > NPC09_make.NPC09_struct.upgrade_cost) {
				NPC09_make.NPC09_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC09_make.NPC09_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC10 enable check
			// NPC10 button check
			if (coin_struct.gold > NPC10_make.NPC10_struct.upgrade_cost) {
				NPC10_make.NPC10_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC10_make.NPC10_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC11 enable check
			// NPC11 button check
			if (coin_struct.gold > NPC11_make.NPC11_struct.upgrade_cost) {
				NPC11_make.NPC11_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC11_make.NPC11_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// NPC12 enable check
			// NPC12 button check
			if (coin_struct.gold > NPC12_make.NPC12_struct.upgrade_cost) {
				NPC12_make.NPC12_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else {
				NPC12_make.NPC12_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

            
        }

        public static string int_to_label_format(ulong _number)
        {
            string _return_label = "";
            int i = 0;
            ulong remainder = 0;
            ulong[] temp_number = new ulong[10];

            for (; i < 10; i++)
            {
                temp_number[i] = _number % 1000;
                remainder = _number / 1000;
                _number = remainder;

                if (remainder == 0)
                    break;
            }

            if (i == 0)
            {
                _return_label = temp_number[0].ToString();
            }
            else if (i == 1)
            {
                _return_label = temp_number[1].ToString() + "K" + temp_number[0].ToString();
            }
            else if (i == 2)
            {
                _return_label = temp_number[2].ToString() + "M" + temp_number[1].ToString() + "K";
            }
            else if (i == 3)
            {
                _return_label = temp_number[3].ToString() + "G" + temp_number[2].ToString() + "M";
            }
            else if (i == 4)
            {
                _return_label = temp_number[4].ToString() + "T" + temp_number[3].ToString() + "G";
            }
            else if (i == 5)
            {
                _return_label = temp_number[5].ToString() + "P" + temp_number[4].ToString() + "T";
            }
            else if (i == 6)
            {
                _return_label = temp_number[6].ToString() + "E" + temp_number[5].ToString() + "P";
            }
            else if (i == 7)
            {
                _return_label = temp_number[7].ToString() + "Z" + temp_number[6].ToString() + "E";
            }
            else if (i == 8)
            {
                _return_label = temp_number[8].ToString() + "Y" + temp_number[7].ToString() + "Z";
            }

            return _return_label;
        }

        public static string int_to_label_format_ea(ulong _number)
		{
			string _return_label = "";
			int i = 0;
			ulong remainder = 0;
			ulong[] temp_number = new ulong[10];

			for(;i < 10 ;i++)
			{
				temp_number [i] = _number % 10000;
				remainder = _number/10000;
				_number = remainder;

				if (remainder == 0)
					break;
			}

			if (i == 0) {
				_return_label = temp_number [0].ToString () + "개";
			} else if (i == 1) {
				_return_label = temp_number [1].ToString () + "만" + temp_number [0].ToString () + "개";
			} else if (i == 2) {
				_return_label = temp_number [2].ToString () + "억" + temp_number [1].ToString () + "만개";
			} else if (i == 3) {
				_return_label = temp_number [3].ToString () + "조" + temp_number [2].ToString () + "억개";
			} else if (i == 4) {
				_return_label = temp_number [4].ToString () + "경" + temp_number [3].ToString () + "조개";
			}else if (i == 5) {
				_return_label = temp_number [5].ToString () + "해" + temp_number [4].ToString () + "경개";
			}else if (i == 6) {
				_return_label = temp_number [6].ToString () + "." + temp_number [5].ToString () + "E";
			}else if (i == 7) {
				_return_label = temp_number [7].ToString () + "." + temp_number [6].ToString () + "Z";
			}else if (i == 8) {
				_return_label = temp_number [8].ToString () + "." + temp_number [7].ToString () + "Y";
			}

			return _return_label;
		}

        public static string int_to_label_format_won(ulong _number)
        {
            string _return_label = "";
            int i = 0;
            ulong remainder = 0;
            ulong[] temp_number = new ulong[10];

            for (; i < 10; i++)
            {
                temp_number[i] = _number % 10000;
                remainder = _number / 10000;
                _number = remainder;

                if (remainder == 0)
                    break;
            }

            if (i == 0)
            {
                _return_label = temp_number[0].ToString() + "원";
            }
            else if (i == 1)
            {
                _return_label = temp_number[1].ToString() + "만" + temp_number[0].ToString() + "원";
            }
            else if (i == 2)
            {
                _return_label = temp_number[2].ToString() + "억" + temp_number[1].ToString() + "만원";
            }
            else if (i == 3)
            {
                _return_label = temp_number[3].ToString() + "조" + temp_number[2].ToString() + "억원";
            }
            else if (i == 4)
            {
                _return_label = temp_number[4].ToString() + "경" + temp_number[3].ToString() + "조원";
            }
            else if (i == 5)
            {
                _return_label = temp_number[5].ToString() + "해" + temp_number[4].ToString() + "경원";
            }
            else if (i == 6)
            {
                _return_label = temp_number[6].ToString() + "." + temp_number[5].ToString() + "E";
            }
            else if (i == 7)
            {
                _return_label = temp_number[7].ToString() + "." + temp_number[6].ToString() + "Z";
            }
            else if (i == 8)
            {
                _return_label = temp_number[8].ToString() + "." + temp_number[7].ToString() + "Y";
            }

            return _return_label;
        }

        public static string int_to_label_format_only_total(ulong _number)
        {
            string _return_label = "";
            int i = 0;
            ulong remainder = 0;
            ulong[] temp_number = new ulong[10];

            for (; i < 10; i++)
            {
                temp_number[i] = _number % 10000;
                remainder = _number / 10000;
                _number = remainder;

                if (remainder == 0)
                    break;
            }

            if (i == 0)
            {
                _return_label = temp_number[0].ToString() + "원";
            }
            else if (i == 1)
            {
                _return_label = temp_number[1].ToString() + "만" + temp_number[0].ToString() + "원";
            }
            else if (i == 2)
            {
                _return_label = temp_number[2].ToString() + "억" + temp_number[1].ToString() + "만" + temp_number[0].ToString() + "원";
            }
            else if (i == 3)
            {
                _return_label = temp_number[3].ToString() + "조" + temp_number[2].ToString() + "억" + temp_number[1].ToString() + "만" + temp_number[0].ToString() + "원";
            }
            else if (i == 4)
            {
                _return_label = temp_number[4].ToString() + "경" + temp_number[3].ToString() + "조" + temp_number[2].ToString() + "억" + temp_number[1].ToString() + "만" + temp_number[0].ToString() + "원";
            }
            else if (i == 5)
            {
                _return_label = temp_number[5].ToString() + "해" + temp_number[4].ToString() + "경" + temp_number[3].ToString() + "조" + temp_number[2].ToString() + "억" + temp_number[1].ToString() + "만" + temp_number[0].ToString() + "원";
            }
            else if (i == 6)
            {
                _return_label = temp_number[6].ToString() + "자" + temp_number[5].ToString() + "해" + temp_number[4].ToString() + "경" + temp_number[3].ToString() + "조" + temp_number[2].ToString() + "억" + temp_number[1].ToString() + "만" + temp_number[0].ToString() + "원";
            }
            else if (i == 7)
            {
                _return_label = temp_number[7].ToString() + "양" + temp_number[6].ToString() + "자" + temp_number[5].ToString() + "해" + temp_number[4].ToString() + "경" + temp_number[3].ToString() + "조" + temp_number[2].ToString() + "억" + temp_number[1].ToString() + "만" + temp_number[0].ToString() + "원";
            }
            else if (i == 8)
            {
                _return_label = temp_number[8].ToString() + "구" + temp_number[7].ToString() + "양" + temp_number[6].ToString() + "자" + temp_number[5].ToString() + "해" + temp_number[4].ToString() + "경" + temp_number[3].ToString() + "조" + temp_number[2].ToString() + "억" + temp_number[1].ToString() + "만" + temp_number[0].ToString() + "원";
            }

            return _return_label;
        }
    }





}
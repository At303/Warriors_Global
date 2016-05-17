using UnityEngine;
using System.Collections;
using gamedata;
using gamedata_weapon;
using UnityEngine.SceneManagement;

public class GM_Boss : MonoBehaviour {

    public struct boss_struct
    {
        public ulong HP;
    }

    // 처음 시작시 Boss struct 초기화.
    public static GameObject[] boss_obj = new GameObject[30];
    public static boss_struct[] boss_st = new boss_struct[30];

    // 어떤 Boss를 Enable할 지 index를 가져올 변수.
    public static int boss_index;

    int slash_index = 0;

    public static float boss_hp;
	public static float _boss_hp;              // 보스 HP 감소시 사용 할 Base 값.

    // 보스와 싸우기 전 Count 다운 Popup 테스트용.
    public static GameObject ready_popup;
    public static GameObject fight_pupup;


    // 보스씬 bgm object.
    GameObject boss_fight_bgm_object;
    GameObject boss_slash_attack_sound_object;
    public static GameObject boss_weapon_attack_sound_object;


    public float start_time = 0.0f;

    // For 데미지 HUD Text.
    public static GameObject slash_HUD;

    public static int touch_count = 0;
    
    public static GameObject ads_retry_button;
    public static bool ads_retry_just_onece = true;
    public static GameObject time_over_window_object;
    void Awake()
    {
        // Count 다운 Popup 테스트용.
        ready_popup = GameObject.Find("ready");
        fight_pupup = GameObject.Find("fight");

        boss_fight_bgm_object = GameObject.Find("boss_fight_bgm_");
        boss_slash_attack_sound_object = GameObject.Find("boss_slash_attack_effect");
        boss_weapon_attack_sound_object = GameObject.Find("boss_weapon_attack_effect");
        time_over_window_object = GameObject.Find("time_over_window");
            
        ads_retry_button = GameObject.Find("RETRYBUTTON");    
        // Boss HP init && object 가져오기.
        for (int i = 0; i < 30; i++)
        {
			boss_st[i].HP = (ulong)( 210245*Mathf.Pow(2.075f,i) + 210245 * Mathf.Pow(1.983f,i));                                            // Boss HP init.
            boss_obj[i] = GameObject.Find("Boss" + i.ToString() + "_Sprite");               // object 가져오기.

            boss_obj[i].SetActive(false);                                                   // 처음에는 전부 False시켜줌.
        }


    }

    // Use this for initialization
    void Start () {

         // 게임 시작시 sound on off값을 가져오고, sound on off 결정.
        if(GameData.sound_on_off)
        {
            // Boss 씬 BGM Play
            boss_fight_bgm_object.GetComponent<AudioSource>().Play(0);
        }
        
        // 처음 시작시에는 무조건 1회 가능하게.
        ads_retry_just_onece = true;
        
        start_time = Time.time + 10;
        // 이전 씬에서 어떤 보스와 싸울지 index값을 가져오고, 해당 index에 맞는 boss HP return
        boss_hp = _boss_hp = boss_st[boss_index].HP;
        print("Boss HP : " + boss_hp.ToString());

        // 가져온 Boss Index에 해당하는 보스 몬스터를 Active 시켜줌.
        boss_obj[boss_index].SetActive(true);

        // Boss에 Damage입힐 시, HUD
        slash_HUD = GameObject.Find("slash_HUD");

    }

    // Update is called once per frame
    void Update () 
	{
        // 처음 Boss Scene진입 시 카운트 다운 시작.
        if (!Boss_make.start_boss_kill)
        {
            double time = (start_time - Time.time) / 10.0f;        // For test set 10 sec.

            string cmp = string.Format("{0:0.0}", time * 10);
            if (cmp == "9.5")
            {
                ready_popup.SetActive(true);
            }
            else if (cmp == "7.5")
            {
                ready_popup.SetActive(false);
                fight_pupup.SetActive(true);
            }
            else if (cmp == "6.5")
            {
                fight_pupup.SetActive(false);
                Boss_make.start_boss_kill = true;

                // Boss Kill Time 세팅.
                Boss_make.target_time = Time.time + 10;
            }
           
        }

        if (Input.GetMouseButtonDown(0) && Boss_make.start_boss_kill)
		{
            float fHP = 0;
           
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

			//If touch is on the fixed range, excute the code.
			if (hit.collider != null)
			{
                if (GameData.sound_on_off)
                {
                    // attack effect sound play.
                    boss_slash_attack_sound_object.GetComponent<AudioSource>().Play(0);
                }
                
                touch_count++;
                // 보스 공격시 보스가 공격당하는 애니메이션 enable
                boss_obj[boss_index].GetComponent<Animator>().SetTrigger("attacked");

                string slash_animation_name = "slash" + (slash_index+1).ToString();
                GameData.slash_animation = GameObject.Find(slash_animation_name);
				    

           		// slash sprite enable
                GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
				GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;


				switch ((SLASH_TYPE)slash_index)
				{
					case SLASH_TYPE.SLASH1:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
						GameObject.Find ("Boss_Object").GetComponent<UIProgressBar> ().value = fHP;
						break;
                    case SLASH_TYPE.SLASH2:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH3:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH4:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH5:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH6:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH7:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH8:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH9:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH10:
                        boss_hp = boss_hp - GameData.slash_struct_object[slash_index].damage;
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;

                }

                // Damage HUDText.
                string slash_damage_hud_str = "-" + GameData.int_to_label_format((ulong)GameData.slash_struct_object[slash_index].damage).ToString();
                slash_HUD.GetComponent<HUDText>().Add(slash_damage_hud_str, Color.red, 0.5f);

                slash_index++;
                // Random touch slash animation
                if (slash_index == GameData.number_of_slash)
				{
                    slash_index = 0;
				}
                if(fHP < 0)
                {
                    // Boss Kill Timer false.
                    Boss_make.start_boss_kill = false;

                    // Get Item popup window 오브젝트가 보스씬 실행시 처음 한번 활성화 되므로 bool변수로 control해줘야 함.
                    boss_popup_window.enable_item_popup = true;

                    // Monster 잡으면 리더보드에 킬 타임 올리고 다음 씬 넘어가기.
                    kill_the_monster();
                    
                }

            }
        }
	}
    public static void kill_the_monster()
    {
        float monster_kill_time_tosave = 10f - (Boss_make.target_time - Time.time);
        
        print("string :::: " + string.Format("{0:F4}", monster_kill_time_tosave));
        print("to save string :::" + (long)Mathf.Floor(monster_kill_time_tosave*10000));
        switch (boss_index)
        {
            case 0:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQAQ", (bool success) => 
            {                    
            });
                break;  

            case 1:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQCA", (bool success) => 
            {
                    
            });
                break;  
                
            case 2:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQCQ", (bool success) => 
            {
                   
            });
                break;  
                
            case 3:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQCg", (bool success) => 
            {
                   
            });
                break; 
                
            case 4:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQCw", (bool success) => 
            {
            });
                break; 
                
            case 5:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQDA", (bool success) => 
            {
            });
                break; 
                
                
            case 6:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQDQ", (bool success) => 
            {
            });
                break; 
                
            case 7:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQDg", (bool success) => 
            {
            });
                break; 
                
            case 8:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQDw", (bool success) => 
            {
            });
                break; 
                
            case 9:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQEA", (bool success) => 
            {
            });
                break; 
                
            case 10:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQEQ", (bool success) => 
            {
            });
                break; 
                
            case 11:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQEg", (bool success) => 
            {
            });
                break; 
                
            case 12:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQEw", (bool success) => 
            {
            });
                break; 
                
            case 13:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQFA", (bool success) => 
            {
            });
                break; 
                
            case 14:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQFQ", (bool success) => 
            {
            });
                break; 
                
            case 15:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQFg", (bool success) => 
            {
            });
                break; 
                
            case 16:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQFw", (bool success) => 
            {
            });
                break; 
                
            case 17:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQGA", (bool success) => 
            {
            });
                break; 
                
            case 18:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQGg", (bool success) => 
            {
            });
                break; 
                
            case 19:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQGw", (bool success) => 
            {
            });
                break; 
                
            case 20:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQHA", (bool success) => 
            {
            });
                break; 
                
            case 21:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQHQ", (bool success) => 
            {
            });
                break; 
                
            case 22:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQHg", (bool success) => 
            {
            });
                break; 
                
            case 23:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQHw", (bool success) => 
            {
            });
                break; 
                
            case 24:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQIA", (bool success) => 
            {
            });
                break; 
                
            case 25:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQIQ", (bool success) => 
            {
            });
                break; 

            case 26:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQIg", (bool success) => 
            {
            });
                break; 
                
            case 27:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQIw", (bool success) => 
            {
            });
                break; 
                
            case 28:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQJA", (bool success) => 
            {
            });
                break; 
                
            case 29:
            Social.ReportScore( (long)Mathf.Floor(monster_kill_time_tosave*10000) , "CgkI6tf649MWEAIQJQ", (bool success) => 
            {
            });
                break;  
                               
            default:
            break;
        }
        
        scene_loading.monster_kill_time = monster_kill_time_tosave;
        SceneManager.LoadScene("Warriors_boss_item_drop");
    }
    
    public static float get_wing_skill_attack_speed(int wing_index)
    {
        float return_anim_attack_speed = 0f;
     
         // Wing index별 스킬 추가.
            // Wing index에 해당하는 스킬을 할당해줌.
            switch (wing_index)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    // 속도 Level 1
                    return_anim_attack_speed = 1f;
                    //attack_speed = 0.9f;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    // 속도 Level 2
                    return_anim_attack_speed = 1f;
                    //attack_speed = 0.8f;
                    break;

                case 10:
                    // 속도 Level 3
                    return_anim_attack_speed = 1f;
                    //attack_speed = 0.7f;
                    break;

                case 11:
                    // 속도 Level 4
                    return_anim_attack_speed = 1.5f;
                    //attack_speed = 0.6f;
                    break;

                case 12:
                case 13:
                    // 속도 level 5
                    return_anim_attack_speed = 1.5f;
                    //attack_speed = 0.5f;
                    break;

                case 14:
                case 15:
                    // 속도 Level 6
                    return_anim_attack_speed = 1.7f;
                    //attack_speed = 0.4f;
                    break;

                case 16:
                    // 속도 Level 7
                    return_anim_attack_speed = 2.3f;
                    //attack_speed = 0.3f;
                    break;

                case 17:
                case 18:
                    // 속도 Level 8
                    return_anim_attack_speed = 3.2f;
                    //attack_speed = 0.2f;
                    break;

                case 19:
                    // 속도 Level MAX
                    return_anim_attack_speed = 6f;
                    //attack_speed = 0.1f;
                    break;

                default:
                    print("wing index error!!!");
                    break;
            }
            
        return return_anim_attack_speed;
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using gamedata;
using gamedata_weapon;

public class boss_button_mgr : MonoBehaviour {

    public static ulong[] boss_enter_cost = new ulong[31];
    public static GameObject[] boss_enter_button_object = new GameObject[31];
	string ToLoadScene_Name;


    public int boss0
    {
        get { return 0; }
    }

    public int boss1
    {
        get { return 1; }
    }

    public int boss2
    {
        get { return 2; }
    }
    public int boss3
    {
        get { return 3; }
    }
    public int boss4
    {
        get { return 4; }
    }
    public int boss5
    {
        get { return 5; }
    }
    public int boss6
    {
        get { return 6; }
    }
    public int boss7
    {
        get { return 7; }
    }
    public int boss8
    {
        get { return 8; }
    }
    public int boss9
    {
        get { return 9; }
    }
    public int boss10
    {
        get { return 10; }
    }

    public int boss11
    {
        get { return 11; }
    }
    public int boss12
    {
        get { return 12; }
    }
    public int boss13
    {
        get { return 13; }
    }
    public int boss14
    {
        get { return 14; }
    }
    public int boss15
    {
        get { return 15; }
    }
    public int boss16
    {
        get { return 16; }
    }
    public int boss17
    {
        get { return 17; }
    }
    public int boss18
    {
        get { return 18; }
    }
    public int boss19
    {
        get { return 19; }
    }
    public int boss20
    {
        get { return 20; }
    }
    public int boss21
    {
        get { return 21; }
    }
    public int boss22
    {
        get { return 22; }
    }
    public int boss23
    {
        get { return 23; }
    }
    public int boss24
    {
        get { return 24; }
    }
    public int boss25
    {
        get { return 25; }
    }
    public int boss26
    {
        get { return 26; }
    }
    public int boss27
    {
        get { return 27; }
    }
    public int boss28
    {
        get { return 28; }
    }
    public int boss29
    {
        get { return 29; }
    }
    public int boss30
    {
        get { return 30; }
    }

   
    
    public void boss_enter_clicked(int boss_index)
    {
        print("boss_index : " + boss_index);
        // Boss Index선택하여 해당 Boss던전으로 입장.
        switch(boss_index)
        {
            case 0:
                GM_Boss.boss_index = boss_index;
                GameData.coin_struct.gold = GameData.coin_struct.gold - boss_enter_cost[boss_index];
                GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);
                
                print("boss index boss_enter_cost[boss_index]: " + boss_enter_cost[boss_index].ToString());
            break;
            case 1:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 2:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 3:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 4:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 5:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 6:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 7:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 8:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 9:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 10:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 11:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 12:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 13:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 14:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 15:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 16:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 17:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 18:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 19:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 20:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 21:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 22:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 23:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 24:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 25:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 26:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 27:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 28:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 29:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
        }

        // 
        select_boss_popup.check_popup_window = false;
        // Boss Scene으로 입장.
        //SceneManager.LoadScene ("warriors_boss");
        ToLoadScene_Name = "warriors_boss";
        StartCoroutine(Load());

        // Boss retry 를 위한 변수.
        GameData.boss_kill_retry_enable = true;
        
        // Gold  변동사항 세이브.
        PlayerPrefs.SetString("gold",GameData.coin_struct.gold.ToString());
        PlayerPrefs.Save();
        
    }
    
    IEnumerator Load()
	{

		AsyncOperation async = SceneManager.LoadSceneAsync(ToLoadScene_Name);

		while(!async.isDone)
		{
		float progress = async.progress * 100.0f;
		print(progress.ToString());
		int pRounded = Mathf.RoundToInt(progress);
		//progressLabel.text = “Loading…”+ pRounded.ToString() + “%”;

		yield return true;
		}

	}
    
   void  Awake()
    {
        
        for(int i=0;i<30;i++)
        {
            // Boss 던전 입장시 지불해야할 보석 공식.
            // =ROUND(110245*POWER(2.175,H4)+110245*POWER(2.175,H4),0)
            boss_enter_cost[i] = (ulong)( 110245*Mathf.Pow(2.175f, i+1) *2 );
            
            // Boss 던전 입장 버튼들 Object값들을 시작시 가져와서 저장해둬야함.
            string find_button_str = "enter_boss" + i.ToString() + "_button";
            boss_enter_button_object[i] = GameObject.Find(find_button_str);

            // Boss 던전 입장 cost를 label에 update.
            string find_cost_label_str = "boss" + i.ToString() + "_cost";
            GameObject.Find(find_cost_label_str).GetComponent<UILabel>().text = GameData.int_to_label_format_won(boss_enter_cost[i]);

            // 처음에는 전부 False시켜주고 popup되었을때, 조건 판별하여 True시켜줌.
            boss_enter_button_object[i].GetComponent<UIButton>().isEnabled = false;

        }

        // 첫번째 boss 버튼은 예외로 항상 true.
        boss_enter_button_object[0].GetComponent<UIButton>().isEnabled = true;


    }
    public static void check_gemstone_for_boss_button()
    {
        for(int i=0;i<30;i++)
        {
            // 현재 사용자가 가지고 있는 골드량을 Boss enter cost와 비교해서 입장을 가능하게 할지 말지 결정.
            if (GameData.coin_struct.gold >= boss_enter_cost[i])
            {
                boss_enter_button_object[i].GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                boss_enter_button_object[i].GetComponent<UIButton>().isEnabled = false;
            }
        }
    }


    public static void check_boss_button_enable_or_not()
    {
        //enter_boss1_button    weapon0_enable , bow0_enable
        for (int i = 0; i < 30; i++)
        {
            print("i :::: " + i);
            if(i == 0)
            {
                print("GameData_weapon.weapon_struct_object[i].enable : " + GameData_weapon.weapon_struct_object[i].enable);
                if (GameData_weapon.weapon_struct_object[i].enable == 0)
                {
                    print("enable");
                    boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                }else
                {
                    print("그렇지 않음.");
                    boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                }
            }
            else if (i < 20)
            {
                // Next 보스로 진입하기 위한 조건 검사 ( 무기 enable && 활 enable )
                if ((GameData_weapon.weapon_struct_object[i].enable == 0) && (GameData_weapon.bow_struct_object[i].enable == 0))
                {
                    print("두 아이템 가지고 있음.");
                    boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
           
                }
                else
                {
                    print("그렇지 않음.");
                    boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                }

            }else
            {

                switch(i)
                {
                    case 20:
                        if (GameData_weapon.bow_struct_object[i].enable == 0)
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                        }
                        else
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                        }
                        break;
                    case 21:
                        if (GameData_weapon.weapon_struct_object[i - 1].enable == 0)
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                        }
                        else
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                        }
                        break;
                    case 22:
                        if (GameData_weapon.bow_struct_object[i - 1].enable == 0)
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                        }
                        else
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                        }
                        break;
                    case 23:
                        if (GameData_weapon.weapon_struct_object[i - 2].enable == 0)
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                        }
                        else
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                        }
                        break;
                    case 24:
                        if (GameData_weapon.bow_struct_object[i - 2].enable == 0)
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                        }
                        else
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                        }
                        break;
                    case 25:
                        if (GameData_weapon.weapon_struct_object[i - 3].enable == 0)
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                        }
                        else
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                        }
                        break;
                    case 26:
                        if (GameData_weapon.bow_struct_object[i - 3].enable == 0)
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                        }
                        else
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                        }
                        break;
                    case 27:
                        if (GameData_weapon.weapon_struct_object[i - 4].enable == 0)
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                        }
                        else
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                        }
                        break;
                    case 28:
                        if (GameData_weapon.bow_struct_object[i - 4].enable == 0)
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = true;
                        }
                        else
                        {
                            boss_enter_button_object[i + 1].GetComponent<UIButton>().isEnabled = false;
                        }
                        break;
                    case 29:
                        // 마지막 보스니 다음 버튼은 없다!!!
                        break;                 
                }  

            }
        }
    }




}

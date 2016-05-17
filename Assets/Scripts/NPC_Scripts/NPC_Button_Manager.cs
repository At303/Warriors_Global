using UnityEngine;
using System.Collections;
using gamedata;
using UnityEngine.SceneManagement;

public class NPC_Button_Manager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ------------------------------------------------------------------------------------------------------------------------------------------------//
	public void Clicked_npc01_Level_UP()
	{
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC01_make.NPC01_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC01 함수를 쓰기 위해 Object 가져옴. 
        NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();

        // update NPC01 데이터.
        NPC01_make.NPC01_struct.Level++;
        npc01.levelup_npc01_data_struct(NPC01_make.NPC01_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if(NPC01_make.NPC01_struct.Level == 2)
        {
            
            PlayerPrefs.SetInt("npc1_enable", 1);
            PlayerPrefs.Save();

            // npc01 캐릭터 init해주고 gameobject Active
            NPC01_make.NPC01_struct.gameobject.SetActive(true);
            npc01.init();

        }

        // 레벨업시 Local에 저장.
        PlayerPrefs.SetInt("npc1_level", NPC01_make.NPC01_struct.Level);
        PlayerPrefs.Save();

        // update NPC01 label Update.
        npc01.update_npc01_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
	}

    public void Clicked_npc02_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC02_make.NPC02_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

		// NPC03 함수를 쓰기 위해 Object 가져옴. 
        NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

        // update NPC02 데이터.
        NPC02_make.NPC02_struct.Level++;
        npc02.levelup_npc02_data_struct(NPC02_make.NPC02_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC02_make.NPC02_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc2_enable", 1);
            PlayerPrefs.Save();

            // npc02 캐릭터 init해주고 gameobject Active
            NPC02_make.NPC02_struct.gameobject.SetActive(true);
            npc02.init();

        }

        // 레벨업시 Local에 저장.
        PlayerPrefs.SetInt("npc2_level", NPC02_make.NPC02_struct.Level);
        PlayerPrefs.Save();

        // update NPC02 label Update.
        npc02.update_npc02_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc03_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC03_make.NPC03_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

		// NPC03 함수를 쓰기 위해 Object 가져옴. 
        NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();

        // update NPC03 데이터.
        NPC03_make.NPC03_struct.Level++;
        npc03.levelup_npc03_data_struct(NPC03_make.NPC03_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC03_make.NPC03_struct.Level == 2)
        {
            print("npc3 enable");
            PlayerPrefs.SetInt("npc3_enable", 1);
            PlayerPrefs.Save();


            // npc03 캐릭터 init해주고 gameobject Active
            NPC03_make.NPC03_struct.gameobject.SetActive(true);
            npc03.init();

        }

        PlayerPrefs.SetInt("npc3_level", NPC03_make.NPC03_struct.Level);
        PlayerPrefs.Save();

        // update NPC03 label Update.
        npc03.update_npc03_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc04_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC04_make.NPC04_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();

        // update NPC 데이터.
        NPC04_make.NPC04_struct.Level++;
        npc04.levelup_npc04_data_struct(NPC04_make.NPC04_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC04_make.NPC04_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc4_enable", 1);
            PlayerPrefs.Save();

            // npc04 캐릭터 init해주고 gameobject Active
            NPC04_make.NPC04_struct.gameobject.SetActive(true);
            npc04.init();

        }

        PlayerPrefs.SetInt("npc4_level", NPC04_make.NPC04_struct.Level);
        PlayerPrefs.Save();

        // update NPC label Update.
        npc04.update_npc04_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc05_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC05_make.NPC05_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();

        // update NPC 데이터.
        NPC05_make.NPC05_struct.Level++;
        npc05.levelup_npc05_data_struct(NPC05_make.NPC05_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC05_make.NPC05_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc5_enable", 1);
            PlayerPrefs.Save();

            // npc04 캐릭터 init해주고 gameobject Active
            NPC05_make.NPC05_struct.gameobject.SetActive(true);
            npc05.init();

        }

        PlayerPrefs.SetInt("npc5_level", NPC05_make.NPC05_struct.Level);
        PlayerPrefs.Save();

        // update NPC label Update.
        npc05.update_npc05_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc06_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC06_make.NPC06_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();

        // update NPC 데이터.
        NPC06_make.NPC06_struct.Level++;
        npc06.levelup_npc06_data_struct(NPC06_make.NPC06_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC06_make.NPC06_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc6_enable", 1);
            PlayerPrefs.Save();

            // npc06 캐릭터 init해주고 gameobject Active
            NPC06_make.NPC06_struct.gameobject.SetActive(true);
            npc06.init();

        }

        PlayerPrefs.SetInt("npc6_level", NPC06_make.NPC06_struct.Level);
        PlayerPrefs.Save();

        // update NPC label Update.
        npc06.update_npc06_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc07_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC07_make.NPC07_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();

        // update NPC 데이터.
        NPC07_make.NPC07_struct.Level++;
        npc07.levelup_npc07_data_struct(NPC07_make.NPC07_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC07_make.NPC07_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc7_enable", 1);
            PlayerPrefs.Save();

            // npc06 캐릭터 init해주고 gameobject Active
            NPC07_make.NPC07_struct.gameobject.SetActive(true);
            npc07.init();

        }

        PlayerPrefs.SetInt("npc7_level", NPC07_make.NPC07_struct.Level);
        PlayerPrefs.Save();

        // update NPC label Update.
        npc07.update_npc07_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc08_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC08_make.NPC08_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();

        // update NPC 데이터.
        NPC08_make.NPC08_struct.Level++;
        npc08.levelup_npc08_data_struct(NPC08_make.NPC08_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC08_make.NPC08_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc8_enable", 1);
            PlayerPrefs.Save();

            // npc06 캐릭터 init해주고 gameobject Active
            NPC08_make.NPC08_struct.gameobject.SetActive(true);
            npc08.init();

        }

        PlayerPrefs.SetInt("npc8_level", NPC08_make.NPC08_struct.Level);
        PlayerPrefs.Save();

        // update NPC label Update.
        npc08.update_npc08_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc09_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC09_make.NPC09_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();

        // update NPC 데이터.
        NPC09_make.NPC09_struct.Level++;
        npc09.levelup_npc09_data_struct(NPC09_make.NPC09_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC09_make.NPC09_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc9_enable", 1);
            PlayerPrefs.Save();

            // npc06 캐릭터 init해주고 gameobject Active
            NPC09_make.NPC09_struct.gameobject.SetActive(true);
            npc09.init();

        }

        PlayerPrefs.SetInt("npc9_level", NPC09_make.NPC09_struct.Level);
        PlayerPrefs.Save();

        // update NPC label Update.
        npc09.update_npc09_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc10_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC10_make.NPC10_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();

        // update NPC 데이터.
        NPC10_make.NPC10_struct.Level++;
        npc10.levelup_npc10_data_struct(NPC10_make.NPC10_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC10_make.NPC10_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc10_enable", 1);
            PlayerPrefs.Save();


            // npc 캐릭터 init해주고 gameobject Active
            NPC10_make.NPC10_struct.gameobject.SetActive(true);
            npc10.init();

        }

        PlayerPrefs.SetInt("npc10_level", NPC10_make.NPC10_struct.Level);
        PlayerPrefs.Save();

        // update NPC label Update.
        npc10.update_npc10_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc11_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC11_make.NPC11_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();

        // update NPC 데이터.
        NPC11_make.NPC11_struct.Level++;
        npc11.levelup_npc11_data_struct(NPC11_make.NPC11_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC11_make.NPC11_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc11_enable", 1);
            PlayerPrefs.Save();

            // npc 캐릭터 init해주고 gameobject Active
            NPC11_make.NPC11_struct.gameobject.SetActive(true);
            npc11.init();

        }

        PlayerPrefs.SetInt("npc11_level", NPC11_make.NPC11_struct.Level);
        PlayerPrefs.Save();
        
        // update NPC label Update.
        npc11.update_npc11_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }

    public void Clicked_npc12_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC12_make.NPC12_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();

        // update NPC 데이터.
        NPC12_make.NPC12_struct.Level++;
        npc12.levelup_npc12_data_struct(NPC12_make.NPC12_struct.Level);

        // npc 최초 생성 시 level은 2가되고 npc_enable변수를 1로 setting 시켜줌 ( enable )
        if (NPC12_make.NPC12_struct.Level == 2)
        {
            PlayerPrefs.SetInt("npc12_enable", 1);
            PlayerPrefs.Save();

            // npc 캐릭터 init해주고 gameobject Active
            NPC12_make.NPC12_struct.gameobject.SetActive(true);
            npc12.init();

        }

        PlayerPrefs.SetInt("npc12_level", NPC12_make.NPC12_struct.Level);
        PlayerPrefs.Save();

        // update NPC label Update.
        npc12.update_npc12_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();
    }


}


    

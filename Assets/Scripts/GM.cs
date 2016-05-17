using UnityEngine;
using System.Collections;
using gamedata;
using gamedata_weapon;
using System;



public class GM : MonoBehaviour {


	// Get a gap of two touch
	int slash_index = 0;
    public static int boost_index = 0;
    public static ulong save_attacked_gold = 0;
    public static GameObject boost_time_label;
    public static UILabel channel1_label;
    public static UILabel channel2_label;
    public static UILabel channel3_label;
    public static UILabel channel4_label;
    public static UILabel channel5_label;

    
    public static UISprite channel1_sprite;
    public static UISprite channel2_sprite;
    public static UISprite channel3_sprite;
    public static UISprite channel4_sprite;
    public static UISprite channel5_sprite;

	public static float target_time = 0.0f;
	public static float base_time = 0.0f;
    
    // 구글 플레이 연동을 위한 변수들.
    bool mAuthOnStart = true;
    bool mInMatch = false;
    System.Action<bool> mAuthCallback;
    
    // 종료 popup window object받아 오기 위한 변수.
    // Use this for initializationf
    void Start () {

        GameData.chest_sprite.SetActive(true);

        // boost time lable을 처음 시작시 가져온다. 처음에는 false시키고 boost time이 enable되있을때만 활성화 시켜줌.
        boost_time_label = GameObject.Find("_boost_time_label");
        boost_time_label.SetActive(false);
        
        channel1_label = GameObject.Find("ads_channel1_count_label").GetComponent<UILabel>();
        channel1_sprite = GameObject.Find("Ads_channel1").GetComponent<UISprite>();

        channel2_label = GameObject.Find("ads_channel2_count_label").GetComponent<UILabel>();
        channel2_sprite = GameObject.Find("Ads_channel2").GetComponent<UISprite>();
        
        channel3_label = GameObject.Find("ads_channel3_count_label").GetComponent<UILabel>();
        channel3_sprite = GameObject.Find("Ads_channel3").GetComponent<UISprite>();
        
        channel4_label = GameObject.Find("ads_channel4_count_label").GetComponent<UILabel>();
        channel4_sprite = GameObject.Find("Ads_channel4").GetComponent<UISprite>();
        
        channel5_label = GameObject.Find("ads_channel5_count_label").GetComponent<UILabel>();
        channel5_sprite = GameObject.Find("Ads_channel5").GetComponent<UISprite>();
        
        // 처음 게임을 시작하면 Gold 데이터를 Local에서 가져옴. 없으면 0으로  Set.
        if (PlayerPrefs.HasKey("gold"))
        {
            string get_gold = PlayerPrefs.GetString("gold");
            GameData.coin_struct.gold = Convert.ToUInt64(get_gold);
        }
        else
        {
            GameData.coin_struct.gold = 0;
        }
       
        // 처음 게임을 시작하면 보석 데이터를 Local에서 가져옴. 없으면 0으로  Set.
        if (PlayerPrefs.HasKey("gemstone"))
        {
            GameData.coin_struct.gemstone =  PlayerPrefs.GetInt("gemstone");

            // 처음 시작시 저장되어 있는 보석을 보고 SKILL enable check.
            GM.check_skills_enable_or_not();            
        }
        else
        {
            GameData.coin_struct.gemstone = 0;            
             // 처음 시작시 저장되어 있는 보석을 보고 SKILL enable check.
            GM.check_skills_enable_or_not();      
        }

        // 게임 시작시 sound on off값을 가져오고, sound on off 결정.
        string sound_on_off_str = PlayerPrefs.GetString("sound_on_off", "ON");
        if (sound_on_off_str == "ON")
        {
            GameData.sound_on_object.SetActive(true);
            GameData.sound_off_object.SetActive(false);
            GameData.sound_object.SetActive(true);
        }
        else
        {
            GameData.sound_on_object.SetActive(false);
            GameData.sound_off_object.SetActive(true);
            GameData.sound_object.SetActive(false);
        }

        //GameData.coin_struct.gold = 10000000000000000000;
        // 골드 && 보석 Label에 Update.
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);
        GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);

		// Check All Buttons
		check_all_function_when_gold_changed();

        // 골드 && 보석 데이터 10초마다 자동 저장.
        StartCoroutine("save_data_gold_gemstone");
        
        // 1초마다 토글메뉴가 On되어 있는 버튼들 체크.
        StartCoroutine("check_button_per_1sec");
       	
		        
        // 벙글 초기화.
        Vungle.init ("5739aca2c595ba6b3c0000e3","","");
        

    }
    void SwitchToMain() {
        //gameObject.GetComponent<MainMenuGui>().MakeActive();
    }

    public void SetAuthOnStart(bool authOnStart) {
        mAuthOnStart = authOnStart;
    }
   

    public static bool enable_boost = false;
    public static float ads1_delay_time = 0.0f;
    public static float ads2_delay_time = 0.0f;
    public static float ads3_delay_time = 0.0f;
    public static float ads4_delay_time = 0.0f;
    public static float ads5_delay_time = 0.0f;

    
    // Update is called once per frame
    void Update () 
	{

         if (channel1_label.enabled)
        {
            float time = (ads1_delay_time - Time.time);

            // ads1 time lable에 남은 시간 update.
            channel1_label.GetComponent<UILabel>().text = string.Format("{0:0초}", time);
             if (time < 0)
            {
                channel1_label.enabled = false;
                channel1_sprite.enabled = true;
            }
        }
        if (channel2_label.enabled)
        {
            float time = (ads2_delay_time - Time.time);

            // ads1 time lable에 남은 시간 update.
            channel2_label.GetComponent<UILabel>().text = string.Format("{0:0초}", time);
             if (time < 0)
            {
                channel2_label.enabled = false;
                channel2_sprite.enabled = true;
            }
        }
        if (channel3_label.enabled)
        {
            float time = (ads3_delay_time - Time.time);

            // ads1 time lable에 남은 시간 update.
            channel3_label.GetComponent<UILabel>().text = string.Format("{0:0초}", time);
             if (time < 0)
            {
                channel3_label.enabled = false;
                channel3_sprite.enabled = true;
            }
        }
        if (channel4_label.enabled)
        {
            float time = (ads4_delay_time - Time.time);

            // ads1 time lable에 남은 시간 update.
            channel4_label.GetComponent<UILabel>().text = string.Format("{0:0초}", time);
             if (time < 0)
            {
                channel4_label.enabled = false;
                channel4_sprite.enabled = true;
            }
        }
        if (channel5_label.enabled)
        {
            float time = (ads5_delay_time - Time.time);

            // ads5 time lable에 남은 시간 update.
            channel5_label.GetComponent<UILabel>().text = string.Format("{0:0초}", time);
             if (time < 0)
            {
                channel5_label.enabled = false;
                channel5_sprite.enabled = true;
            }
        }
        
        // 뒤로가기 버튼 클릭 시, 게임 종료 popup window.
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                // 다른 팝업 윈도우가 열려 있으면 닫고 해당 팝업창 띄워줌.
                if(GameData.Skill_popup_window.activeSelf)
                {
                    GameData.Skill_popup_window.SetActive(false);
                }
                if(GameData.Ads_popup_window.activeSelf)
                {
                    GameData.Ads_popup_window.SetActive(false);
                }
                if(GameData.boss_sel_popup_window_obj.activeSelf)
                {
                    GameData.boss_sel_popup_window_obj.SetActive(false);
                }
            
                // Insert Code Here (I.E. Load Scene, Etc) 
                GameData.quit_popup_window.SetActive(true);
            }
        }
        
        // 광고 클릭 후 골드 2배 및 캐릭터 공속 맥스로 설정하는 코드.
        if (enable_boost)
        {
            float time = (target_time - Time.time) / 10.0f;

            // Boost time lable에 남은 시간 update.
            boost_time_label.GetComponent<UILabel>().text = string.Format("{0:0.0}", time * 10);
            
            // Boost time progressbar update.
            time = (target_time - Time.time) / base_time; 
            GameObject.Find ("skill_boost_time_progressbar").GetComponent<UIProgressBar> ().value = time;
                
            if (time < 0)
            {
                print("end boost time");
                // boost time end.
                enable_boost = false;

                // boost time label false.
                boost_time_label.SetActive(false);
                
                // boost time progressbar false
                GameData.skill_object.SetActive(false);
                
                Color _tochange_color;
                switch (boost_index)
                {
                    case 1:
                        GameData.chest_struct.attacked_gold = save_attacked_gold;
                        break;
                    
                    case 2:
                        // NPC 색상 원상태로 복귀 
                        _tochange_color = new Color(1f, 1f, 1f, 1f);                // Set to red color  
                        unity_ads.check_npc(_tochange_color,false,0,0);             // reset color.
                        unity_ads.reset_npc();                                      // reset attack speed.
                        break;
                    
                    case 3:
                        GameData.chest_struct.attacked_gold = save_attacked_gold;
                        break;
                    
                    case 4:
                        // NPC 색상 원상태로 복귀
                        _tochange_color = new Color(1f, 1f, 1f, 1f);                // Set to red color  
                        unity_ads.check_npc(_tochange_color,false,0,0);             // reset color.
                        unity_ads.reset_npc();                                      // reset attack speed.
                        break;
                    
                    default:
                    
                       break;
                }
            }
        }
        
        // Mouse Click Enable
        //if (Input.GetMouseButtonDown(0))
        //{
            //{

        // Touch Enable
        if (Input.touchCount > 0) 
		{
			Touch touch1 = Input.GetTouch (0);				// first touch

			// if Touch is On
			if (touch1.phase == TouchPhase.Began) 
			{                     
                
                // attack effect sound play.
                // GameData.slash_effect_sound_object.GetComponent<AudioSource>().Play(0);

                //Get the mouse position on the screen and send a raycast into the game world from that position.
                Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                //If touch is on the fixed range, excute the code.
                if (hit.collider != null && hit.collider.name == "Touch_Area" )
                {
                    if (GameData.sound_on_off)
                    {
                        // 공격 효과음 enable.
                        GameData.slash_effect_sound_object.GetComponent<AudioSource>().Play(0);
                    }                   

                    // 보물상자 공격시 보물상자가 공격당하는 애니메이션 enable
                    GameData.chest_animator.GetComponent<Animator>().SetTrigger("attacked");

                    string slash_animation_name = "slash" + (slash_index + 1).ToString();
                    GameData.slash_animation = GameObject.Find(slash_animation_name);

                    // slash sprite enable
                    GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
                    GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;

                    string get_coin_str = "";
                    // Add touch coin to total_coin and update total coin label
                    switch ((SLASH_TYPE)slash_index)
                    {
                        case SLASH_TYPE.SLASH1:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold*GameData.slash_struct_object[0].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;
                        case SLASH_TYPE.SLASH2:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;
                        case SLASH_TYPE.SLASH3:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;

                        case SLASH_TYPE.SLASH4:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;

                        case SLASH_TYPE.SLASH5:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[4].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[4].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;

                        case SLASH_TYPE.SLASH6:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[5].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[5].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;

                        case SLASH_TYPE.SLASH7:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[6].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[6].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;

                        case SLASH_TYPE.SLASH8:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[7].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[7].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;

                        case SLASH_TYPE.SLASH9:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[8].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[8].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;

                        case SLASH_TYPE.SLASH10:
                            GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[9].add_gold_percent);
                            GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

                            // Test HUDText;;;;
                            get_coin_str = "+" + GameData.int_to_label_format_won(GameData.chest_struct.attacked_gold + (ulong)(GameData.chest_struct.attacked_gold * GameData.slash_struct_object[9].add_gold_percent));
                            GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
                            break;
                    }

                    slash_index++;
                    // Random touch slash animation
                    if (slash_index == GameData.number_of_slash)
                    {
                        slash_index = 0;
                    }
                }
                // check upgrade buttons들을 활성화 할 지말지.
                check_all_function_when_gold_changed();				
            }
        }
	}
    
    








 







/*


    
	void FixedUpdate()
	{
        // 뒤로가기 버튼 클릭 시, 게임 종료 popup window.
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                // Insert Code Here (I.E. Load Scene, Etc) 
                GameData.quit_popup_window.SetActive(true);
            }
        }

        if (enable_boost)
        {
            float time = (target_time - Time.time) / 5.0f;

            // Boost time lable에 남은 시간 update.
            boost_time_label.GetComponent<UILabel>().text = string.Format("{0:0.0}", time * 10);
            if (time < 0)
            {
                print("end boost time");
                // boost time end.
                enable_boost = false;

                // boost time label false.
                boost_time_label.SetActive(false);

                // NPC 색상 원상태로 복귀
                Color _tochange_color = new Color(1f, 1f, 1f, 1f);     // Set to red color  
                unity_ads.check_npc(_tochange_color,false);

                print("획득하는 gold & gemstone 원상복귀.");
                GameData.chest_struct.attacked_gold = GameData.chest_struct.attacked_gold / 2;
                GameData.chest_struct.attacked_gemstone = GameData.chest_struct.attacked_gemstone / 2;

            }
        }

        // Single touch
        if (Input.touchCount > 0) 
		{
			Touch touch1 = Input.GetTouch (0);				// first touch

			// if Touch is On
			if (touch1.phase == TouchPhase.Began) 
			{                

                //Get the mouse position on the screen and send a raycast into the game world from that position.
                Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                //If touch is on the fixed range, excute the code.
                if (hit.collider != null && hit.collider.name == "Touch_Area" && !(opened_chest_box.enable_disable_chest_open))
                {
                    if (GameData.sound_on_off)
                    {
                        // attack effect sound play.
                        GameData.slash_effect_sound_object.GetComponent<AudioSource>().Play(0);
                    }

                    // Test HUDText;;;;
                    string get_coin_str = "+" + GameData.chest_struct.attacked_gold + "g";
                    GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.7f);

                    // 보물상자 공격시 보물상자가 공격당하는 애니메이션 enable
                    GameData.chest_animator.GetComponent<Animator>().SetTrigger("attacked");

                    // Add touch coin to total_coin and update total coin label
                    GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold;
                    GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

                    // if chest HP is under 0, reset chest HP.
                    if (GameData.chest_struct._HP <= 0)
                    {
                        print("open chest");

                        // 보물상자가 attacked 애니메이션에 의해 커져있는 상태를 다시 원복시켜줌.
                        GameData.chest_animator.GetComponent<UISprite>().depth = -1;

                        // 보물상자 false시키고 , open된 보물상자 enable
                        //GameData.chest_sprite.SetActive(false);
                        GameData.chest_HP_Bar.SetActive(false);
                        GameData.chest_HP_Bar_bg.SetActive(false);
                        opened_chest_box.enable_disable_chest_open = true;

                        opened_chest_box.target_time = Time.time + 5.0f;
                        GameData.chest_struct._HP = GameData.chest_struct.HP;
                        GameData.chest_sprite.GetComponent<UIProgressBar>().value = GameData.chest_struct._HP;

                        GameData.chest_opened_sprite.SetActive(true);
                    }
                    else
                    {

                        string slash_animation_name = "slash" + (slash_index + 1).ToString();
                        GameData.slash_animation = GameObject.Find(slash_animation_name);
                        slash_index++;

                        // slash sprite enable
                        GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
                        GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;

                        // Chest box HP modify
                        float fHP;
                        switch ((SLASH_TYPE)slash_index)
                        {
                            case SLASH_TYPE.SLASH1:

                                GameData.chest_struct._HP = GameData.chest_struct._HP - (GameData.slash_struct_object[0].damage + GameData.slash_struct_object[0].add_damage);
                                fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
                                GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
                                break;
                            case SLASH_TYPE.SLASH2:

                                GameData.chest_struct._HP = GameData.chest_struct._HP - (GameData.slash_struct_object[1].damage + GameData.slash_struct_object[1].add_damage);
                                fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
                                GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
                                break;
                            case SLASH_TYPE.SLASH3:

                                GameData.chest_struct._HP = GameData.chest_struct._HP - (GameData.slash_struct_object[2].damage + GameData.slash_struct_object[2].add_damage);
                                fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
                                GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
                                break;
                            case SLASH_TYPE.SLASH4:

                                GameData.chest_struct._HP = GameData.chest_struct._HP - (GameData.slash_struct_object[3].damage + GameData.slash_struct_object[3].add_damage);
                                fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
                                GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
                                break;
                            case SLASH_TYPE.SLASH5:

                                GameData.chest_struct._HP = GameData.chest_struct._HP - (GameData.slash_struct_object[4].damage + GameData.slash_struct_object[4].add_damage);
                                fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
                                GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
                                break;
                        }

                        // Random touch slash animation
                        if (slash_index == GameData.number_of_slash)
                        {
                            slash_index = 0;
                        }
                    }
                    // check upgrade buttons들을 활성화 할 지말지.
                    check_all_function_when_gold_changed();
                }

                // 보물상자가 열림. 보석 획득 시작.
                else if (hit.collider != null && hit.collider.name == "Touch_Area")
                {
                    if (GameData.sound_on_off)
                    {
                        // attack effect sound play.
                        GameData.slash_effect_sound_object.GetComponent<AudioSource>().Play(0);
                    }

                    // only touched in the collision area //
                    // Gemstone HUDText;;;;
                    string get_coin_str = "+" + GameData.chest_struct.attacked_gemstone + "G";
                    GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.red, -0.8f);

                    // Random touch slash animation
                    string slash_animation_name = "slash" + (slash_index + 1).ToString();
                    GameData.slash_animation = GameObject.Find(slash_animation_name);
                    slash_index++;

                    // slash sprite enable
                    GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
                    GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;

                    // 보물상자가 open되어 보석을 얻을 수 있음.
                    GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + GameData.chest_struct.attacked_gemstone;
                    GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gemstone);

                    // check upgrade buttons들을 활성화 할 지말지 .
                    check_all_function_when_gems_changed();

                    // Random touch slash animation
                    if (slash_index == GameData.number_of_slash)
                    {
                        slash_index = 0;
                    }

                }
            }
        }
	}
   */


	// 골드획득량 변경시 check해야할 모든 함수 불르기
	public static void check_all_function_when_gold_changed()
	{
		// check upgrade buttons들을 활성화 할 지말지 .
		GameData.check_lvup_button_is_enable_or_not ();                  // check slash && npc
        GameData_weapon.check_weapon_buttons_is_enable_or_not();         // check weapon 

    }
    // 보석획득량 변경시 check해야할 모든 함수 불르기
    public static void check_skills_enable_or_not()
    {
        if(GameData.coin_struct.gemstone >= 1)
        {
            // skill 1 , 2 enable
            GameData.skill1_button_object.isEnabled = true;
            GameData.skill2_button_object.isEnabled = true;
        }else
        {
            GameData.skill1_button_object.isEnabled = false;
            GameData.skill2_button_object.isEnabled = false;
        }
        
        if(GameData.coin_struct.gemstone >= 10)
        {
            // skill 3 , 4 enable
            GameData.skill3_button_object.isEnabled = true;
            GameData.skill4_button_object.isEnabled = true;
        }else
        {
            GameData.skill3_button_object.isEnabled = false;
            GameData.skill4_button_object.isEnabled = false;
        }
        
        GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);
    }

    //  Coroutine   //
    // attack animation coroutine about 2sec.
    IEnumerator save_data_gold_gemstone()
    {
        yield return new WaitForSeconds(5f);    
        string temp_string;

        // 골드 저장.
        temp_string = GameData.coin_struct.gold.ToString();
        PlayerPrefs.SetString("gold", temp_string);

        // 보석 저장.
        PlayerPrefs.SetInt("gemstone", GameData.coin_struct.gemstone);
        print("save gold & gemstone");
        PlayerPrefs.Save();
        
        StartCoroutine("save_data_gold_gemstone");
    }
 IEnumerator check_button_per_1sec()
	{
		yield return new WaitForSeconds(1f);  
        check_button_for_coroutine();       	 
		StartCoroutine("check_button_per_1sec");

	}
    void check_button_for_coroutine()
    {
        if(GameData.menu1_clicked)
        {
            // TO DO...
            // slash & chest button check
            GameData.check_lvup_button_is_enable_or_not();
        }else if(GameData.menu2_clicked)
        {
            // TO DO...
            // NPC button check
            GameData.check_lvup_button_is_enable_or_not();
        }else if(GameData.menu3_clicked)
        {
            // TO DO...
            // weapon button check
            GameData_weapon.check_weapon_buttons_is_enable_or_not();
        }else if(GameData.menu4_clicked)
        {
            // TO DO...
            // armor button check
            GameData_weapon.check_armor_buttons_is_enable_or_not();
        }else if(GameData.menu5_clicked)
        {
            // TO DO...
            // bow button check
            GameData_weapon.check_weapon_buttons_is_enable_or_not();
        }else if(GameData.menu6_clicked)
        {
            // TO DO...
            // wing button check
            GameData_weapon.check_wing_buttons_is_enable_or_not();
        }
    }

}

using UnityEngine;
using gamedata;
using gamedata_weapon;
using UnityEngine.Advertisements;
using UnityEngine.SocialPlatforms;

public class button_manager : MonoBehaviour {

    // Setting 버튼 클릭 시 true , 다시 클릭 시 false.
    bool setting_popup_enable_or_not = false;
    public static GameObject facebook_obj;
    public static GameObject review_obj;

    void Start()
    {
        facebook_obj = GameObject.Find("Facebook_click");
        review_obj = GameObject.Find("AppReview");
    }
	// 보물상자 Level UP Button클릭 시 호출 함수. 
	public void Clicked_Chest_Level_UP()
	{
		// 현재 가지고 있는 골드에서 보물상자 upgrade cost만큼 빼주고 Gold Label에 update.
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.chest_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // 보물상자 레벨 1 증가 시키고 해당 값으로 보물상자 구조체에 Data Setting.
        GameData.chest_struct.Level++;
        GameData.levelup_chest_data_struct(GameData.chest_struct.Level);

        // 보물상자 레벨 1 증가 시킨 값을 Local Data에 저장.
        PlayerPrefs.SetInt("chest_level", GameData.chest_struct.Level);
        PlayerPrefs.Save();

		// Update된 보물상자 데이터를 보물상자 Label에 모두 Update.
		GameData.update_chest_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();

    }

	//slash1 레벨 업 버튼 클릭시 호출 함수
	public void Clicked_slash_Level_UP(int _slash_index)
	{
        // 현재 가지고 있는 골드에서 slash upgrade cost만큼 빼주고 Gold Label에 update.
        GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.slash_struct_object[_slash_index].upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // slash 레벨 1 증가 시키고 해당 값으로 slash 구조체에 Data Setting.
        GameData.slash_struct_object[_slash_index].Level++;
        GameData.slash_data_struct_levelup(_slash_index , GameData.slash_struct_object[_slash_index].Level);

        // slash 레벨 1 증가 시킨 값을 Local Data에 저장.
        string To_levelup_slash = "slash"+ _slash_index.ToString() + "_level";
        PlayerPrefs.SetInt(To_levelup_slash, GameData.slash_struct_object[_slash_index].Level);
        PlayerPrefs.Save();

        // slash index에 따른 추가데미지도 증가시켜줘야함.

        // Update된 slash 데이터를 slash Label에 모두 Update.
        GameData.update_slash_data_label(_slash_index);

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();      

    }

	public void Clicked_boss_scene()
	{
        // 터치 클릭 영역을 boss menu만큼 감소 시킴.
        GameObject.Find("Touch_Area").GetComponent<BoxCollider2D>().size = new Vector2(1085f, 890f);
        GameObject.Find("Touch_Area").transform.position = new Vector2(0, -0.2f);

        // 다른 팝업 윈도우가 열려 있으면 닫고 해당 팝업창 띄워줌.
        if(GameData.Skill_popup_window.activeSelf)
        {
            GameData.Skill_popup_window.SetActive(false);
        }
        if(GameData.Store_popup_window.activeSelf)
        {
            GameData.Store_popup_window.SetActive(false);
        }
        if(GameData.Ads_popup_window.activeSelf)
        {
            GameData.Ads_popup_window.SetActive(false);
        }
        if(GameData.quit_popup_window.activeSelf)
        {
            GameData.quit_popup_window.SetActive(false);
        }
        
        // 처음 게임 시작시 check button 함수를 부르지 않고 popup되었을때만 call하기 위한 변수.
        select_boss_popup.check_popup_window = true;
        
        // Boss 선택 창 Popup Open.
        GameData.boss_sel_popup_window_obj.SetActive(true);

    }

    public void Clicked_AdsPlay_button(int index_ads_channel)
    {
        // 유니티 광고를 불러오기 위한 코드.
        unity_ads unityADs = unity_ads.ads_object.GetComponent<unity_ads>();
        unityADs.ShowRewardedAd(index_ads_channel);
        print("get the coin!@!@!@!@");



    }

    public void Clicked_skill_button()
    {

        // 다른 팝업 윈도우가 열려 있으면 닫고 해당 팝업창 띄워줌.
        if(GameData.Store_popup_window.activeSelf)
        {
            GameData.Store_popup_window.SetActive(false);
        }
        if(GameData.Ads_popup_window.activeSelf)
        {
            GameData.Ads_popup_window.SetActive(false);
        }
        if(GameData.boss_sel_popup_window_obj.activeSelf)
        {
            GameData.boss_sel_popup_window_obj.SetActive(false);
        }
        
        GameData.Skill_popup_window.SetActive(true);

    }
    public void Clicked_skill_window_close_button()
    {

        GameData.Skill_popup_window.SetActive(false);

    }
    
    public void Clicked_store_window_close_button()
    {

        GameData.Store_popup_window.SetActive(false);

    }
      public void Clicked_store_button()
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
        if(GameData.quit_popup_window.activeSelf)
        {
            GameData.quit_popup_window.SetActive(false);
        }
        
        
                
        GameData.Store_popup_window.SetActive(true);

    }
    public void Clicked_Ads_button()
    {

        // 다른 팝업 윈도우가 열려 있으면 닫고 해당 팝업창 띄워줌.
        if(GameData.Skill_popup_window.activeSelf)
        {
            GameData.Skill_popup_window.SetActive(false);
        }
        if(GameData.Store_popup_window.activeSelf)
        {
            GameData.Store_popup_window.SetActive(false);
        }
        if(GameData.boss_sel_popup_window_obj.activeSelf)
        {
            GameData.boss_sel_popup_window_obj.SetActive(false);
        }
        if(GameData.quit_popup_window.activeSelf)
        {
            GameData.quit_popup_window.SetActive(false);
        }
        
        int facebook_enable = PlayerPrefs.GetInt("facebook_enable",100);
        if(facebook_enable == 0)
        {
            facebook_obj.SetActive(false);
        }
        int review_enable = PlayerPrefs.GetInt("review_enable",100);
        
        if(review_enable == 0)
        {
            review_obj.SetActive(false);
        }
        
        GameData.Ads_popup_window.SetActive(true);
        GameData.ads_icon_clicked.SetActive(true);

        // TEMP CODE>>>>>>
        //PlayerPrefs.DeleteAll();
    }
    public void Clicked_Ads_window_close_button()
    {
        // 유니티 광고를 불러오기 위한 코드.
        //unity_ads unityADs = unity_ads.ads_object.GetComponent<unity_ads>();
        //unityADs.ShowRewardedAd();
        GameData.Ads_popup_window.SetActive(false);
        GameData.ads_icon_clicked.SetActive(false);

    }
    public void Clicked_sound_on_off()
    {
        print("sound off" + GameData.sound_on_off.ToString());
        GameData.sound_on_off = !GameData.sound_on_off;
        if (GameData.sound_on_off)
        {
            PlayerPrefs.SetString("sound_on_off","ON");
            PlayerPrefs.Save();
            GameData.sound_on_object.SetActive(true);
            GameData.sound_off_object.SetActive(false);
            GameData.sound_object.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("sound_on_off", "OFF");
            PlayerPrefs.Save();
            GameData.sound_on_object.SetActive(false);
            GameData.sound_off_object.SetActive(true);
            GameData.sound_object.SetActive(false);

        }
    }

    public void Clicked_quit_yes_button()
    {
        
        Application.Quit();
    }
    public void Clicked_quit_no_button()
    {
        GameData.quit_popup_window.SetActive(false);
    }

 public void toggle1_changed()
    {
        {
            GameData.menu1_clicked = true;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = false;
        }

        // NPC 선택 창 Popup Close.
    }
    
     public void toggle2_changed()
    {
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = true;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = false;
        }

    }
    
     public void toggle3_changed()
    {
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = true;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = false;
        }

        GameData_weapon.check_weapon_buttons_is_enable_or_not();

        GameData.weapon_sel_popup_window_obj.SetActive(false);
    }

    public void toggle4_changed()
    {
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = true;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = false;
        }
        // armor 메뉴가 open되어 있으므로 보석량과 gemstone을 비교하여 enable할지 말지 결정.
        GameData_weapon.check_armor_buttons_is_enable_or_not();

        // NPC 선택 창 Popup Close.
        GameData.clothes_sel_popup_window_obj.SetActive(false);
    }

	public void toggle5_changed()
	{
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = true;
            GameData.menu6_clicked = false;
        }
        // NPC 선택 창 Popup Close.
        GameData.bow_sel_popup_window_obj.SetActive(false);
	}
	public void toggle6_changed()
	{
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = true;
        }
        // wing 메뉴가 open되어 있으므로 보석량과 gemstone을 비교하여 enable할지 말지 결정.
        GameData_weapon.check_wing_buttons_is_enable_or_not();

        // NPC 선택 창 Popup Close.
        GameData.wing_sel_popup_window_obj.SetActive(false);
	}
    public void temp_delete_save()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public void skill1_click_button()
    {
        print("clicked skill1 button clicked ");        
        if( !GM.enable_boost )
        {                  
            // Skill1 cost인 보석1개를 지불.
            GameData.coin_struct.gemstone--;
            PlayerPrefs.SetInt("gemstone",GameData.coin_struct.gemstone);
            PlayerPrefs.Save();
            
            // 보석이 변동됬으니 skill이 enable인지 체크.
            GM.check_skills_enable_or_not();
              
            // 광고클릭 후 10초동안 gold 획득량 5배.
            print("5배로 뿔려줌.");
            GM.save_attacked_gold = GameData.chest_struct.attacked_gold;
            GameData.chest_struct.attacked_gold = GameData.chest_struct.attacked_gold * 5;
                    
            GM.enable_boost = true;
            GM.boost_time_label.SetActive(true);
            // Boost time progressbar를 위함.    
            GameData.skill_object.SetActive(true);               
                        
            // skill1 boost time progress bar를 위한 타임 설정.
            GM.target_time = Time.time + 10;
            GM.base_time = 10;
            
            // skill 1번이라고 GM에 Notify.
            GM.boost_index = 1;

            
        }
        Clicked_skill_window_close_button();
    }
    
    public void skill2_click_button()
    {
        print("clicked skill1 button clicked ");  
        if( !GM.enable_boost )
        {
            // Skill2 cost인 보석1개를 지불.
            GameData.coin_struct.gemstone--;
            PlayerPrefs.SetInt("gemstone",GameData.coin_struct.gemstone);
            PlayerPrefs.Save();
            
            // 보석이 변동됬으니 skill이 enable인지 체크.
            GM.check_skills_enable_or_not();
            
            // NPC가 enable되어 있는지 check후 해당 npc 색상을 변경해줌.
            Color tochange_color = new Color(0.8f, 0f, 0f, 1f);     // Set to red color     
            
            // 캐릭터 색상과 attack speed를 아래 함수에서 바꿔줌.  
            unity_ads.check_npc(tochange_color,true,0.1f,6f);

            GM.target_time = Time.time + 5;
            GM.enable_boost = true;
            GM.boost_time_label.SetActive(true);
            
            // Boost time progressbar를 위함.    
            GameData.skill_object.SetActive(true);               
                        
            // skill1 boost time progress bar를 위한 타임 설정.
            GM.target_time = Time.time + 5;
            GM.base_time = 5;
                    
            // skill 1번이라고 GM에 Notify.
            GM.boost_index = 2;
        }   
        Clicked_skill_window_close_button();        
    }
    
    public void skill3_click_button()
    {
        print("clicked skill1 button clicked ");
        if( !GM.enable_boost )
        {
            // Skill3 cost인 보석10개를 지불.
            GameData.coin_struct.gemstone = GameData.coin_struct.gemstone - 10;
            PlayerPrefs.SetInt("gemstone",GameData.coin_struct.gemstone);
            PlayerPrefs.Save();
            
            // 보석이 변동됬으니 skill이 enable인지 체크.
            GM.check_skills_enable_or_not();
            
            // 광고클릭 후 10초동안 gold 획득량 5배.
            print("100배로 뿔려줌.");
            GM.save_attacked_gold = GameData.chest_struct.attacked_gold;
            GameData.chest_struct.attacked_gold = GameData.chest_struct.attacked_gold * 100;
                    
            GM.target_time = Time.time + 10;
            GM.enable_boost = true;
            GM.boost_time_label.SetActive(true);

            // Boost time progressbar를 위함.    
            GameData.skill_object.SetActive(true);                   
                                    
            // skill1 boost time progress bar를 위한 타임 설정.
            GM.target_time = Time.time + 10;
            GM.base_time = 10;
            
            // skill 1번이라고 GM에 Notify.
            GM.boost_index = 3;
        }
        Clicked_skill_window_close_button();
    }
    
    public void skill4_click_button()
    {
        print("clicked skill1 button clicked ");
        if( !GM.enable_boost )
        {
            // Skill4 cost인 보석10개를 지불.
            GameData.coin_struct.gemstone = GameData.coin_struct.gemstone - 10;
            PlayerPrefs.SetInt("gemstone",GameData.coin_struct.gemstone);
            PlayerPrefs.Save();
            
            // 보석이 변동됬으니 skill이 enable인지 체크.
            GM.check_skills_enable_or_not();
            
             // NPC가 enable되어 있는지 check후 해당 npc 색상을 변경해줌.
            Color tochange_color = new Color(0.8f, 0f, 0f, 1f);     // Set to red color     
            
            // 캐릭터 색상과 attack speed를 아래 함수에서 바꿔줌.  
            unity_ads.check_npc(tochange_color,true,0.1f,6f);

            GM.target_time = Time.time + 10;
            GM.enable_boost = true;
            GM.boost_time_label.SetActive(true);
            // Boost time progressbar를 위함.    
            GameData.skill_object.SetActive(true);                   
                                    
            // skill1 boost time progress bar를 위한 타임 설정.
            GM.target_time = Time.time + 10;
            GM.base_time = 10;
            
            // skill 1번이라고 GM에 Notify.
            GM.boost_index = 4;
        }
        Clicked_skill_window_close_button();
    }
    
    public void rank_leaderboardUI()
    {
        Social.ShowLeaderboardUI();
    }
    
    public void clicked_goto_facebook()
    {
        Application.OpenURL("https://www.facebook.com/PowerRoom-1122397801115140/");  
        
        // facebook 좋아요 10개 지급..
        GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + 10;
        PlayerPrefs.SetInt("gemstone",GameData.coin_struct.gemstone);
        PlayerPrefs.Save();
        GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);

        // 한번만 보석 지급을 위해 로컬 변수를 저장.
        PlayerPrefs.SetInt("facebook_enable",0);
        PlayerPrefs.Save();
        
        // window button close
        Clicked_Ads_window_close_button();
        
    }
    
     public void clicked_goto_review()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.PowerRoom.Warriors");  
        
        // facebook 좋아요 10개 지급..
        GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + 10;
        PlayerPrefs.SetInt("gemstone",GameData.coin_struct.gemstone);
        PlayerPrefs.Save();
        GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);

        // 한번만 보석 지급을 위해 로컬 변수를 저장.
        PlayerPrefs.SetInt("review_enable",0);
        PlayerPrefs.Save();

        // window button close
        Clicked_Ads_window_close_button();

    }
    
    public void reset_test_button()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Add_gold_test_button()
    {
        GameData.coin_struct.gold = GameData.coin_struct.gold + 10000000000000000000;
        GameData.coin_struct.gemstone = 10000;

        // 골드 && 보석 Label에 Update.
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);
        GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);
    }
}

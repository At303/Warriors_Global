using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using gamedata;

public class unity_ads : MonoBehaviour
{
    public static GameObject ads_object;
    public static Animator anim;

    public static int ads_index = 0;
     void Start()
    {
               
        ads_object = this.gameObject;
    }
    
        public void ShowRewardedAd(int ads_channel)
    {        
        if (Advertisement.IsReady())
        {
            
            //int ads_random = Random.RandomRange(0,6);
            ads_index++;
            if(ads_index < 2)
            {
                VungleAndroid.playAd();

            }else
            {
                Advertisement.Show();
                if(ads_index > 5)
                {
                    ads_index = 0;                    
                }
            }
            
            // 보석 1개 추가해줌.
            GameData.coin_struct.gemstone++;    
            GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);   
                
            PlayerPrefs.SetInt("gemstone",(int)GameData.coin_struct.gemstone);  
            PlayerPrefs.Save();               
            
            // 보석이 추가됬으니 skill이 enable인지 체크.
            GM.check_skills_enable_or_not();            

            // 광고 클릭 후 15초 딜레이 줌.
            switch (ads_channel)
            {
                case 1:
                    GM.channel1_sprite.enabled = false;
                    GM.channel1_label.enabled = true;                   
                    
                    // 광고 아이콘 타이머 설정.
                    GM.ads1_delay_time = Time.time + 20;
                    break;
                    
                case 2:
                    GM.channel2_sprite.enabled = false;
                    GM.channel2_label.enabled = true;                                     

                    
                    // 광고 아이콘 타이머 설정.
                    GM.ads2_delay_time = Time.time + 20;
                    break;
            
                case 3:
                    GM.channel3_sprite.enabled = false;
                    GM.channel3_label.enabled = true;                    
                    
                    // 광고 아이콘 타이머 설정.
                    GM.ads3_delay_time = Time.time + 20;
                    break;
                    
                case 4:
                    GM.channel4_sprite.enabled = false;
                    GM.channel4_label.enabled = true;
                    
                    // 광고 아이콘 타이머 설정.
                    GM.ads4_delay_time = Time.time + 20;
                    break;
                    
                case 5:
                    GM.channel5_sprite.enabled = false;
                    GM.channel5_label.enabled = true;
                    
                    // 광고 아이콘 타이머 설정.
                    GM.ads5_delay_time = Time.time + 20;
                    break;
                        
                default:
                    print("Fail ads channel!!!");
                    break;
            }

        }

        // 광고 popup window닫아줌.
        GameData.Ads_popup_window.SetActive(false);    
        

    }
    public static void check_npc(Color tochange_color, bool speed_change_enable, float attack_speed, float anim_speed)
    {
        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc1_enable", 0);

        if (check_npc_enable == 1)
        {
            NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();
            npc01.change_color(tochange_color);
            if(speed_change_enable)
            {
                npc01.change_attack_speed(attack_speed,anim_speed);
            }
        }
        
        check_npc_enable = PlayerPrefs.GetInt("npc2_enable", 0);
        if (check_npc_enable == 1)
        {

            NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();
            npc02.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc02.change_attack_speed(attack_speed,anim_speed);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc3_enable", 0);
        if (check_npc_enable == 1)
        {

            NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();
            npc03.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc03.change_attack_speed(attack_speed,anim_speed);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc4_enable", 0);
        if (check_npc_enable == 1)
        {

            NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();
            npc04.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc04.change_attack_speed(0.2f,3.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc5_enable", 0);
        if (check_npc_enable == 1)
        {

            NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();
            npc05.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc05.change_attack_speed(attack_speed,anim_speed);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc6_enable", 0);
        if (check_npc_enable == 1)
        {


            NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();
            npc06.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc06.change_attack_speed(attack_speed,anim_speed);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc7_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();
            npc07.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc07.change_attack_speed(attack_speed,anim_speed);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc8_enable", 0);
        if (check_npc_enable == 1)
        {

            NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();
            npc08.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc08.change_attack_speed(attack_speed,anim_speed);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc9_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();
            npc09.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc09.change_attack_speed(attack_speed,anim_speed);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc10_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();
            npc10.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc10.change_attack_speed(0.2f,3.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc11_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();
            npc11.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc11.change_attack_speed(attack_speed,anim_speed);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc12_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();
            npc12.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc12.change_attack_speed(attack_speed,anim_speed);
            }
        }
        
    }

    public static void reset_npc()
    {
        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc1_enable", 0);

        if (check_npc_enable == 1)
        {
            NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();
            npc01.ads_reset_attack_speed();            
        }

        check_npc_enable = PlayerPrefs.GetInt("npc2_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();
            npc02.ads_reset_attack_speed();
        }

        check_npc_enable = PlayerPrefs.GetInt("npc3_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();
            npc03.ads_reset_attack_speed();
        }

        check_npc_enable = PlayerPrefs.GetInt("npc4_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();
            npc04.ads_reset_attack_speed();
        }

        check_npc_enable = PlayerPrefs.GetInt("npc5_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();
            npc05.ads_reset_attack_speed();
        }

        check_npc_enable = PlayerPrefs.GetInt("npc6_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();
            npc06.ads_reset_attack_speed();
        }

        check_npc_enable = PlayerPrefs.GetInt("npc7_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();
            npc07.ads_reset_attack_speed();
        }

        check_npc_enable = PlayerPrefs.GetInt("npc8_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();
            npc08.ads_reset_attack_speed();
        }

        check_npc_enable = PlayerPrefs.GetInt("npc9_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();
            npc09.ads_reset_attack_speed();
        }

        check_npc_enable = PlayerPrefs.GetInt("npc10_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();
            npc10.ads_reset_attack_speed();
        }

        check_npc_enable = PlayerPrefs.GetInt("npc11_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();
            npc11.ads_reset_attack_speed();

        }

        check_npc_enable = PlayerPrefs.GetInt("npc12_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();
            npc12.ads_reset_attack_speed();

        }
      
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}

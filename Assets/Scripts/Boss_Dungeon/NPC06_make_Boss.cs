using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;
using UnityEngine.SceneManagement;
using gamedata_weapon;
 
public class NPC06_make_Boss : MonoBehaviour, IAnimEventListener
{

    // NPC struct
    public struct NPC06_Boss_struct
    {
        // NPC06 Data. 
        public static bool enable;
        public static int Level;
        public static ulong damage;
        public static ulong add_damage;
        public static float attack_speed;
        public static float add_speed;
        public static ulong upgrade_cost;

    }
    float fHP;

    // 화면에 보여지는 캐릭터 이미지.
    public DevCharacter character;

    // 보스 CountDown이 끝났는지 체크할 변수.
    private bool check_count_down;

    // Use this for initialization
    void Start ()
    {
        // count down이 끝나고 npc animation실행하게 할 변수
        check_count_down = true;

        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc6_enable", 0);
        if (check_npc_enable == 1)
        {
            // 이전의 저장되어있는 캐릭터 무기, 헬멧 , 망또를 불러와서 init 해야함. 
            GameObject.Find("_NPC06_gameobj_intheboss").SetActive(true);                 // npc 캐릭터 활성화.
                                                                                         // npc Level 데이터를 가져온 후 해당 값으로 Data Setting.
            if (PlayerPrefs.HasKey("npc6_level"))
            {
                int get_npc_level = PlayerPrefs.GetInt("npc6_level");
                levelup_npc06_data_struct(get_npc_level);
            }

            init();
        }
        else
        {
            GameObject.Find("_NPC06_gameobj_intheboss").SetActive(false);                 // npc6 캐릭터 비활성화.
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Count Down이 완료 되면 NPC가 공격 시작.
        if (check_count_down && Boss_make.start_boss_kill)
        {
            // attack animation coroutine about 2sec.
            StartCoroutine("npc_attack_func");
            check_count_down = false;
        }

        // 다른 곳에서 보스를 죽이면 보스가 죽엇는지 변수를 체크하여 coroutine stop시킴.
        if (!Boss_make.start_boss_kill)
        {
            StopCoroutine("npc_attack_func");
        }
    }
    public void init()
    {
        // NPC 캐릭터 이미지 초기화.
        character.Info.order = 1;
        character.Info.unit_part = "dwarf-female";
        character.Info.unit_index = 4;
        character.Info.main_weapon_part = "bow-a";
        character.Info.main_weapon_index = 0;
        character.Info.sub_weapon_part = "arrow-a";
        character.Info.sub_weapon_index = 0;

        // Boss Scene Loading시 weapon 체크해야 Error 발생하지 않음 
        // weapon enable값을 가져옴. 없으면 default값으로 0을 setting.
        if (PlayerPrefs.GetInt("npc6_weapon_enable", 0) == 1)
        {
            character.Info.main_weapon_part = PlayerPrefs.GetString("npc6_weapon_part", "");
            character.Info.main_weapon_index = PlayerPrefs.GetInt("npc6_weapon_index", 0);
        }

        if (PlayerPrefs.GetInt("npc6_armor_enable", 0) == 1)
        {
            character.Info.armor_part = PlayerPrefs.GetString("npc6_armor_part", "");
            character.Info.armor_index = PlayerPrefs.GetInt("npc6_armor_index", 0);
            character.Info.armor_color = PlayerPrefs.GetInt("npc6_armor_color", 0);
        }

        if (PlayerPrefs.GetInt("npc6_wing_enable", 0) == 1)
        {
            character.Info.wing_part = PlayerPrefs.GetString("npc6_wing_part", "");
            character.Info.wing_index = PlayerPrefs.GetInt("npc6_wing_index", 0);
                                
            //현재 장착하고 있는 Wing 스킬 Setting.
            Animator anim = GameObject.Find("Impl6").GetComponent<Animator>();
            int equip_wing_index = GameData_weapon.wingDIC[character.Info.wing_part + character.Info.wing_index];       
            anim.speed = GM_Boss.get_wing_skill_attack_speed(equip_wing_index);
        }

        // NPC가 가지고있는 데이터를 setting해줌.
        NPC06_Boss_struct.damage = NPC06_make.NPC06_struct.damage;
        NPC06_Boss_struct.add_damage = NPC06_make.NPC06_struct.add_damage;

        // 무기에 따라서 해당 값을 변경해주면될듯.
        NPC06_Boss_struct.attack_speed = NPC06_make.NPC06_struct.attack_speed;

        character.InitWithoutTextureBaking();

        // Add Attack event clip interface. ( NPC06이 공격 애니메이션 시 사용할 함수를 추가. )
        character.event_listener.Add(this);
    }

    //  Coroutine   //
    // attack animation coroutine about 2sec.
    IEnumerator npc_attack_func()
    {
        yield return new WaitForSeconds(NPC06_Boss_struct.attack_speed);             // 모든 NPC 공격 default속도는 1. attack. 무한반복.
        character.PlayAnimation("anim_bow_shoot", true);                         // NPC공격 animation 실행.

        StartCoroutine("npc_attack_func");

    }

    // Interface //
    // Interface about attacked. ( 캐릭터가 공격 애니메이션 이후 실행 할 함수. )
    public void OnAnimation_Hitting(int _index)
    {

        // 보스 공격시 보스가 공격당하는 애니메이션 enable
        GM_Boss.boss_obj[GM_Boss.boss_index].GetComponent<Animator>().SetTrigger("attacked");
         
        if (GM_Boss.boss_hp > 0)
        {

            // Damage HUDText.
            //string get_coin_str = "-" + (NPC06_Boss_struct.damage + NPC06_Boss_struct.add_damage).ToString();
            string set_npc_attack_damage = "-" + GameData.int_to_label_format((ulong)NPC06_Boss_struct.damage+NPC06_Boss_struct.add_damage).ToString();                                               
            GM_Boss.slash_HUD.GetComponent<HUDText>().Add(set_npc_attack_damage, Color.red, 0.5f);

            // Chest box HP modify.
            GM_Boss.boss_hp = GM_Boss.boss_hp - (NPC06_Boss_struct.damage + NPC06_Boss_struct.add_damage);
            fHP = GM_Boss.boss_hp / GM_Boss._boss_hp;
            GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
        }
        else
        {
            print("kill the boss HP : " + GM_Boss.boss_hp.ToString());

            // Boss kill하였으므로 NPC Animation Stop.
            StopCoroutine("npc_attack_func");

            // Boss Kill Timer false.
            Boss_make.start_boss_kill = false;

            // Get Item popup window 오브젝트가 보스씬 실행시 처음 한번 활성화 되므로 bool변수로 control해줘야 함.
            boss_popup_window.enable_item_popup = true;

            // Monster 잡으면 리더보드에 킬 타임 올리고 다음 씬 넘어가기.
            GM_Boss.kill_the_monster();
        }


    }
    public void OnAnimation_AttackMove()
    {

    }

    /// NPC06 처음 init시 현재저장되어 있는 NPC Level에 맞게 값을 설정해줄 Function.
    public void levelup_npc06_data_struct(int Level)
    {

        // NPC06 데이터 초기화 및 레벨업시 적용되는 공식.
        NPC06_Boss_struct.Level = Level;
        NPC06_Boss_struct.damage = (ulong)(NPC06_Boss_struct.Level * 2) + 7;
        NPC06_Boss_struct.attack_speed = NPC06_make.NPC06_struct.attack_speed;
    }
}

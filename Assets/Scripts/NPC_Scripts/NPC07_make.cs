using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;
using gamedata_weapon;

public class NPC07_make : MonoBehaviour, IAnimEventListener
{

    // NPC07 struct
    public struct NPC07_struct
    {
        // NPC Data. 
        public static bool enable;
        public static int Level;
        public static ulong damage;
        public static ulong add_damage;
        public static float attack_speed;
        public static float add_speed;
        public static ulong upgrade_cost;

        // NPC Label.
        public static GameObject gameobject;
        public static GameObject npc_enable;

        public static GameObject lv_label;
        public static GameObject lvup_cost_label;
        public static GameObject damage_label;
        public static GameObject add_damage_label;
        public static GameObject add_speed_label;
        public static GameObject unlock_sp;
        public static GameObject skill_label;

        // NPC Sprite.
        public static UISprite weapon_sp;
        public static UISprite clothes_sp;
        public static UISprite wing_sp;

        // NPC Button.
        public static GameObject lvup_btn;
    }

    public struct npc07_char
    {
        public static int weapon_enable;
        public static string weapon_part;
        public static int weapon_index;

        public static int armor_enable;
        public static string armor_type;
        public static int armor_index;
        public static int armor_color;

        public static int wing_enable;
        public static string wing_type;
        public static int wing_index;

    }

    // 화면에 보여지는 캐릭터 이미지.
    public DevCharacter character;
    // For 데미지 HUD Text.
    public GameObject NPC07_HUD;

    // 광고 시청 후 캐릭터 공속 원복을 위한 변수.
    public float saved_attack_speed = 0f;
    public float saved_animatoion_speed = 0f;
    public Animator anim;
    
    // NPC07 Struct 구조체 초기화 및 Gameobject 가져오기.
    void Awake()
    {
        // **************************************   NPC07 GameObject init    ************************************************ //
        NPC07_struct.gameobject = GameObject.Find("_NPC07_gameobj");
        NPC07_struct.npc_enable = GameObject.Find("_npc7_enable");                                             // NPC02하위 요소들을 enable할지 말지 결정할 val.

        // NPC07 GameObject.    
        NPC07_struct.weapon_sp = GameObject.Find("_npc07_weapon_sprite").GetComponent<UISprite>();               // NPC01 무기 icon Object.
        NPC07_struct.clothes_sp = GameObject.Find("_npc07_clothes_sprite").GetComponent<UISprite>();             // NPC01 옷 icon Object.
        NPC07_struct.wing_sp = GameObject.Find("_npc07_wing_sprite").GetComponent<UISprite>();                   // NPC01 날개 icon Object.

        NPC07_struct.unlock_sp = GameObject.Find("_npc07_locking_sprite");                   // NPC01 날개 icon Object.
        NPC07_struct.lv_label = GameObject.Find("_npc07_level_label");
        NPC07_struct.lvup_cost_label = GameObject.Find("_npc07_lvup_cost_label");
        NPC07_struct.damage_label = GameObject.Find("_npc07_damage_label");
        NPC07_struct.add_damage_label = GameObject.Find("_npc07_damage_plus_label");
        NPC07_struct.add_speed_label = GameObject.Find("_npc07_speed_plus_label");
        NPC07_struct.add_speed_label.GetComponent<UILabel>().text = "+0%";

        NPC07_struct.skill_label = GameObject.Find("_npc07_skill_label");

        NPC07_struct.lvup_btn = GameObject.Find("_npc07_lvup_btn");
		NPC07_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;

        // Damage HUD Init.
        NPC07_HUD = GameObject.Find("7th_friend_HUD");
        // **************************************   NPC03 GameObject init    ************************************************ //

        // Init NPC01 Data && Update Label.
        //levelup_npc07_data_struct();
        //update_npc07_data_label();
    }

    // Use this for initialization
    void Start()
    {
        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc7_enable", 0);

        if (check_npc_enable == 1)
        {
            // 이전의 저장되어있는 캐릭터 무기, 헬멧 , 망또를 불러와서 init 해야함.

            NPC07_struct.gameobject.SetActive(true);                 // npc 캐릭터 활성화.

            init();
        }
        else
        {
            // 처음 NPC07 GameObject생성시 enable 변수는 False로 해줌.
            NPC07_struct.enable = false;            // boss Scene에서 사용할 변수.

            NPC07_struct.npc_enable.SetActive(false);   // npc 하위 변수들 비활성화. ( 해당 npc가 enable이 아닌데도 버튼이 눌려지는 현상을 해결하기 위함. )
            NPC07_struct.gameobject.SetActive(false);
        }

        // npc Level 데이터를 가져온 후 해당 값으로 Data Setting.
        if (PlayerPrefs.HasKey("npc7_level"))
        {
            int get_npc_level = PlayerPrefs.GetInt("npc7_level");
            levelup_npc07_data_struct(get_npc_level);
            update_npc07_data_label();
        }
        else
        {
            // npc를 처음 만드는 경우.
            int init_level = 1;
            levelup_npc07_data_struct(init_level);
            update_npc07_data_label();
        }

        int check_npc_level = PlayerPrefs.GetInt("npc6_level", 0);
        if (check_npc_level > 2)
        {
            NPC07_struct.npc_enable.SetActive(true);
            NPC07_struct.unlock_sp.SetActive(false);                  // npc 아이템 캐릭터창 unlock 풀어주기
        }
    }



    // Use this for initialization
    public void init () {
        character.Info.order = 1;
        character.Info.unit_part = "darkelf-male";
        character.Info.unit_index = 5;

        // NPC 속도 1로 초기화.
        NPC07_struct.attack_speed = 1f;

        // NPC03 캐릭터 enable 변수 True.
        NPC07_struct.enable = true;

        // Boss Scene Loading시 weapon 체크해야 Error 발생하지 않음 
        // weapon enable값을 가져옴. 없으면 default값으로 0을 setting.
        npc07_char.weapon_enable = PlayerPrefs.GetInt("npc7_weapon_enable", 0);
        if (npc07_char.weapon_enable == 1)
        {
            character.Info.main_weapon_part = PlayerPrefs.GetString("npc7_weapon_part", "");
            character.Info.main_weapon_index = PlayerPrefs.GetInt("npc7_weapon_index", 0);

            int weapon_index = GameData_weapon.weaponDIC[character.Info.main_weapon_part + character.Info.main_weapon_index];
            GameData_weapon.equip_the_weapon(weapon_index, popup_window_button_mgr.NPC_INDEX.NPC07);
            
            // Change the NPC01 Weapon01 icon Sprite.
            // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
            NPC07_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC07_struct.weapon_sp.spriteName = character.Info.main_weapon_part + character.Info.main_weapon_index.ToString();

        }

        npc07_char.armor_enable = PlayerPrefs.GetInt("npc7_armor_enable", 0);
        if (npc07_char.armor_enable == 1)
        {
            character.Info.armor_part = PlayerPrefs.GetString("npc7_armor_part", "");
            character.Info.armor_index = PlayerPrefs.GetInt("npc7_armor_index", 0);
            character.Info.armor_color = PlayerPrefs.GetInt("npc7_armor_color", 0);

            // 현재 장착하고 있는 Armor 스킬 Setting.
            int someValue = GameData_weapon.armorDIC[character.Info.armor_part + character.Info.armor_index + character.Info.armor_color];
            GameData_weapon.get_armor_skill_func(someValue, 6);

            // Change the NPC05 Clothes icon Sprite.
            NPC07_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC07_struct.clothes_sp.spriteName = character.Info.armor_part + character.Info.armor_index.ToString() + character.Info.armor_color.ToString();

        }

        npc07_char.wing_enable = PlayerPrefs.GetInt("npc7_wing_enable", 0);
        if (npc07_char.wing_enable == 1)
        {
            character.Info.wing_part = PlayerPrefs.GetString("npc7_wing_part", "");
            character.Info.wing_index = PlayerPrefs.GetInt("npc7_wing_index", 0);

            //현재 장착하고 있는 Wing 스킬 Setting.
            int equip_wing_index = GameData_weapon.wingDIC[character.Info.wing_part + character.Info.wing_index];
            print("npc7이 현재 장착하고 있는 wing index : " + equip_wing_index);
            GameData_weapon.get_wing_skill_func(equip_wing_index, popup_window_button_mgr.NPC_INDEX.NPC07);

            // Change the NPC Clothes icon Sprite.
            NPC07_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC07_struct.wing_sp.spriteName = character.Info.wing_part + character.Info.wing_index.ToString();

        }

        character.InitWithoutTextureBaking();

        // Add Attack event clip interface.
        character.event_listener.Add(this);

        // attack animation coroutine about 2sec.
        StartCoroutine("npc_attack_func");
    }

    IEnumerator npc_attack_func()
    {
        yield return new WaitForSeconds(NPC07_struct.attack_speed);                                // 모든 NPC 공격 default속도는 3. attack. 무한반복.
		character.PlayAnimation("anim_melee_attack1", false);                // NPC공격 animation 실행.

        StartCoroutine("npc_attack_func");

    }

    // Interface //
    // Interface about attacked. ( 캐릭터가 공격 애니메이션 이후 실행 할 함수. )
    public void OnAnimation_Hitting(int _index)
    {
        if (GameData.sound_on_off)
        {
            // 검 캐릭터이므로 검 사운드 enable시켜줌.
            GameData.npc_sword_sound_object.GetComponent<AudioSource>().Play(0);
        }

      
            // 보물상자 공격시 보물상자가 공격당하는 애니메이션 enable
        GameData.chest_animator.GetComponent<Animator>().SetTrigger("attacked");
            
 
        // Gold HUDText;;;;
        string get_coin_str = "+" + GameData.chest_struct.attacked_gold + "원";
        NPC07_HUD.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, 0.5f);

        // Add touch coin to total_coin and update total coin label
        GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // Chest box HP modify
		GameData.chest_struct._HP = GameData.chest_struct._HP - (NPC07_struct.damage + NPC07_struct.add_damage);
        float fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
        GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;

        // check upgrade buttons들을 활성화 할 지말지 .
        GM.check_all_function_when_gold_changed();

      

    }
    public void OnAnimation_AttackMove()
    {

    }

    // ********************************************************			NPC03 init functions 					******************************************************** //

    // NPC03 데이터 초기화. ( NPC03 레벨업 버튼 클릭 시 실행할 함수. )
    public void levelup_npc07_data_struct(int Level)
    {

        // NPC03 데이터 초기화 및 레벨업시 적용되는 공식.
        NPC07_struct.Level = Level;

        // 캐릭터 공격력도 누적.
        NPC07_struct.damage = 0;

        for (int i = 1; i < Level + 1; i++)
        {
            NPC07_struct.damage = NPC07_struct.damage + (ulong)(560 * Mathf.Pow(1.275f, i) + 10);
        }

        // =POWER(1.325,A2)*10000
        NPC07_struct.upgrade_cost = (ulong)Mathf.Round(Mathf.Pow(1.325f, Level) * 10000000);

        // NPC03 레벨이 10 이상이면 NPC04 캐릭터 구입할 수 있음.
        if (NPC07_struct.Level == 10)
        {
            // NPC08 Level up 캐릭터 창 Enable 시켜줌. ( 단, 아직은 NPC04 캐릭터는 화면에 안보여짐. )
            NPC08_make.NPC08_struct.unlock_sp.SetActive(false);
            NPC08_make.NPC08_struct.npc_enable.SetActive(true);

        }
    }

    // NPC03 라벨 && Level up cost 버튼 Update.
    public void update_npc07_data_label()
    {
        NPC07_struct.lv_label.GetComponent<UILabel>().text = NPC07_struct.Level.ToString();
        NPC07_struct.lvup_cost_label.GetComponent<UILabel>().text = GameData.int_to_label_format_won(NPC07_struct.upgrade_cost);
        NPC07_struct.damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC07_struct.damage);

    }

    // ********************************************************			NPC03 init functions 					******************************************************** //

    // ********************************************************			Image change functions 					******************************************************** //

    // Change the Weapon.
    public void change_weapon(int enable, int weapon_index, string weapon_name)
    {
        // 캐릭터 이미지 변화시 잠시 캐릭터 이미지 저장할 Reference 생성.
        // CharacterData _character = new CharacterData();
        // 기존에 가지고 있는 캐릭터 정보를 Reference에 copy.      
        // character.Info.Copy(_character);

        // 캐릭터 False.
        this.gameObject.SetActive(false);

        character.Info.main_weapon_part = weapon_name;
        character.Info.main_weapon_index = weapon_index;

        // Boss Scene Load시 사용할 character image;
        npc07_char.weapon_enable = enable;
        npc07_char.weapon_part = weapon_name;
        npc07_char.weapon_index = weapon_index;

        // Local에 npc1 weapon 이미지 저장.
        PlayerPrefs.SetInt("npc7_weapon_enable", npc07_char.weapon_enable);
        PlayerPrefs.SetString("npc7_weapon_part", npc07_char.weapon_part);
        PlayerPrefs.SetInt("npc7_weapon_index", npc07_char.weapon_index);

        PlayerPrefs.Save();
        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }

    // Change the clothes.
    public void change_clothes(int enable, int index, int color, string clothes_type)
    {
        // 캐릭터 False.
        this.gameObject.SetActive(false);

        character.Info.armor_part = clothes_type;
        character.Info.armor_index = index;
        character.Info.armor_color = color;

        // Boss Scene Load시 사용할 character image;
        npc07_char.armor_enable = enable;
        npc07_char.armor_type = clothes_type;
        npc07_char.armor_index = index;
        npc07_char.armor_color = color;

        // Local에 npc1 armor 이미지 저장.
        PlayerPrefs.SetInt("npc7_armor_enable", npc07_char.armor_enable);
        PlayerPrefs.SetString("npc7_armor_part", npc07_char.armor_type);
        PlayerPrefs.SetInt("npc7_armor_index", npc07_char.armor_index);
        PlayerPrefs.SetInt("npc7_armor_color", npc07_char.armor_color);
        PlayerPrefs.Save();

        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }

    // wing the clothes.
    public void change_wing(int enable,int index, string wing_type)
    {
        // 캐릭터 False.
        this.gameObject.SetActive(false);

        character.Info.wing_part = wing_type;
        character.Info.wing_index = index;

        // Boss Scene Load시 사용할 character image;
        npc07_char.wing_enable = enable;
        npc07_char.wing_type = wing_type;
        npc07_char.wing_index = index;

        // Local에 npc1 weapon 이미지 저장.
        PlayerPrefs.SetInt("npc7_wing_enable", npc07_char.wing_enable);
        PlayerPrefs.SetString("npc7_wing_part", npc07_char.wing_type);
        PlayerPrefs.SetInt("npc7_wing_index", npc07_char.wing_index);

        PlayerPrefs.Save();
        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }
    public void change_color(Color ToChangeColor)
    {

        character.SetColor(ToChangeColor);
    }
    public void change_attack_speed(float speed, float anim_speed)
    {
        // 광고 클릭 후 캐릭터 속도 복원을 위해 저장해둘 변수들.
        // 캐릭터의 애니메이션 속도도 reset.
        anim = GameObject.Find("Impl7").GetComponent<Animator>();   
        saved_animatoion_speed= anim.speed;
        saved_attack_speed = NPC07_struct.attack_speed;
        
        NPC07_struct.attack_speed = 1 * speed;
        anim.speed = anim_speed;

    }
    public void reset_attack_speed()
    {
        NPC07_struct.attack_speed = 1;
    }
    public void ads_reset_attack_speed()
    {
        // 캐릭터의 애니메이션 속도도 reset.
        anim = GameObject.Find("Impl7").GetComponent<Animator>();
        anim.speed = saved_animatoion_speed;
            
        NPC07_struct.attack_speed = saved_attack_speed;
    }
}

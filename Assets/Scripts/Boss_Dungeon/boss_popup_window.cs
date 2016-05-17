using UnityEngine;
using System.Collections;
using gamedata;

public class boss_popup_window : MonoBehaviour {

    public GameObject label_;
    public UISprite sprite_;
    public static bool enable_item_popup;

    public ParticleSystem getitem;


    void Start()
    {
        setDisable();
        getitem = GameObject.Find("getitem_particle").GetComponent<ParticleSystem>();
        getitem.Stop();
        
    }
    void Awake()
    {
        // Boss Kill시 popup창에서 사용할 Label && Sprite.
        label_ = GameObject.Find("get_item_label");
        sprite_ = GameObject.Find("get_item_sprite").GetComponent<UISprite>();
        enable_item_popup = false;

    }
    //SetActive(true) 호출 시 실행됩니다.
    void OnEnable()
    {
        open();
    }
    //SetActive(false) 호출 시 실행됩니다.
    void OnDisable()
    {
        close();
    }

    // 팝업 열기
    void open()
    {
        // randmom value 생성.
        float select_val = 0f;
        select_val = Random.Range(0, 100);
        print("open pop up : " + select_val.ToString());

        if (enable_item_popup)
        {
            print("select_val : " + select_val.ToString());
            print("GM_Boss.boss_index :" + GM_Boss.boss_index);
            
            switch (GM_Boss.boss_index)
            {
                // 50% : 단검 , 50% : 활1
                case 0:
                    if (select_val < 50)
                    {
                        // 단검 enable
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "단검 획득!!!");
                    }
                    else
                    {
                        // 기본 활 enable
                        fail_getitem_popup_window();
                    }
                    
                    break;

                // 46% : 독 묻은 단검 , 46% : 독수리뿔 활  , 나머지 꽝.
                case 1:
                    if (select_val < 47)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "독 묻은 단검 획득!!!");
                    }
                    else if (46 < select_val && select_val < 92)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "독수리뿔 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 42% : 생선 , 42% : 초록 활, 나머지 꽝.
                case 2:
                    if (select_val < 43)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "생선 획득!!!");
                    }
                    else if (42 < select_val && select_val < 84)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "초록 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 38% : 당근 , 38% : 막대기 활, 나머지 꽝.
                case 3:
                    if (select_val < 38)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "당근 획득!!!");
                    }
                    else if (62 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "초록 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 34% : 동물뼈 , 34% : 나뭇가지 활, 나머지 꽝.
                case 4:
                    if (select_val < 34)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "동물뼈 획득!!!");
                    }
                    else if (66 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "나뭇가지 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 30% : 돌망치 , 30% : 티타늄 활, 나머지 꽝.
                case 5:
                    if (select_val < 30)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "돌망치 획득!!!");
                    }
                    else if (70 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "티타늄 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 26% : 식칼 , 26% : 하늘불꽃 활, 나머지 꽝.
                case 6:
                    if (select_val < 26)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "식칼 획득!!!");
                    }
                    else if (74 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "하늘불꽃 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 22% : 양날도끼 , 22% : 별화살 장궁, 나머지 꽝.
                case 7:
                    if (select_val < 22)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "양날도끼 획득!!!");
                    }
                    else if (78 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "별화살 장궁 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 18% : 절지도 , 18% : 악마가 쓰던 활, 나머지 꽝.
                case 8:
                    if (select_val < 19)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "절지도 획득!!!");
                    }
                    else if (81 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "악마가 쓰던 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 16% : 고대양날도끼 , 16% : 막무가내 활, 나머지 꽝.
                case 9:
                    if (select_val < 17)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "고대양날도끼 획득!!!");
                    }
                    else if (83 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "막무가내 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 14% : 토막도끼 , 14% : 전갈 활, 나머지 꽝.
                case 10:
                    if (select_val < 15)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "토막도끼 획득!!!");
                    }
                    else if (85 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "전갈 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 12% : 귀신잡이 , 12% : 천사의 활, 나머지 꽝.
                case 11:
                    if (select_val < 13)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "귀신잡이 획득!!!");
                    }
                    else if (87 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "천사의 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 10% : 중세 롱소드 , 10% : 박쥐 활, 나머지 꽝.
                case 12:
                    if (select_val < 11)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "중세 롱소드 획득!!!");
                    }
                    else if (89 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "박쥐 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 9% : 피바다 , 9% : 용 사냥꾼 활, 나머지 꽝.
                case 13:
                    if (select_val < 10)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "피바다 획득!!!");
                    }
                    else if (90 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "용 사냥꾼 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 8% : 악마잡이 , 8% : 킹 크랩 활, 나머지 꽝.
                case 14:
                    if (select_val < 9)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "악마잡이 획득!!!");
                    }
                    else if (91 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "킹 크랩 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 7% : 해골양날도끼 , 7% : 불꽃 활, 나머지 꽝.
                case 15:
                    if (select_val < 8)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "해골양날도끼 획득!!!");
                    }
                    else if (92 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "불꽃 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 6% : 삼단철퇴 , 6% : 아이스 활, 나머지 꽝.
                case 16:
                    if (select_val < 7)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "삼단철퇴 획득!!!");
                    }
                    else if (93 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "아이스 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 5% : 뾰족한 롱소드 , 5% : 지지직 활, 나머지 꽝.
                case 17:
                    if (select_val < 6)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "뾰족한 롱소드 획득!!!");
                    }
                    else if (94 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "지지직 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 4% : 얼음나라의 검 , 4% : 잭과 콩나물 활, 나머지 꽝.
                case 18:
                    if (select_val < 5)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "얼음나라의 검 획득!!!");
                    }
                    else if (95 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "잭과 콩나물 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 3% : 아라비아 왕국의 검 , 3% : 스타워즈 활, 나머지 꽝.
                case 19:
                    if (select_val < 4)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index, "weapon", "아라비아 왕국의 검 검 획득!!!");
                    }
                    else if (96 < select_val)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "스타워즈 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 3% : 보라빛 활, 나머지 꽝.
                case 20:
                    if (select_val < 4)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index, "bow", "보라빛 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 3% : 황제의 검 , 나머지 꽝.
                case 21:
                    if (select_val < 4)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index-1, "weapon", "아라비아 왕국의 검 검 획득!!!");
                    }                   
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 3% : 피부림 활, 나머지 꽝.
                case 22:
                    if (select_val < 4)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index-1, "bow", "피부림 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 3% : 어둠의 검 , 나머지 꽝.
                case 23:
                    if (select_val < 4)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index-2, "weapon", "아라비아 왕국의 검 검 획득!!!");
                    }                   
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 3% : 대제국의 활, 나머지 꽝.
                case 24:
                    if (select_val < 3)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index-2, "bow", "대제국의 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 2% : 매직해머  나머지 꽝.
                case 25:
                    if (select_val < 3)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index-3, "weapon", "아라비아 왕국의 검 검 획득!!!");
                    }                   
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 2% : 용이빨로 만든 활, 나머지 꽝.
                case 26:
                    if (select_val < 3)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index-3, "bow", "용이빨로 만든 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 2% : 전설의 검, 나머지 꽝.
                case 27:
                    if (select_val < 3)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index-4, "weapon", "전설의 검 획득!!!");
                    }                    
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 1% : 대재앙 활, 나머지 꽝.
                case 28:
                    if (select_val < 2)
                    {
                        Setbow_to_popup_window(GM_Boss.boss_index-4, "bow", "대재앙의 활 획득!!!");
                    }
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;

                // 1% : 대재앙의 검 , 나머지 꽝.
                case 29:
                    if (select_val < 2)
                    {
                        Setweapon_to_popup_window(GM_Boss.boss_index-5, "weapon", "대재앙의 검 획득!!!");
                    }                   
                    else
                    {
                        fail_getitem_popup_window();
                    }
                    break;
            }

            // pop 창 띄우기.
            init();
        }
    }

    float duration = 0.2f; // 애니메이션의 길이입니다.(시간)
    float startDelay = 0.2f; // 애니메이션 시작 전 딜레이입니다.
    Vector3 scaleTo = new Vector3(1f, 1f, 1f); // 오브젝트의 최종 Scale 입니다.

    // 부풀었다가 줄어드는 효과를 위한 AnimationCurve 입니다.
    AnimationCurve animationCurve = new AnimationCurve(
    new Keyframe(0f, 0f, 0f, 1f), // 0%일때 0의 값에서 시작해서 
    new Keyframe(0.7f, 1.2f, 1f, 1f), // 애니메이션 시작후 70% 지점에서 1.2의 사이즈까지 커졌다가 
    new Keyframe(1f, 1f, 1f, 0f)); // 100%로 애니메이션이 끝날때는 1.0의 사이즈가 됩니다.

    // 초기화
    void init()
    {
        
        TweenScale tween = TweenScale.Begin(gameObject, duration, scaleTo);
        tween.duration = duration;
        tween.delay = startDelay;
        //tween.method = UITweener.Method.BounceIn; // AnimationCurve 대신 이것도 한번 써보세요.
        tween.animationCurve = animationCurve;
        print("play particle");
        getitem.Play();
    }

    // 팝업 닫기
    public void close()
    {
        setDisable();
    }

    // 오브젝트 Disable
    void setDisable()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 보스 킬 후 popup window에 setting할 weapon data 입력할 함수.
    /// </summary>
    /// <param name="boss_index"></param>
    /// <param name="type"></param>
    /// <param name="_popup_label"></param>
    void Setweapon_to_popup_window(int boss_index,string type, string _popup_label)
    {
        // Monster Kill Time Setting                
        scene_loading.boss_kill_time_text_label.SetActive(true);
        scene_loading.boss_kill_time_time_label.SetActive(true);
        scene_loading.boss_kill_time_time_label.GetComponent<UILabel>().text = string.Format("{0:F4}", scene_loading.monster_kill_time) + "초";
        
        string weapon_enable_str = type + boss_index.ToString() + "_enable";
        print("get item str : " + weapon_enable_str);

        if (PlayerPrefs.GetInt(weapon_enable_str,1) == 0)
        {
            //index에 해당하는 무기의 lock이 이미 풀려있음.
            // Label update.
            label_.GetComponent<UILabel>().text = "이미 가지고 있음...";

            // popup window sprite update.
            // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
            // weapon icon은 1부터시작이라 1을 더해줘야함.
            string weapon_sprite_str = type + (boss_index + 1).ToString() + "_icon";

            sprite_.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            sprite_.spriteName = weapon_sprite_str;
            sprite_.MakePixelPerfect();
        }
        else
        {
            //index에 해당하는 무기의 lock sprite를 false시켜줌. ( boss_index도 어차피 weapon_index랑 같음. )
            PlayerPrefs.SetInt(weapon_enable_str, 0);
            PlayerPrefs.Save();

            // 함수 콜시 가져온 String을 popup window label에 setting.
            label_.GetComponent<UILabel>().text = _popup_label;

            // popup window sprite update.
            // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
            // weapon icon은 1부터시작이라 1을 더해줘야함.
            string weapon_sprite_str = type + (boss_index + 1).ToString() + "_icon";

            sprite_.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            sprite_.spriteName = weapon_sprite_str;
            sprite_.MakePixelPerfect();
        }
    }

    /// 보스 킬 후 popup window에 setting할 weapon data 입력할 함수.
    void Setbow_to_popup_window(int boss_index, string type, string _popup_label)
    {
        // Monster Kill Time Setting                
        scene_loading.boss_kill_time_text_label.SetActive(true);
        scene_loading.boss_kill_time_time_label.SetActive(true);
        scene_loading.boss_kill_time_time_label.GetComponent<UILabel>().text = string.Format("{0:F4}", scene_loading.monster_kill_time) + "초";
        
        string weapon_enable_str = type + boss_index.ToString() + "_enable";

        if (PlayerPrefs.GetInt(weapon_enable_str, 1) == 0)
        {
            //index에 해당하는 무기의 lock이 이미 풀려있음.
            // Label update.
            label_.GetComponent<UILabel>().text = "이미 가지고 있음...";

            // 이미 가지고 있으므로 광고보고 한번 더 시도할지 묻기.
            if(GameData.boss_kill_retry_enable)
            {
                scene_loading.ads_play_retry_object.SetActive(true);
                GameData.boss_kill_retry_enable = false;        
            }
        
            // popup window sprite update.
            // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
            string weapon_sprite_str = type + boss_index .ToString() + "_icon";

            sprite_.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            sprite_.spriteName = weapon_sprite_str;
            sprite_.MakePixelPerfect();

        }
        else
        {
            //index에 해당하는 무기의 lock sprite를 false시켜줌. ( boss_index도 어차피 weapon_index랑 같음. )
            PlayerPrefs.SetInt(weapon_enable_str, 0);
            PlayerPrefs.Save();

            // 함수 콜시 가져온 String을 popup window label에 setting.
            label_.GetComponent<UILabel>().text = _popup_label;

            // popup window sprite update.
            // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
            // weapon icon은 1부터시작이라 1을 더해줘야함.
            string weapon_sprite_str = type + boss_index.ToString() + "_icon";

            sprite_.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            sprite_.spriteName = weapon_sprite_str;
            sprite_.MakePixelPerfect();
            


        }
    }

    void fail_getitem_popup_window()
    {
        // Monster Kill Time Setting                
        scene_loading.boss_kill_time_text_label.SetActive(true);
        scene_loading.boss_kill_time_time_label.SetActive(true);
        scene_loading.boss_kill_time_time_label.GetComponent<UILabel>().text = string.Format("{0:F4}", scene_loading.monster_kill_time)+ "초";
            
        // 꽝.
        // Label update.
        label_.GetComponent<UILabel>().text = "무기 획득 실패...";

        // 광고보고 한번더 시도할지 묻기.
        if(GameData.boss_kill_retry_enable)
        {
            scene_loading.ads_play_retry_object.SetActive(true);
            GameData.boss_kill_retry_enable = false;
        }
        
        // sprite update.
        // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
        string weapon_sprite_str = "Fail";

        sprite_.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
        sprite_.spriteName = weapon_sprite_str;
        sprite_.MakePixelPerfect();
    }

}

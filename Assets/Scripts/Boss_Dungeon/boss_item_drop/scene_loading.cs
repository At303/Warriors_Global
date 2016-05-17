using UnityEngine;
using System.Collections;
using gamedata;

public class scene_loading : MonoBehaviour {

    private UISprite m_Fade;

    public float m_fDuration = 0.2f;
    public static float monster_kill_time = 0f;
    public static GameObject getitem_window;
    public static GameObject item_drop_bgm_object;
    // Use this for initialization

    public static GameObject ads_play_retry_object;
    public static GameObject boss_kill_time_text_label;
    public static GameObject boss_kill_time_time_label;

    void Awake()
    {
        ads_play_retry_object = GameObject.Find("ads_and_retry");
        ads_play_retry_object.SetActive(false);
        
        // Monster Kill time label init and deactive.
        boss_kill_time_text_label = GameObject.Find("monster_kill_time_Label");
        boss_kill_time_text_label.SetActive(false);
        boss_kill_time_time_label = GameObject.Find("monster_kill_time");
        boss_kill_time_time_label.SetActive(false);
    }

    void Start()
    {
        // Item Drop시 popup window object.
        getitem_window = GameObject.Find("get_item_pop_window");
        item_drop_bgm_object = GameObject.Find("item_drop_bgm_object");

         // 게임 시작시 sound on off값을 가져오고, sound on off 결정.
        if (GameData.sound_on_off)
        {
             print("item drop bgm play");
             item_drop_bgm_object.GetComponent<AudioSource>().Play(0);
        }
       

        m_Fade = GameObject.Find("FadeObject").GetComponent<UISprite>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        // Fade In
        TweenAlpha.Begin(m_Fade.gameObject, m_fDuration, 0.0f);
        yield return new WaitForSeconds(m_fDuration);
        NextSceneCall();

        // Fade Out
        //TweenAlpha.Begin(m_Fade.gameObject, m_fDuration, 1f);
        //yield return new WaitForSeconds(m_fDuration);

    }

    void NextSceneCall()
    {
        // Get Item popup window 띄워줌.
        boss_popup_window.enable_item_popup = true;
        getitem_window.SetActive(true);
    }

}

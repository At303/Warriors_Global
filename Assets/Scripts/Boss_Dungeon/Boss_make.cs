using UnityEngine;
using System.Collections;




public class Boss_make : MonoBehaviour {
	

	public static GameObject gameobject;

	

    // 보스 HP && Kill Time을 위한 변수들.
    public static float target_time = 0.0f;
	public static GameObject Boss_HP_Bar;
	public static GameObject Boss_kill_time_label;
    public static bool start_boss_kill;
    public static float time = 0f;
	void Awake()
	{
        // 카운트 다운이 끝났는지 check할 변수.
        start_boss_kill = false;
      
        // GameObject 초기화.
        Boss_HP_Bar = GameObject.Find("Boss_kill_time");
        Boss_kill_time_label = GameObject.Find("_kill_time_label");
    }

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update ()
    {

        // CountDown 끝나고 보스 Kill Time Start.
        if (start_boss_kill)
        {
            // 보스 Kill Time 설정
            time = (target_time - Time.time) / 10.0f;        // For test set 20 sec.

            if (time > 0 )
            {
                // 보스 Kill Time progress bar 설정
                Boss_HP_Bar.GetComponent<UIProgressBar>().value = (float)time;

                Boss_kill_time_label.GetComponent<UILabel>().text = string.Format("{0:0.0}", time * 10);
            }
            else
            {
                if(GM_Boss.ads_retry_just_onece)
                {
                    GM_Boss.ads_retry_button.SetActive(true);
                    GM_Boss.ads_retry_just_onece = !GM_Boss.ads_retry_just_onece;
                }else
                {
                    GM_Boss.ads_retry_button.SetActive(false);
                    GM_Boss.ads_retry_just_onece = !GM_Boss.ads_retry_just_onece;
                }
                // Boss Kill TIme 종료.
                // 시간 내에 Boss를 죽이지 못하여 popup 창 띄워줌.
                GM_Boss.time_over_window_object.SetActive(true);
                start_boss_kill = false;
            }

        }

    }

}

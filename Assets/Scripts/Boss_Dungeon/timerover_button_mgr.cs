using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class timerover_button_mgr : MonoBehaviour {

 	public void timeover_todungeon()
    {
        SceneManager.LoadScene("Warriors");
    }

    public void timeover_adsview_and_retry()
    {
        // To Do retry.
        // ads view and retry.
        int ads_random = Random.RandomRange(0,6);
        if(ads_random < 2)
        {
            print("vungleads");
            VungleAndroid.playAd();

        }else
        {
            print("unityads");
            Advertisement.Show();
        }
        SceneManager.LoadScene ("Warriors_boss");
    }
}

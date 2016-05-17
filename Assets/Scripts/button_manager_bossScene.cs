using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class button_manager_bossScene : MonoBehaviour {

	// Use this for initialization

	public void Clicked_boss_scene()
	{
		SceneManager.LoadScene ("warriors");

	}

    public void Clicked_boss_kill_ok()
    {
        SceneManager.LoadScene("warriors");
        print("clicked boss kill ok button");
        //StartCoroutine(Load());

    }
	
	 public void Clicked_boss_retry_kill()
    {
		if (Advertisement.IsReady())
        {
            Advertisement.Show();
			SceneManager.LoadScene("Warriors_boss");

		}

    }
	
	 IEnumerator Load()
	{

		AsyncOperation async = SceneManager.LoadSceneAsync("warriors");

		while(!async.isDone)
		{
		float progress = async.progress * 100.0f;
		int pRounded = Mathf.RoundToInt(progress);

		yield return true;
		}

	}
}

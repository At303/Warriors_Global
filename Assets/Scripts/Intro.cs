using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Intro : MonoBehaviour {

	public float target_time = 0.0f;

	// Use this for initialization
	void Start () 
	{
		target_time = Time.time + 2;
 
        // Google Log in.
        google_sign_in();	
          
       
	}
	
 void google_sign_in()
    {
        
           PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        //.EnableSavedGames()
        // registers a callback to handle game invitations received while the game is not running.
         //.WithInvitationDelegate(<this.Deb>)
        // registers a callback for turn based match notifications received while the
        // game is not running.
        //.WithMatchDelegate(<callback method>)
        // require access to a player's Google+ social graph to sign in
        .RequireGooglePlus()
        .Build();

    PlayGamesPlatform.InitializeInstance(config);
    // recommended for debugging:
    PlayGamesPlatform.DebugLogEnabled = true;
    // Activate the Google Play Games platform
    PlayGamesPlatform.Activate();
    
    //authenticate user:
    Social.localUser.Authenticate((bool success) =>
        {
            if(success)
            {
               // NGUIDebug.Log("success");
            }else
            {
              //  NGUIDebug.Log("fail to login");
            }
    //handle success or failure
    });
    }
    

	
	// Update is called once per frame
	void Update () 
	{
		float time = (target_time - Time.time) / 2.0f;

			if (time < 0) 
			{
			    SceneManager.LoadScene ("warriors");
			}
	}
}

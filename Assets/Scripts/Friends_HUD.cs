using UnityEngine;
using System.Collections;
using gamedata;

public class Friends_HUD : MonoBehaviour {

	// Use this for initialization

    public void friends_hud_func()
    {
        // Test HUDText;;;;
        string get_coin_str = "+" + (GameData.chest_struct.attacked_gold * 2);
        this.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);
    }
}

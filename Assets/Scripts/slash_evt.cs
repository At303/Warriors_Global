using UnityEngine;
using System.Collections;

public class slash_evt : MonoBehaviour {

	void sprite_disalbe()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class JojoBehaviour : MonoBehaviour {
	public Player p; 
	// Use this for initialization
	void Start () {
		//p.MoveToPoint (new Vector3 (5,12, 0f), false, true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			//KickStarter.player.MoveToPoint (new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f));
			//KickStarter.player.MoveAlongPoints (new Vector3[1] { new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0f) }, false, true);
			//print (new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0f));
		}
	}
}

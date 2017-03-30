using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickReturnFunction : MonoBehaviour {
	public GameObject objective;
	public string functionReturn;
	// Use this for initialization
	void Start () {
		
	}

	void OnMouseDown(){
		objective.SendMessage (functionReturn);
	}

	// Update is called once per frame
	void Update () {
		
	}
}

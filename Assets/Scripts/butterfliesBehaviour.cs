using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterfliesBehaviour : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

	public void reposition(){
		transform.position = new Vector3(Random.Range(-7f, 27f), Random.Range(5f, -14f), 0f);
	}
	
	// Update is called once per frame
	void Update () {
	}
}

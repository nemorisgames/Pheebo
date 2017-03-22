using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour {
	public GameObject spawnObject;
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	void OnMouseDown(){
		if (spawnObject != null) {
			GameObject g = (GameObject)Instantiate(spawnObject, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f), Quaternion.identity);
			print (new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0f));
			Destroy (g, 1f);
		}
		if (animator != null)
			animator.SetTrigger ("Click1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

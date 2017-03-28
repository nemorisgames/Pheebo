using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour {
	public GameObject spawnObject;
	Animator animator;
	public AudioClip[] sounds;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}

	void OnMouseDown(){
		print ("click " + gameObject.name);
		if (spawnObject != null) {
			GameObject g = (GameObject)Instantiate(spawnObject, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f), Quaternion.identity);
			print (new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0f));
			Destroy (g, 1f);
		}
		if (animator != null) {
			print ("click animator");
			animator.SetTrigger ("Click1");
		}
		if (sounds != null && sounds.Length > 0) {
			audio.PlayOneShot (sounds [Random.Range (0, sounds.Length)]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

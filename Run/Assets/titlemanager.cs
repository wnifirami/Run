using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlemanager : MonoBehaviour {
	public GameObject [] titleprefabs;
	private Transform Playertransform;
	public GameObject player;
	private float spawnZ =64.2f;
	private float titlelenght =7f;
	private int animtilesonscreen = 4;
	// Use this for initialization
	void Start () {
		Playertransform =player.transform;
		spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void spawn(int prefindex =-1){
	
		GameObject go;
		go = Instantiate (titleprefabs [0]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += titlelenght;
	}
}

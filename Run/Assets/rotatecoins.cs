using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecoins : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 25*Time.deltaTime, 0));
	}
}

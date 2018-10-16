using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSound : MonoBehaviour {

	public Slider volume;
	public AudioSource source;
	
	// Update is called once per frame
	void Update () {
		source.volume = volume.value;		
	}
}

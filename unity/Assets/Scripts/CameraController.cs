using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float r;
	public float rad = 0.4f;
	public float height = 3.0f;
	public Vector3 lookAt = new Vector3(0, 0f, 0f);
	float angle = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		angle += rad * Time.deltaTime;
		transform.position = new Vector3( r * Mathf.Cos (angle), height, r * Mathf.Sin(angle) );
		transform.LookAt(lookAt);
	}

	void OnNoteOn(MidiMessage midi) {
		if(midi.data1 == 0x5D) { // slider
		} else if(midi.data1 == 0x0C) { // x
			var data = midi.data2 - 0x40;
			rad = -data * 0.1f;
		} else if(midi.data1 == 0x0D) { // y
			var data = midi.data2 - 0x40;
			height = data;
		}
	}
}

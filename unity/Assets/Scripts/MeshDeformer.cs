using UnityEngine;
using System.Collections;

public class MeshDeformer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnNoteOn(MidiMessage midi) {
		if(midi.data1 == 0x5D) { // slider
			renderer.material.SetColor("_Color", new Color(midi.data2 / 255f, (midi.data1 - 128f * Random.Range(0f, 2f))/255f, midi.data1 * Random.Range(0f, 1f)));
		} else if(midi.data1 == 0x0C) { // x
			var data = midi.data2 - 0x40;
			renderer.material.SetVector("_RotVector", new Vector3(data, 0f));
//			rad = -data * 0.1f;
		} else if(midi.data1 == 0x0D) { // y
			var data = midi.data2 - 0x40;
			renderer.material.SetVector("_RotVector", new Vector3(0f, data));
//			height = data;
		}
	}
}

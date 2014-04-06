using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicInput : MonoBehaviour
{
	public float loudness = 0;
	
	void Awake()
	{
		audio.clip = Microphone.Start(null, true, 1, 44100);
		audio.loop = true;
//		audio.mute = true; // Mute the sound, we don't want the player to hear it
		while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the recording has started
		audio.Play(); // Play the audio source!
		
	}
	
	void Start()
	{
	}
	
	void Update()
	{
		loudness = GetAveragedVolume() * 100f;
	}
	
	float GetAveragedVolume()
	{
		float[] data = new float[256];
		float a = 0.0f;
		audio.GetOutputData(data, 0);
		foreach (float s in data)
		{
			a += Mathf.Abs(s);
		}

		for(int i = 1; i < 256; i++) {
			Vector3 start = new Vector3((i-1) * 0.1f, data[(i-1)] * 10f);
			Vector3 end = new Vector3(i * 0.1f, data[i] * 10f);
			Debug.DrawLine(start, end, Color.magenta);
		}

		return a / 256.0f;
	}
}

﻿using UnityEngine;
using System.Collections;

public class MidiMessageDistributor : MonoBehaviour {

	public GameObject[] targets;
	MidiReceiver receiver;
	
	void Start ()
	{
		receiver = FindObjectOfType (typeof(MidiReceiver)) as MidiReceiver;
	}
	
	void Update ()
	{
		while (!receiver.IsEmpty) {
			var message = receiver.PopMessage ();
			if (message.status == 0xB0) {
				foreach (var go in targets) {
					go.SendMessage ("OnNoteOn", message);
				}
			}
		}
	}
}

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(MicInput))]
class MicEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		// Only shows the details on Play Mode.
		if (EditorApplication.isPlaying) {
			// Incomming messages.
			var temp = "loudness:";
//			foreach (var message in (target as MidiReceiver).History) {
//				temp += "\n" + message.ToString ();
//			}
			var micInput = target as MicInput;
			temp += "\n" + micInput.loudness;
			EditorGUILayout.HelpBox (temp, MessageType.None);
			
			// Make itself dirty to update on every time.
			EditorUtility.SetDirty (target);
		} else {
			EditorGUILayout.HelpBox ("You can view the sutatus on Play Mode.", MessageType.Info);
		}
	}
}

using UnityEngine;
using System.Collections;

// https://github.com/izmhr/DrawLineFromMesh/blob/master/Assets/material/MakeLineFromMesh.cs
public class MakeLineFromMesh : MonoBehaviour {
	
	private MeshFilter meshFilter;
	private Vector3[] vertices;
	private int[] triangles;

	private int m_sliderVal;

	// Use this for initialization
	void Start () {
		meshFilter = GetComponent<MeshFilter>();
		
		if (meshFilter.mesh == null) return;
		
		MeshTopology topo = meshFilter.mesh.GetTopology(0);
		Debug.Log(topo); // triangle
		
		triangles = meshFilter.mesh.triangles;
		meshFilter.mesh.SetIndices(MakeIndices(), MeshTopology.Lines, 0);
		
		topo = meshFilter.mesh.GetTopology(0);
		Debug.Log(topo); // line
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	int[] MakeIndices()
	{
		int[] indices = new int[2 * triangles.Length];
		int i = 0;
		for( int t = 0; t < triangles.Length; t+=3 )
		{
			indices[i++] = triangles[t];		//start
			indices[i++] = triangles[t + 1];	//end
			indices[i++] = triangles[t + 1];	//start
			indices[i++] = triangles[t + 2];	//end
			indices[i++] = triangles[t + 2];	//start
			indices[i++] = triangles[t];		//end
		}
		return indices;
	}

	void OnNoteOn(MidiMessage midi) {
		if(midi.data1 == 0x5E) { // FX depth knob
//			m_sliderVal = midi.data2 - 0x40;
			var scale = midi.data2;
			transform.localScale = new Vector3(scale, scale, scale);
		}
	}
}
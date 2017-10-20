using UnityEngine;
using UnityEditor;

namespace HatTrick {

[CustomEditor(typeof(Trick))]
public class TrickEditor : Editor {
	
	public override void OnInspectorGUI () {
		var trick = (Trick) target;

		if (trick.OccupiedPositions != null)
			foreach (var entry in trick.OccupiedPositions)
				EditorGUILayout.LabelField(entry.Key.ToString(), entry.Value.ToString());
		else
			EditorGUILayout.LabelField("not initialized");
	}

}

}
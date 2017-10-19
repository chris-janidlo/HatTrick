using UnityEngine;
using UnityEditor;

namespace HatTrick {

[CustomEditor(typeof(CardPool))]
public class CardPoolEditor : Editor {
	
	public override void OnInspectorGUI () {
		var pool = ((CardPool) target).Pool;

		if (GUILayout.Button("Add new random card"))
			pool.Add(CardQualities.RandomCard(8));
		if (GUILayout.Button("Clear"))
			pool.Clear();
		
		for (int i = 0; i < pool.Count; i++)
			EditorGUILayout.LabelField("Card " + i.ToString(), pool[i].ToString() ?? "");
	}

}

}
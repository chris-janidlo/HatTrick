using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour {


	public static T Choose<T> (List<T> list) {
		return (T) list[Random.Range(0, list.Count)];
	}

	public static T Choose<T> (T[] arr) {
		return arr[Random.Range(0, arr.Length)];
	}

}

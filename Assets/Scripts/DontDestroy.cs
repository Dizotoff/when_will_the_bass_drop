using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
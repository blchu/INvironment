using UnityEngine;
using System.Collections;

public class BoxSelect : MonoBehaviour {
    public static bool boxSelected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        boxSelected = this.gameObject == Selection.selected ? true : false;
	}
}

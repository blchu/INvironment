using UnityEngine;
using System.Collections;

public class Box1 : MonoBehaviour {
    private float init;
    private float fin;

	// Use this for initialization
	void Start()
    {
        init = transform.position.y;
        fin = init + 2;
	}
	
	// Update is called once per frame
	void Update()
    {
        GetComponent<Renderer>().enabled = BoxSelect.boxSelected || transform.position.y > init ? true : false;

        if (Selection.inSelection && transform.position.y < fin && BoxSelect.boxSelected)
            transform.Translate(Vector3.up * 8f * Time.deltaTime, Space.World);
        if (!Selection.inSelection && transform.position.y > init)
            transform.Translate(Vector3.down * 8f * Time.deltaTime, Space.World);
    }
}

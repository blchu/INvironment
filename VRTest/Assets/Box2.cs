using UnityEngine;
using System.Collections;

public class Box2 : MonoBehaviour {
    private float init;
    private float fin;

    // Use this for initialization
    void Start()
    {
        init = transform.position.y;
        fin = init + 3;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject boxObj = GameObject.FindGameObjectsWithTag("Box")[0];
        GetComponent<Renderer>().enabled = boxObj == Selection.selected || transform.position.y > init ? true : false;

        if (Selection.inSelection && transform.position.y < fin && BoxSelect.boxSelected)
            transform.Translate(Vector3.up * 12f * Time.deltaTime, Space.World);
        if (!Selection.inSelection && transform.position.y > init)
            transform.Translate(Vector3.down * 12f * Time.deltaTime, Space.World);
    }
}

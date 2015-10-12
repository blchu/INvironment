using UnityEngine;
using System.Collections;

public class Box0 : MonoBehaviour {
    private float init;
    private float fin;

    // Use this for initialization
    void Start()
    {
        init = transform.position.y;
        fin = init + 1;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject boxObj = GameObject.FindGameObjectsWithTag("Box")[0];
        GetComponent<Renderer>().enabled = boxObj == Selection.selected || transform.position.y > init ? true : false;

        if (Selection.inSelection && transform.position.y < fin && BoxSelect.boxSelected)
            transform.Translate(Vector3.up * 4f * Time.deltaTime);
        if (!Selection.inSelection && transform.position.y > init)
            transform.Translate(Vector3.down * 4f * Time.deltaTime);
    }
}

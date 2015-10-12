using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {
    public static GameObject selected;
    private static GameObject highlighted;
    public static bool inSelection;
	
    // Use this for initialization
	void Start()
    {
        selected = null;
        highlighted = null;
	}
	
	// Update is called once per frame
	void Update()
    {
        highlighted = null;
        if (selected)
        {
            selected.GetComponent<Renderer>().enabled = true;
            selected.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.5f, 0.5f);
        }
        else
        {
            GameObject[] selectObjects = GameObject.FindGameObjectsWithTag("Selector");
            foreach (GameObject obj in selectObjects)
            {
                Vector3 dir = (obj.transform.position - transform.position).normalized;
                float dot = Vector3.Dot(dir, transform.forward);
                if (dot > .95)
                {
                    obj.GetComponent<Renderer>().enabled = true;
                    highlighted = obj;
                }
                else
                {
                    obj.GetComponent<Renderer>().enabled = false;
                }
                obj.GetComponent<Renderer>().material.color = new Color(0.5f, 1.0f, 1.0f, .25f);
            }
        }
	}

    public static void Select()
    {
        selected = highlighted;
        inSelection = true;
    }

    public static void Unselect()
    {
        selected = null;
        inSelection = false;
    }
}

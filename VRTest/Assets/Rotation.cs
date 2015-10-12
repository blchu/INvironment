using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	
	// Update is called once per frame
	void Update()
    {
        transform.Rotate(new Vector3(60, 60, -60) * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            Camera.main.backgroundColor = Color.black;
        }
	}
}
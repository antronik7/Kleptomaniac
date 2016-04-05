using UnityEngine;
using System.Collections;

public class boutonDirection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Vector4(0.8f, 0.8f, 0.8f, 1);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
    }

    void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
    }
}

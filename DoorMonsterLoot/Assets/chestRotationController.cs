using UnityEngine;
using System.Collections;

public class chestRotationController : MonoBehaviour {

    public GameObject green;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        green.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        green.SetActive(false);
    }
}

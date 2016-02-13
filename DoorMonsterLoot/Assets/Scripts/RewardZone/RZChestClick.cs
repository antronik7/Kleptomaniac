using UnityEngine;
using System.Collections;

public class RZChestClick : MonoBehaviour {

    public GameObject openChest;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        openChest.SetActive(true);
        gameObject.SetActive(false);
    }
}

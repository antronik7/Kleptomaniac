using UnityEngine;
using System.Collections;

public class TestItem : MonoBehaviour {

    public int index;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        IventoryManager.instance.removeFromInventory(index);
        Destroy(gameObject);
    }
}

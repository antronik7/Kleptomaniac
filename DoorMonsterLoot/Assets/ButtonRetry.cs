using UnityEngine;
using System.Collections;

public class ButtonRetry : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("InventoryManager"));

        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}

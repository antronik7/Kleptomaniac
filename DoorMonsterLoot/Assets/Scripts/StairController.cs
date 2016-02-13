using UnityEngine;
using System.Collections;

public class StairController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Shop");
        //Application.LoadLevel(nomScene);
    }
}

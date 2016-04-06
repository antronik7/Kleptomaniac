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
        GameManager.instance.StopTime = true;

        GameManager.instance.distanceEnd = 1100;

        UnityEngine.SceneManagement.SceneManager.LoadScene("Shop");

        //Application.LoadLevel(nomScene);
    }
}

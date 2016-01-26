using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public string nomScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nomScene);
        //Application.LoadLevel(nomScene);
    }
}

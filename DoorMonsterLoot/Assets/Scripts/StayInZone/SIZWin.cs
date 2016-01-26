using UnityEngine;
using System.Collections;

public class SIZWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        ScoreManager.score += 100;
        ScoreManager.scoreDoors += 1;

        UnityEngine.SceneManagement.SceneManager.LoadScene("DoorSelection");
    }
}

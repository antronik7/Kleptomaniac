using UnityEngine;
using System.Collections;

public class SIZWin : MonoBehaviour {

    public GameObject canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.spawnRewardScreen();
        canvas.SetActive(false);
    }
}

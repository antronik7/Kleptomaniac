using UnityEngine;
using System.Collections;

public class zoneRotationGagner : MonoBehaviour {

    int compteur = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(compteur > 1)
        {
            GameManager.instance.spawnRewardScreen();
            compteur = -1000;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        compteur++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        compteur--;
    }
}

using UnityEngine;
using System.Collections;

public class BeOCercle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void DetruitToi()
    {
        this.gameObject.SetActive(false);
    }

    public void joueTonSon()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

}

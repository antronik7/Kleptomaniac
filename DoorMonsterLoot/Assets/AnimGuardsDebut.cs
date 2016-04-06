using UnityEngine;
using System.Collections;

public class AnimGuardsDebut : MonoBehaviour {

    public GameObject g2;
    public GameObject g3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartRun()
    {
        g2.GetComponent<Animator>().SetBool("Run", true);
        g3.GetComponent<Animator>().SetBool("Run", true);
        Debug.Log("Je suis ici");
    }

    public void changeMain()
    {
        Application.LoadLevel("Main");
    }
}

using UnityEngine;
using System.Collections;

public class RZManager : MonoBehaviour {

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public Vector3[] getPosition()
    {
        return new[] { spawn1.transform.position, spawn2.transform.position, spawn3.transform.position };
    }
}

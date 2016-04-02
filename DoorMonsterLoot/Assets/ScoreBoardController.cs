using UnityEngine;
using System.Collections;

public class ScoreBoardController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Camera.main.orthographicSize > 4.95)
        {
            Destroy(gameObject);
        }
	}
}

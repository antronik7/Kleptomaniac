using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject thePlayer;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x - thePlayer.transform.position.x < 5.5)
        {
            transform.position = new Vector3(thePlayer.transform.position.x + 5.5f, transform.position.y, transform.position.z);
        }
    }
}

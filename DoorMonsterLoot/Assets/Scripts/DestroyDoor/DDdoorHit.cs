using UnityEngine;
using System.Collections;

public class DDdoorHit : MonoBehaviour {

    public GameObject healthbar;
    public GameObject particule;
    DDHealthBar hbScript;
    Vector2 mousePosition;
	// Use this for initialization
	void Start () {
        hbScript = healthbar.GetComponent<DDHealthBar>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        hbScript.HealthDown();

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        gameObject.GetComponent<AudioSource>().Play();

        Instantiate(particule, pos, Quaternion.identity);
    }

}

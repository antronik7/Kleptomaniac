using UnityEngine;
using System.Collections;

public class ItemShopController : MonoBehaviour {

    public int prix;

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "" + prix + " $";
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseDown()
    {
        ScoreManager.score -= prix;

        Destroy(gameObject);
    }
}

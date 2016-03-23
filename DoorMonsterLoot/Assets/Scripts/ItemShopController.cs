using UnityEngine;
using System.Collections;

public class ItemShopController : MonoBehaviour {

    public int prix;
    public GameObject item;

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "" + prix + " $";
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseDown()
    {
        if (ScoreManager.score >= prix)
        {
            ScoreManager.score -= prix;
            IventoryManager.instance.addToInventory(item);
            Destroy(gameObject);

        }
        else
        {
            //p-e faire un son pour dire que le joueur peut pas acheter
        }

        
    }
}

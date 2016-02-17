using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {


    public bool gogogo = false;
    public int sens = 0;
    public float dommageSiLeJoueurEstTouche = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(gogogo == true)
        {
            if (sens == 1)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - Time.deltaTime * 20, gameObject.transform.position.y);
            }
            else
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - Time.deltaTime * 20);

            }
        }


        if (gameObject.transform.position.x <= -15 || gameObject.transform.position.y <= -10)
        {
            Debug.Log("Je suis deleter" + Time.time);
            Destroy(gameObject);
        }

	}

    public float retournerValeurDeDommage()
    {
        return dommageSiLeJoueurEstTouche;
    }
}

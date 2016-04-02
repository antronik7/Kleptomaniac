using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {


    public bool gogogo = false;
    public int sens = 0;
    public int dommageSiLeJoueurEstTouche = 0;
    //public monstre1 scriptDuMonstre;

	// Use this for initialization
	void Start () {

        setValeurDommage();

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

    public int retournerValeurDeDommage()
    {
        return dommageSiLeJoueurEstTouche;
    }

    public void setValeurDommage()
    {
        dommageSiLeJoueurEstTouche = GameObject.FindGameObjectWithTag("Monstre").GetComponent<monstre1>().attaqueDuMonstre;
        Debug.Log("Atk du monstre :" + dommageSiLeJoueurEstTouche);
    }
}

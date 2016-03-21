using UnityEngine;
using System.Collections;
using System;

public class BeOManager : MonoBehaviour {

    public GameObject[] leTableauDeSpawner;
    public GameObject[] leTableauDeBoutonChiffre;
    private Vector3[] leTableauDePositionDesSpawner;
    private int[] leTableauPriorite;

    private int[] indexeDejaFait;
    bool indexeExistant = true;

    GameObject btnQuiVientEtreSpawner;

    public int nbrDeBoutonASpawner;

    int j = 0;
    int k = 0;
    int l = 0;

	// Use this for initialization
	void Start () {

        leTableauDePositionDesSpawner = new Vector3[nbrDeBoutonASpawner];
        leTableauPriorite = new int[nbrDeBoutonASpawner];
        indexeDejaFait = new int[nbrDeBoutonASpawner];

        j = 0;
        k = 0;
        l = 0;

        //Aller chercher la progression du joueur pour voir la difficule a mettre pour le mini jeu. Les different tableau avec les differents bouton (chiffre, lettre, chiffre romain etc)

        //Faire Spawner les boutons
        InitialiserLeTableauDePosition();
        InitialiserLeMiniJeuBoutonChiffre();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void InitialiserLeTableauDePosition()
    {
        //Boucle pour trouver les spawners a spawner du stock dessus
        for (int i = 0; i < nbrDeBoutonASpawner; i++)
        {
            //Debug.Log("i :"+i);
            j = UnityEngine.Random.Range(0, leTableauDeSpawner.Length);

            while (leTableauDeSpawner[j].GetComponent<BeOSpawner>().getDejaChoisi() == true)
            {
                j = UnityEngine.Random.Range(0, leTableauDeSpawner.Length);
            }

            leTableauDeSpawner[j].GetComponent<BeOSpawner>().okChoisi();

            leTableauDePositionDesSpawner[i] = leTableauDeSpawner[j].gameObject.transform.position;
        }
    }

    void InitialiserLeMiniJeuBoutonChiffre()
    {
        //Boncle pour trouver les bouton chiffre a spawner
        for (int i = 0; i < nbrDeBoutonASpawner; i++)
        {

            while (indexeExistant == true)
            {
                indexeExistant = false;
                k = UnityEngine.Random.Range(0, leTableauDeBoutonChiffre.Length);

                for (int c = 0; c < i; c++)
                {
                    if (indexeDejaFait[c] == k)
                    {
                        indexeExistant = true;
                    }
                }
            }

            indexeExistant = true;

            /*while (leTableauDeBoutonChiffre[k] == null)
            {


                k = UnityEngine.Random.Range(0, 5);
            }*/
               
            //Debug.Log("K :"+ k);

            btnQuiVientEtreSpawner = (GameObject) Instantiate(leTableauDeBoutonChiffre[k].gameObject, leTableauDePositionDesSpawner[i], Quaternion.identity);

            leTableauPriorite[i] = btnQuiVientEtreSpawner.GetComponent<BeOBouton>().getPriorite();

            indexeDejaFait[i] = k;

            //leTableauDeBoutonChiffre[k] = null;

        }

        Array.Sort(leTableauPriorite);

    }

    //Fonction qui va etre appaler dans le mouse donw du bouton et qui verifira si on est prioritaire et on se detruit ou pas selon le bool renvoiyer
    public bool BoutonClicker(int maPriorite)
    {
        Debug.Log(maPriorite);

        //Si je suis la priorite
        if(maPriorite == leTableauPriorite[l])
        {
            l++;

            if(l == nbrDeBoutonASpawner)
            {
                Debug.Log("Win");
            }

            return true;
        }

        return false;
    }

}

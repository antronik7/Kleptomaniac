using UnityEngine;
using System.Collections;
using System;

public class BeOManager : MonoBehaviour {

    public GameObject[] leTableauDeSpawner;
    public GameObject[] leTableauDeBoutonChiffre;
    private Vector3[] leTableauDePositionDesSpawner;

    //Tableau pour supprimer les bouton si jamais le joueur se trompe pendant un round;
    private GameObject[] leTableauDesBoutonSpawner;
    private int[] leTableauPriorite;

    private int[] indexeDejaFait;
    bool indexeExistant = true;

    GameObject btnQuiVientEtreSpawner;

    public int nbrDeBoutonASpawner;

    int j = 0;
    int k = 0;
    int l = 0;

    public int nbrDeRoundAFaire = 0;
    int nbrDeRoundFait = 0;

    public GameObject checkMark;
    public GameObject cross;
    public GameObject cercle;

    public GameObject[] indicateurDeRoundGagner;

	// Use this for initialization
	void Start () {

        nbrDeRoundFait = 0;

        DeciderCombienDeRound();

        InitialiserUnePartie();

      

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void InitialiserLeTableauDePosition()
    {

        foreach (GameObject go in leTableauDeSpawner)
        {
            go.GetComponent<BeOSpawner>().ReinitialiseLeChoisi();
        }

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

            leTableauDesBoutonSpawner[i] = btnQuiVientEtreSpawner;

            //leTableauDeBoutonChiffre[k] = null;



        }

        //Supprimer les boutons qui ne sont pu bon 
        for (int i = 0; i < indexeDejaFait.Length; i++)
        {
            //Valeur trop grosse pour un indexe de bouton
            indexeDejaFait[i] = 999;
        }

        Array.Sort(leTableauPriorite);

    }

    //Fonction qui va etre appaler dans le mouse donw du bouton et qui verifira si on est prioritaire et on se detruit ou pas selon le bool renvoiyer
    public bool BoutonClicker(int maPriorite)
    {
        //Si je suis la priorite
        if(maPriorite == leTableauPriorite[l])
        {
            l++;

            if(l == nbrDeBoutonASpawner)
            {
                Debug.Log("Win Round");

                nbrDeRoundFait++;
                cercle.SetActive(true);
                ajouterRoundGagner();

                if (nbrDeRoundFait >= nbrDeRoundAFaire)
                {
                    //Ici on fait spawner les tresors
                    Debug.Log("Win la game!!!");
                    GameManager.instance.spawnRewardScreen();
                }
                else
                {
                    InitialiserUnePartie();

                }
            }
            else
            {
                gameObject.GetComponent<AudioSource>().Play();

            }



            return true;
        }

        return false;
    }

    void InitialiserUnePartie()
    {
        leTableauDePositionDesSpawner = new Vector3[nbrDeBoutonASpawner];
        leTableauPriorite = new int[nbrDeBoutonASpawner];
        indexeDejaFait = new int[nbrDeBoutonASpawner];
        leTableauDesBoutonSpawner = new GameObject[nbrDeBoutonASpawner];

        j = 0;
        k = 0;
        l = 0;

        //Aller chercher la progression du joueur pour voir la difficule a mettre pour le mini jeu. Les different tableau avec les differents bouton (chiffre, lettre, chiffre romain etc)

        //Faire Spawner les boutons
        InitialiserLeTableauDePosition();
        InitialiserLeMiniJeuBoutonChiffre();
    }

    //Fonction qui regardera combien de round on veut faire gagner au joueur (selon le nombre d'etage complete
    void DeciderCombienDeRound()
    {
        //Pour le moment je hardcode 2 round
        nbrDeRoundAFaire = 2;

        //Activer les cercle conteur de round
        for(int i = 0; i < nbrDeRoundAFaire; i++)
        {
            indicateurDeRoundGagner[i].gameObject.SetActive(true);
        }
    }

    public void leJoueurAFaitUneFaute()
    {
        Debug.Log("Le joueur a fait une faute");
        if (nbrDeRoundFait > 0)
        {
            nbrDeRoundFait--;
            perdreRoundGanger();
        }

        //Supprimer les boutons qui ne sont pu bon 
        foreach (GameObject go in leTableauDesBoutonSpawner)
        {
            Destroy(go);
        }

        cross.SetActive(true);

        InitialiserUnePartie();
    }

    public void bonChoix(Vector3 positionDuBouton)
    {
        Instantiate(checkMark, positionDuBouton, Quaternion.identity);
    }

    public void ajouterRoundGagner()
    {
        Debug.Log("nbr de round ganger :" + nbrDeRoundFait);
        for (int i = 0; i < nbrDeRoundFait; i++)
        {
            Debug.Log("Ajoute un round");
            indicateurDeRoundGagner[i].GetComponent<Animator>().SetBool("roundGagner", true);
        }
    }

    public void perdreRoundGanger()
    {
        indicateurDeRoundGagner[nbrDeRoundFait].GetComponent<Animator>().SetBool("roundGagner", false);
    }
}

﻿using UnityEngine;
using System.Collections;

public class controleurPersonnage : MonoBehaviour {

    //Cette classe sert a prendre les inputs du joueur pour les esquives.

    //Variable pour le controller du joueur
    private Vector2 touchOrigin = -Vector2.one;
    private int horizontal = 0;
    private int vertical = 0;

    //Variable qui garde en memoire l'emplacement du dernier click de joueur
    private Vector2 positionAncienClick = Vector2.zero;
    private float leDeplacementEnX = 0;
    private float leDeplacementEnY = 0;
    private bool faireUnEvitement = false;
    private Vector2 positionJoueurAvantEvitement = Vector2.zero;
    private Vector2 backupPositionJoueurAvantEvitement;
    private Vector2 positionAAller = Vector2.zero;
    //Variable qui sert a savoir si le joueur est entrain d'etre dans le moment de "freeze d'animation" pendant une esquive
    private bool esquiveEnCours = false;
    private float backUpTempsFreezerPendantEsquive;

    public int variableDeVitesseEsquive;
    public float tempsFreezerPendantEsquive;
    public float mouvementMinimumPourCapterEsquive;
    public Vector2[] lesPositionMaximumPourEvitement;

    //Variable pour contenir la vie du personnage (normalement elle devrait etre assigner par le gameManagerPrincipal)
    public int vieDuJoueurMaximum= 0;

    public int vieDuJoueurRestante = 0;

    //Variable pour contenir la defense du personnage (normalement elle devrait etre assigner par le gameManagerPrincipal)
    public int defenseDuJoueur = 0;

    public int dommageRecu = 0;

    //Variable que l'on verifie si l'aller a ete effectue
    bool allerFait = false;

    //Variable pour avoir l'animator
    private Animator myAnimator;

    private SpriteRenderer mySpriteRenderer;
    public Sprite recuDommage;
    bool faireFlasherPersonnageApresRecuDommage = false;

    //Variable qui garde le temps quand on fait flasher le personnage
    float tempsAccumule =0 ;
    float tempsAccumele2 = 0;


    // public GameObject progresBarVieJoueur;

    //  public TimeBar progresBarVieJoueurScript;


    // Use this for initialization
    void Start () {

        //Aller chercher les infos du joueur avec le singleton du gameManager
        getInformationJoueur();

        //Garder en memoire la position initiale du joueur
        positionJoueurAvantEvitement = gameObject.transform.position;

        //Garder un backup pour pouvoir revenir a la bonne position quand un fini une esquive
        backupPositionJoueurAvantEvitement = positionJoueurAvantEvitement;

        //Garder un backup du temps freezer pendant les esquive.
        backUpTempsFreezerPendantEsquive = tempsFreezerPendantEsquive;

        //Trouver la progress bar de vie du joueur et son script
        AllerChercheProgresBarVieJoueur();

        //Trouver l'animator
        myAnimator = GetComponent<Animator>();

        //Trouver le Sprite renderer
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
    void Update()
    {

        


        if (faireFlasherPersonnageApresRecuDommage == true)
        {
            //On garde le temps passe
            tempsAccumule = tempsAccumule + (Time.deltaTime);
            if (tempsAccumule < 1)
            {
                tempsAccumele2 = tempsAccumele2 + Time.deltaTime;

                if(tempsAccumele2 > 0.10)
                {
                    if(mySpriteRenderer.enabled == false)
                    {
                        mySpriteRenderer.enabled = true;
                    }
                    else
                    {
                        mySpriteRenderer.enabled = false;
                    }

                    tempsAccumele2 = 0;

                }
            }
            else
            {
                faireFlasherPersonnageApresRecuDommage = false;
                mySpriteRenderer.enabled = true;
                tempsAccumule = 0;

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            positionAncienClick = Input.mousePosition;
            //Debug.Log("Position de l'ancien click : " + positionAncienClick);
        }

        if (Input.GetMouseButtonUp(0))
        {
            leDeplacementEnX = Input.mousePosition.x - positionAncienClick.x;
            leDeplacementEnY = Input.mousePosition.y - positionAncienClick.y;

            if (Mathf.Abs(leDeplacementEnX) > Mathf.Abs(leDeplacementEnY) && Mathf.Abs(leDeplacementEnX) > mouvementMinimumPourCapterEsquive)
            {
                horizontal = leDeplacementEnX > 0 ? 1 : -1;

                if (horizontal == -1)
                {
                    evitementGauche();
                }
                else
                {
                    //Donner le possibilite d'eviter vers la droite ??
                }
            }
            else
            {
                if (Mathf.Abs(leDeplacementEnY) > mouvementMinimumPourCapterEsquive)
                {
                    vertical = leDeplacementEnY > 0 ? 1 : -1;
                    if (vertical == -1)
                    {
                        evitementBas();
                    }
                    else
                    {
                        evitementHaut();
                    }
                }
            }
        }
    }

    //Fonction appler quand le joueur veut eviter vers la gauche
    void evitementGauche()
    {
        Debug.Log("recule");

        //positionAAller = lesPositionMaximumPourEvitement[0];
        myAnimator.SetInteger("StanceBattle", 2);
    }

    //Fonction appler quand le joueur veut eviter vers le bas
    void evitementBas()
    {
        Debug.Log("Crouch Toi");
        myAnimator.SetInteger("StanceBattle", 1);
        //positionAAller = lesPositionMaximumPourEvitement[1];
    }

    //Fonction appler quand le joueur veut eviter vers le haut
    void evitementHaut()
    {
        Debug.Log("Saute mon caliss");
        myAnimator.SetInteger("StanceBattle", 3);
        //positionAAller = lesPositionMaximumPourEvitement[2];
    }

    //Fonction pour reinitialiser les variable pour l'esquive
    void reinitialisation()
    {
        //On doit tout reinitialiser
        faireUnEvitement = false;
        gameObject.transform.position = backupPositionJoueurAvantEvitement;
        allerFait = false;
        vertical = 0;
        horizontal = 0;
        positionAAller = Vector2.zero;
        positionJoueurAvantEvitement = backupPositionJoueurAvantEvitement;
        tempsFreezerPendantEsquive = backUpTempsFreezerPendantEsquive;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Quand le joueur se fait toucher par le monstre
        if (other.tag == "Projectile")
        {

            dommageRecu = other.GetComponent<projectile>().retournerValeurDeDommage();

            Destroy(other.gameObject);

            dommageRecu = dommageRecu - defenseDuJoueur;

            if (dommageRecu < 0)
            {

            }
            else
            {
                vieDuJoueurRestante = vieDuJoueurRestante - dommageRecu;

            }

            GameManager.instance.CurrentHealth = vieDuJoueurRestante;

          //  progresBarVieJoueurScript.setFillAmount(vieDuJoueurRestante / vieDuJoueurMaximum);

            if(vieDuJoueurRestante <= 0)
            {
                //On doit avertir le gameMangerCombat que je suis mort
                Destroy(gameObject);

                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }
            else
            {
                //myAnimator.SetInteger("StanceBattle", 10);
                faireFlasherPersonnageApresRecuDommage = true;
                Debug.Log("Jai mal");

            }
        }
    }

    //Fonction qui fera appel au singleton de gameManager pour aller chercher les information du joueurs
    void getInformationJoueur()
    {
        vieDuJoueurMaximum = GameManager.instance.MaxHealth;

        vieDuJoueurRestante = GameManager.instance.CurrentHealth;

        defenseDuJoueur = GameManager.instance.characterDef;
    }

    //Fonction pour trouver la bar de vie du personnage ainsi que son script
    void AllerChercheProgresBarVieJoueur()
    {
       /* progresBarVieJoueur = GameObject.FindGameObjectWithTag("VieJoueur");

        progresBarVieJoueurScript = progresBarVieJoueur.GetComponent<TimeBar>();*/
    }

    public void prendrePotion(int vieQuePotionDonne)
    {

    }

    //Fonction qui arrte l'animation 
    public void animationIdle()
    {
        myAnimator.SetInteger("StanceBattle", 5);
    }


}

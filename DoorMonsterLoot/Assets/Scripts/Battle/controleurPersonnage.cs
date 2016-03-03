using UnityEngine;
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

	}
	
	// Update is called once per frame
    void Update()
    {

        if (faireUnEvitement == true)
        {
            //On verifie si le joueur est supposer etre freezer encore
            if (esquiveEnCours == true)
            {
                //on Verifie sa fait combien de temps
                if (tempsFreezerPendantEsquive <= 0)
                {
                    esquiveEnCours = false;
                }
                else
                {
                    tempsFreezerPendantEsquive = tempsFreezerPendantEsquive - Time.deltaTime;
                }
            }
            else
            {
                //On verifie si nous fesons un mouvement horizontal ou vertical. Si horizontal n'est pas = a 1 ou -1 alors on fait un mouvement vertical
                //Si le mouvement est horizontal
                if (horizontal != 0)
                {
                    //Si le mouvement est negatif
                    if (horizontal == -1)
                    {
                        //Si je ne suis pas encore rendu a l'emplacement que l'on desire 
                        if (gameObject.transform.position.x > (positionJoueurAvantEvitement.x + positionAAller.x))
                        {

                            //Tu dois faire le mouvement.
                            gameObject.transform.Translate(positionAAller * Time.deltaTime * variableDeVitesseEsquive);

                            //Si jamais le mouvement est aller trop loin on remet le joueur a la bonne position
                            if (gameObject.transform.position.x <= (positionJoueurAvantEvitement.x + positionAAller.x))
                            {
                                gameObject.transform.position = positionJoueurAvantEvitement + positionAAller;
                            }

                        }
                        else
                        {
                            //Tu dois arreter le mouvement.
                            positionJoueurAvantEvitement = positionAAller;

                            //Si l'aller est deja fait. Alors cela veut dire que nous venons de finir le retour

                            if (allerFait == true)
                            {
                                //L'esquive est terminer

                                reinitialisation();
                            }
                            else
                            {
                                //Il faut indiquer que l'aller est deja fait. Donc la prochain fois qu'on entre dans ce if c'est que le retour est termine.
                                allerFait = true;

                                //Ici on doit donner le vecteur de retour
                                positionAAller.x = positionAAller.x * -1;
                                horizontal = horizontal * -1;
                                positionJoueurAvantEvitement = gameObject.transform.position;
                                esquiveEnCours = true;
                            }
                        }
                    }
                    //Sinon il est positif
                    else
                    {
                        //Si je ne suis pas encore rendu a l'emplacement que l'on desire 
                        if (gameObject.transform.position.x < (positionJoueurAvantEvitement.x + positionAAller.x))
                        {
                            //Tu dois faire le mouvement.
                            gameObject.transform.Translate(positionAAller * Time.deltaTime * variableDeVitesseEsquive);

                            //Si jamais le mouvement est aller trop loin on remet le joueur a la bonne position
                            if (gameObject.transform.position.x >= (positionJoueurAvantEvitement.x + positionAAller.x))
                            {
                                gameObject.transform.position = positionJoueurAvantEvitement + positionAAller;
                            }
                        }
                        else
                        {
                            //Tu dois arreter le mouvement.
                            positionJoueurAvantEvitement = positionAAller;

                            //Si l'aller est deja fait. Alors cela veut dire que nous venons de finir le retour

                            if (allerFait == true)
                            {
                                //L'esquive est terminer
                                reinitialisation();
                            }
                            else
                            {
                                //Il faut indiquer que l'aller est deja fait. Donc la prochain fois qu'on entre dans ce if c'est que le retour est termine.
                                allerFait = true;

                                //Ici on doit donner le vecteur de retour
                                positionAAller.x = positionAAller.x * -1;
                                horizontal = horizontal * -1;
                                positionJoueurAvantEvitement = gameObject.transform.position;
                                esquiveEnCours = true;

                            }
                        }
                    }
                }
                //Le mouvement est vertical
                else
                {
                    //Si le mouvement est negatif
                    if (vertical == -1)
                    {
                        //Si je ne suis pas encore rendu a l'emplacement que l'on desire 
                        if (gameObject.transform.position.y > (positionJoueurAvantEvitement.y + positionAAller.y))
                        {
                            //Tu dois faire le mouvement.
                            gameObject.transform.Translate(positionAAller * Time.deltaTime * variableDeVitesseEsquive);

                            //Si jamais le mouvement est aller trop loin on remet le joueur a la bonne position
                            if (gameObject.transform.position.y <= (positionJoueurAvantEvitement.y + positionAAller.y))
                            {
                                gameObject.transform.position = positionJoueurAvantEvitement + positionAAller;
                            }
                        }
                        else
                        {
                            //Tu dois arreter le mouvement.
                            positionJoueurAvantEvitement = positionAAller;

                            //Si l'aller est deja fait. Alors cela veut dire que nous venons de finir le retour

                            if (allerFait == true)
                            {
                                //L'esquive est terminer

                                reinitialisation();
                            }
                            else
                            {
                                //Il faut indiquer que l'aller est deja fait. Donc la prochain fois qu'on entre dans ce if c'est que le retour est termine.
                                allerFait = true;

                                //Ici on doit donner le vecteur de retour
                                positionAAller.y = positionAAller.y * -1;
                                vertical = vertical * -1;
                                positionJoueurAvantEvitement = gameObject.transform.position;
                                esquiveEnCours = true;

                            }
                        }
                    }
                    //Sinon il est positif
                    else
                    {
                        //Si je ne suis pas encore rendu a l'emplacement que l'on desire 
                        if (gameObject.transform.position.y < (positionJoueurAvantEvitement.y + positionAAller.y))
                        {
                            //Tu dois faire le mouvement.
                            gameObject.transform.Translate(positionAAller * Time.deltaTime * variableDeVitesseEsquive);

                            //Si jamais le mouvement est aller trop loin on remet le joueur a la bonne position
                            if (gameObject.transform.position.y >= (positionJoueurAvantEvitement.y + positionAAller.y))
                            {
                                gameObject.transform.position = positionJoueurAvantEvitement + positionAAller;
                            }
                        }
                        else
                        {
                            //Tu dois arreter le mouvement.
                            //Si l'aller est deja fait. Alors cela veut dire que nous venons de finir le retour

                            if (allerFait == true)
                            {
                                //L'esquive est terminer
                                reinitialisation();
                            }
                            else
                            {
                                //Il faut indiquer que l'aller est deja fait. Donc la prochain fois qu'on entre dans ce if c'est que le retour est termine.
                                allerFait = true;

                                //Ici on doit donner le vecteur de retour
                                positionAAller.y = positionAAller.y * -1;
                                vertical = vertical * -1;
                                positionJoueurAvantEvitement = gameObject.transform.position;
                                esquiveEnCours = true;

                            }
                        }
                    }
                }
            }
        }
       
        //Si il n'y a pas de d'esquive a faire alors on prend les input du joueur
        else
        {
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

                faireUnEvitement = true;
            }
        }
    }

    //Fonction appler quand le joueur veut eviter vers la gauche
    void evitementGauche()
    {
        positionAAller = lesPositionMaximumPourEvitement[0];
    }

    //Fonction appler quand le joueur veut eviter vers le bas
    void evitementBas()
    {
        positionAAller = lesPositionMaximumPourEvitement[1];
    }

    //Fonction appler quand le joueur veut eviter vers le haut
    void evitementHaut()
    {
        positionAAller = lesPositionMaximumPourEvitement[2];
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




}

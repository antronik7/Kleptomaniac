using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class gameManagerCombat : MonoBehaviour {

    //Contient un tableau avec chacun des boss possible. En spawn un random au debut du combat
    //Il sera avertie par le boss quand le joueur attaque celui-ci
    //Contient aussi un tableau avec chacun des tresor possible (Pas le loot que le boss donne mais bien le tresor present dans la salle que le joueur peut looter)
    //Il sera donc averti par le tresor quand le joueur click sur celui-ci (Ajoute le loot au score du personnage) 


    //Le gameManagerCombat a donc besoin :
        //D'un tableau qui contient tous le boss possible a spawner
        //D'une référence au boss qu'il a decider de spawner
        //
        //D'un tableau qui contient tous les tresor possible a spawner
        //D'une reference au tresor qu'il a spawner

    //Le gameMangerCombat n'a pas beson :
        //D'une reference du player car celui-ci va connaitre le gameManagerCombat et va caller une fonction du gameMaangerCombat


    public GameObject[] listeMonstre;
    public GameObject[] listeTresor;

    //Ceci ne devrait pas toujours = 0
    public int idDuMonstreSpawner = 0;

    //Ceci ne devrait pas toujours = 0
    public int idDuTresorSpawner = 0;
    
    //Valeur qui devrait etre donner par le gameManager pricinpale
    public int attaqueDuPersonnage = 2;

    //Variable qui sera transmit au gameManager apres le combat. (Sera ajouter au score du joueur)
    public int lootTemporaire = 0;

    



	// Use this for initialization
	void Start () {

        initialiserAttaqueDuPersonnage();

         SpawnerLeMonstre();
      
       // SpawnerLeTresor();

       // remplirInventaire();
     
	}
	
	// Update is called once per frame
    void Update()
    {

    }

    //fonction qui retourne le nbr d'attaque que le joueur a fait
    public int leJoueurABlesserLeMonstre()
    {
       // Debug.Log("gameManagerCombat : leJoueurABlesserLeMonstre() Vie : " + attaqueDuPersonnage);

        return attaqueDuPersonnage;
    }

    //Fonction qui ajoute le au loot le montant recu
    public void leJoueurALooter(int loot)
    {
        lootTemporaire += loot;
        //Debug.Log("leJoueurALooter : " + lootTemporaire);
    }

    //Fonctoin qui supprime le monstre apres qu'il soit mort. C'est le monstre qui call cette fonction. Elle supprime aussi le projectile s'il en n'a un
    public void leMonstreEstMort()
    {
        Destroy(GameObject.FindGameObjectWithTag("Monstre"));
        Destroy(GameObject.FindGameObjectWithTag("Projectile"));

        Application.LoadLevel("Main");
    }


    //Fonction qui spawner le monstre. Cette fonction devrait prendre en concideration l'etage
    void SpawnerLeMonstre()
    {
        /*switch (GameManager.instance.floor)
        {
            case 0: idDuMonstreSpawner = 0;
                break;

            case 1: idDuMonstreSpawner = 0; //Random.Range(1, 3) - 1;
                break;

            default:
                idDuMonstreSpawner = 0;
                break;
        }*/


        //Instantiate le monstre
        Instantiate(listeMonstre[idDuMonstreSpawner], new Vector2(4, 0), Quaternion.identity);

        

    }

    //Fonction qui spawner le tresor. Cette fonction devrait prendre en concideration l'etage et le monstre spawner
    void SpawnerLeTresor()
    {
        switch (GameManager.instance.floor)
        {
            case 0:
                idDuTresorSpawner = Random.Range(1, 3) - 1;
                break;

            case 1:
                idDuTresorSpawner = Random.Range(1, 3) - 1;
                break;

            default:
                idDuTresorSpawner = 1;
                break;
        }

        //Instantiate le tresor
        Instantiate(listeTresor[idDuTresorSpawner], new Vector2(7, 0), Quaternion.identity);

    }

    //Fonction qui sert a aller cherhcer dans le gameManagerPrincipale combien de fois les diffents item ont ete achete pour les rendre disponible au jour est indiquer le nombre de fois qu'il peut les utiliser
    public void remplirInventaire()
    {
        //POUR LE MOMENT on va pas chercher dans le gameManager
    }

    void initialiserAttaqueDuPersonnage()
    {
        attaqueDuPersonnage = GameManager.instance.characterDmg;
    }

}

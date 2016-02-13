using UnityEngine;
using System.Collections;

public class DDManager : MonoBehaviour {

    public float percentDMG = 0.05f;

    public GameObject[] tableauDeDoors;
    public GameObject DoorVide;
    public GameObject loot;
    public GameObject BonhommeVert;
<<<<<<< HEAD
=======
    public GameObject ParticulePorte;
>>>>>>> master

    public int difficuty = 0;

    int nbrDoorASpawner = 0;
    bool first = true;

    int winner = 0;

    // Use this for initialization
    void Start()
    {
        //SI ON VEUX UN BONUS
        /*dmgModifier = 0.15f;
        //dmgModifier = GameManager.instance.DDdmgModifier;
        percentDMG = percentDMG + (percentDMG * dmgModifier);*/

        

        //HBd1 =  door1.GetComponentInChildren<DDHealthBar>();
        
        initialiseDoors();
        setDmgToDoor();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void setDmgToDoor()
    {
        for (int i = 0; i < nbrDoorASpawner; i++)
        {
            tableauDeDoors[difficuty].GetComponentInChildren<DDHealthBar>().setDmg(percentDMG);
        }
    }

    void getDifficulte()
    {
        //Fonction pour aller chercher la difficulte voulu
        difficuty = 1;
    }

    void initialiseDoors()
    {
        getDifficulte();

        switch (difficuty)
        {
            //Easy
            case 1:
                nbrDoorASpawner = 2;
                break;

            //Medium 
            case 2:
                nbrDoorASpawner = 3;
                break;

            //Hard
            case 3:
                nbrDoorASpawner = 4;
                break;
        }

        for (int i = 0; i < nbrDoorASpawner; i++)
        {
            
            difficuty = Random.Range(0, 4);

            while (tableauDeDoors[difficuty].activeSelf)
            {
                difficuty = Random.Range(0, 4);
            }

            if (first)
            {
                winner = difficuty;
                first = false;
            }

            tableauDeDoors[difficuty].SetActive(true);
            tableauDeDoors[difficuty].GetComponentInChildren<DDHealthBar>().setIndexDoor(difficuty);
        }
    }

    public void DestroyDoor(int i)
    {
        Instantiate(DoorVide, tableauDeDoors[i].transform.position, Quaternion.identity);
<<<<<<< HEAD
=======
        Instantiate(ParticulePorte, tableauDeDoors[i].transform.position, Quaternion.identity);
>>>>>>> master
        tableauDeDoors[i].SetActive(false);

        if (i == winner)
        {
            Instantiate(loot, tableauDeDoors[i].transform.position - new Vector3(1.65f,2.3f,0), Quaternion.identity);
<<<<<<< HEAD
=======
            
>>>>>>> master
            //Win
            ScoreManager.score += 100;
            ScoreManager.scoreDoors += 1;

<<<<<<< HEAD
=======
            GameManager.instance.spawnRewardScreen();

>>>>>>> master
            //UnityEngine.SceneManagement.SceneManager.LoadScene("DoorSelection");
        }
        else
        {
            Instantiate(BonhommeVert, tableauDeDoors[i].transform.position - new Vector3(0, 1.82f, 0), Quaternion.identity);
            //Perdu
        }


    }
}

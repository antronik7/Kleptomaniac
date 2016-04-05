using UnityEngine;
using System.Collections;

public class LabyManager : MonoBehaviour {

    public GameObject[] lesBouton;


    public GameObject spawner1Btn;
    public GameObject spawner2Btn;
    public GameObject spawner3Btn;
    public GameObject spawner4Btn;

    int indexeSpawner = 0;

    bool okPlacer = false;

    int difficuty = 50;

    int randomChange = 0;
   
    // Use this for initialization
    void Start () {

        trouverDifficulty();

        initialiserUnePartie();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void initialiserLesSpawner()
    {
        spawner1Btn.GetComponent<lesSpawner>().initialiserChoisir();
        spawner2Btn.GetComponent<lesSpawner>().initialiserChoisir();
        spawner3Btn.GetComponent<lesSpawner>().initialiserChoisir();
        spawner4Btn.GetComponent<lesSpawner>().initialiserChoisir();

    }

    void initialiserUnePartie()
    {
        initialiserLesSpawner();

        for (int i = 0; i <= 3; i++)
        {
            while (okPlacer == false)
            {
                indexeSpawner = UnityEngine.Random.Range(0, 4);

                switch (indexeSpawner)
                {
                    case 0:
                        if (!spawner1Btn.GetComponent<lesSpawner>().getDejaChoisi())
                        {
                            lesBouton[i].transform.position = spawner1Btn.transform.position;

                            okPlacer = true;
                        }
                        break;

                    case 1:
                        if (!spawner1Btn.GetComponent<lesSpawner>().getDejaChoisi())
                        {
                            lesBouton[i].transform.position = spawner2Btn.transform.position;
                            okPlacer = true;
                        }
                        break;

                    case 2:
                        if (!spawner1Btn.GetComponent<lesSpawner>().getDejaChoisi())
                        {
                            lesBouton[i].transform.position = spawner3Btn.transform.position;
                            okPlacer = true;
                        }
                        break;

                    case 3:
                        if (!spawner1Btn.GetComponent<lesSpawner>().getDejaChoisi())
                        {
                            lesBouton[i].transform.position = spawner4Btn.transform.position;
                            okPlacer = true;
                        }
                        break;

                    default:
                        break;
                }
            }

            okPlacer = false;
        }
    }

    void trouverDifficulty()
    {
        difficuty = difficuty + (GameManager.instance.floor * 5) ;

        if(difficuty > 100)
        {
            difficuty = 100;
        }
    }

    public void verifierSiOnChange()
    {
        randomChange = UnityEngine.Random.Range(0, 100);

        if(randomChange >= difficuty)
        {
            initialiserUnePartie();
        }

    }
}

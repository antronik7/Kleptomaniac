using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public  GameObject[] DoorArray;

    public GameObject OpenStairs;

    public GameObject PosDoor1Object;
    public GameObject PosDoor2Object;
    public GameObject PosDoor3Object;
    public GameObject PosDoor4Object;
    public GameObject PosDoor5Object;
    public GameObject PosDoor6Object;

    public GameObject PosStairs1Object;
    public GameObject PosStairs2Object;

    public GameObject RewardScreen;
    public GameObject chest;

    public Vector3 PosDoor1;
    public Vector3 PosDoor2;
    public Vector3 PosDoor3;
    public Vector3 PosDoor4;
    public Vector3 PosDoor5;
    public Vector3 PosDoor6;

    public Vector3 PosStairs1;
    public Vector3 PosStairs2;

    public bool isDoorOpen1 = true;
    public bool isDoorOpen2 = true;
    public bool isDoorOpen3 = true;

    public int indexDoor1;
    public int indexDoor2;
    public int indexDoor3;

    public int idDoorClicked;

    public float currentTime;
    public float startTime = 30f;

    public int MaxHealth = 100;
    public int CurrentHealth = 100;

    public int floor = 1;

    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        PosDoor1 = PosDoor1Object.transform.position;
        PosDoor2 = PosDoor2Object.transform.position;
        PosDoor3 = PosDoor3Object.transform.position;
        PosDoor4 = PosDoor4Object.transform.position;
        PosDoor5 = PosDoor5Object.transform.position;
        PosDoor6 = PosDoor6Object.transform.position;

        PosStairs1 = PosStairs1Object.transform.position;
        PosStairs2 = PosStairs2Object.transform.position;

        InstantiateDoors();

        currentTime = startTime;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void InstantiateDoors()
    {
        int randomDoorIndex;

        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor1 = randomDoorIndex;

        GameObject myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor1, Quaternion.identity);
        DoorController myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 1;

        /*if(isDoorOpen1)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }*/


        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor2 = randomDoorIndex;

        myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor2, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 2;

        /*if (isDoorOpen1)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }*/


        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor3 = randomDoorIndex;

        myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor3, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 3;

        /*if (isDoorOpen1)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }*/
    }

    public void InstantiateNextDoors()
    {
        int randomDoorIndex;

        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor1 = randomDoorIndex;

        GameObject myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor4, Quaternion.identity);
        DoorController myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 1;

        
        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor2 = randomDoorIndex;

        myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor5, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 2;


        randomDoorIndex = Random.Range(0, DoorArray.Length);
        indexDoor3 = randomDoorIndex;

        myDoor = (GameObject)Instantiate(DoorArray[randomDoorIndex], PosDoor6, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 3;
    }

    public void RecreateDoor()
    {
        if(idDoorClicked == 1)
        {
            isDoorOpen1 = false;
        }
        else if(idDoorClicked == 2)
        {
            isDoorOpen2 = false;
        }
        else if (idDoorClicked == 3)
        {
            isDoorOpen3 = false;
        }

        if(ScoreManager.score > 500 * floor)
        {
            Instantiate(OpenStairs, PosStairs1, Quaternion.identity);
            Instantiate(OpenStairs, PosStairs2, Quaternion.identity);
        }

        GameObject myDoor = (GameObject)Instantiate(DoorArray[indexDoor1], PosDoor1, Quaternion.identity);
        DoorController myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 1;

        if (isDoorOpen1)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }

        myDoor = (GameObject)Instantiate(DoorArray[indexDoor2], PosDoor2, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 2;

        if (isDoorOpen2)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }

        myDoor = (GameObject)Instantiate(DoorArray[indexDoor3], PosDoor3, Quaternion.identity);
        myDoorController = myDoor.GetComponent<DoorController>();
        myDoorController.idDoor = 3;

        if (isDoorOpen3)
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Close") child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in myDoor.transform)
            {
                if (child.name == "Open") child.gameObject.SetActive(false);
            }
        }
    }

    public void LooseGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        //Application.LoadLevel("GameOver");
    }

    //section a chri
    public void spawnRewardScreen()
    {
        GameObject RS = (GameObject)Instantiate(RewardScreen, new Vector3(0, 0, 0), Quaternion.identity);

        Vector3[] tab = RS.GetComponent<RZManager>().getPosition();

        for (int i = 0; i < 3; i++)
        {
            Instantiate(chest, tab[i], Quaternion.identity);
        }

        //IL FAUT ARRETER LE TIMER

        

    }
    //----------------------------
}

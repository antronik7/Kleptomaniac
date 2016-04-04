﻿using UnityEngine;
using System.Collections;

public class CastleController : MonoBehaviour {

    public GameObject ScoreBoard;
    public GameObject PosScoreBoard;
    public GameObject Cadenas;
    public GameObject textPrix;

    GameObject lescorebord;

    public string nomChateau;

    int bestScore;
    int bestFloor;
    int bestDoor;

    int prix;

    bool unlocked = false;

    bool JeVeuxZoomer = false;

	// Use this for initialization
	void Start () {

        prix = int.Parse(textPrix.GetComponent<TextMesh>().text);

            if (PlayerPrefs.HasKey(nomChateau + "BestScore"))
            {
                bestScore = PlayerPrefs.GetInt(nomChateau + "BestScore");
                bestFloor = PlayerPrefs.GetInt(nomChateau + "BestFloor");
                bestDoor = PlayerPrefs.GetInt(nomChateau + "BestDoor");
            }
            else
            {
                PlayerPrefs.SetInt(nomChateau + "BestScore", 0);
                PlayerPrefs.SetInt(nomChateau + "BestFloor", 0);
                PlayerPrefs.SetInt(nomChateau + "BestDoor", 0);
                bestScore = 0;
                bestFloor = 0;
                bestDoor = 0;
            }
        
	    
	}
	
	// Update is called once per frame
	void Update () {


        

        if (Camera.main.orthographicSize == 2.5f && Camera.main.transform.position.x == transform.position.x && Camera.main.transform.position.y == transform.position.y)
        {
            //Debug.Log("Je suis dans le if");
            JeVeuxZoomer = false;
        }

        if(JeVeuxZoomer && Camera.main.orthographicSize != 2.5)
        {
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, 2.5f, 10 * Time.deltaTime);
        }

        if(JeVeuxZoomer && Camera.main.transform.position != transform.position)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z), 20 * Time.deltaTime);
        }

	}

    void OnMouseDown()
    {
       
            if (Camera.main.orthographicSize != 2.5)
            {
                lescorebord = (GameObject)Instantiate(ScoreBoard, PosScoreBoard.transform.position, Quaternion.identity);
                lescorebord.GetComponent<ScoreBoardController>().setText(bestScore, bestFloor, bestDoor);
                JeVeuxZoomer = true;
            }
            else if (!unlocked)
            {
            Debug.Log(prix);
                //Acheter le chateau
                if (PlayerPrefs.GetInt("ScoreGlobal") >= prix)
                {
                    PlayerPrefs.SetInt("ScoreGlobal", PlayerPrefs.GetInt("ScoreGlobal") - prix);
                    setUnlocked(nomChateau + "Unlocked");
                    //Ajouter un son pour oui je l'ai ahceter
                }
                else
                {
                    //Ajouter un son pour fuck jpeux as acheter jai pas assez de gold
                }
            }
            else
            {
                //Enregistrer dans les players pref le chateau dans lequel le joueur va jouer
                PlayerPrefs.SetString("ChateauActuel", nomChateau);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
            }
    }

    public void setUnlocked(string nomPlayerPref)
    {
        unlocked = true;
        PlayerPrefs.SetInt(nomPlayerPref, 1);
        Cadenas.SetActive(false);
    }
}

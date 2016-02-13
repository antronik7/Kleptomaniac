using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SIZManager : MonoBehaviour {

<<<<<<< HEAD
=======
    public GameObject particule;

>>>>>>> master
    GameObject pBar;
    ProgressBar PBScript;

    GameObject wZone;
    SIZWinZone WZScript;

    GameObject player;
    Transform Ptrans;

    GameObject boulder;
    Transform Btrans;

<<<<<<< HEAD
=======
    float leTempsPasser = 0;

    bool inZone = false;
    bool isPlaying = false;

    int result;

>>>>>>> master
    public float x = 0.75F;
    public Vector3 transformation;

	// Use this for initialization
	void Start () {

        pBar = GameObject.FindGameObjectWithTag("PBar");
        PBScript = (ProgressBar)pBar.GetComponent(typeof(ProgressBar));

        //win zone
        wZone = GameObject.FindGameObjectWithTag("WinZone");
        WZScript = (SIZWinZone)wZone.GetComponent(typeof(SIZWinZone));

        player = GameObject.FindGameObjectWithTag("player");
        Ptrans = player.GetComponent<Transform>();

        boulder = GameObject.FindGameObjectWithTag("boulder");
        Btrans = boulder.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.deltaTime * 100 >= 1f)
        {
            PBScript.SubstractTime();
            DansLaWinZone();
<<<<<<< HEAD
=======
            playSound();
>>>>>>> master
        }
	}

    public void FromButton()
    {
        PBScript.AddTime();
    }

    void DansLaWinZone()
    {
<<<<<<< HEAD
        int result;
=======
        
>>>>>>> master
        float pourcentage;

        pourcentage = PBScript.getFillAmount();

        result = WZScript.VerifierInZone(pourcentage);

        switch (result)
        {
            case 0:
<<<<<<< HEAD
                break;
            case 1:
=======
                inZone = false;
                break;
            case 1:
                inZone = true;
>>>>>>> master
                transformation.x = x;
                move();
                break;
            case 2:
<<<<<<< HEAD
=======
                inZone = true;
>>>>>>> master
                transformation.x = x * 1.5F;
                move();
                break;
        }
    }

    void move()
    {
<<<<<<< HEAD
        if (Btrans.position.x < 2.25F)
        {
            Btrans.Translate(transformation * Time.deltaTime);
        }
        Ptrans.Translate(transformation * Time.deltaTime);
    }
=======
        if (Btrans.position.x < 4.25F)
        {
            Btrans.Translate(transformation * Time.deltaTime);

            Debug.Log(Time.deltaTime);

            if (leTempsPasser >= 0.5f)
            {

                leTempsPasser = 0;

                if (result == 2)
                {
                    Instantiate(particule, new Vector3(Btrans.transform.position.x - 0.5f, -1.95f, 0), Quaternion.identity);
                    Instantiate(particule, new Vector3(Btrans.transform.position.x - 0.5f, -1.95f, 0), Quaternion.identity);
                    Instantiate(particule, new Vector3(Btrans.transform.position.x - 0.5f, -1.95f, 0), Quaternion.identity);

                }
                else
                {
                    Instantiate(particule, new Vector3(Btrans.transform.position.x - 0.5f, -1.95f, 0), Quaternion.identity);
                }
            }
            else
            {
                leTempsPasser += Time.deltaTime;
            }
        }
        Ptrans.Translate(transformation * Time.deltaTime);
    }

    void playSound()
    {
        if (inZone)
        {
            if (!isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
                isPlaying = true;
            }
        }
        else
        {
            if (isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Stop();
                isPlaying = false;
            }
        }
    }

>>>>>>> master
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SIZManager : MonoBehaviour {

    GameObject pBar;
    ProgressBar PBScript;

    GameObject wZone;
    SIZWinZone WZScript;

    GameObject player;
    Transform Ptrans;

    GameObject boulder;
    Transform Btrans;

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
        }
	}

    public void FromButton()
    {
        PBScript.AddTime();
    }

    void DansLaWinZone()
    {
        int result;
        float pourcentage;

        pourcentage = PBScript.getFillAmount();

        result = WZScript.VerifierInZone(pourcentage);

        switch (result)
        {
            case 0:
                break;
            case 1:
                transformation.x = x;
                move();
                break;
            case 2:
                transformation.x = x * 1.5F;
                move();
                break;
        }
    }

    void move()
    {
        if (Btrans.position.x < 2.25F)
        {
            Btrans.Translate(transformation * Time.deltaTime);
        }
        Ptrans.Translate(transformation * Time.deltaTime);
    }
}

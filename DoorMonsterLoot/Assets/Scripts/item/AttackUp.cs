﻿using UnityEngine;
using System.Collections;

public class AttackUp : MonoBehaviour {

    public int index;
    GameObject GameManagerCombat;
    gameManagerCombat scriptGM;


    // Use this for initialization
    void Start()
    {
        GameManagerCombat = GameObject.FindGameObjectWithTag("GameManagerCombat");
        scriptGM = GameManagerCombat.GetComponent<gameManagerCombat>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        scriptGM.AttackUp();
        IventoryManager.instance.removeFromInventory(index);
        Destroy(gameObject);
    }
}

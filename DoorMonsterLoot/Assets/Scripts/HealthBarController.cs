using UnityEngine;
using System.Collections;

public class HealthBarController : MonoBehaviour {

    public GameObject Hearth;
    public GameObject HeadPerso;

    private float pourcentage;

	// Use this for initialization
	void Start () {
        pourcentage = (GameManager.instance.CurrentHealth * 100) / GameManager.instance.MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

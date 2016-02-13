using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public float plus = 0.04f;
    public float minus = 0.001f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddTime()
    {
        gameObject.GetComponent<Image>().fillAmount += plus;
    }

    public void SubstractTime()
    {
        gameObject.GetComponent<Image>().fillAmount -= minus;
    }

    public float getFillAmount()
    {
        return gameObject.GetComponent<Image>().fillAmount;
    }

}

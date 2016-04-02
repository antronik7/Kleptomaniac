using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoutonOption : MonoBehaviour {

    public GameObject panelPourLesOptions;
    public GameObject leSliderVolume;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnMouseDown()
    {
        panelPourLesOptions.SetActive(true);
        leSliderVolume.SetActive(true);

        leSliderVolume.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
    }
}

using UnityEngine;
using System.Collections;

public class BarDeTempsController : MonoBehaviour {

    public GameObject barreDeTemps;
    public GameObject guard;
    public int startTime;
    public bool addingTime = false;

    private float currentTime;

	// Use this for initialization
	void Start () {
        currentTime = startTime;
	}
	
	// Update is called once per frame
	void Update () {


        if (addingTime)
        {
            if (currentTime < 60f)
            {
                barreDeTemps.transform.localScale += new Vector3((15 * Time.deltaTime) / startTime, 0, 0);
                guard.transform.position -= new Vector3((11.5f * Time.deltaTime) / startTime, 0, 0);
            }

            currentTime += Time.deltaTime;
        }
        else
        {
            barreDeTemps.transform.localScale -= new Vector3((15 * Time.deltaTime) / startTime, 0, 0);
            guard.transform.position += new Vector3((11.5f * Time.deltaTime) / startTime, 0, 0);

            currentTime -= Time.deltaTime;

            if(currentTime < 0.1)
            {
                GameManager.instance.LooseGame();
                Destroy(gameObject);
            }
        }
	}
}

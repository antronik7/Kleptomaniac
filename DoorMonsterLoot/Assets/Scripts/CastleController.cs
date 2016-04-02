using UnityEngine;
using System.Collections;

public class CastleController : MonoBehaviour {

    public GameObject ScoreBoard;
    public GameObject PosScoreBoard;

    bool JeVeuxZoomer = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if(Camera.main.orthographicSize == 2.5f && Camera.main.transform.position.x == transform.position.x && Camera.main.transform.position.y == transform.position.y)
        {
            Debug.Log("Je suis dans le if");
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
        if(Camera.main.orthographicSize != 2.5)
        {
            Instantiate(ScoreBoard, PosScoreBoard.transform.position, Quaternion.identity);
            JeVeuxZoomer = true;
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }
}

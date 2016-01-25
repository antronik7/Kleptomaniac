using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour {

    private Vector2 previousPosition;
    private Vector2 distanceBetWeenDrag;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            previousPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
 
    void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        distanceBetWeenDrag = objPosition - previousPosition;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x + distanceBetWeenDrag.x, -15, 2), transform.position.y);

        previousPosition = objPosition;
    }
}

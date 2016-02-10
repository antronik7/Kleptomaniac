using UnityEngine;
using System.Collections;

public class ShopController : MonoBehaviour {

    public GameObject[] ShopItemsArray;

    public GameObject PosItem1Object;
    public GameObject PosItem2Object;
    public GameObject PosItem3Object;

    public Vector3 PosItem1;
    public Vector3 PosItem2;
    public Vector3 PosItem3;



    // Use this for initialization
    void Start () {
        PosItem1 = PosItem1Object.transform.position;
        PosItem2 = PosItem2Object.transform.position;
        PosItem3 = PosItem3Object.transform.position;

        int randomDoorIndex;

        randomDoorIndex = Random.Range(0, ShopItemsArray.Length);

        Instantiate(ShopItemsArray[randomDoorIndex], PosItem1, Quaternion.identity);

        randomDoorIndex = Random.Range(0, ShopItemsArray.Length);

        Instantiate(ShopItemsArray[randomDoorIndex], PosItem2, Quaternion.identity);

        randomDoorIndex = Random.Range(0, ShopItemsArray.Length);

        Instantiate(ShopItemsArray[randomDoorIndex], PosItem3, Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

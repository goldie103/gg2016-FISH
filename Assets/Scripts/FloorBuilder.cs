using UnityEngine;
using System.Collections;

public class FloorBuilder : MonoBehaviour {
    public Sprite[] sprites;
    public GameObject floorItemPrefab;
    public int floorLength = 300;
    public float floorHeight = 5.0f;
    public float xMinInterval = 2.0f;
    public float xMaxInterval = 4.5f;

    // Use this for initialization
    void Start () {
        for (float x = 0; x < floorLength; x += Random.Range(xMinInterval, xMaxInterval)) {
            GameObject newItem = Instantiate(floorItemPrefab);
            newItem.transform.position = new Vector3(x, Random.Range(0, floorHeight));
            newItem.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

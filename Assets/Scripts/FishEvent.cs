using UnityEngine;
using System.Collections;

public class FishEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D pCollider)
    {
        Debug.Log("Event triggered!");
    }
}

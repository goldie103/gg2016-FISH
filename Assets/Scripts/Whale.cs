using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * -0.5f);
    }
}

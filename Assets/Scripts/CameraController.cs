using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraController : MonoBehaviour {

    public float DistanceToZoomIn = 12f;

    public float DistanceToZoomOut = 13f;

    public Transform Fish;

    public Transform School;

    private Camera mCamera;

	// Use this for initialization
	void Start () {
        mCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Fish.position + new Vector3(0, 0, -10);
        Debug.Log(Vector3.Distance(transform.position, School.position));
        if (Vector3.Distance(transform.position, School.position) > DistanceToZoomOut)
        {
            mCamera.DOOrthoSize(8, 1);
        }
        else if (Vector3.Distance(transform.position, School.position) < DistanceToZoomIn)
        {
            mCamera.DOOrthoSize(5, 1);
        }
    }
}

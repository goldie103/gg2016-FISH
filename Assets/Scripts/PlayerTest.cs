using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerTest : MonoBehaviour {
	private int speed = 3;
	private float x, y;
	private Rigidbody2D rigidBody;
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

	public void FixedUpdate() {
		rigidBody.velocity = new Vector2(x, y);
        if (Input.GetKeyDown(KeyCode.RightArrow)) { DoRotation(); }
		if (Input.GetKeyDown(KeyCode.LeftArrow)) { DoRotation(-1); }
		if (Input.GetKeyDown(KeyCode.UpArrow)) { speed += 1; }
    }

	public void DoRotation(int multiplier=1) {
		float angle = transform.eulerAngles.z;
		transform.DORotate(new Vector3 (0, 0, 45 * multiplier), 1, RotateMode.LocalAxisAdd);
		Debug.Log (transform.eulerAngles.z);
		if ((angle < 90 && angle >= 0) || (angle > 270 && angle <= 360)) {
			x = 0.5f;
		} else if (angle == 90 || angle == 270) {
			x = 0;
		} else {
			x = -0.5f;
		}

		if (angle > 0 && angle < 180) {
			y = 0.5f;
		} else if (angle == 0 || angle == 180) {
			y = 0;
		} else {
			y = -0.5f;
		}
   }
}
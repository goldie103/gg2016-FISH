using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class SplashManager : MonoBehaviour {
    public SpriteRenderer spriteBody;
    public SpriteRenderer spriteTail;
    public GameObject[] schoolFish;
    public Transform parentSchool;

    public Text textSpace;
    public float initialPause = 2.5f;
    public float textInterval = 5f;
    private Vector3 movement = Vector3.right;
    private Vector3 schoolMovement = Vector3.zero;
    private Rigidbody2D rigidBody;
    public string[] StoryText;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(DoIntro());
    }

    private IEnumerator DoIntro() {
        yield return new WaitForSeconds(initialPause);
        for (int i = 0; i < StoryText.Length; i++) {
            textSpace.text = StoryText[i];
            if (i == 4) {
                schoolMovement = Vector3.right * 6;
            } else if (i == 6) {
                parentSchool.position = new Vector3(-4.7f, transform.position.y);
                schoolMovement = Vector3.zero;
            }
            var tween = textSpace.DOFade(1, 2);
            yield return tween.WaitForCompletion();
            yield return new WaitForSeconds(textInterval);
            var tween2 = textSpace.DOFade(0, 2);
            yield return tween2.WaitForCompletion();
        }
    }

    void Update() {
        rigidBody.velocity = movement;
        foreach (GameObject fish in schoolFish) {
            fish.GetComponent<Rigidbody2D>().velocity = schoolMovement;
        }
    }
}

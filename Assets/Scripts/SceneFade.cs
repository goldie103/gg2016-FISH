using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SceneFade : MonoBehaviour {
    public SpriteRenderer coverTexture;
    public float fadeSpeed = 10;

	void Start () {
        coverTexture.DOFade(0, fadeSpeed);
	}
    	
	void Update () {
	
	}
}

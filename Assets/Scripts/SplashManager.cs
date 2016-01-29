using UnityEngine;
using System.Collections;

public class SplashManager : MonoBehaviour {

    public SpriteRenderer SplashImage;

    public float FadeSpeed = 1.5f;

    public ScenesManager scenesManager;

    private SplashStates mCurrentState;

    public enum SplashStates
    {
        START,
        SHOW,
        FINISH
    }

    private const float cLogoAppearanceTime = 2f;

    private float mTimer = 0;

	// Use this for initialization
	void Start () {
        ChangeState(SplashStates.START);
        
    }

    // Update is called once per frame
    void Update() {
        switch (mCurrentState)
        {
            case SplashStates.START:
                if (SplashImage.material.color.a <= 0.95f)
                {
                    FadeIn();
                }
                else
                {
                    ChangeState(SplashStates.SHOW);
                }
            break;
            case SplashStates.SHOW:
                mTimer += Time.deltaTime;
                if (mTimer > cLogoAppearanceTime)
                {
                    ChangeState(SplashStates.FINISH);
                }
                break;
            case SplashStates.FINISH:
                if (SplashImage.material.color.a >= 0.05f)
                {
                    FadeOut();
                }
                else
                {
                    scenesManager.GoToMainMenu();
                }
                break;
        }
    }

    void ChangeState(SplashStates pNewState)
    {
        switch (pNewState)
        {
            case SplashStates.START:
                SplashImage.material.color = Color.clear;
                break;
            case SplashStates.SHOW:
                mTimer = 0;
                SplashImage.material.color = Color.white;
                break;
            case SplashStates.FINISH:
                break;
        }
        mCurrentState = pNewState;
    }
    
    void FadeOut()
    {
        // Lerp the colour of the texture between itself and transparent.
        SplashImage.material.color = Color.Lerp(SplashImage.material.color, Color.clear, FadeSpeed * Time.deltaTime);
    }


    void FadeIn()
    {
        // Lerp the colour of the texture between itself and black.
        SplashImage.material.color = Color.Lerp(SplashImage.material.color, Color.white, FadeSpeed * Time.deltaTime);
    }
}

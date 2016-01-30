using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScenesManager : MonoBehaviour {

    private static ScenesManager sInstance = null;

    public static ScenesManager Instance;

    private GameScenes mCurrentGameScene;

    private const float cMaxFloatingOffset = 2;

    private float mFloatingEffect;

    public List<Transform> Cameras;

    public enum GameScenes
    {
        LOGO        =       0,
        MAIN_MENU   =       1,
        OPTIONS     =       2,
        CREDITS     =       3,
        GAME        =       4,
        PAUSE       =       5,
        END         =       6
    }

    private void ChangeScene(GameScenes pNewScene)
    {
        for (int i = 0; i < Cameras.Count; ++i)
        {
            Cameras[i].gameObject.SetActive(false);
            if (i == (int)pNewScene)
            {
                Cameras[i].gameObject.SetActive(true);
            }
        }

        switch (pNewScene)
        {
            case GameScenes.LOGO:
                break;
            case GameScenes.MAIN_MENU:
                break;
            case GameScenes.OPTIONS:
                break;
            case GameScenes.CREDITS:
                break;
            case GameScenes.GAME:
                GameObject.Find("GameManager").GetComponent<GameManager>().Initialize();
                break;

        }

        mCurrentGameScene = pNewScene;
    }

    void Awake()
    {
        if (sInstance == null)
        {
            sInstance = GetComponent<ScenesManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        mFloatingEffect = Random.value * cMaxFloatingOffset;
        ChangeScene(GameScenes.LOGO);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void GoToMainMenu()
    {
        ChangeScene(GameScenes.MAIN_MENU);
    }

    public void GoToGame()
    {
        ChangeScene(GameScenes.GAME);
    }

    public void GoToEnd()
    {
        ChangeScene(GameScenes.END);
    }

    public bool PlayingGame()
    {
        return mCurrentGameScene.Equals(GameScenes.GAME);
    }
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager sInstance = null;

    public static GameManager Instance;

    void Awake()
    {
        if (sInstance == null)
        {
            sInstance = GetComponent<GameManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

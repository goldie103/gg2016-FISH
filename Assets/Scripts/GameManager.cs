using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager sInstance = null;

    public static GameManager Instance;

    private SchoolController mSchoolController;

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
	    mSchoolController = GameObject.Find("SchoolController").GetComponent<SchoolController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize()
    {

    }
}

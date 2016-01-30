using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public float WindConditionPoints = 800;

    public float ProPoints = 10;
    public float DecentPoints = 5;
    public float BadPoints = 2;

    public float DistanceOne = 20;
    public float DistanceTwo = 50;
    public float DistanceThree = 80;

    private float mPointsTimer;
    private float mGamePoints;

    /// <summary>
    /// last timer in integer, so that it is possible to know if one second has ellapsed
    /// </summary>
    private int mLastPointsTimer;

    public Transform SchoolLeader;

    private static GameManager sInstance = null;

    public static GameManager Instance;

    public Transform Player;

    private SchoolController mSchoolController;

    private ScenesManager mScenesManager;

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
        mScenesManager = GameObject.Find("ScenesManager").GetComponent<ScenesManager>();
    }
	
	// Update is called once per frame
	void Update () {
        CheckLeaderDistance();
        if (mGamePoints > WindConditionPoints)
        {
            mScenesManager.GoToEnd();
        }
	}

    public void Initialize()
    {
        mPointsTimer = 0;
        mLastPointsTimer = 0;
        mGamePoints = 0;
    }

    private void CheckLeaderDistance()
    {
        float distance = Vector3.Distance(Player.position, SchoolLeader.transform.position);
        if (distance < DistanceOne) {
            mPointsTimer += Time.deltaTime;
            
            SchoolLeader.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
            if (mPointsTimer - mLastPointsTimer >= 1)
            {
                mGamePoints += ProPoints;
            }
            mLastPointsTimer = Mathf.FloorToInt(mPointsTimer);
            SaturationEventManager.OnSaturate(4);

        }
        else if (distance < DistanceTwo)
        {
            mPointsTimer += Time.deltaTime;
            SchoolLeader.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
            if (mPointsTimer - mLastPointsTimer >= 1)
            {
                mGamePoints += DecentPoints;
            }
            mLastPointsTimer = Mathf.FloorToInt(mPointsTimer);
            SaturationEventManager.OnSaturate(3);
        }
        else if (distance < DistanceThree)
        {
            mPointsTimer += Time.deltaTime;
            SchoolLeader.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            if (mPointsTimer - mLastPointsTimer >= 1)
            {
                mGamePoints += BadPoints;
            }
            mLastPointsTimer = Mathf.FloorToInt(mPointsTimer);
            SaturationEventManager.OnSaturate(2);
        }
        else
        {
            mPointsTimer = 0;
            SchoolLeader.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
            SaturationEventManager.OnSaturate(1);
        }
    }
}

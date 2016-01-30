using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    private const int mNumberOfPointsPerformance = 51;

    public float WindConditionPoints = 800;

    public float DistanceToLose = 100;

    public float ProPoints = 10;
    public float DecentPoints = 5;
    public float BadPoints = 2;

    public float DistanceOne = 20;
    public float DistanceTwo = 50;
    public float DistanceThree = 80;

    private float mPointsTimer;
    private float mGamePoints;

    private List<float> mPlayerPerformance;

    public AudioClip soundBG, sound1,sound2,sound3;
    public AudioSource audioSource;

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

    public GameObject RestartGameButton;

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
        //Debug.Log(mGamePoints);
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
        mPlayerPerformance = new List<float>();
        RestartGameButton.SetActive(false);
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

                CalculatePerformance(ProPoints);

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
                CalculatePerformance(DecentPoints);
            }
            mLastPointsTimer = Mathf.FloorToInt(mPointsTimer);
            SaturationEventManager.OnSaturate(3);
        }
        else if (distance < DistanceThree)
        {
            if (!audioSource.isPlaying || audioSource.clip != sound2)
            {
                audioSource.clip = sound2;
                audioSource.Play();
            }
            mPointsTimer += Time.deltaTime;
            SchoolLeader.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            if (mPointsTimer - mLastPointsTimer >= 1)
            {
                mGamePoints += BadPoints;
                CalculatePerformance(BadPoints);
            }
            mLastPointsTimer = Mathf.FloorToInt(mPointsTimer);
            SaturationEventManager.OnSaturate(2);
        }
        else if (distance < DistanceToLose)
        {
            mPointsTimer += Time.deltaTime;
            if (!audioSource.isPlaying || audioSource.clip != soundBG)
            {
                audioSource.clip = soundBG;
                audioSource.Play();
            }
            if (mPointsTimer - mLastPointsTimer >= 1)
            {
                CalculatePerformance(0);
            }
            mLastPointsTimer = Mathf.FloorToInt(mPointsTimer);
            
            SchoolLeader.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
            SaturationEventManager.OnSaturate(1);
        }
        else
        {
            RestartGameButton.SetActive(true);
        }
    }

    public void PauseResumeGame()
    {

       // mScenesManager.GoToPause();
    }

    private void CalculatePerformance(float pPoints)
    {
        mPlayerPerformance.Add(pPoints);
        float totalPoints = 0;
        if (mPlayerPerformance.Count == mNumberOfPointsPerformance)
        {
            for (int i = 0; i < mPlayerPerformance.Count; ++i)
            {
                totalPoints += mPlayerPerformance[i];
                
            }
        }
        
        if (totalPoints > 0)
        {
            //if (totalPoints < 20)
            //{

            //        audioSource.clip = sound1;
            //        audioSource.Play();



            //}
            //else if (totalPoints < 50)
            //{
            //    audioSource.clip = sound2;
            //    audioSource.Play();
            //}
            //else if (totalPoints < 80)
            //{
            //    audioSource.clip = sound3;
            //    audioSource.Play();
            //}
            //else
            //{
            //    audioSource.clip = sound3;
            //    audioSource.Play();
            //}
            
            audioSource.clip = sound3;
            audioSource.Play(); 
            
            mPlayerPerformance = new List<float>();
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SchoolController : MonoBehaviour {

    public Transform SchoolLeader;
    
    public int NumberOfFishes = 4;

    public float XFishOffset = 2;
    public float YFishOffset = 2;

    public float LagToFollow = 0.1f;

    public Transform Player;

    public ScenesManager scenesManager;

    private float mPreviousSpeed;

    public float StopTime = 3f;

    /// <summary>
    /// The code assumes the fish prefab will be positioned at the beginning of the school
    /// </summary>

    public GameObject FishPrefab;

    List<Fish> School;

    private float mTimeEllapsed;

    private List<bool> mAlreadyFollowedCommand;

    public List<float> Commands;
    private int mCurrentCommandIndex;



	// Use this for initialization
	void Start () {
        
        InitializeSchool();
        
    }

    public void InitializeSchool()
    {
        FishPrefab.SetActive(true);
        mTimeEllapsed = 0;
        mCurrentCommandIndex = 0;
        //mCommands = new List<float>();
        mAlreadyFollowedCommand = new List<bool>();
        School = new List<Fish>();
        for (int i = 0; i < NumberOfFishes; ++i)
        {
            mAlreadyFollowedCommand.Add(false);
            GameObject newFish = GameObject.Instantiate(FishPrefab);
            newFish.transform.position = new Vector3(FishPrefab.transform.position.x - i * XFishOffset * Random.value, Random.value > 0.5f? FishPrefab.transform.position.y + Random.value * YFishOffset: FishPrefab.transform.position.y - Random.value * YFishOffset, 0);
            School.Add(newFish.GetComponent<Fish>());
        }

        SchoolLeader.transform.SetParent(School[NumberOfFishes / 2].transform);

        SchoolLeader.transform.localPosition = Vector3.zero;

        mPreviousSpeed = School[0].Speed;

        FishPrefab.SetActive(false);

    }

	// Update is called once per frame
	void Update ()
    {
        if (scenesManager.PlayingGame())
        {



            if (School[0].Speed != mPreviousSpeed)
            {
                mTimeEllapsed += Time.deltaTime;
                if (mTimeEllapsed > StopTime)
                {
                    for (int i = 0; i < School.Count; ++i)
                    {
                        School[i].Speed = mPreviousSpeed;
                    }
                    mTimeEllapsed = 0;
                }
            }
            else
            {
                SchoolCommands();
            }
        }
	}

    
    private void FollowCommand(Fish pFish)
    {
        if (mCurrentCommandIndex < Commands.Count)
        {
         
            pFish.DoRotation(Commands[mCurrentCommandIndex]);
            
        }
    }

    private void SchoolCommands()
    {
        mTimeEllapsed += Time.deltaTime;
        for (int i = 0; i < School.Count; ++i)
        {
            if (mTimeEllapsed > i * LagToFollow && !mAlreadyFollowedCommand[i])
            {
                FollowCommand(School[i]);
                mAlreadyFollowedCommand[i] = true;
            }
        }

        if (mTimeEllapsed > (School.Count - 1) * LagToFollow)
        {
            if (mCurrentCommandIndex < School.Count - 1)
            {
                ++mCurrentCommandIndex;
                mTimeEllapsed = 0;
                for (int i = 0; i < NumberOfFishes; ++i)
                {
                    mAlreadyFollowedCommand[i] = false;
                }
            }
        }
    }

    public void Stop()
    {
        for (int i = 0; i < School.Count; ++i)
        {
            School[i].Speed = 0;
        }
    }

    public void ChangeSpeed(float pSpeedDelta)
    {
        for (int i = 0; i < School.Count; ++i)
        {
            School[i].Speed += pSpeedDelta;
        }
    }

    public void MoveDirection(float pRotation)
    {
        mCurrentCommandIndex = 0;
        Commands = new List<float>();
        Commands.Add(pRotation);
        for (int i = 0; i < NumberOfFishes; ++i)
        {
            mAlreadyFollowedCommand[i] = false;
        }
    }

    public void Loop360()
    {
        mCurrentCommandIndex = 0;
        Commands = new List<float>();
        Commands.Add(0);
        Commands.Add(45);
        Commands.Add(90);
        Commands.Add(135);
        Commands.Add(180);
        Commands.Add(225);
        Commands.Add(270);
        Commands.Add(315);
        Commands.Add(359);

        for (int i = 0; i < NumberOfFishes; ++i)
        {
            mAlreadyFollowedCommand[i] = false;
        }
    }


}

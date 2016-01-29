using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SchoolController : MonoBehaviour {

    public Transform SchoolLeader;

    public float DistanceToRed = 17;

    public float DistanceToGreen = 14;

    public int NumberOfFishes = 4;

    public float XFishOffset = 2;
    public float YFishOffset = 2;

    private float LagToFollow = 0.5f;

    public Transform Player;

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
    }

	// Update is called once per frame
	void Update ()
    {
        CheckLeaderDistance();

        mTimeEllapsed += Time.deltaTime;
        for (int i = 0; i < NumberOfFishes; ++i)
        {
            if (mTimeEllapsed > i * LagToFollow && !mAlreadyFollowedCommand[i])
            {
                FollowCommand(School[i]);
                mAlreadyFollowedCommand[i] = true;
            }
        }

        if (mTimeEllapsed > (NumberOfFishes - 1) * LagToFollow)
        {
            if(mCurrentCommandIndex < NumberOfFishes - 1)
            ++mCurrentCommandIndex;
            mTimeEllapsed = 0;
            for (int i = 0; i < NumberOfFishes; ++i)
            {
                mAlreadyFollowedCommand[i] = false;
            }
        }
	}

    private void CheckLeaderDistance()
    {
        if (Vector3.Distance(Player.position, SchoolLeader.transform.position) > DistanceToRed)
        {
            SchoolLeader.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
        else if (Vector3.Distance(Player.position, SchoolLeader.transform.position) < DistanceToGreen)
        {
            SchoolLeader.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        }
    }

    private void FollowCommand(Fish pFish)
    {
        if (Commands[mCurrentCommandIndex] > 0 && Commands[mCurrentCommandIndex] <= 45)
        {
            //TODO all the possible commands!
            pFish.DoRotation(1);
        }
        else if (Commands[mCurrentCommandIndex] > 45 && Commands[mCurrentCommandIndex] <= 90)
        {
            pFish.DoRotation(2);
        }
        else if (Commands[mCurrentCommandIndex] > 90 && Commands[mCurrentCommandIndex] <= 135)
        {
            pFish.DoRotation(3);
        }
        else if (Commands[mCurrentCommandIndex] > 135 && Commands[mCurrentCommandIndex] <= 180)
        {
            pFish.DoRotation(4);
        }
        else if (Commands[mCurrentCommandIndex] > 180 && Commands[mCurrentCommandIndex] <= 225)
        {
            pFish.DoRotation(5);
        }
        else if (Commands[mCurrentCommandIndex] > 225& Commands[mCurrentCommandIndex] <= 270)
        {
            pFish.DoRotation(6);
        }
        else if (Commands[mCurrentCommandIndex] > 270 && Commands[mCurrentCommandIndex] <= 315)
        {
            pFish.DoRotation(7);
        }
        else if (Commands[mCurrentCommandIndex] > 315 && Commands[mCurrentCommandIndex] <= 360)
        {
            pFish.DoRotation(8);
        }

    }
}

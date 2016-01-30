using UnityEngine;
using System.Collections;

public class FishEvent : MonoBehaviour
{

    private SchoolController mSchoolController;
    public SchoolEvent SchoolAction = SchoolEvent.UP;

    /// <summary>
    /// This parameter will only be used when 
    /// </summary>

    public float SpeedDelta = 0.1f;

    public AudioSource audioSource;

    public enum SchoolEvent
    {
        STOP,
        SLOWDOWN,
        SPEEDUP,
        UP,
        DOWN,
        LOOP,
        DIAGONAL_UP,
        DIAGONAL_DOWN

    }

    // Use this for initialization
    void Start()
    {
        mSchoolController = GameObject.Find("SchoolController").GetComponent<SchoolController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D pCollider)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        Debug.Log("Event triggered! " + SchoolAction);
        switch (SchoolAction)
        {
            case SchoolEvent.STOP:
                mSchoolController.Stop();
                break;
            case SchoolEvent.SLOWDOWN:
            case SchoolEvent.SPEEDUP:
                mSchoolController.ChangeSpeed(SpeedDelta);
                break;
            case SchoolEvent.UP:
                mSchoolController.MoveDirection(90);
                break;
            case SchoolEvent.DOWN:
                mSchoolController.MoveDirection(-90);
                break;
            case SchoolEvent.LOOP:
                mSchoolController.Loop360();
                break;
            case SchoolEvent.DIAGONAL_UP:
                mSchoolController.MoveDirection(45);
                break;
            case SchoolEvent.DIAGONAL_DOWN:
                mSchoolController.MoveDirection(-45);
                break;
        }
    }

    void OnTriggerExit2D(Collider2D pCollider)
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
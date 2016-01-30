using UnityEngine;
using System.Collections;
using DG.Tweening;

/// <summary>
/// School fish
/// </summary>
public class Fish : MonoBehaviour {

    
    private float x, y;

    public float Speed = 2f;

    public float VelocityX
    {
        get { return x; }
        private set { }
    }

    public float VelocityY
    {
        get { return y; }
        private set { }
    }

    private ScenesManager mScenesManager;

    private Rigidbody2D rigidBody;
    void Start()
    {
        mScenesManager = GameObject.Find("ScenesManager").GetComponent<ScenesManager>();
        rigidBody = GetComponent<Rigidbody2D>();
        //StartCoroutine(MoveLeft());
    }
    //private IEnumerator MoveLeft()
    //{
    //    yield return new WaitForSeconds(2.5f);
    //    RotateL(true);
    //    yield return new WaitForSeconds(2.5f);
    //    RotateL(false);

    //}

    void Update()
    {
        if (mScenesManager.PlayingGame())
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
    }


    public void DoRotation(float pRotation)
    {

        transform.DORotate(Vector3.forward * pRotation, 2);
        
        
    }


}

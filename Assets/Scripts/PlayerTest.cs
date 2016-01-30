using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerTest : MonoBehaviour
{
    public Animator Anim;
    private Rigidbody2D rigidBody;
    private int numbe = 0;
    private int numbea = 0;
    private float x, y;
    public ParticleSystem particle;
    public int particlePerSecond = 75;

    public float Speed = 2f;

    public float SpeedOffset = 0.2f;

    private ScenesManager mScenesManager;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //x = 2f;
        StartCoroutine(updateAnim());
        mScenesManager = GameObject.Find("ScenesManager").GetComponent<ScenesManager>();
    }

    public IEnumerator updateAnim()
    {
        yield return new WaitForSeconds(2.0f);
        //Anim.speed = 1;

    }

    public void FixedUpdate()
    {
        if (mScenesManager.PlayingGame())
        {
            if (true)
            {
                transform.Translate(Vector3.right * Time.deltaTime * Speed);
            }
            if (Input.GetAxis("Horizontal") > 0)
                transform.Rotate(Vector3.forward * Time.deltaTime * 98);

            if (Input.GetAxis("Horizontal") < -0)
                transform.Rotate(Vector3.forward * Time.deltaTime * -98);

            if (Input.GetAxis("Vertical") > 0)
            {
                if (Speed < 0.8f)
                {
                    Speed += SpeedOffset;
                }
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                if (Speed > 0)
                {
                    Speed -= SpeedOffset;
                }
            }
        }

        //rigidBody.velocity = new Vector2(hello,hello);

    }
}

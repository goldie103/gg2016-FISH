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
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //x = 2f;
        StartCoroutine(updateAnim());

    }

    public IEnumerator updateAnim()
    {
        yield return new WaitForSeconds(2.0f);
        Anim.speed = 3;

    }

    public void FixedUpdate()
    {
        if (true)
        {
            //rigidBody.velocity = new Vector2(x,y);
        }
        if (Input.GetAxis("Horizontal")>0)
            transform.Rotate(Vector3.forward* Time.deltaTime * 98);

        if (Input.GetAxis("Horizontal") < -0)
            transform.Rotate(Vector3.forward * Time.deltaTime * -98);

        transform.Translate(Vector3.right * Time.deltaTime * 10);

        //rigidBody.velocity = new Vector2(hello,hello);

    }
}

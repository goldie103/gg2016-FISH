using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FishAnimaion : MonoBehaviour
{

    public Transform p1, p2;
    public float Speed;
    public Ease EaseType;
    public void Awake()
    {
        transform.localPosition = p1.localPosition;
    }

    // Use this for initialization
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(transform.DOLocalMove(p2.localPosition, Speed)).SetEase(EaseType);
        mySequence.Append(transform.DOLocalMove(p1.localPosition, Speed)).SetEase(EaseType);
        //mySequence.Append(transform.DOLocalMove(p1.localPosition, 1f));


        mySequence.Play().SetLoops(-1,LoopType.Restart);
        //transform.DOLocalMoveY(p2.localPosition.y, 1f).SetLoops(-1,LoopType.Yoyo);
    }

   
}

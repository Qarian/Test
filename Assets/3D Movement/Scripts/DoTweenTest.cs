using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoTweenTest : MonoBehaviour
{
    [SerializeField] private Transform player;

    //[SerializeField] private AnimationCurve curve;
    

    private void Start()
    {
        var t =DOTween.To(Pos, v => player.position = v, Vector3.forward * 10, 4).OnComplete(EndOfAnimation);
    }

    private void EndOfAnimation()
    {
        Debug.Log("koniec");
    }

    private Vector3 Pos()
    {
        return player.position;
    }
}

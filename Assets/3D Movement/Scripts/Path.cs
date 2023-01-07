using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> targets;

    [SerializeField] private float speed = 1f;
    [SerializeField] private PathOption pathOption;

    private int currentTarget = 0;

    private bool moveInReverse = false;
    private bool canMove = true;

    private void Update()
    {
        if (!canMove) return;
        
        Vector3 distance = targets[currentTarget].position - player.position;
        player.Translate(distance.normalized * speed * Time.deltaTime, Space.World);
        if (distance.magnitude < 0.3f) NextTarget();
    }

    private void NextTarget()
    {
        switch (pathOption)
        {
            case PathOption.Stop:
                currentTarget++;
                if (currentTarget == targets.Count)
                    canMove = false;
                break;
            case PathOption.Reverse:
                if (moveInReverse)
                {
                    currentTarget--;
                    if (currentTarget == -1)
                    {
                        moveInReverse = false;
                        currentTarget = 1;
                    } 
                }
                else
                {
                    currentTarget++;
                    if (currentTarget == targets.Count)
                    {
                        moveInReverse = true;
                        currentTarget = targets.Count - 2;
                    }
                }
                break;
            case PathOption.Restart:
                currentTarget++;
                if (currentTarget == targets.Count)
                    currentTarget = 0;
                break;
        }
        
        Vector3 distance = targets[currentTarget].position - player.position;
        player.DORotateQuaternion(quaternion.LookRotation(distance, Vector3.up), 1f);
    }
}

public enum PathOption
{
    Stop,
    Reverse,
    Restart,
}

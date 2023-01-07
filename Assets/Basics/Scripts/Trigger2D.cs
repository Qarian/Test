using System;
using UnityEngine;

public class Trigger2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
    }
}

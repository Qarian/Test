using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        Vector3 input = new Vector3(
            Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            0,
            Input.GetAxis("Vertical") * speed * Time.deltaTime);

        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        transform.Translate(vertical * transform.right, Space.World);
        transform.Translate( horizontal * transform.forward, Space.World);
    }
}

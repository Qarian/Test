using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Test : MonoBehaviour
{
    public string tekst = "Hello";

    public float velocity = 5.5f;
    public float multiply = 1.25f;
    public float jumpForce = 10f;

    public new Rigidbody2D rigidbody;

    private Vector2 movement = Vector2.zero;
    private bool jump = false;

    private void Start()
    {
        Debug.Log(tekst);
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveObjectRigidbody();
        ScaleObject();
    }

    private void FixedUpdate()
    {
        movement *= velocity;
        // MovePosition
        /*Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        rigidbody.MovePosition(pos + movement);*/

        rigidbody.AddForce(movement, ForceMode2D.Force);

        if (jump)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void MoveObjectRigidbody()
    {
        movement.x = Input.GetAxis("Horizontal");
        //movement.y = Input.GetAxis("Vertical");

        if (!jump)
        {
            jump = Input.GetKeyDown(KeyCode.Space);
        }
    }

    private void MoveObjectTransform()
    {
        Vector2 movement = Vector2.zero;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        //horizontal = horizontal * Time.deltaTime * velocity;
        movement *= Time.deltaTime * velocity;
        transform.Translate(movement, Space.World);
    }

    private void ScaleObject()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.localScale *= multiply;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.localScale /= multiply;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //collision.rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

}

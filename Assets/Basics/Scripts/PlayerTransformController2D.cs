using UnityEngine;

public class PlayerTransformController2D : MonoBehaviour
{
    public float velocity = 5.5f;
    public float multiply = 1.25f;
    public float jumpForce = 10f;

    private void Update()
    {
        MoveObjectUsingTransform();
        ScaleObject();
    }

    private void MoveObjectUsingTransform()
    {
        Vector2 movement = Vector2.zero;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        // Time.deltaTime is required so player character will have the speed in 30FPS and 240FPS
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
}

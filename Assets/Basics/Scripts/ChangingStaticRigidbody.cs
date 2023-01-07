using UnityEngine;

// Ensures that game object with this component will also have physics component
// as otherwise it wouldn't do anything
[RequireComponent(typeof(Rigidbody2D))]
public class ChangingStatic : MonoBehaviour
{
    // Triggered when collides with others
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.rigidbody.gameObject.name);
        collision.rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlappyBirdController : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 10f;
    private bool jumpInput = false;
    
    private new Rigidbody2D rigidbody;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        // Przypisywanie funkcji OnDeath, żeby wywołała się gdy OnGameOver zostanie wywołane
        ActionManager.OnGameOver += OnDeath;

        ActionManager.OnGameStart += StartGame;
        rigidbody.simulated = false;
    }

    private void OnDestroy()
    {
        ActionManager.OnGameOver -= OnDeath;
        ActionManager.OnGameStart -= StartGame;
    }

    private void StartGame()
    {
        rigidbody.simulated = true;
        enabled = true;
    }

    private void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayerUsingPhysics();
    }

    private void MovePlayerUsingPhysics()
    {
        if (jumpInput)
        {
            jumpInput = false;

            Vector2 velocity = rigidbody.velocity;
            velocity.y = jumpSpeed;
            rigidbody.velocity = velocity;
        }
    }

    private void GetPlayerInput()
    {
        if (!jumpInput)
        {
            jumpInput = Input.GetKeyDown(KeyCode.Space);
        }
    }

    private void OnDeath()
    {
        // Robi to samo co odznaczenie kwadratu koło komponentu (nie całego obiektu)
        // Update i Fixed Update nie będą wywołane póki enabled jest ustawione na false
        enabled = false;
        
        //Jeżeli chcemy raczej usunąć komponent całkowicie można użyć funkcji Destroy
        //Destroy(this);
    }
    
    
}


















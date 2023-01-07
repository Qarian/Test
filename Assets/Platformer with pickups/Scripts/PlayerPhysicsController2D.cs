using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysicsController2D : MonoBehaviour
{
    [SerializeField] private float velocity = 50f;
    [SerializeField] private float jumpForce = 10f;

    private new Rigidbody2D rigidbody;

    private float horizontalInput;
    private bool jumpInput = false;
    private bool ground = false;
    
    private int money;

    private void Start()
    {
        if (rigidbody == null)
            rigidbody = GetComponent<Rigidbody2D>();
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
        // Time.fixedDeltaTime ensures that player character will move the same speed
        // when fixed timestep will be changed in project settings
        // But unlike Time.deltaTime in Update it can be ommited
        float horizontalMovement = horizontalInput * velocity * Time.fixedDeltaTime;

        // AddForce requires Vector2 so we have to create one
        Vector2 movement = new Vector2(horizontalMovement, 0);
        rigidbody.AddForce(movement, ForceMode2D.Force);

        if (jumpInput)
        {
            jumpInput = false;
            if (ground)
            {
                rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        
        ground = false;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        // Małe oszukiwanie - nie tyle sprawdzamy czy gracz dotyka ziemi co czy dotyka czegokolwiek - w tym ścian i sufitu
        ground = true;
    }

    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (!jumpInput)
        {
            jumpInput = Input.GetKeyDown(KeyCode.Space);
        }
    }

    public void ChangeMoney(int moneyChange)
    {
        money += moneyChange;
        UIMoney.Instance.DisplayMoney(money);
      //^       ^        ^
      //Klasa   |        |  
      // Instancja klasy |
      //              Funkcja już na konretnej instancji (nie statyczna)
    }

}

using UnityEngine;

public class ObstackleCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Kolizja powiadamia odpowiedni system o przegranej i nie robi nic więcej
        // Dzięki temu nie musimy pisać logiki w skrypcie przeszkody
        ActionManager.GameOver();
    }
}

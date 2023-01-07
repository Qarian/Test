using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerPhysicsController2D player = col.GetComponent<PlayerPhysicsController2D>();
        // Dalsza część kodu zakłada, że udało się zdobyć komponent gracza, bo w naszym wypadku tylko gracz się porusza
        // Jeżeli nie mamy 100% gwarancji że tylko jedna rzecz może wejść w kolizję trzeba użyć if by jakoś sobie z tym poradzić
        // Poniższa linijka zatrzymuje działanie tej funkcji jeżeli wejdzie w kolizję z czymś co nie jest graczem
        if (player == null) return;
        
        player.ChangeMoney(1);

        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}

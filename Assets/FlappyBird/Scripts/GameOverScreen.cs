using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointsText;

    private void Awake()
    {
        ActionManager.OnGameOver += OnGameOver;
        
        gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        gameObject.SetActive(true);
        pointsText.text = PointsMangers.Points.ToString();
    }
}

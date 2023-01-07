using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PointsMangers : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private int points = 0;

    public static PointsMangers instance;

    public static int Points => instance.points;

    private void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();

        instance = this;

        textComponent.text = points.ToString();
    }
    
    public void AddPoints(int pointAmount = 1)
    {
        points += pointAmount;
        textComponent.text = points.ToString();
    }
}

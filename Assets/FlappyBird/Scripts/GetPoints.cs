using UnityEngine;

public class GetPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        //col.GetComponent<FlappyBirdController>()
        PointsMangers.instance.AddPoints();
    }
}

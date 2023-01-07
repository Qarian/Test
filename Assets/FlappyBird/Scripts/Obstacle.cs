using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleManager manager;
    
    private void OnBecameInvisible()
    {
        manager.MoveObstacle(this);
    }
}

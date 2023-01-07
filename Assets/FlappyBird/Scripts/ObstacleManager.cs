using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float distance = 3;
    public float maxHeightDifference = 3;
    public int initialObstacles = 5;
    
    public float speed = -4;
    public Obstacle obstackle;

    private int obstaclesCounter = 0;

    private void Start()
    {
        ActionManager.OnGameOver += DisableComponent;
        ActionManager.OnGameStart += StartSpawning;

        enabled = false;
    }

    private void StartSpawning()
    {
        enabled = true;
        // Pętli for używa się do zrobienia czegoś X razy
        // Tutaj wywołuje funkcję 'CreateObstacle' 'initialObstacles' razy
        for (int i = 0; i < initialObstacles; i++)
        {
            CreateObstacle();
        }
    }

    private void CreateObstacle()
    {
        Vector3 position = transform.position;
        position.x += obstaclesCounter * distance;
        position.y += Random.Range(-maxHeightDifference, maxHeightDifference);
        Obstacle obstacle = Instantiate(obstackle, position, Quaternion.identity, transform);
        obstacle.manager = this;
        obstaclesCounter++;
    }

    public void MoveObstacle(Obstacle obstacle)
    {
        Vector3 postion = obstacle.transform.position;
        postion.x = obstaclesCounter * distance;
        obstacle.transform.position = postion;
        obstaclesCounter++;
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
    }

    private void DisableComponent()
    {
        //Więcej o tym w skrypcie FlappyBirdController
        enabled = false;
        //Destroy(this);
    }
}

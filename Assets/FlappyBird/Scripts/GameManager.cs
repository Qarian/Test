using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // [SerializeField]
    // private Button button;
    //
    // private void Awake()
    // {
    //     button.onClick.AddListener(ResetGame);
    // }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}

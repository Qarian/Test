using UnityEngine;

public class DisplayingMessage : MonoBehaviour
{
    // public keyword makes this available visible in inspector
    public string messageBeforeFirstFrame;
    public string messageEveryFrame;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(messageBeforeFirstFrame);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(messageEveryFrame);
    }
}

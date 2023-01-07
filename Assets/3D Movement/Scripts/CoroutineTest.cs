using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(4f);
        Debug.Log("End");
    }
}

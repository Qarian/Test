using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    public List<FlappyBirdController> skinsList;
    
    [SerializeField]
    private FlappyBirdController player;
    
    [SerializeField]
    private TMP_Dropdown dropdown;

    private void Awake()
    {
        TMP_Dropdown.OptionData[] datas = new TMP_Dropdown.OptionData[skinsList.Count];
        for (int i = 0; i < skinsList.Count; i++)
        {
            datas[i] = new TMP_Dropdown.OptionData(skinsList[i].name);
        }
        
        dropdown.options = datas.ToList();
        dropdown.onValueChanged.AddListener(SetPlayer);
    }

    public void StartGame()
    {
        ActionManager.GameStart();
        gameObject.SetActive(false);
    }

    private void SetPlayer(int value)
    {
        Vector3 position = player.transform.position;
        Destroy(player.gameObject);
        player = Instantiate(skinsList[value], position, Quaternion.identity);
        //player = Instantiate(skinsArray[value], position, Quaternion.identity);
    }
}

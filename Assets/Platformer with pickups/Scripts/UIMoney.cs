using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class UIMoney : MonoBehaviour
{
    // Singleton
    // Inne skrypty mogęą użyć tej zmiennej żeby mieć dostęp do instancji (obiektu na scenie)
    public static UIMoney Instance;

    private TMP_Text textComponent;

    // Statyczną referencję trzeba ustawić zanim jakikolwiek inny skrypt będzie chciał z niej korzystać
    // Awake wywołuje się zawsze przed Start
    private void Awake()
    {
        Instance = this;
        textComponent = GetComponent<TMP_Text>();
        
    }

    public void DisplayMoney(int money)
    {
        Debug.Log(money);
        textComponent.text = $"Money: {money}"; //"Money: " + money
    }
}

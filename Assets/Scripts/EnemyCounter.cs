using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    static TextMeshProUGUI txt;

    public static void UpdateCounter()
    {
        if (GameManager.enemies / 2 == 1)
        {
            txt.text = "Enemy left : " + GameManager.enemies / 2;
        }
        else
        {
            txt.text = "Enemies left : " + GameManager.enemies / 2;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        UpdateCounter();
    }

    public static void ResetCounter()
    {
        GameManager.enemies = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD_Script : MonoBehaviour
{
    public GameObject enemyHUD;

    private GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        popUp = Instantiate(enemyHUD) as GameObject;
        HideHUD();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowEnemyData(string name, float life, float maxlife, string level)
    {
        

        popUp.GetComponent<CanvasGroup>().alpha = 1;
        Slider slider = popUp.GetComponentInChildren<Slider>();
        slider.maxValue = maxlife;
        slider.value = life;
        popUp.GetComponentInChildren<Text>().text = name + "   Lv: " + level;
    }

    public void HideHUD()
    {
        popUp.GetComponent<CanvasGroup>().alpha = 0;
    }
}

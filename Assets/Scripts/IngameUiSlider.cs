using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting;
using TMPro;

public class IngameUiSlider : MonoBehaviour
{
    // Start is called before the first frame update
    Slider slider;
    GameObject player;
    Statbloc statbloc;
    public TextMeshProUGUI healthtext;
    GameObject deathscreen;
    RawImage diededscreenimage;
    Image[] diedimage;
    Text[] diedtext;
    TextMeshProUGUI youdiedtext;
    Button[] diedbutton;
    public TextMeshProUGUI scoretext;

    void Start()
    {
        slider = GetComponent<Slider>();
        player = GameObject.Find("Player");
        statbloc = player.GetComponent<Statbloc>();
        deathscreen = GameObject.Find("Dieded");
        diededscreenimage = deathscreen.GetComponentInChildren<RawImage>();
        diedimage = deathscreen.GetComponentsInChildren<Image>();
        diedtext = deathscreen.GetComponentsInChildren<Text>();
        youdiedtext = deathscreen.GetComponentInChildren<TextMeshProUGUI>();
        diedbutton = deathscreen.GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = statbloc.maxhealth;
        slider.value = statbloc.health;
        if (slider.value <= 0)
        {
            slider.value = statbloc.maxhealth;
            statbloc.health = statbloc.maxhealth;
            if (statbloc.respawn > 0)
            {
                statbloc.respawn--;
                Died();
            }
            else
            {
                GameManager.instance.gameState = GameManager.GameState.Dieded;
                diededscreenimage.enabled = true;
                for (int i = 0; i < diedimage.Length; i++)
                {
                    diedimage[i].enabled = true;
                }
                for (int j = 0; j < diedtext.Length; j++)
                {
                    diedtext[j].enabled = true;
                }
                youdiedtext.enabled = true;
                for (int g = 0; g < diedbutton.Length; g++)
                {
                    diedbutton[g].enabled = true;
                }
            }

        }
        scoretext.text = $"Score: {statbloc.money}";
    }
    void Died()
    {
        healthtext.text = $"{statbloc.respawn} X";
    }
}
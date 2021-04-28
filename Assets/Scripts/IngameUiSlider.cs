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
    TextMeshProUGUI healthtext;
    GameObject deathscreen;
    GameObject subui;
    RawImage diededscreenimage;

    void Start()
    {
        slider = GetComponent<Slider>();
        player = GameObject.Find("Player");
        statbloc = player.GetComponent<Statbloc>();
        healthtext = GetComponentInChildren<TextMeshProUGUI>();
        deathscreen = GameObject.Find("Dieded");
        diededscreenimage = deathscreen.GetComponentInChildren<RawImage>();

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
            }

        }
    }
    void Died()
    {
        healthtext.text = $"{statbloc.respawn} X";
    }
}
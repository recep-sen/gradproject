using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IngameUiSlider : MonoBehaviour
{
    Slider slider;
    GameObject player;
    Statbloc statbloc;
    public TextMeshProUGUI healthtext;
    public GameObject deathscreen;
    public TextMeshProUGUI scoretext;
    void Start()
    {
        slider = GetComponent<Slider>();
        player = GameObject.Find("Player");                                 //references
        statbloc = player.GetComponent<Statbloc>();
    }
    void Update()
    {
        slider.maxValue = statbloc.maxhealth;
        slider.value = statbloc.health;                                         //updating in-game ui
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
                deathscreen.SetActive(true);
            }
        }
        scoretext.text = $"Score: {statbloc.money}";
    }
    void Died()                                                             //setting the respawn count right
    {
        healthtext.text = $"{statbloc.respawn} X";
    }
}
using UnityEngine;
using TMPro;
public class scorecalculator : MonoBehaviour
{
    public GameObject player;
    Statbloc statbloc;
    TextMeshProUGUI text;
    private void Start()
    {
        statbloc = player.GetComponent<Statbloc>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {                                                                   //score calculator for ui
        text.text = $"SCORE: {statbloc.money}";
    }
}
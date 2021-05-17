using UnityEngine;
using TMPro;
public class scoremultiplierupdater : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void FixedUpdate()                              //score multiplier calculator
    {
        text.text = $"SCORE MULTIPLIER: {GameManager.instance.scoremltp}";
    }
}
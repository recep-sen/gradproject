using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoremultiplierupdater : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void FixedUpdate()
    {
        text.text = $"SCORE MULTIPLIER: {GameManager.instance.scoremltp}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class menusliders : MonoBehaviour
{
    public GameObject text;
    public void slider1()
    {
        GameManager.instance.chests = gameObject.GetComponent<Slider>().value;
        text.GetComponent<TextMeshProUGUI>().text = $"CHESTS: {GameManager.instance.chests}";
    }
    public void slider2()
    {
        GameManager.instance.enemies = gameObject.GetComponent<Slider>().value;
        text.GetComponent<TextMeshProUGUI>().text = $"ENEMIES: {GameManager.instance.enemies}";
    }
    public void slider3()
    {
        GameManager.instance.trap = gameObject.GetComponent<Slider>().value;
        text.GetComponent<TextMeshProUGUI>().text = $"TRAPS: {GameManager.instance.trap}";
    }
    public void slider4()
    {
        GameManager.instance.respawn = gameObject.GetComponent<Slider>().value;
        text.GetComponent<TextMeshProUGUI>().text = $"RESPAWN: {GameManager.instance.respawn}";
    }
}
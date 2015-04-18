using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public Slider Slider;

    public void Awake()
    {
        PlayerHealth = FindObjectOfType<PlayerHealth>();
        Slider = GetComponent<Slider>();
    }

    public void FixedUpdate()
    {
        if (PlayerHealth)
        {
            Slider.value = (float)PlayerHealth.Health / PlayerHealth.MaxHealth;
        }
        else
        {
            Slider.value = 0;
        }
    }
}

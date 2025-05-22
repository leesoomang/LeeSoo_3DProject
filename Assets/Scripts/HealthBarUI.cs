using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;

    void OnEnable()
    {
        HealthSystem.OnHealthChanged += UpdateHealthBar;
    }

    void OnDisable()
    {
        HealthSystem.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float current, float max)
    {
        healthSlider.value = current / max;
    }
}

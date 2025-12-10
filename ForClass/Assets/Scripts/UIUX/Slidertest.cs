using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class Slidertest : MonoBehaviour
{
    public void ShowValueofSlider(float value)
    {
        GetComponentInChildren<TextMeshProUGUI>().text=value.ToString("0");
    }
}

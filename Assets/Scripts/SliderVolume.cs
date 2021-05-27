using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    private Slider slider;
    private VolumeController volumeController;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { UpdateVolume(); });

        volumeController = FindObjectOfType<VolumeController>();

        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = volumeController.GetVolume();
    }

    private void UpdateVolume()
    {
        volumeController.SetVolume(slider.value);
    }
}

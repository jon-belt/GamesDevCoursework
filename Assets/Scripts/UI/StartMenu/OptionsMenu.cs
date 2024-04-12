using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sensitivitySlider;

    private float mouseSensitivity;

    private void Start()
    {
        //load saved settings or default values
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.5f);
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 0.5f);

        sensitivitySlider.value = PlayerPrefs.GetFloat("mouseSensitivity", 0.5f);
        float savedSensitivity = PlayerPrefs.GetFloat("mouseSensitivity", 0.5f);
    }

    public void OnVolumeChange()
    {
        float volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volume);     //saves to prefs
        AudioListener.volume = volume;
    }

    public void OnSensitivityChange()
    {
        mouseSensitivity = sensitivitySlider.value;
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity);
        // Now, wherever you handle mouse movement in your game, you would use the mouseSensitivity variable to scale the input.
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
}

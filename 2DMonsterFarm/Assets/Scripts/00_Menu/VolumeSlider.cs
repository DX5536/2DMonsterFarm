using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;


    private void Start()
    {
        // save volume to playerprefs
        if (!PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume",1);
            Load();
        }
        else
        {
            Load();
        }
    }


    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MasterVolume", volumeSlider.value);
    }


}

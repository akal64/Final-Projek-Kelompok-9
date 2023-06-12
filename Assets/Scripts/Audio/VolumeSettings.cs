using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public static VolumeSettings instance;
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] public AudioSource bgm;

    private void Awake() {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
            bgm.Play();

        }
    }
    private void Start() {
        if (PlayerPrefs.HasKey("BGMVolume"))
            LoadVolume();

        setMasterVolume();
        setBGMVolume();
        setSFXVolume();

    }

    public void setMasterVolume() {
        float volume = masterSlider.value;
        Mixer.SetFloat("MASTER", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void setBGMVolume() {
        float volume = BGMSlider.value;
        Mixer.SetFloat("BGM", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void setSFXVolume() {
        float volume = SFXSlider.value;
        Mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume() {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        setMasterVolume();
        setBGMVolume();
        setSFXVolume();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [Header("UI Elements")]
    public Slider volumeSlider;
    public Button muteButton;
    public Sprite muteIcon;
    public Sprite unmuteIcon;

    [Header("Audio")]
    public AudioSource backgroundMusic;

    private bool isMuted = false;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Load saved settings
        isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        float volume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        volumeSlider.value = volume;
        backgroundMusic.volume = isMuted ? 0 : volume;

        UpdateMuteButtonIcon();

        // Add listeners
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        muteButton.onClick.AddListener(ToggleMute);
    }

    private void OnVolumeChanged(float value)
    {
        if (!isMuted)
            backgroundMusic.volume = value;

        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;
        backgroundMusic.volume = isMuted ? 0 : volumeSlider.value;

        PlayerPrefs.SetInt("MusicMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        UpdateMuteButtonIcon();
    }

    private void UpdateMuteButtonIcon()
    {
        if (muteButton != null && muteButton.image != null)
        {
            muteButton.image.sprite = isMuted ? muteIcon : unmuteIcon;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class ToggleSound : MonoBehaviour
{
    private Button _volumeButton;
    private Image _volumeImage;

    [SerializeField] private Sprite[] _volumeImages;

    void HandleToggleSound()
    {
        bool soundEnabled = AudioListener.volume == 1;
        AudioListener.volume = soundEnabled ? 0f : 1f;
        SwitchVolumeSprite(!soundEnabled);
    }

    void Awake()
    {
        Transform childImage = transform.Find("Image");
        if (childImage != null)
        {
            _volumeImage = childImage.GetComponent<Image>();
        }
        _volumeButton = GetComponent<Button>();

        if (_volumeImage != null && _volumeImages.Length == 2)
        {
            SwitchVolumeSprite(AudioListener.volume == 1);
        }

        if (_volumeButton != null)
        {
            _volumeButton.onClick.AddListener(HandleToggleSound);
        }

    }

    void SwitchVolumeSprite(bool soundEnabled)
    {
        if (soundEnabled)
        {
            _volumeImage.sprite = _volumeImages[0];
        }
        else
        {
            _volumeImage.sprite = _volumeImages[1];
        }
    }
}

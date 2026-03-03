using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;
    public Sprite SelectedPlayerSprite { get; private set; }
    public RuntimeAnimatorController SelectedAnimatorController { get; private set; }

    void Awake()
    {
        Application.targetFrameRate = 60;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerSprite(Sprite player)
    {
        SelectedPlayerSprite = player;
    }

    public void SetPlayerAnimator(RuntimeAnimatorController controller)
    {
        SelectedAnimatorController = controller;
    }
}

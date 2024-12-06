using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerManager PlayerManager;
    public UIManager UIManager;
    public CameraController CameraController;

    private void Awake()
    {
        Instance = this;

        CameraController.Initialize(PlayerManager.transform);
    }
}

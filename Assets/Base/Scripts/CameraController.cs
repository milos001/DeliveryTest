using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _playerTs;

    private bool _initialized;

    public void Initialize(Transform playerTs)
    {
        _playerTs = playerTs;

        _initialized = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!_initialized)
            return;

        Vector3 position = _playerTs.position;
        position.y += 10;
        transform.position = position;
    }
}

using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _playerRb;

    private Vector3 _steerDirection, _gasDirection;

    private float _accelerationRate = 10f;
    private int _currentRpm = 1000, _currentGear = 1;

    private bool _clutchPressed;

    // Update is called once per frame
    void Update()
    {
        _clutchPressed = Input.GetKey(KeyCode.Space);

        GetSteerDirection();
        CheckForGearChange();

        if (_clutchPressed)
            return;

        CheckForAcceleration();
    }

    private void GetSteerDirection()
    {
        if (Input.GetKey(KeyCode.W))
            _gasDirection = transform.forward;
        else if (Input.GetKey(KeyCode.S))
            _gasDirection = -transform.forward;
        else
            _gasDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            _steerDirection = -transform.right;
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _steerDirection = transform.right;
            return;
        }

        _steerDirection = Vector3.zero;
    }

    private void CheckForGearChange()
    {
        if (!_clutchPressed)
            return;

        if (Input.GetKeyDown(KeyCode.UpArrow) && _currentGear < 5)
        {
            _currentGear++;
            GameManager.Instance.UIManager.UpdateGear(_currentGear);
        }


        if (Input.GetKeyDown(KeyCode.DownArrow) && _currentGear > 1)
        {
            _currentGear--;
            GameManager.Instance.UIManager.UpdateGear(_currentGear);
        }
    }

    private void CheckForAcceleration()
    {
        if (_gasDirection.magnitude > .1f || _gasDirection.magnitude < -.1f)
        {
            _playerRb.AddForce((_gasDirection + _steerDirection) * GetAccelerationRate(), ForceMode.Acceleration);
            transform.forward = transform.forward + (_steerDirection * .01f);
            _currentRpm += 1500 / _currentRpm;
        }
        else if (_currentRpm > 800)
            _currentRpm--;

        GameManager.Instance.UIManager.UpdateRPM(_currentRpm);
    }

    private float GetAccelerationRate()
    {
        return _accelerationRate * (1500f / _currentRpm);
    }
}

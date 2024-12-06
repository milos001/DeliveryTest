using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _speedText, _rpmText, _gearText;

    public void UpdateSpeed(float speed)
    {
        _speedText.text = speed.ToString();
    }

    public void UpdateRPM(float rpm)
    {
        _rpmText.text = "rpm : " + rpm;
    }

    public void UpdateGear(int gear)
    {
        _gearText.text = "gear : " + gear;
    }
}

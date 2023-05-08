using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelection : MonoBehaviour
{
    public static ModeSelection instance;

    [SerializeField] private Toggle VisualToggle, TimedToggle;

    public bool VisualMode => _visualMode;
    public bool TimedMode => _timedMode;

    private bool _visualMode;
    private bool _timedMode;

    private void Awake()
    {
        instance = this;

        SetTimedMode(TimedToggle.isOn);
        SetVisualMode(VisualToggle.isOn);
    }

    public void SetVisualMode(bool value)
    {
        _visualMode = value;
        VisualSettings.instance.ViewVisualSettings(value);
    }

    public void SetTimedMode(bool value)
    {
        _timedMode = value;
        TimerSettings.instance.ViewTimerSettings(value);
    }
}

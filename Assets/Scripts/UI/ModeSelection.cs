using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour
{
    public static ModeSelection instance;

    public bool VisualMode => visualMode;
    public bool TimedMode => _timedMode;

    private bool visualMode;
    private bool _timedMode;

    private void Awake()
    {
        instance = this;    
    }

    public void SetVisualMode(bool value)
    {
        visualMode = value;
    }

    public void SetTimedMode(bool value)
    {
        _timedMode = value;
    }
}

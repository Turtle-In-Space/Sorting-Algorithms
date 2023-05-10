using UnityEngine;
using TMPro;

public class VisualSettings : MonoBehaviour
{
    public static VisualSettings instance;

    public int TimeStep => _timeStep;

    [SerializeField] private TMP_InputField timeStepInput;

    private Animator animator;

    private const int MAX_TIME_STEP = 1000;
    private const int MIN_TIME_STEP = 0;

    private int _timeStep = 200;


    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public void SetTimeStep(string value)
    {
        if (int.TryParse(value, out _timeStep))
        {
            if (_timeStep > MAX_TIME_STEP)
            {
                timeStepInput.text = MAX_TIME_STEP.ToString();
                _timeStep = MAX_TIME_STEP;
            }
            else if (_timeStep < MIN_TIME_STEP)
            {
                timeStepInput.text = MIN_TIME_STEP.ToString();
                _timeStep = MIN_TIME_STEP;
            }
        }

        else
        {
            timeStepInput.text = _timeStep.ToString();
        }
    }

    public void ViewVisualSettings(bool value)
    {
        animator.SetBool("isShowing", value);
    }
}
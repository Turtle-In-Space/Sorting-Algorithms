using UnityEngine;
using TMPro;

public class VisualSettings : MonoBehaviour
{
    public static VisualSettings instance;

    public float TimeStep => _timeStep;

    [SerializeField] private TMP_InputField timeStepInput;

    private Animator animator;

    private const float MAX_TIME_STEP = 2f;
    private const float MIN_TIME_STEP = 0.01f;

    private float _timeStep = MIN_TIME_STEP;


    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public void SetTimeStep(string value)
    {
        if (float.TryParse(value, out _timeStep))
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
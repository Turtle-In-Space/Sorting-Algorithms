using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSettings : MonoBehaviour
{
    public static TimerSettings instance;

    public int Iterations => _iterations;

    [SerializeField] private TMP_InputField iterationsInput;
    [SerializeField] private TMP_Text sortTime;

    private Animator animator;

    private const int MAX_ITERATIONS_COUNT = 10000;
    private const int MIN_ITERATIONS_COUNT = 1;

    private int _iterations = MIN_ITERATIONS_COUNT;


    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public void DisplayResult(double time)
    {
        time *= 1000 / Iterations;
        sortTime.text = time.ToString("F3");
    }

    public void SetIterations(string value)
    {        
        if (int.TryParse(value, out _iterations))
        {
            if (_iterations > MAX_ITERATIONS_COUNT)
            {
                iterationsInput.text = MAX_ITERATIONS_COUNT.ToString();
                _iterations = MAX_ITERATIONS_COUNT;
            }
            else if (_iterations < MIN_ITERATIONS_COUNT)
            {
                iterationsInput.text = MIN_ITERATIONS_COUNT.ToString();
                _iterations = MIN_ITERATIONS_COUNT;
            }
        }

        else
        {
            iterationsInput.text = _iterations.ToString();
        }
    }

    public void ViewTimerSettings(bool value)
    {
        if (value)
        {
            DisplayResult(0);
            animator.SetTrigger("Show");
        }
        else
        {
            animator.SetTrigger("Hide");
        }
        
    }
}
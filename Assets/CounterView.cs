using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private float _timeBetweenTicks = 0.5f;
    private float _currentTicks = 0;
    private bool isPaused = false;

    private void OnEnable()
    {
        _counter.Changed += ChangeActiveStatus;
    }

    private void OnDisable()
    {
        _counter.Changed -= ChangeActiveStatus;
    }

    private void ChangeActiveStatus()
    {
        isPaused = !isPaused;

        if (isPaused == false)
        {
            StartCoroutine(ChangeTime());
        }
    }

    private IEnumerator ChangeTime()
    {
        while (isPaused == false)
        {
            yield return new WaitForSeconds(_timeBetweenTicks);
            _currentTicks++;
            Debug.Log(_currentTicks);
            yield return null;
        }
    }

}

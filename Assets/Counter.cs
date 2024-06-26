using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _timeBetweenTicks = 0.5f;
    private bool _isPaused = false;

    public event Action Changed;

    public float CurrentTicks { get; private set; }

    private void Start()
    {
        CurrentTicks = 0;
    }

    private void OnMouseDown()
    {
        ChangeActiveStatus();
    }

    private void ChangeActiveStatus()
    {
        _isPaused = !_isPaused;

        if (_isPaused == false)
        {
            StartCoroutine(ChangeTime());
        }
    }

    private IEnumerator ChangeTime()
    {
        while (_isPaused == false)
        {
            yield return new WaitForSeconds(_timeBetweenTicks);
            CurrentTicks++;
            Changed?.Invoke();
        }
    }
}

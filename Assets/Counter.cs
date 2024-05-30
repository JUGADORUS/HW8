using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action Changed;
    public float _currentTicks = 0;
    private float _timeBetweenTicks = 0.5f;
    private bool isPaused = false;

    private void OnMouseDown()
    {
        ChangeActiveStatus();
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
            Changed?.Invoke();
        }
    }
}

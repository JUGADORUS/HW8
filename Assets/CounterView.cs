using System.Collections;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.Changed += ShowCount;
    }

    private void OnDisable()
    {
        _counter.Changed -= ShowCount;
    }

    private void ShowCount()
    {
        Debug.Log(_counter._currentTicks);
    }
}

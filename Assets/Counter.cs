using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action Changed;

    private void OnMouseDown()
    {
        Changed?.Invoke();
    }
}

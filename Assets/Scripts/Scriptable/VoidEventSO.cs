using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventSO/VoidEventSO")]
public class VoidEventSO : ScriptableObject
{
    public Action voidEvent;

    public void RaiseVoidEvent()
    {
        voidEvent?.Invoke();
    }
}

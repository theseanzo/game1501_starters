using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClickGameInput : MonoBehaviour
{
    public event Action LeftClick, RightClick;
    public event Action<Vector2> PositionChanged;

    private PointClickInput _pointClickInput;

    private void OnEnable()
    {
        if (_pointClickInput == null)
        {
            _pointClickInput = new PointClickInput();
            _pointClickInput.GameInput.LeftClick.performed += (val) => LeftClick?.Invoke();
            _pointClickInput.GameInput.RightClick.performed += (val) => RightClick?.Invoke();
            _pointClickInput.GameInput.MouseMove.performed +=
                (val) => PositionChanged?.Invoke(val.ReadValue<Vector2>());
        }
        _pointClickInput.Enable();
    }

    private void OnDisable()
    {
        _pointClickInput.Disable();
    }
}

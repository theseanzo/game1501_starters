using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.TankControl;
using UnityEngine;

namespace Code.Scripts.FixedControl
{
    public class FixedControlGameInput : MonoBehaviour
    {
        public event Action<Vector2> Movement;
        private FixedControlInput _fixedControlInput;
        private void OnEnable()
        {
            if (_fixedControlInput == null)
            {
                _fixedControlInput = new FixedControlInput();
                _fixedControlInput.PlayerControl.Movement.performed +=
                    (val) => Movement?.Invoke(val.ReadValue<Vector2>());
            }
            _fixedControlInput.Enable();
        }

        private void OnDisable()
        {
            _fixedControlInput.Disable();
        }
    }
}


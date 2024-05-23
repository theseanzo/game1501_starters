using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.FixedControl
{
    public interface IMouseControlListener
    {
        private void LeftClick(){
        }
        private void Rightclick(){}

        private void PositionChanged(Vector2 position)
        {
        }

    }
}

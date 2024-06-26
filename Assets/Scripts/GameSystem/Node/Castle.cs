using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Territory.GameSystem.Node
{
    public class Castle : NodeElement
    {
        [SerializeField]
        private int _protectionValue = 2;
        public override void ConquerNode(int value, int attackID)
        {

            if (_ownerID == attackID || _ownerID == -1)     // When we conquer free or move on owned node
            {
                AddValue(value);
                ChangeOwner(attackID);
            }
            else                                            // When we attack node
            {
                int newValue;
                if (value >= _value + _protectionValue)    //attack succed
                {
                    newValue = value - _value;
                    ChangeOwner(attackID);
                }
                else // attack failed
                {
                    newValue = _value - value;
                }
                UpdateValue(newValue);
            }
        }

        public override void UpdateDisplay()
        {
            base.UpdateDisplay();
            if (_ownerID == 0)
            {
                _renderer.sprite = _ArmiesSprite[PlayerColorEnum.Blue].CastleSprite;
            }
            else if (_ownerID == 1)
            {
                _renderer.sprite = _ArmiesSprite[PlayerColorEnum.Red].CastleSprite;
            }
        }
    }
}

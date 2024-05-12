using System.Collections;
using System.Collections.Generic;
using Territory.Events;
using UnityEngine;

namespace Territory.Animation
{
    [RequireComponent(typeof(GameEventListener))]
    public class PlayAnimationOnEvent : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        
        public bool IsActive { get; set; } = true;
        public void Play (string triggerName)
        {
            if (IsActive)
            {
                _animator.SetTrigger(triggerName);

            }
        }
    }
}

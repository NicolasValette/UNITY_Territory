using System.Collections;
using System.Collections.Generic;
using Territory.Events;
using TMPro;
using UnityEngine;

namespace Territory.Animation
{
    [RequireComponent(typeof(GameEventListener))]
    [RequireComponent(typeof(TMP_Text))]
    public class NewTurnAnimation : MonoBehaviour
    {
        private Animator _animator;
        private TMP_Text _text;
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _text = GetComponent<TMP_Text>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
       
        private void PlayAnimation()
        {
            _animator.SetTrigger("Play");
        }
        public void PlayPlayerAnimation()
        {
            _text.text = "New Player turn !";
            PlayAnimation();
        }
        public void PlayEnnemyAnimation()
        {
            _text.text = "New Ennemy turn !";
            PlayAnimation();
        }
        public void PlayGrowthAnimation()
        {
            _text.text = "Army growth !";
            PlayAnimation();
        }
    }
}

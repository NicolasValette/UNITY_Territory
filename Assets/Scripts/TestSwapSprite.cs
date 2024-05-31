using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory
{
    public class TestSwapSprite : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer;
        [SerializeField]
        private Sprite sprite1;
        [SerializeField]
        private Sprite sprite2;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void Sprite1()
        {
            _renderer.sprite = sprite1;
        }
        public void Sprite2()
        {
            _renderer.sprite = sprite2;
        }
    }
}

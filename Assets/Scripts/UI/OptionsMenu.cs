using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

namespace Territory.UI
{
    public class OptionsMenu : MonoBehaviour
    {
        [SerializeField]
        private Slider _AISlider;
        [SerializeField]
        private TMP_Text _AITimerText;
        [SerializeField]
        private Slider _volumeSlider;
        // Start is called before the first frame update
        void Start()
        {

            LoadAITimer();
            LoadVolume();
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SetSliderValue(float value)
        {
            _AISlider.value = value;
            _AITimerText.text = (Mathf.Floor(value * 100)/100).ToString();
        }
        public void SetSliderVolumeValue(float value)
        {
            _volumeSlider.value = value;
           
        }

        public void SaveAITimer()
        {
            PlayerPrefs.SetFloat("AITimer", _AISlider.value);
            PlayerPrefs.Save();
        }
        public void LoadAITimer()
        {
            float value = PlayerPrefs.GetFloat("AITimer", 2f);
            _AISlider.value = value;
            
            _AITimerText.text = (Mathf.Floor(_AISlider.value * 100) / 100).ToString();
        }
        public void SaveVolume()
        {
            PlayerPrefs.SetFloat("MasterVolume", _volumeSlider.value);
            PlayerPrefs.Save();
        }
        public void LoadVolume()
        {
            float value = PlayerPrefs.GetFloat("MasterVolume", 0f);
            _volumeSlider.value = value;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Territory.UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private float _waitingTime;
        [SerializeField]
        private Animator _transitionAnimator;
      
        public void LoadSceneByIndex(int buildIndexId)
        {
            StartCoroutine(LoadScene(buildIndexId));
        }

        private IEnumerator LoadScene(int buildIndexId)
        {
            _transitionAnimator.SetTrigger("Transition");
            yield return new WaitForSeconds(_waitingTime);
            SceneManager.LoadScene(buildIndexId);
        }
    }
}

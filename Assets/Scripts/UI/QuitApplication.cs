using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory.UI
{
    public class QuitApplication : MonoBehaviour
    {

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }

}

using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class UIEvents : MonoBehaviour
    {
        public delegate void UIHandler();

        public event UIHandler OnPauseMenuShow;

        public void CallPauseMenu()
        {
            if (OnPauseMenuShow != null)
                OnPauseMenuShow();
        }
        
    }
}
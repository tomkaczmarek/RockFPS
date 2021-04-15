using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class IUIManager : MonoBehaviour
    {
        public GameObject canvas;
        Events.UIEvents _events;
        
        public void OnEnable()
        {
            _events = GetComponent<Events.UIEvents>();
            _events.OnPauseMenuShow += _events_OnPauseMenuShow;
        }
        public void Start()
        {
            if (canvas == null)
                canvas = this.gameObject;
        }

        private void _events_OnPauseMenuShow()
        {
            var panel = canvas.transform.Find("PauseMenu");
            panel.gameObject.SetActive(true);
            GameManager.GameManager.Instance.PauseGame();

        }

        public void OnDisable()
        {
            _events.OnPauseMenuShow -= _events_OnPauseMenuShow;
        }
    }
}
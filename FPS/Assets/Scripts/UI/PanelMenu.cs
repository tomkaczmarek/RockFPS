using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PanelMenu : MonoBehaviour
    {
        public GameObject parent;
        public void ResumeGame()
        {
            parent.SetActive(false);
            GameManager.GameManager.Instance.ResumeGame();
        }

        public void EndGame()
        {
            Application.Quit();
        }
    }
}
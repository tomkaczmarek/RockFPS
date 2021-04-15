using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Scenes.UI
{
    public class ExitButton : MonoBehaviour
    {
       public void Exit()
        {
            Application.Quit();
        }
    }
}
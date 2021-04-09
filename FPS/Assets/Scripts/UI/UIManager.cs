using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        Text _text;
        public UIManager(Text text)
        {
            _text = text;
        }
        public void SetWeaponName(string text)
        {
            _text.text = text;
        }
    }
}
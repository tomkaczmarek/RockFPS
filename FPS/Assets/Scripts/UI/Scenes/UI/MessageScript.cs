using Assets.Scripts.Events;
using Assets.Scripts.Scenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundEvents sound = GetComponent<SoundEvents>();     
        transform.Find("WinMessageText").gameObject.SetActive(false);
        transform.Find("NewMessageText").gameObject.SetActive(false);
        if (SceneMediator.IsWin)
        {
            transform.Find("WinMessageText").gameObject.SetActive(true);
            sound.CallWinSound();
        }
            
        else
        {
            transform.Find("NewMessageText").gameObject.SetActive(true);
            sound.CallIntroSound();
        }    
            
    }

}

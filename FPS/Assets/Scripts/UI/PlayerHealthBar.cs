using Assets.Scripts.GameManager;
using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider _slider;
    private AbstractHealth _player;
    private Text _healhText;


    void Start()
    {
        _healhText = transform.Find("Text").GetComponent<Text>();
        _player = FindObjectOfType<PlayerHealth>();
        _slider = transform.gameObject.GetComponent<Slider>();
        _slider.maxValue = _player.GetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        _healhText.text = $"{_player.GetCurrentHealth()}/{_player.GetMaxHealth()}";
        _slider.value = _player.GetCurrentHealth();
    }
}

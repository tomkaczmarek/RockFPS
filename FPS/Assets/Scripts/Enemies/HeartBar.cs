using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    public GameObject target;

    private AbstractHealth _health;
    private Slider _slider;
    private Text _healhText;

    // Start is called before the first frame update
    void Start()
    {
        _health = target.GetComponent<AbstractHealth>();
        _healhText = transform.Find("Text").GetComponent<Text>();
        _slider = transform.gameObject.GetComponent<Slider>();
        _slider.maxValue = _health.GetMaxHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        _healhText.text = $"{_health.GetCurrentHealth()}/{_health.GetMaxHealth()}";
        _slider.value = _health.GetCurrentHealth();
    }
}

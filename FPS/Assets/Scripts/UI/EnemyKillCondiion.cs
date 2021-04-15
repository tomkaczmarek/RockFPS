using Assets.Scripts.GameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKillCondiion : MonoBehaviour
{
    // Start is called before the first frame update
    private Text _text;

    void Start()
    {
        _text = transform.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = $"kill: {GameManager.Instance.GetCurrentEnemyKill()}{System.Environment.NewLine}required: {GameManager.Instance.enemyToKillToWin}";
    }
}

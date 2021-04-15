using Assets.Scripts.Enemies;
using Assets.Scripts.GameManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyAIMode
{
    Attack = 1,
    Follow = 2
}
public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public Rigidbody rig;
    public float speed = 4f;
    public EnemyBaseAttack enemyBehevior;

    private EnemyAIMode _aiMode;
    private float _currentHealth;


  public void Start()
    {
        speed += GameManager.Instance.GetLevelModification(speed);
        rig = GetComponent<Rigidbody>();
        _aiMode = EnemyAIMode.Follow;
    }
    public void Update()
    {
        if (_aiMode == EnemyAIMode.Attack)
        {       
            enemyBehevior.AttackBehavior(transform, target);
        }          
        else
            Follow();
    }
    private void Follow()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _aiMode = EnemyAIMode.Attack;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _aiMode = EnemyAIMode.Follow;
    }
}

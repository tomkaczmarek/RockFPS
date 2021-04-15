using Assets.Scripts.Events;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class RolingAttack : EnemyBaseAttack
    {

        public float timeBeetwenAttack = 3;

        public int minPlayerDamage = 5;
        public int maxPlayerDamage = 20;

        private Player.AbstractHealth _player;
        private bool _isAttack;

        public void Start()
        {
            maxPlayerDamage += (int)GameManager.GameManager.Instance.GetLevelModification(maxPlayerDamage);
            _player = FindObjectOfType<Player.PlayerHealth>();
        }
        public override void AttackBehavior(Transform enemyUnit, Transform target)
        {
            if(!_isAttack)
            {
                Rigidbody rig = gameObject.GetComponent<Rigidbody>();
                rig.AddForce(transform.forward * 20f, ForceMode.Impulse);
                rig.AddForce(transform.up * 4f, ForceMode.Impulse);
                EventsManager attackEvent = transform.Find("Sphere").GetComponent<EventsManager>();
                attackEvent.OnDamage += AttackEvent_OnDamage;
                _isAttack = !_isAttack;
                Invoke(nameof(ResetAttack), timeBeetwenAttack);
            }
        }

        private void AttackEvent_OnDamage()
        {
            _player.TakeDamage((Random.Range(minPlayerDamage, maxPlayerDamage)));
        }

        private void ResetAttack()
        {
            _isAttack = false;
        }
    }
}
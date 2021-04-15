using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemyBaseAttack : MonoBehaviour
    {
        public virtual void AttackBehavior(Transform enemyUnit, Transform target) { }
 
    }
}
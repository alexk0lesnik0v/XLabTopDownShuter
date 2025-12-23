using UnityEngine;
using Entities.Enemies.Data;

namespace Entities.Enemies.Data
{
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private AttackEnemyType m_enemyType;
        
        [Header("Parametrs")]
        [SerializeField] [Min(0)] private float m_health;
        [SerializeField] [Range(0f, 100f)] private float m_speed;
        
        [Header("Attack")]
        [SerializeField] [Min(0)] private float m_attackTime;
        [SerializeField] [Min(0)] private float m_attackRange;
        
        //TODO Add ProjectileRange - область поражения снаряда
        //TODO Add Damage
        
        public float heals => m_health;
        
        public float speed => m_speed;

        public float attackTime => m_attackTime;
        
        public float attackRange => m_attackRange;
        
        public AttackEnemyType enemyType => m_enemyType;
    }
    
}
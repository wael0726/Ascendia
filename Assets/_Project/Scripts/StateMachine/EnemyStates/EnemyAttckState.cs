using UnityEngine;
using UnityEngine.AI;

namespace Platformer {
    public class EnemyAttackState : EnemyBaseState {
        readonly NavMeshAgent agent;
        readonly Transform player;
        
        public EnemyAttackState(Enemy enemy, NavMeshAgent agent, Transform player) : base(enemy) {
            this.agent = agent;
            this.player = player;
        }
        
        public override void OnEnter() {
            Debug.Log("Attack");
        }
        
        public override void Update() {
            agent.SetDestination(player.position);
            enemy.Attack();
        }
    }
}

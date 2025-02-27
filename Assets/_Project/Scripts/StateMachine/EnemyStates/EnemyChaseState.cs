using UnityEngine;
using UnityEngine.AI;

namespace Platformer {
    public class EnemyChaseState : EnemyBaseState {
        readonly NavMeshAgent agent;
        readonly Transform player;
        
        public EnemyChaseState(Enemy enemy, NavMeshAgent agent, Transform player) : base(enemy) {
            this.agent = agent;
            this.player = player;
        }
        
        public override void OnEnter() {
            Debug.Log("Chase");
        }
        
        public override void Update() {
            agent.SetDestination(player.position);
        }
    }
}

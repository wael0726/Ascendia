namespace Platformer {
    public abstract class EnemyBaseState : IState {
        protected readonly Enemy enemy;
        
        protected const float crossFadeDuration = 0.1f;

        // Removed the Animator and animation references

        protected EnemyBaseState(Enemy enemy) {
            this.enemy = enemy;
        }
        
        public virtual void OnEnter() {
            // noop
        }

        public virtual void Update() {
            // noop
        }

        public virtual void FixedUpdate() {
            // noop
        }

        public virtual void OnExit() {
            // noop
        }
    }
}

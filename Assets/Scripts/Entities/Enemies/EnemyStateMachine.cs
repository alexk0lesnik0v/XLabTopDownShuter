namespace Entities.Enemies
{
    public class EnemyStateMachine
    {
        public EnemyState currentState { get; private set; }
    }
    
    private EnemyStateMachine()
    {
        currentState = EnemyState.Idle;
    }

    public void ChangeState(EnemyState nextState)
    {
        
    }
}
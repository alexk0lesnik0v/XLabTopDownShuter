using System;
using System.Collections.Generic;

namespace Infrastructure.States
{
   public class StateMachine
   {
      private IState m_state;
      private Dictionary<Type, IState> m_states = new();

      public void Initialize(params IState[] states)
      {
         if (m_states.Count > 0) return;
      
         foreach (var state in states)
         {
            m_states.Add(state.GetType(), state);
         }
      }
   
      public void ChangedState<T>()
         where T : IState
      {
         m_state?.Exit();
         {
            m_state = m_states[typeof(T)];
         }
         m_state.Enter();
      }
   }

   public interface IState
   {
      public void Enter() => throw new NotImplementedException();
      
      public void Exit() => throw new NotImplementedException();
   }
   
   public class MainMenuState : IState
   {
      private readonly StateMachine m_stateMachine;

      public MainMenuState(StateMachine stateMachine)
      {
         m_stateMachine = stateMachine;
      }
      
      public void Enter() => throw new NotImplementedException();
      
      public void Exit() => throw new NotImplementedException();
   }
   
   public class PauseMenuState : IState
   {
      private readonly StateMachine m_stateMachine;

      public PauseMenuState(StateMachine stateMachine)
      {
         m_stateMachine = stateMachine;
      }
      
      public void Enter() => throw new NotImplementedException();
      
      public void Exit() => throw new NotImplementedException();
   }
   
   public class GameplayState : IState
   {
      private readonly StateMachine m_stateMachine;

      public GameplayState(StateMachine stateMachine)
      {
         m_stateMachine = stateMachine;
      }
      
      public void Enter() => throw new NotImplementedException();
      
      public void Exit() => throw new NotImplementedException();
   }
   
   public class DeadState : IState
   {
      private readonly StateMachine m_stateMachine;

      public DeadState(StateMachine stateMachine)
      {
         m_stateMachine = stateMachine;
      }
      
      public void Enter() => throw new NotImplementedException();
      
      public void Exit() => throw new NotImplementedException();
   }
}
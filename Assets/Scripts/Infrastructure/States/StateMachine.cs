using System;
using System.Collections.Generic;
using Entities.Enemies;
using Players;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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
      public void Enter();
      
      public void Exit();
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
      private readonly SpawnerEnemy m_spawnerEnemy;
      private readonly PlayerController m_playerController;

      public GameplayState(
         StateMachine stateMachine,
         SpawnerEnemy spawnerEnemy,
         PlayerController playerController)
      {
         m_spawnerEnemy = spawnerEnemy;
         m_stateMachine = stateMachine;
         m_playerController = playerController;
      }
      
      public void Enter()
      {
         m_spawnerEnemy.Spawn();
         m_playerController.Health.Died += OnDied;
      }

      public void Exit()
      {
         m_playerController.Health.Died -= OnDied;
      }
      
      private void OnDied() =>
         m_stateMachine.ChangedState<DeadState>();
   }
   
   public class DeadState : IState
   {
      private readonly StateMachine m_stateMachine;
      private readonly DeadMenuView m_deadMenuView;

      public DeadState(StateMachine stateMachine, DeadMenuView deadMenuView)
      {
         m_stateMachine = stateMachine;
         m_deadMenuView = deadMenuView;
         
         deadMenuView.gameObject.SetActive(false);
      }

      public void Enter()
      {
         m_deadMenuView.GoToMenuClicked += OnGoToMenuClicked;
         m_deadMenuView.gameObject.SetActive(true);
      }
     
      public void Exit()
      {
         m_deadMenuView.GoToMenuClicked -= OnGoToMenuClicked;
         m_deadMenuView.gameObject.SetActive(false);
      }

      private void OnGoToMenuClicked()
      {
         SceneManager.LoadScene(GlobalConstants.Scenes.Main);
      }
   }
}
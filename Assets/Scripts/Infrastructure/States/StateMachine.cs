using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
         m_state = null;
      }
   }
}

public interface IState
{
   public void Enter() => throw new NotImplementedException();
   public void Exit() => throw new NotImplementedException();
}

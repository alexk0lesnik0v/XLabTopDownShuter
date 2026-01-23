using System;
using UnityEngine;

namespace Magic.Buffs.Base
{
    [Serializable]
    public abstract class BaseBuff : IBuff
    {
        [field: SerializeField]
        public string Id { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }
        
        [field: SerializeField]
        public BuffType Type { get; private set; }

        protected BuffConteiner conteiner { get; private set; }

        protected BaseBuff()
        {
            
        }

        protected BaseBuff(string id)
        {
            Id = id;
        }

        public void Initialize(BuffConteiner conteiner)
        {
            this.conteiner = conteiner;
            OnInitialized();
        }
        
        protected virtual void OnInitialized() { }

        public void Deinitialize()
        {
            OnDeinitializing();
            
            conteiner.Remove(this);
            conteiner =  null;
        }
        
        protected virtual void OnDeinitializing() { }

        public virtual void Update(float deltatime) { }

        public abstract IBuff Clone();
    }
}
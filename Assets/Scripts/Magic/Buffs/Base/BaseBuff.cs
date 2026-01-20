using UnityEngine;

namespace Magic.Buffs.Base
{
    public abstract class BaseBuff : IBuff
    {
        protected BuffConteiner conteiner { get; private set; }
        
        [field: SerializeField]
        public string Id { get; private set; }

        public void Initialize(BuffConteiner conteiner)
        {
            this.conteiner = conteiner;
            OnInitialize();
        }
        
        protected virtual void OnInitialize() { }

        public void Deinitialize()
        {
            OnDeinitializing();
            
            conteiner.Remove(this);
            conteiner =  null;
        }
        
        protected virtual void OnDeinitializing() { }

        public virtual void Update(float deltatime) { }

        public object Clone() => 
            this.MemberwiseClone();
    }
}
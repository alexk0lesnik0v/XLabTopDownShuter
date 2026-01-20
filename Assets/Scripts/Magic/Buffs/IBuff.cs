using System;

namespace Magic.Buffs
{
    public interface IBuff : ICloneable
    {
        public string Id { get; }
    
        public void Initialize(BuffConteiner conteiner);
        
        public void Deinitialize();
        
        public void Update(float deltatime);
    }
}
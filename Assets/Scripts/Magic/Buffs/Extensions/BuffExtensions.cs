namespace Magic.Buffs.Extensions
{
    public static class BuffExtensions
    {
        public static void Refresh(this IBuff buff, BuffConteiner buffConteiner)
        {
            buff.Deinitialize();
            buff.Initialize(buffConteiner);
        }
    }
}
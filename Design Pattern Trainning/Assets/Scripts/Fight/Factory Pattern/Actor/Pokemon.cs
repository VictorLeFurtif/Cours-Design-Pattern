namespace Fight.Factory_Pattern.Actor
{
    
    public class Pokemon
    {
        #region Fields

        public string Name;
        public int Life;
        public int Damage;

        #endregion

        #region Constructor

        public Pokemon(string _name,int _life, int _damage)
        {
            Life = _life;
            Name = _name;
            Damage = _damage;
        }

        #endregion
    }
}
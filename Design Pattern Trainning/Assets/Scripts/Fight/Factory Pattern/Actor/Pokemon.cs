using System;
using StatePattern;

namespace Fight.Factory_Pattern.Actor
{
    [Serializable]
    public class Pokemon
    {
        #region Fields

        public string Name;
        public int Life;
        public int Damage;
        public AbstractStatePokemon currentStatePokemon;

        #endregion

        #region Constructor

        public Pokemon(string _name,int _life, int _damage)
        {
            Life = _life;
            Name = _name;
            Damage = _damage;
            currentStatePokemon = new NormalState();
        }

        #endregion
    }
}
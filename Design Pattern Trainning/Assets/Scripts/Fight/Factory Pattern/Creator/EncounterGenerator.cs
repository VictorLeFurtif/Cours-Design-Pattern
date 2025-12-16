using Fight.Factory_Pattern.Enum;
using Observer;
using UnityEngine;

namespace Fight.Factory_Pattern.Creator
{
    public abstract class EncounterGenerator : MonoBehaviour
    {
            
        #region Fields

        [SerializeField] protected GameObject buttonPrefabs;
        protected bool fightHappen = false;

        #endregion

        public abstract void InitialiseEncounter(); 
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            InitialiseEncounter();
        }

        public void OnWinPlayer()
        {
            fightHappen = true;
        }
        
    }
    
}
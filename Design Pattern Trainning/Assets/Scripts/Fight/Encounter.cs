using UnityEngine;

namespace Fight
{
    public abstract class Encounter : MonoBehaviour
    {
        Pokemon pokemonNmy;
        [SerializeField] private GameObject principalUiFight;
        public static Encounter instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void StartFight()
        {
            pokemonNmy = new Pokemon();
            DisplayUi();
        }


        protected virtual void DisplayUi()
        {
            principalUiFight.SetActive(true);
        }
    }
}

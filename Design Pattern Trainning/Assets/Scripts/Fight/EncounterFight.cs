using UnityEngine;

namespace Fight
{
    public class EncounterFight : Encounter
    {
        private Dresseur dresseur;
        [SerializeField] private GameObject dresserUiFight;

        protected override void StartFight()
        {
            base.StartFight();
            dresseur = new Dresseur();
        }

        protected override void DisplayUi()
        {
            base.DisplayUi();
            dresserUiFight.SetActive(true);
        }
    }
}
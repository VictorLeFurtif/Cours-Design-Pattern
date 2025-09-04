using UnityEngine;

namespace Fight
{
    public class EncouterWild : Encounter
    {
        [SerializeField] private GameObject wildUiFight;
        
        protected override void DisplayUi()
        {
            base.DisplayUi();
            wildUiFight.SetActive(true);
        }
    }
}
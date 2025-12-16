using Fight.Factory_Pattern.Product;
using Observer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fight.Factory_Pattern.Creator
{
    public class EncounterGeneratorFight : EncounterGenerator
    {
        
        private FightEncounter fightEncounter;
        GameObject objToSpawn;
        public override void InitialiseEncounter()
        {
            if (fightHappen) return;
            
            //create Fight Encounter
            objToSpawn = new GameObject("Fight Encounter");
            fightEncounter = objToSpawn.AddComponent<FightEncounter>();
            fightEncounter.GetRefGenerator(this);
            
            //canvas part
            Canvas canvas = objToSpawn.AddComponent<Canvas>();
            CanvasScaler canvasScaler = objToSpawn.AddComponent<CanvasScaler>();
            objToSpawn.AddComponent<GraphicRaycaster>();
            VerticalLayoutGroup verticalLayout = objToSpawn.AddComponent<VerticalLayoutGroup>();

            //canvas parameters
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            verticalLayout.childAlignment = TextAnchor.LowerRight;
            verticalLayout.spacing = 30;
            verticalLayout.padding.right = 30;
            verticalLayout.padding.bottom = 30;
            verticalLayout.childControlHeight = false;
            verticalLayout.childControlWidth = false;
            verticalLayout.childForceExpandHeight = false;
            verticalLayout.childForceExpandWidth = false;
            
            //Add button link to fight Encounter //TODO POSITION !!!!!
            GameObject buttonAttack = Instantiate(buttonPrefabs, canvas.transform, true);
            buttonAttack.GetComponent<Button>().onClick.AddListener(fightEncounter.Attack);
            buttonAttack.transform.GetChild(0).GetComponent<TMP_Text>().text = fightEncounter.ActionsList[0];
            
            GameObject buttonHeal = Instantiate(buttonPrefabs, canvas.transform, true);
            buttonHeal.GetComponent<Button>().onClick.AddListener(fightEncounter.Heal);
            buttonHeal.transform.GetChild(0).GetComponent<TMP_Text>().text = fightEncounter.ActionsList[1];
            
            GameObject buttonParalyzed = Instantiate(buttonPrefabs, canvas.transform, true);
            buttonParalyzed.GetComponent<Button>().onClick.AddListener(fightEncounter.Paralyzed);
            buttonParalyzed.transform.GetChild(0).GetComponent<TMP_Text>().text = fightEncounter.ActionsList[2];
            
            EventManager.OnFightStart.Invoke();
        }
    }
}
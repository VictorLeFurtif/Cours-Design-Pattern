using Fight.Factory_Pattern.Product;
using Observer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fight.Factory_Pattern.Creator
{
    public class EncounterGeneratorWild : EncounterGenerator
    {
        private WildEncounter wildEncounter;
        GameObject objToSpawn;
        public override void InitialiseEncounter()
        {
            
            if (fightHappen) return;
            
            //create Fight Encounter
            objToSpawn = new GameObject("Wild Encounter");
            wildEncounter = objToSpawn.AddComponent<WildEncounter>();
            wildEncounter.GetRefGenerator(this);
            
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
            verticalLayout.spacing = 5;
            verticalLayout.childControlHeight = false;
            verticalLayout.childControlWidth = false;
            verticalLayout.childForceExpandHeight = false;
            verticalLayout.childForceExpandWidth = false;
            
            //Add button link to fight Encounter 
            GameObject buttonAttack = Instantiate(buttonPrefabs, canvas.transform, true);
            buttonAttack.GetComponent<Button>().onClick.AddListener(wildEncounter.Attack);
            buttonAttack.transform.GetChild(0).GetComponent<TMP_Text>().text = wildEncounter.ActionsList[0];
            
            GameObject buttonHeal = Instantiate(buttonPrefabs, canvas.transform, true);
            buttonHeal.GetComponent<Button>().onClick.AddListener(wildEncounter.Heal);
            buttonHeal.transform.GetChild(0).GetComponent<TMP_Text>().text = wildEncounter.ActionsList[1];
            
            GameObject buttonFlee = Instantiate(buttonPrefabs, canvas.transform, true);
            buttonFlee.GetComponent<Button>().onClick.AddListener(wildEncounter.Flee);
            buttonFlee.transform.GetChild(0).GetComponent<TMP_Text>().text = wildEncounter.ActionsList[2];
            
            GameObject buttonCatch = Instantiate(buttonPrefabs, canvas.transform, true);
            buttonCatch.GetComponent<Button>().onClick.AddListener(wildEncounter.Catch);
            buttonCatch.transform.GetChild(0).GetComponent<TMP_Text>().text = wildEncounter.ActionsList[3];
            
            EventManager.OnFightStart.Invoke();
        }

        
    }
}
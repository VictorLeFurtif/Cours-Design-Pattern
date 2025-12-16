using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LogEncounter : MonoBehaviour
    {
        public static LogEncounter Instance;

        [Header("UI")]
        [SerializeField] private CanvasGroup panelGroup;
        [SerializeField] private TMP_Text logText;
        
        [Header("Typing")]
        [SerializeField] private float charDelay = 0.03f;
        [SerializeField] private float fadeDuration = 0.2f;

        private readonly Queue<string> messageQueue = new();
        private bool isTyping;

        private void Awake()
        {
            Instance = this;
            HideInstant();
        }

        public void AddMessage(string message)
        {
            messageQueue.Enqueue(message);

            if (!isTyping)
                StartCoroutine(ProcessQueue());
        }

        private IEnumerator ProcessQueue()
        {
            isTyping = true;
            yield return Fade(true);

            while (messageQueue.Count > 0)
            {
                yield return TypeMessage(messageQueue.Dequeue());
                yield return new WaitForSeconds(0.2f);
            }

            yield return Fade(false);
            isTyping = false;
        }

        private IEnumerator TypeMessage(string message)
        {
            logText.text = "";

            foreach (char c in message)
            {
                logText.text += c;
                yield return new WaitForSeconds(charDelay);
            }
        }

        private IEnumerator Fade(bool show)
        {
            float start = panelGroup.alpha;
            float target = show ? 1f : 0f;
            float t = 0f;

            panelGroup.blocksRaycasts = show;
            panelGroup.interactable = show;

            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                panelGroup.alpha = Mathf.Lerp(start, target, t / fadeDuration);
                yield return null;
            }

            panelGroup.alpha = target;
        }

        private void HideInstant()
        {
            panelGroup.alpha = 0f;
            panelGroup.blocksRaycasts = false;
            panelGroup.interactable = false;
            logText.text = "";
        }
        
        public void Hide()
        {
            StopAllCoroutines();
            messageQueue.Clear();
            HideInstant();
        }


        public bool IsBusy() => isTyping;
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Script.Manager
{
    public class GraphManager : MonoBehaviour
    {
        [System.Serializable]
        public class Link
        {
            public Transform pointA;
            public Transform pointB;
        }

        public List<Link> liens = new();
        private List<LineRenderer> lines = new();

        [ContextMenu("Generate Lines")]
        public void Start()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
                DestroyImmediate(transform.GetChild(i).gameObject);

            lines.Clear();

            for (int i = 0; i < liens.Count; i++)
            {
                var go = new GameObject("Link_" + i);
                go.transform.parent = transform;
                var lr = go.AddComponent<LineRenderer>();
                lr.positionCount = 2;
                lr.startWidth = lr.endWidth = 0.05f;
                lr.material = new Material(Shader.Find("Sprites/Default"));
                lr.startColor = lr.endColor = Color.cyan;
                lines.Add(lr);
            }
            
            
            for (int i = 0; i < liens.Count && i < lines.Count; i++)
            {
                var link = liens[i];
                if (link.pointA && link.pointB)
                {
                    lines[i].SetPosition(0, link.pointA.position);
                    lines[i].SetPosition(1, link.pointB.position);
                }
            }
        }

    }
}
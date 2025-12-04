using System.Collections.Generic;
using UnityEngine;

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

    public List<Transform> nodes = new List<Transform>(); //la liste des points du graphes dans l'ordre de la matrice de valuation

    [ContextMenu("Generate Lines")]
    public void Start()
    {
        // reinitialisation
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

    [ContextMenu("Generate node list")]
    public void GenerateNodeList()
    {
        //reinitialisation
        nodes = new List<Transform>();
        //je cr�e la liste de tous les sommets du graphe a partir des binomes
        foreach (var link in liens)
        {
            if (link.pointA != null && !nodes.Contains(link.pointA))
                nodes.Add(link.pointA);
            if (link.pointB != null && !nodes.Contains(link.pointB))
                nodes.Add(link.pointB);
        }

    }

    public double[,] GraphMatrix()
    {
        GenerateNodeList();
        int n = nodes.Count;
        //je cr�e la matrice de valuation
        double[,] matrix = new double[n, n];

        //pour chaque couple de point
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                matrix[i, j] = double.PositiveInfinity; // j'initialise a infini

        foreach (var link in liens) // je parcours toutes les ar�tes
        { // je remplace l'infini dans la matrice de valuation par la distance entre les 2 points de l'ar�te
            if (link.pointA != null && link.pointB != null)
            {
                int i = nodes.IndexOf(link.pointA);
                int j = nodes.IndexOf(link.pointB);
                double distance = Vector3.Distance(link.pointA.position, link.pointB.position);
                matrix[i, j] = distance;
                matrix[j, i] = distance; // dans ce cas on se limite � des graphes non orient�s
                                         //c'est � dire que les chemins peuvent �tre emprunt�s dans les deux sens
            }
        }

        return matrix;
    }
}
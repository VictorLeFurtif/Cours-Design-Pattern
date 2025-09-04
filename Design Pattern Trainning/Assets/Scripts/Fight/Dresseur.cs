using UnityEngine;

namespace Fight
{
    public class Dresseur
    {
        public string name;
        private string[] allName = new[] {"Valentin","Nour", "Lina","Charlotte",}; //imaginons bank data


        public Dresseur()
        {
            name = allName[Random.Range(0, allName.Length)];
        }
    }
}
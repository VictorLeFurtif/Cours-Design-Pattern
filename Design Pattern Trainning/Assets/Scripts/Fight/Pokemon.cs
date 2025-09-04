using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace Fight
{
    public class Pokemon
    {
        public int lvl;
        public int life;
        public string name;
        private string[] allName = new[] {"ronflex","pikachu", "roudoudou","Dracaufeu",}; //imaginons bank data

        // horrible mais c'est pour l'exemple
        public Pokemon()
        {
            lvl = Random.Range(1, 100);
            life = Random.Range(50, 100);
            name = allName[Random.Range(0, allName.Length)];
        }
    }
    
}
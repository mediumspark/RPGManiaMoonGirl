using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(fileName ="Bag", menuName ="Bag(Only Make One)")]
    public class PlayerBag : ScriptableObject
    {
        public GameObject[] Items; 
    }
}
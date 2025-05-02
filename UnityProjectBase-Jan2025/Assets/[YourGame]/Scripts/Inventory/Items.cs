using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Items : ScriptableObject
{
    
        public int id;
        public string itemName;
        public string itemSprite;
        public int sellvalue;

}

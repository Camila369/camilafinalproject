using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Items : ScriptableObject
{
    //Objects
        public int id;
        public string ItemName;
        public Sprite icon; //ItemSprite
        public int sellvalue;

}

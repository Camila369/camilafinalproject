using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Items : ScriptableObject
{
    //Objects
        public int id;
        public string ItemName;
        public Sprite icon; //ItemSprite
        public int sellvalue;
        public bool CanRemove;
        public bool CanTradeorSell;
        public ItemType Itemtype;

    public enum ItemType
    {
        Food,
        Water,
        Weapon,
        Ammunition,
        Key,
        Clue

    }

    public virtual void Use()
    {
        Debug.Log("Using item: " + ItemName);

        switch (Itemtype)
        {
            case ItemType.Food:
            // show eat food menu
            Debug.Log("It's Food");
                break;

            case ItemType.Water:
            Debug.Log("It's Water");
            // show drink water menu
                break;

            case ItemType.Weapon:
            // show equip weapon menu
                break;

            case ItemType.Key:
            Debug.Log("It's Key");
            // show equip weapon menu
                break;

            case ItemType.Clue:
            //show more abour the clue
                break;

            case ItemType.Ammunition:
            //show reload gun, if possible
                break;

        }
    }


}

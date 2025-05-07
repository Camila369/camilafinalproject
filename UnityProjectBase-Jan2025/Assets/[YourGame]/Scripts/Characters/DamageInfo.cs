using UnityEngine;

public class DamageInfo : MonoBehaviour
{
    public DamageInfo(float amount, GameObject source, GameObject instigator)
    {
        Amount = amount;
        Source = source;
        Instigator = instigator;
    }

    public float Amount { get; set; }
    public GameObject Source { get; set; }          // grenade object
    public GameObject Instigator { get; set; }      // character throwing the grenade
}

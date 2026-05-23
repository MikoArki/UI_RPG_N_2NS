using UnityEngine;

public class Wapon : MonoBehaviour
{
    [SerializeField] internal float damage;

    public virtual float GetDamage()
    {
        return damage;
    }
    
}

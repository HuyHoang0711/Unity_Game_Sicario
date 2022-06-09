using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    // Start is called before the first frame update
    public int GetDamage()
    {
        return damage;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}

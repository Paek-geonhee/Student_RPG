using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableObject : MonoBehaviour
{
    public int Level;                       // 레벨
    public float HP;                        // 최대 체력
    public float Damage;                    // 공격력
    public float Defense;

    protected float curHP;

    public bool NoDamage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

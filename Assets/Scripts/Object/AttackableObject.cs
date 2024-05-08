using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableObject : MonoBehaviour
{
    [Header("Flags")]
    public bool Attacking;
    public bool NoDamage;

    [Header("Main Stats")]
    public int Level;                       // ����
    public float HP;                        // �ִ� ü��
    public float Damage;                    // ���ݷ�
    public float Defense;

    protected float curHP;


    

    protected void Init()
    {
        curHP = HP;
        NoDamage = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

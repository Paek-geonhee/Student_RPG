using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public float curHP;
    [SerializeField]
    public BoxCollider2D BC;
    public Rigidbody2D RB;

    public float HP;
    public float Damage;
    public float Defense;

    // Start is called before the first frame update
    void Start()
    {
        curHP = HP; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(float damage, float lethality, float cri_damage, float cri_prob) {
        // �ܺ� ������Ʈ���� ȣ���ϴ� �Լ��Դϴ�.
        // �Լ� ���� ��, �Ķ���ͷ� ���޵� damage ���� ���� ������ ���ҵǴ� hp���� �����մϴ�.


        // ġ��Ÿ ���� Ȱ��ȭ ���θ� �����մϴ�.
        float cri = Random.Range(0, 100) <= cri_prob * 100 ? cri_damage : 1f;

        // ���� �������� �����ϰ� HP�� ���ҽ�ŵ�ϴ�.
        curHP -= cri * (damage * damage / (damage + Defense * (1-lethality)));


        // ü���� ���� ��� ������Ʈ�� �ı��մϴ�.
        if (curHP <= 0) {
            Destroy(gameObject);
        }
    }
}

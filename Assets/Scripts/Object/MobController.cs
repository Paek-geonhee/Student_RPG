using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : AttackableObject
{
    
    [SerializeField]
    public BoxCollider2D BC;
    public Rigidbody2D RB;
    public SpriteRenderer SR;


   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeAway() {
        NoDamage = true;
        SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.5f);
        yield return new WaitForSeconds(0.5f);
        

        SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f);
        NoDamage = false;
        yield return null;
    }

    public void Hit(float damage, float lethality, float cri_damage, float cri_prob) {
        // �ܺ� ������Ʈ���� ȣ���ϴ� �Լ��Դϴ�.
        // �Լ� ���� ��, �Ķ���ͷ� ���޵� damage ���� ���� ������ ���ҵǴ� hp���� �����մϴ�.
        if (NoDamage) return;
        StartCoroutine(FadeAway());
        // ġ��Ÿ ���� Ȱ��ȭ ���θ� �����մϴ�.
        float cri = Random.Range(0, 100) <= cri_prob * 100 ? cri_damage : 1f;

        // ���� �������� �����ϰ� HP�� ���ҽ�ŵ�ϴ�.
        Debug.Log(cri * (damage * damage / (damage + Defense * (1 - lethality))));
        this.curHP -= cri * (damage * damage / (damage + Defense * (1-lethality)));


        // ü���� ���� ��� ������Ʈ�� �ı��մϴ�.
        if (this.curHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

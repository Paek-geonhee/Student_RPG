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
        // 외부 오브젝트에서 호출하는 함수입니다.
        // 함수 실행 시, 파라미터로 전달된 damage 값을 통해 실제로 감소되는 hp량을 결정합니다.
        if (NoDamage) return;
        StartCoroutine(FadeAway());
        // 치명타 공격 활성화 여부를 결정합니다.
        float cri = Random.Range(0, 100) <= cri_prob * 100 ? cri_damage : 1f;

        // 최종 데미지를 결정하고 HP를 감소시킵니다.
        Debug.Log(cri * (damage * damage / (damage + Defense * (1 - lethality))));
        this.curHP -= cri * (damage * damage / (damage + Defense * (1-lethality)));


        // 체력이 고갈된 경우 오브젝트를 파괴합니다.
        if (this.curHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

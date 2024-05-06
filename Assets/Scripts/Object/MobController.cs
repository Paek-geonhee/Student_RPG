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
        // 외부 오브젝트에서 호출하는 함수입니다.
        // 함수 실행 시, 파라미터로 전달된 damage 값을 통해 실제로 감소되는 hp량을 결정합니다.


        // 치명타 공격 활성화 여부를 결정합니다.
        float cri = Random.Range(0, 100) <= cri_prob * 100 ? cri_damage : 1f;

        // 최종 데미지를 결정하고 HP를 감소시킵니다.
        curHP -= cri * (damage * damage / (damage + Defense * (1-lethality)));


        // 체력이 고갈된 경우 오브젝트를 파괴합니다.
        if (curHP <= 0) {
            Destroy(gameObject);
        }
    }
}

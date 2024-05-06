using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float currentCoolTime;
    bool Attacking;
    float curHP;

    [SerializeField]
    public BoxCollider2D BC;
    public Rigidbody2D RB;
    public SpriteRenderer SR;

    // Player's Movement Speed
    public float SpeedX;                    // x축 이동속도
    public float SpeedY;                    // y축 이동속도
    /////////////////////


    // Player's Stats
    public int Level;                       // 레벨
    public float HP;                        // 최대 체력
    public float Damage;                    // 공격력
    public float Defense;                   // 방어력
    public float AttackCoolTime;            // 공격 속도(쿨타임)
    public float Lethality;                 // 관통력% (0~1)

    public float CriticalDamage;            // 치명타 데미지
    public float CriticalProbability;       // 치명타 확률
    /////////////////////

    // 공격 범위와 위치를 설정하기 위한 벡터입니다.
    public Vector2 AttackRange;

    
    // Start is called before the first frame update
    void Start()
    {
        Attacking = false;
        currentCoolTime = AttackCoolTime;
        curHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AttackToMob();
    }

    void PlayerMovement() {
        // 공격 중이라면 움직일 수 없습니다
        if (Attacking) return;


        float axis_x = Input.GetAxisRaw("Horizontal");
        float axis_y = Input.GetAxisRaw("Vertical");

        float dash = Input.GetKey(KeyCode.LeftShift) ? 1.5f : 1f;

        SR.flipX = axis_x == 1 ? false : axis_x == -1 ? true : SR.flipX;

        RB.velocity = new Vector2 (axis_x*SpeedX*dash, axis_y*SpeedY* dash);
    }

    IEnumerator MoveDelay() {
        // 공격 버튼을 누르면 움직임을 제한합니다.
        // 0.5 초가 경과하면 다시 움직임을 허용합니다.

        Attacking = true;
        yield return new WaitForSeconds(0.5f);

        Attacking = false;
        yield return null;
    }

    void AttackToMob() {
        if (currentCoolTime > 0)
        {
            currentCoolTime -= Time.deltaTime;
            return;
        }

        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            // 왼족 컨트롤 버튼을 누를때 발생하는 이벤트입니다.

            // 플레이어의 움직임 방향에 따라 공격 범위를 설정합니다.
            int flip = SR.flipX ? -1 : 1;
            AttackRange = new Vector2(AttackRange.x * flip, AttackRange.y);

            // 공격 범위 내 Mob들은 인식합니다.
            Collider2D[] mobs = Physics2D.OverlapBoxAll((Vector2)transform.position + AttackRange, new Vector2(1f, 1f), 0, 1 << LayerMask.NameToLayer("Mob"));


            // 공격 범위 내 Mob들에게 데미지를 줍니다.
            // 파라미터는 플레이어의 데미지, 관통력, 치명타 데미지, 치명타 확률입니다.
            foreach (Collider2D col in mobs)
            {
                col.gameObject.GetComponent<MobController>().Hit(Damage, Lethality, CriticalDamage, CriticalProbability);
            }

            if (!Attacking) {
                StartCoroutine(MoveDelay());
            }

            currentCoolTime = AttackCoolTime;
        }
    }
}

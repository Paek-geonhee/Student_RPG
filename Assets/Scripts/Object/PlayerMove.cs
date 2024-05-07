using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어는 메인 스테이지에 있는 경우 지속적으로 curHP가 감소하며, 만약 curHP가 0 이하가 되는 경우 게임이 종료됩니다.
public class PlayerMove : AttackableObject
{
    float currentCoolTime;
    bool Attacking;

    [SerializeField]
    public BoxCollider2D BC;
    public Rigidbody2D RB;
    public SpriteRenderer SR;

    // 이동속도
    // 이동속도는 변경하지 않음.
    public float SpeedX;                    // x축 이동속도
    public float SpeedY;                    // y축 이동속도
    /////////////////////


    // 전투 스텟
    // 체력, 공격력, 방어력은 상위 클래스로 이전
    // 기본 스텟은 레벨로 결정하며, 보조 스텟으로 조정됨.
    // 장비를 통해 직접 스텟을 상수적으로 조정함.
                      
    public float AttackCoolTime;            // 공격 속도(쿨타임)
    public float Lethality;                 // 관통력% (0~1)

    public float CriticalDamage;            // 치명타 데미지
    public float CriticalProbability;       // 치명타 확률
                                            /////////////////////

    // 보조 스텟
    // 0~100 으로 결정됨. / 0미만, 100 초과로 스텟이 증가하지 않음.
    // 게임이 지속될수록 감소하며, 소모성 아이템과 장비를 이용해 수치를 조정할 수 있음.

    public int fatigue;                     // 피로도가 높을수록 받는 데미지가 증가함. (방어력 감소) / 커피를 마시면 증가합니다.
    public int concentration;               // 집중력이 높을수록 획득하는 자원이 증가함. (아이템 및 경험치 획득 시, 비율 결정)
    public int sociability;                 // 사교성이 높을수록 주는 데미지가 증가함. (관통력, 치명타 계수 증가)
    public int health;                      // 체력이 높을수록 최대 HP가 증가함. (HP 증가)
    public int caffeine;                    // 카페인 수치가 높을수록 커피를 마셨을때 증가하는 체력이 줄어듭니다. 커피를 마시지 않으면 회복됩니다.

    // 공격 범위와 위치를 설정하기 위한 벡터입니다.
    public Vector2 AttackRange;

    
    // Start is called before the first frame update
    void Start()
    {
        Init();
        Attacking = false;
        currentCoolTime = AttackCoolTime;
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
        RB.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.2f);

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

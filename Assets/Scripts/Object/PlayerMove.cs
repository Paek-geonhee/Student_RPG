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
    public float SpeedX;                    // x�� �̵��ӵ�
    public float SpeedY;                    // y�� �̵��ӵ�
    /////////////////////


    // Player's Stats
    public int Level;                       // ����
    public float HP;                        // �ִ� ü��
    public float Damage;                    // ���ݷ�
    public float Defense;                   // ����
    public float AttackCoolTime;            // ���� �ӵ�(��Ÿ��)
    public float Lethality;                 // �����% (0~1)

    public float CriticalDamage;            // ġ��Ÿ ������
    public float CriticalProbability;       // ġ��Ÿ Ȯ��
    /////////////////////

    // ���� ������ ��ġ�� �����ϱ� ���� �����Դϴ�.
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
        // ���� ���̶�� ������ �� �����ϴ�
        if (Attacking) return;


        float axis_x = Input.GetAxisRaw("Horizontal");
        float axis_y = Input.GetAxisRaw("Vertical");

        float dash = Input.GetKey(KeyCode.LeftShift) ? 1.5f : 1f;

        SR.flipX = axis_x == 1 ? false : axis_x == -1 ? true : SR.flipX;

        RB.velocity = new Vector2 (axis_x*SpeedX*dash, axis_y*SpeedY* dash);
    }

    IEnumerator MoveDelay() {
        // ���� ��ư�� ������ �������� �����մϴ�.
        // 0.5 �ʰ� ����ϸ� �ٽ� �������� ����մϴ�.

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
            // ���� ��Ʈ�� ��ư�� ������ �߻��ϴ� �̺�Ʈ�Դϴ�.

            // �÷��̾��� ������ ���⿡ ���� ���� ������ �����մϴ�.
            int flip = SR.flipX ? -1 : 1;
            AttackRange = new Vector2(AttackRange.x * flip, AttackRange.y);

            // ���� ���� �� Mob���� �ν��մϴ�.
            Collider2D[] mobs = Physics2D.OverlapBoxAll((Vector2)transform.position + AttackRange, new Vector2(1f, 1f), 0, 1 << LayerMask.NameToLayer("Mob"));


            // ���� ���� �� Mob�鿡�� �������� �ݴϴ�.
            // �Ķ���ʹ� �÷��̾��� ������, �����, ġ��Ÿ ������, ġ��Ÿ Ȯ���Դϴ�.
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

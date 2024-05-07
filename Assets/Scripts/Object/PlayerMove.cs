using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾�� ���� ���������� �ִ� ��� ���������� curHP�� �����ϸ�, ���� curHP�� 0 ���ϰ� �Ǵ� ��� ������ ����˴ϴ�.
public class PlayerMove : AttackableObject
{
    float currentCoolTime;
    bool Attacking;

    [SerializeField]
    public BoxCollider2D BC;
    public Rigidbody2D RB;
    public SpriteRenderer SR;

    // �̵��ӵ�
    // �̵��ӵ��� �������� ����.
    public float SpeedX;                    // x�� �̵��ӵ�
    public float SpeedY;                    // y�� �̵��ӵ�
    /////////////////////


    // ���� ����
    // ü��, ���ݷ�, ������ ���� Ŭ������ ����
    // �⺻ ������ ������ �����ϸ�, ���� �������� ������.
    // ��� ���� ���� ������ ��������� ������.
                      
    public float AttackCoolTime;            // ���� �ӵ�(��Ÿ��)
    public float Lethality;                 // �����% (0~1)

    public float CriticalDamage;            // ġ��Ÿ ������
    public float CriticalProbability;       // ġ��Ÿ Ȯ��
                                            /////////////////////

    // ���� ����
    // 0~100 ���� ������. / 0�̸�, 100 �ʰ��� ������ �������� ����.
    // ������ ���ӵɼ��� �����ϸ�, �Ҹ� �����۰� ��� �̿��� ��ġ�� ������ �� ����.

    public int fatigue;                     // �Ƿε��� �������� �޴� �������� ������. (���� ����) / Ŀ�Ǹ� ���ø� �����մϴ�.
    public int concentration;               // ���߷��� �������� ȹ���ϴ� �ڿ��� ������. (������ �� ����ġ ȹ�� ��, ���� ����)
    public int sociability;                 // �米���� �������� �ִ� �������� ������. (�����, ġ��Ÿ ��� ����)
    public int health;                      // ü���� �������� �ִ� HP�� ������. (HP ����)
    public int caffeine;                    // ī���� ��ġ�� �������� Ŀ�Ǹ� �������� �����ϴ� ü���� �پ��ϴ�. Ŀ�Ǹ� ������ ������ ȸ���˴ϴ�.

    // ���� ������ ��ġ�� �����ϱ� ���� �����Դϴ�.
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

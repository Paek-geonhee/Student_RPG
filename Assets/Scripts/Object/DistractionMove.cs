using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �� : �길��
// ���θ� �����ϴ� �������� ��ҵ��̿���.
// ����Ʈ��, ģ�� �� ���� ��Ұ� ���� �����ϹǷ�
// ���� �ǵ帮�� ���� ����ġ����.
// ���� �� ���� �浹�ϰų� �����Ѵٸ� ���߷��� ��������.

// �ð��� ������ ������ϴ�.
public class DistractionMove : MobController
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        // �ش������Ʈ�� 10�� �� �ƹ� ��ġ�� �̵��մϴ�.
        // 10�ʰ� ������ ������ϴ�.
    }
}

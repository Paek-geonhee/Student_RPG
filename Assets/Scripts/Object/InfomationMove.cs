using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� : �������� ����
// �������� ������ �� �����ؿ�.
// �������� ������ óġ�ϸ� ����ġ�� ��带 ȹ���ؿ�.
public class InfomationMove : MobController
{
    //public float goldDrop;
    public float expDrop;
    // Start is called before the first frame update

    void RewardSetting() {
        //goldDrop = Random.Range(10, 100) * Level / 2f;
        expDrop = Random.Range(10, 100) * Level / 2f;
    }
    void Start()
    {
        Init();
        RewardSetting();
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾ ���� �����̰ų� �������� ��ġ�� �̵��մϴ�.
        // �÷��̾ ���� ������ �ִٸ� ������ �õ��մϴ�.
        // óġ�Ǵ� ���, �÷��̾�� ������ �ݴϴ�.
    }
}

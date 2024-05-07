using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몹 : 교수님의 설명
// 교수님의 설명을 잘 들어야해요.
// 교수님의 설명을 처치하면 경험치와 골드를 획득해요.
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
        // 플레이어를 향해 움직이거나 무작위의 위치로 이동합니다.
        // 플레이어가 공격 범위에 있다면 공격을 시도합니다.
        // 처치되는 경우, 플레이어에게 보상을 줍니다.
    }
}

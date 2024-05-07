using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 몹 : 산만함
// 공부를 방해하는 여러가지 요소들이에요.
// 스마트폰, 친구 등 여러 요소가 나를 방해하므로
// 절대 건드리지 말고 도망치세요.
// 만약 이 몹과 충돌하거나 공격한다면 집중력이 떨어져요.

// 시간이 지나면 사라집니다.
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
        // 해당오브젝트는 10초 간 아무 위치로 이동합니다.
        // 10초가 지나면 사라집니다.
    }
}

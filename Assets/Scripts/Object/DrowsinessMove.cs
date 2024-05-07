using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몹 : 졸음
// 이 몹을 시간안에 잡지 못하면 
// 교수님의 설명을 들을 기회가 줄어들어요.
// 이 몹을 직접 처치하지 않은채로 몹이 사라지면
// HP가 크게 감소해요.
public class DrowsinessMove : MobController
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // 해당 오브젝트는 플레이어를 향해 천천히 움직입니다. 
        // 시간이 지나면 저절로 사라지지만, 시간 초과로 사라지는 경우
        // 플레이어의 스텟을 감소시킵니다.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템을 위한 스크립트입니다.
// 아이템 정보를 기본적으로 담고 있고 착용 아이템, 소비 아이템, 펫 류는 따로 정의됩니다.
// 해당 스크립트는 컴포넌트로 사용하지는 않으나, InventoryManager에서 미리 정의하여 활용합니다.
// Inventory에서 정의 시, 기본적으로 배열에 저정할때, 아이템 ID가 인덱스입니다.

public class Item : MonoBehaviour
{
    public SpriteRenderer SR;

    [Header("Item Info")]
    public int ID;
    public string Name;
    public string Description;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

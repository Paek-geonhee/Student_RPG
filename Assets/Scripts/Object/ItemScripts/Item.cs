using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ���� ��ũ��Ʈ�Դϴ�.
// ������ ������ �⺻������ ��� �ְ� ���� ������, �Һ� ������, �� ���� ���� ���ǵ˴ϴ�.
// �ش� ��ũ��Ʈ�� ������Ʈ�� ��������� ������, InventoryManager���� �̸� �����Ͽ� Ȱ���մϴ�.
// Inventory���� ���� ��, �⺻������ �迭�� �����Ҷ�, ������ ID�� �ε����Դϴ�.

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

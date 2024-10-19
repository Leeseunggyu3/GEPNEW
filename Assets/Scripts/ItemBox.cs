using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Sprite openImage; //���� �̹���
    public GameObject itemPrefab; //��� �������� ������
    public bool isClosed = true; // true �����ִ� false �����ִ�
    public int arrangedId = 0; //��ġ �ĺ��� ���
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //����(����)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isClosed && collision.gameObject.tag == "Player")
        {
            //���ڰ� ���� �ִ� ���¿��� �÷��̾�� ����
            GetComponent<SpriteRenderer>().sprite = openImage;
            isClosed = false; //���� ���·� �ϱ�
            if(itemPrefab != null)
            {
                //���������� ������ �����
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}

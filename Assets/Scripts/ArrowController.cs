using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called before the first frame update
    public float deleteTime = 2;
    void Start()
    {
        Destroy(gameObject,deleteTime); //���� �ð� �� �����ϱ�   
    }
    //���� ������Ʈ�� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //������ ���� ������Ʈ�� �ڽ����� �����ϱ�
        transform.SetParent(collision.transform);
        //�浹 ������ ��Ȱ��
        GetComponent<CircleCollider2D>().enabled = false;
        //���� �ùķ��̼��� ��Ȱ��
        GetComponent<Rigidbody2D>().simulated = false;
    }

}

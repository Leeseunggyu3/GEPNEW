using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ա� ��ġ
public enum ExitDirection
{
    right, //������
    left, //����
    down, //�Ʒ���
    up, //����
}

public class Exit : MonoBehaviour
{

    public string sceneName = ""; //�̵��� �� �̸�
    public int doorNumber = 0; //�� ��ȣ
    public ExitDirection direction = ExitDirection.left; //���� ��ġ

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            RoomManager.ChangeScene(sceneName, doorNumber);
        }
    }
}

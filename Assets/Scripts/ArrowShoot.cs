using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float shootSpeed = 12.0f;
    public float shootDelay = 0.25f;
    public GameObject bowPrefab;
    public GameObject arrowPrefab;

    bool inAttack = false; //���� �� ����
    GameObject bowObj;

    void Start()
    {
        //Ȱ�� �÷��̾� ĳ���Ϳ� ��ġ
        Vector3 pos = transform.position;
        bowObj = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObj.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetButtonDown("Fire3")))
        {//����Ű�� ����
            Attack();
        }
        //Ȱ�� ȸ���� �켱����
        float bowZ = -1; //Ȱ�� Z �� (ĳ���ͺ��� ������ ����)
        PlayerController plmv = GetComponent<PlayerController>();
        if (plmv.angleZ > 30 && plmv.angleZ < 150)
        {
            //�� ����
            bowZ = 1; //Ȱ�� Z �� (ĳ���ͺ��� �ڷ� ����)
        }
        //Ȱ�� ȸ��
        bowObj.transform.rotation = Quaternion.Euler(0, 0, plmv.angleZ);
        //Ȱ�� �켱����
        bowObj.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);
    }
    //����
    public void Attack()
    {

        //ȣ�ä����� ������ ���� & ���� ���� �ƴ�
        if (ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows -= 1; //ȭ���� �Ҹ�
            inAttack = true; //���� ������ ����
            //ȭ��߻�
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ; //ȸ�� ����
            //ȭ���� ���� ������Ʈ �����(���� �������� ȸ��)
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position, r);
            //ȭ���� �߻��� ���� ����
            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            Vector3 v = new Vector3(x, y) * shootSpeed;
            //ȭ�쿡 ���� ���ϱ�
            Rigidbody2D body = arrowObj.GetComponent<Rigidbody2D> ();
            body.AddForce (v,ForceMode2D.Impulse);
            //���� ���� �ƴ����� ����
            Invoke("StopAttack", shootDelay);
        }
    }
    //���� ����
    public void StopAttack()
    {
        inAttack = false; //���� ���� �ƴ����� ����
    }



}

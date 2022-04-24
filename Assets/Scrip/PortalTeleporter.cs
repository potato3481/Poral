using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform Player;
    public Transform reciever;

    private bool PlayersOverlapping = true;
    
    void Update()
    {
        //T0 �÷��̾� ��ž  = �÷��̾��
        if (PlayersOverlapping)
        {
            //To�÷��̾� ��ž = �÷��̾� . ��ġ- ��ȯ .��ġ
            Vector3 portalToPlayer = Player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);


            //�̰��� ����̶�� : �÷��̾ ������ �������� �̵��߽��ϴ�
            if (dotProduct < 0f)
        {
            float rotaitionDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
            //ȸ�� ����+= 180;
            //�÷��� ȸ�� (���� ) �� , ȸ�� ����
            rotaitionDiff += 180;
            Player.Rotate(Vector3.up, rotaitionDiff);

            //����3 ��ġ ������  =���ʹϿ� .���Ϸ� (0f ,ȸ�� ����,0f )* ��žTOPlayer 
            Vector3 PositionOffset = Quaternion.Euler(0f, rotaitionDiff, 0f) * portalToPlayer;
            //�÷��̾� ��ġ = reciever��ġ +������;
            Player.position = reciever.position + PositionOffset;
            //�÷��̾� �������� = ���� 
            PlayersOverlapping = false;
        }
        }
    }
    //����
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //�÷��̾� �������� = ��� 
            PlayersOverlapping = false;
          
        }
    }
    //����
   void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayersOverlapping = true;
           
        }
    }
}

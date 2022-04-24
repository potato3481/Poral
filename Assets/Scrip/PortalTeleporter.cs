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
        //T0 플레이어 포탑  = 플레이어어
        if (PlayersOverlapping)
        {
            //To플레이어 포탑 = 플레이어 . 위치- 변환 .위치
            Vector3 portalToPlayer = Player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);


            //이것이 사실이라면 : 플레이어가 포털을 가로질러 이동했습니다
            if (dotProduct < 0f)
        {
            float rotaitionDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
            //회전 디프+= 180;
            //플레이 회전 (백터 ) 업 , 회전 디프
            rotaitionDiff += 180;
            Player.Rotate(Vector3.up, rotaitionDiff);

            //백터3 위치 오프셋  =쿼터니온 .오일러 (0f ,회전 디프,0f )* 포탑TOPlayer 
            Vector3 PositionOffset = Quaternion.Euler(0f, rotaitionDiff, 0f) * portalToPlayer;
            //플레이어 위치 = reciever위치 +오프셋;
            Player.position = reciever.position + PositionOffset;
            //플레이어 오버랩핑 = 거짓 
            PlayersOverlapping = false;
        }
        }
    }
    //시작
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //플레이어 오버랩핑 = 사실 
            PlayersOverlapping = false;
          
        }
    }
    //종료
   void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayersOverlapping = true;
           
        }
    }
}

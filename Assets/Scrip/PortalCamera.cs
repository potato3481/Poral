using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    //만들다 플레이어 카메라 
    public Transform PlayerCamera;
    //포탑 
    public Transform portal;
    //포탑을 공개 변환 
    public Transform otherPortal;

    private void Update()
    {
        Vector3 PlayerOffsetFormPortal = PlayerCamera.position - otherPortal.position;
        //변환한다 위치 = 포탑위치 + 플레이어 오프셋 포탑 
        transform.position = portal.position + PlayerOffsetFormPortal;

        //각도 차이 포탑 로테이션 = 쿼터니온 각도 (포탑,회전,기타 포탑 ,회전 
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        //포탑 회전 자치 = 쿼터니온.앵글 액스 (각도 차이 포탑 회전 백터 3위로 ) 
        Quaternion portalRotationaiDfference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);

        Vector3 newCameraDirection = portalRotationaiDfference * PlayerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);


    }
}

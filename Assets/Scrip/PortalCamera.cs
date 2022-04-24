using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    //����� �÷��̾� ī�޶� 
    public Transform PlayerCamera;
    //��ž 
    public Transform portal;
    //��ž�� ���� ��ȯ 
    public Transform otherPortal;

    private void Update()
    {
        Vector3 PlayerOffsetFormPortal = PlayerCamera.position - otherPortal.position;
        //��ȯ�Ѵ� ��ġ = ��ž��ġ + �÷��̾� ������ ��ž 
        transform.position = portal.position + PlayerOffsetFormPortal;

        //���� ���� ��ž �����̼� = ���ʹϿ� ���� (��ž,ȸ��,��Ÿ ��ž ,ȸ�� 
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        //��ž ȸ�� ��ġ = ���ʹϿ�.�ޱ� �׽� (���� ���� ��ž ȸ�� ���� 3���� ) 
        Quaternion portalRotationaiDfference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);

        Vector3 newCameraDirection = portalRotationaiDfference * PlayerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);


    }
}

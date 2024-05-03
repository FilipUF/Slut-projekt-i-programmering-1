using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplingHook_02 : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplepoint;
    public LayerMask whatIsGrappable;
    [SerializeField] Transform grappleTip, player;
    private float maxDistance = 100f;
    RaycastHit hit;
    private SpringJoint joint;
    
    
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            stopGrapple();
        }  

       
    }
    void startGrapple()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z));
        Vector3 mouseDirection = spawnPosition - transform.position;



        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), mouseDirection, out hit, maxDistance))
        {
            grapplepoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplepoint;
            float distanceFromPoint = Vector3.Distance(a: player.position, b: grapplepoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.maxDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;

        }
    }

    void stopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private void LateUpdate()
    {
        drawRope();
    }
    void drawRope()
    {    if (!joint) return;
            lr.SetPosition(index: 0, grappleTip.position);
            lr.SetPosition(index: 1, grapplepoint);
    }
}

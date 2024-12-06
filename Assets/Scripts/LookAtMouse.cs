using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Camera cam;
    public LayerMask mask;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, mask))
        {
            Vector3 targetDirection = hit.point - transform.position;
            Vector3 tankUp = transform.parent.up;
            targetDirection = Vector3.ProjectOnPlane(targetDirection, tankUp); 
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, tankUp);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 4f);
        }
    }
}

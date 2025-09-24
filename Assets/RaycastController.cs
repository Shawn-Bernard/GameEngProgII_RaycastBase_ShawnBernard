using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastController : MonoBehaviour
{
    public Camera camera;

    private RaycastHit raycastHit;

    private float distants = 10;

    MeshRenderer hitMesh => raycastHit.collider.GetComponent<MeshRenderer>();

    public LayerMask ignoreMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward,out raycastHit, 10))
            {
                if (raycastHit.collider.CompareTag("Target"))
                {
                    hitMesh.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                }
                Debug.Log("Hit: " + raycastHit.collider.name + " from " + raycastHit.distance);
                Debug.DrawLine(camera.transform.position, camera.transform.forward);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out raycastHit, 10))
            {
                if (raycastHit.collider.excludeLayers == ignoreMask)
                {
                    Debug.Log($"Pass though {raycastHit.collider.name} ignore target");
                    if (Physics.Raycast(camera.transform.position, camera.transform.forward, out raycastHit, 10))
                    {
                        Debug.Log("Hit: " + raycastHit.collider.name + " from " + raycastHit.distance);
                        Debug.DrawLine(camera.transform.position, camera.transform.forward);
                    }
                }
                
            }
        }
    }
}

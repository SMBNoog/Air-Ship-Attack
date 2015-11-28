#region namespace and class declaration
using UnityEngine;
using System.Collections;

public class LockCamera : MonoBehaviour
{
    #endregion

    #region Variables: Speed of the Lerp motion to follow the player and the player gameobject.
    public float smoothing = 2f;
    private GameObject player_Obj;
    private Rigidbody camera_Rigidbody;
    private Vector3 lastTargetPosition;
    private Vector3 cameraPos;
    private bool playerFound = false;

    #endregion

    void Start()
    {
        camera_Rigidbody = GetComponent<Rigidbody>();
        cameraPos = new Vector3(transform.position.x, transform.position.y, -240);
    }

    //#region Update: Find the player gameobject and set the camera's postion relative to the player using an offset.
    void Update()
    {
        if (player_Obj == null)
        {
            if (FindObjectOfType<PlayerController>().gameObject != null)
            {
                player_Obj = FindObjectOfType<PlayerController>().gameObject;
                playerFound = true;
            }
                
        }

        //    Vector3 offSet = new Vector3(0, 150, 0);
        //    cameraPos = new Vector3(transform.position.x, transform.position.y, -240);
        //    transform.position = Vector3.Lerp(cameraPos, player_Obj.transform.position + offSet, Time.deltaTime * smoothing);
    }
    //#endregion

    void FixedUpdate()
    {
        if(playerFound)
        {
            Vector3 MoveDirection = (player_Obj.transform.position - transform.position).normalized;
            float distanceBetweenTargetandCamera = Vector3.Distance(transform.position, player_Obj.transform.position);

            camera_Rigidbody.velocity = MoveDirection * distanceBetweenTargetandCamera * Time.deltaTime * smoothing;

            lastTargetPosition = player_Obj.transform.position;
        }
    }
}

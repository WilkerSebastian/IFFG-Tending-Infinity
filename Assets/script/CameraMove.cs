using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Camera mainCamera;
    public Player player1;
    private float smoothness = 3f;

    void Update() {

        Vector3 targetPosition = new Vector3(player1.rb.position.x, player1.rb.position.y, mainCamera.transform.position.z);

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * smoothness);
    
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //public float input;
    public GameObject player;
    public GameObject[] cameraPositions;
    public carController controller;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<carController>();
        //controller.CamTarget.transform.GetChild(0);
    }

    void FixedUpdate()
    {
        //input = Input.GetAxis("Horizontal");
        gameObject.transform.position = controller.CamTarget.transform.GetChild(0).transform.position;
        //gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + input, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        gameObject.transform.LookAt(controller.CamTarget.transform.GetChild(1).transform.position);
    }
}

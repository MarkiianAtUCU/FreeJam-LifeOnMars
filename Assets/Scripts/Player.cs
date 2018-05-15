using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public GameObject camera;

    public GameObject Launcher;
    public GameObject Laser;
    public GameObject Tesla;
    // 1-RocketLauncher
    // 2-Laser
    // 3-TeslaGun

    public Image LaserHolder;
    public Image LauncherHolder;


    CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;


    // Update is called once per frame
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update () {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;
        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
           
            transform.rotation=Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = camera.transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            moveDirection.y = 0;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            LaserHolder.enabled = false;
            LauncherHolder.enabled = true;

            Debug.Log("Louncher");
            Laser.SetActive(false);
            Tesla.SetActive(false);
            Launcher.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            LaserHolder.enabled = true;
            LauncherHolder.enabled = false;
            Laser.SetActive(true);
            Tesla.SetActive(false);
            Launcher.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            Laser.SetActive(false);
            Tesla.SetActive(true);
            Launcher.SetActive(false);
        }
        if (Input.GetKey(KeyCode.C))
        {
            LaserHolder.enabled = false;
            LauncherHolder.enabled = false;
            Laser.SetActive(false);
            Tesla.SetActive(false);
            Launcher.SetActive(false);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float minXCoords = 4.2f;
    [SerializeField] float maxXCoords = 31.6f;
    [SerializeField] float minYCoords = -7.8f;
    [SerializeField] float maxYCoords = -2.5f;

    Vector3 origin;
    Vector3 difference;
    Vector3 reset;

    bool drag = false;
    bool canMove = true;

    void Start()
    {
        reset = Camera.main.transform.position;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;

            if (drag == false)
            {
                drag = true;

                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag & canMove)
        {
            Camera.main.transform.position = origin - difference;
        }

        if (Camera.main.transform.position.x > maxXCoords)
        {
            Camera.main.transform.position = new Vector3(maxXCoords, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }

        if (Camera.main.transform.position.x < minXCoords)
        {
            Camera.main.transform.position = new Vector3(minXCoords, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }

        if (Camera.main.transform.position.y > maxYCoords)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, maxYCoords, Camera.main.transform.position.z);
        }

        if (Camera.main.transform.position.y < minYCoords)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, minYCoords, Camera.main.transform.position.z);
        }

        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = reset;
        }
    }

    public void CamCanMove()
    {
        canMove = true;
    }

    public void CamStop()
    {
        canMove = false;
    }
}

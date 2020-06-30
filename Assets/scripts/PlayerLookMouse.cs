using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerLookMouse : MonoBehaviour
{
    private Vector3 mousePos;
    public Transform target;
    private Vector3 objPos;
    private float angle;

    void Update()
    {
        if (Player.Vivo == true)
        {
            Function();
        }
    }
    void Function()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        objPos = Camera.main.WorldToScreenPoint(target.position);

        mousePos.x = mousePos.x - objPos.x;
        mousePos.y = mousePos.y - objPos.y;

        angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(180, 0, angle);
    }
}

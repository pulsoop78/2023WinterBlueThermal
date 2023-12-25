using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Setting")]
    [SerializeField]
    private float _smooth;
    [SerializeField]
    private float _multiplier;

    private void Update()
    {
        Sway();
    }

    private void Sway()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * _multiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _multiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, _smooth * Time.deltaTime);
    }
}
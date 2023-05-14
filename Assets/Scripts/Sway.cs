using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField]
    private float _intensity;
    [SerializeField]
    private float _smooth;

    private Quaternion _originRotation;


    private void Start()
    {
        _originRotation = transform.localRotation;
    }

    private void Update()
    {
        UpdateSway();
    }

    private void UpdateSway()
    {
        //controls 
        float t_x_mouse = Input.GetAxis("Mouse X");
        float t_y_mouse = Input.GetAxis("Mouse Y");

        //calculate rotation
        Quaternion t_x_adj = Quaternion.AngleAxis(_intensity * t_x_mouse * -1, Vector3.up); //adjustment
        Quaternion t_y_adj = Quaternion.AngleAxis(_intensity * t_y_mouse, Vector3.right); 
        Quaternion target_rotation = _originRotation * t_x_adj * t_y_adj;

        //rotate towards to the tarhet rotaion 
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target_rotation, Time.deltaTime * _smooth);
    }
}

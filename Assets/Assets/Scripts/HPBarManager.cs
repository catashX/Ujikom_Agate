using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarManager : MonoBehaviour
{
    [SerializeField] Transform targetFollow;
    [SerializeField] Camera targetCamera;
    [SerializeField] RectTransform greenBar;
    private void Start()
    {
        targetCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    public void set(Transform _target)
    {
        targetFollow = _target;
    }

    public void setScale(float _scale)
    {
        greenBar.localScale = new Vector3(_scale, 1, 1);
    }

    private void Update()
    {
        transform.position = targetCamera.WorldToScreenPoint(targetFollow.position);
    }
}

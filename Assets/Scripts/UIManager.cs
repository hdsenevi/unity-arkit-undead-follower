using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class UIManager : MonoBehaviour
{
    public UnityARGeneratePlane generatePlanes;
    private Animator _animator;
    private float _deltaTime = 0f;


    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        EnableUIPanel();
    }

    public void EnableUIPanel()
    {
        if (_animator == null)
        {
            return;
        }

        _deltaTime = 0f;

        _animator.SetBool("enableUI", true);
    }

    public void ToggleDebugPlanes()
    {
        if (generatePlanes == null)
            return;

        generatePlanes.gameObject.SetActive(!generatePlanes.gameObject.activeSelf);
    }
}

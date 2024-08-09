using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraRoot : MonoBehaviour
{
    Quaternion rotation;
    [Inject] Player player;
    PlayerInputSystem _input;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
        _input = player.GetComponent<PlayerInputSystem>();
    }

    private void Update()
    {
        CalculateTargetRotate();
        transform.rotation = rotation;
    }

    void CalculateTargetRotate()
    {
        Vector3 currentEulerAngles = rotation.eulerAngles;
        currentEulerAngles.y += _input.DeltaLook;
        rotation.eulerAngles = currentEulerAngles;

        _input.DeltaLook = 0;
    }
}

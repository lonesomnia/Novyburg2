using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using UnityEngine.Splines;
using System;
using UnityEngine.UIElements;


public class CCamConroller : MonoBehaviour
{
    public SplineContainer splineContainer;
    public CinemachineCamera playerCamera;
    public CinemachineSplineDolly dolly;
    public CinemachinePanTilt panTilt;

    //  [SerializeField] private float moveSpeed = 0f;

    private int splineIndex = 0;
    private bool pathEnd;

    private float pan;
    private float tilt;

    [Header("FOV Ì‡ÒÚÓÈÍË")]
    public float minFOV = 40f;
    public float maxFOV = 70f;

    [Header("Tilt ‰Ë‡Ô‡ÁÓÌ")]
    public float minTilt = -60f;
    public float maxTilt = 60f;

    void Start()
    {
        panTilt.enabled = false;

        var spline = splineContainer.Splines[splineIndex];
        int lastIndex = spline.Count - 1;
        BezierKnot lastKnot = spline[lastIndex];

        //  Vector3 direction = (lastKnot.TangentOut);
        //  direction = splineContainer.transform.TransformDirection(direction);


        //  Vector3 up = Vector3.up;
        //  Quaternion lookRotation = Quaternion.LookRotation(direction, up);
        //  Vector3 eulerAngles = lookRotation.eulerAngles;

        //  pan = eulerAngles.y;
        //  tilt = eulerAngles.x;



        //  Vector3 direction = new Vector3(lastKnot.Position.x, lastKnot.Position.y, lastKnot.Position.z);
        //  Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        //  direction.Normalize();
        //  Vector3 euler = rotation.eulerAngles;

        //  float pan = euler.y;
        //  float tilt = euler.x;
    }

    void Update()
    {
        TrackPath();
        InvokeEvent();
        //  ChangeFOV
    }

    private void TrackPath()
    {
        if (dolly.CameraPosition >= 1f)
        {
            pathEnd = true;
        }
    }

    private void InvokeEvent()
    {
        if (pathEnd == true)
        {
            panTilt.enabled = true;

        //    panTilt.PanAxis.Value = pan;
        //    panTilt.TiltAxis.Value = tilt;

            /// ÀŒ√» ¿ »Õ“≈–¿ “»¬¿ ///
        }
    }

    private void ChangeFOV()
    {
        float tilt = panTilt.TiltAxis.Value;
        float t = Mathf.InverseLerp(minTilt, maxTilt, tilt);
        float targetFOV = Mathf.Lerp(minFOV, maxFOV, t);
        playerCamera.Lens.FieldOfView = targetFOV;
    }
}


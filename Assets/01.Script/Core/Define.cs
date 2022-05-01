using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    private static Camera mainCam;
    public static Camera MainCam
    {
        get
        {
            mainCam ??= Camera.main;
            return mainCam;
        }
    }

    private static CinemachineVirtualCamera cmVcam;
    public static CinemachineVirtualCamera VCam
    {
        get
        {
            cmVcam ??= GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            return cmVcam;
        }
    }

    public enum ResourceTypeEnum
    {

    }
}

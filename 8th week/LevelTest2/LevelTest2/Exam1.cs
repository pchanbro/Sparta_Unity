using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

// 문제 링크
// https://teamsparta.notion.site/Unity-6-Unity-1282dc3ef5148020aa3ce9693d395a14

namespace LevelTest2
{
    internal class Exam1
    {
        void CameraLook()
        {
            camCurXRot +=  ㉠ : mouseDelta.y * lookSensitivity;
            camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);

            float YRot = CameraContainer.localEulerAngles.y +  ㉡ mouseDelta.x * lookSensitivity;

            CameraContainer.localEulerAngles = new Vector3(-camCurXRot, YRot, 0);
        }
    }
}


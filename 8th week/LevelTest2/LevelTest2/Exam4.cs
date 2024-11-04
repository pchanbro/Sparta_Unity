using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LevelTest2
{
    internal class Exam4
    {
        private Ray returnInteractionRay()
        {
            Ray ray;
            if (nowFirstPerson)
            {
                //TODO
                //camera를 활용할 것
                ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            }
            else
            {
                //TODO
                //interactionRayPointTransform를 활용할 것
                ray = new Ray(interactionRayPointTransform.position, interactionRayPointTransform.forward);
            }
            return ray;
        }
    }
}

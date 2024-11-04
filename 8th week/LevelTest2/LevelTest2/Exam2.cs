using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LevelTest2
{
    internal class Exam2
    {

    }

    public class CampFire : MonoBehaviour
    {
        private int damage = 5;
        private float damageRate = 1;

        private List< ㉠ : IDamagable > things = new List< ㉡ : IDamagable >();

        private void Start()
        {
            InvokeRepeating("DealDamage", 0, damageRate);
        }

        void DealDamage()
        {
            for (int i = 0; i < things.Count; i++)
            {
                things[i]. ㉢ : TakePhysicalDamage ( ㉣ : damage );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ㉤ : IDamagable  target))
        {
            things.Add(target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ㉥ : IDamagable  target))
        {
            things.Remove(target);
        }
    }
}

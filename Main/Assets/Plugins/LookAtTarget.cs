using System;
using UnityEngine;

namespace ChuongLibrary.Game2D
{
    public static class LookAtTargetClass
    {
        // Overload gốc: theLooker, target là Vector3.
        // Offset là góc bù (góc bù này dương thì quay cùng chiều kim đồng hồ). Góc ban đầu là hướng sang phải
        public static Quaternion LookAtTarget(Vector3 theLooker, Vector3 target, float offsetAngle = 0)
        {
            var diff = (target - theLooker).normalized;
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, rotZ + offsetAngle);
        }

        // Overload 1: target là Transform.
        public static Quaternion LookAtTarget(Vector3 theLooker, Transform target, float offsetAngle = 0)
            => LookAtTarget(theLooker, target.position, offsetAngle);

        // Overload 2: theLooker là Transform.
        public static Quaternion LookAtTarget(Transform theLooker, Vector3 target, float offsetAngle = 0)
        {
            theLooker.rotation = LookAtTarget(theLooker.position, target, offsetAngle);
            return theLooker.rotation;
        }

        // Overload 3: theLooker, target là Transform.
        public static Quaternion LookAtTarget(Transform theLooker, Transform target, float offsetAngle = 0)
            => LookAtTarget(theLooker, target.position, offsetAngle);

        // Overload 4: Hàm gốc nhưng trả về void
        public static void LookAtTarget(Transform theLooker, Vector3 target, string forVoid, float offsetAngle = 0)
            => theLooker.rotation = LookAtTarget(theLooker, target, offsetAngle);

        // Overload 5: target là Transform
        public static void LookAtTarget(Transform theLooker, Transform target, string forVoid, float offsetAngle = 0)
            => LookAtTarget(theLooker, target.position, forVoid, offsetAngle);

        // gần giống cái phía trên, nhưng là quay dần dần
        public static void GraduallyLookAtTarget(Transform rotater, float rotSpeed, Vector3 target,
            float offsetAngle = 0)
        {
            var targetRot = LookAtTarget(rotater.position, target, offsetAngle);
            rotater.rotation = Quaternion.Lerp(rotater.rotation, targetRot, rotSpeed * Time.deltaTime);
        }

        // Overload 1: target là Transform
        public static void GraduallyLookAtTarget(Transform rotater, float rotSpeed, Transform target,
            float offsetAngle = 0)
        {
            var targetRot = LookAtTarget(rotater.position, target, offsetAngle);
            rotater.rotation = Quaternion.Lerp(rotater.rotation, targetRot, rotSpeed * Time.deltaTime);
        }
    }
}
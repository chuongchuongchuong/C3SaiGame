using System;
using UnityEngine;

namespace ChuongLibrary.GameDev
{
    public static class Game2D
    {
        // Hàm gốc: target là Vector3. Hướng của theLooker ban đầu là hướng sang phải
        public static void LookAtTarget(Transform theLooker, Vector3 target)
        {
            var diff = (target - theLooker.position).normalized;
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            theLooker.rotation = Quaternion.Euler(0, 0, rotZ);
        }

        // Overload 1: target là Transform
        public static void LookAtTarget(Transform theLooker, Transform target)
        {
            LookAtTarget(theLooker, target.position);
        }

        // Overload 2: target là Vector3, thêm offset góc (góc bù này dương thì quay cùng chiều kim đồng hồ)
        public static void LookAtTarget(Transform theLooker, Vector3 target, float offsetAngle)
        {
            var diff = (target - theLooker.position).normalized;
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            theLooker.rotation = Quaternion.Euler(0, 0, rotZ + offsetAngle);
        }

        // Overload 3: target là Transform, thêm offset góc (góc bù này dương thì quay cùng chiều kim đồng hồ)
        public static void LookAtTarget(Transform theLooker, Transform target, float offsetAngle)
        {
            LookAtTarget(theLooker, target.position, offsetAngle);
        }

        //Overload 4: theLooker là 1 Vector3 vị trí. Hàm trả về Quaternion, khi theLooker chưa được spawn ra transform
        public static Quaternion LookAtTarget(Vector3 theLooker, Vector3 target)
        {
            var diff = (target - theLooker).normalized;
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, rotZ);
        }

        // Overload 5: theLooker là 1 Vector3 vị trí. target là Transform
        public static Quaternion LookAtTarget(Vector3 theLooker, Transform target)
        {
            return LookAtTarget(theLooker, target.position);
        }

        // Overload 6: target là Vector3, thêm offset góc (góc bù này dương thì quay cùng chiều kim đồng hồ)
        public static Quaternion LookAtTarget(Vector3 theLooker, Vector3 target, float offsetAngle)
        {
            var diff = (target - theLooker).normalized;
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, rotZ + offsetAngle);
        }

        // Overload 7: target là Transform, thêm offset góc (góc bù này dương thì quay cùng chiều kim đồng hồ)
        public static Quaternion LookAtTarget(Vector3 theLooker, Transform target, float offsetAngle)
        {
            return LookAtTarget(theLooker, target.position, offsetAngle);
        }

        //Hàm lấy 1 điểm random nằm bên ngoài màn hình
        public static Vector3 RandomPointOutsideScreen(Camera camera)
        {
            //Xác định vị trí của điểm trong góc trái phía dưới màn hình
            var bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
            //Xác định vị trí của điểm trong góc trên bên phải màn hình
            var topRight = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.nearClipPlane));

            //Tính bán kính của hình tròn có tâm là tâm màn hình, đường kính chính là đường chéo hình chữ nhật màn hình
            var screenRadius = Vector2.Distance(bottomLeft, topRight) / 2f;

            // Tìm điểm random trong hình tròn bán kính `screenRadius`
            var randomDirection = UnityEngine.Random.insideUnitCircle.normalized; // Vector ngẫu nhiên, chuẩn hóa

            // Khoảng cách nằm ngoài bán kính màn hình
            var randomDistance = UnityEngine.Random.Range(screenRadius + .1f, screenRadius + 1f);
            var randomPoint = camera.transform.position +
                              new Vector3(randomDirection.x, randomDirection.y, 0) * randomDistance;

            return randomPoint;
        }


        public static Vector3 RandomPositionInCircle(Vector3 circleCenter, float radius)
        {
            // Tạo điểm ngẫu nhiên trong hình tròn 2D (mặt phẳng XY)
            var randomPoint2D = UnityEngine.Random.insideUnitCircle * radius;

            // Đổi từ Vector2 thành Vector3 (giữ nguyên giá trị Z của vị trí gốc)
            return new Vector3(circleCenter.x + randomPoint2D.x, circleCenter.y + randomPoint2D.y, circleCenter.z);
        }
    }
}
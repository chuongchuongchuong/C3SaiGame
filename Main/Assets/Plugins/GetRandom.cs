using System;
using UnityEngine;
using DG.Tweening;

namespace ChuongLibrary.Game2D
{
    public static class GetRandom
    {
        //Hàm lấy 1 điểm random nằm bên ngoài màn hình
        public static Vector3 RandomPointOutsideScreen(Camera camera)
        {
            //Xác định vị trí của điểm trong góc trái phía dưới màn hình
            var bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
            //Xác định vị trí của điểm trong góc trên bên phải màn hình
            var topRight = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.nearClipPlane));

            //Tính bán kính của hình tròn có tâm là tâm màn hình, đường kính chính là đường chéo hình chữ nhật màn hình
            var screenRadius = Vector2.Distance(bottomLeft, topRight) / 2f;
            Debug.Log(screenRadius);

            // Tìm điểm random trong hình tròn bán kính `screenRadius`
            var randomDirection = UnityEngine.Random.insideUnitCircle.normalized; // Vector ngẫu nhiên, chuẩn hóa

            // Khoảng cách nằm ngoài bán kính màn hình
            var randomDistance = UnityEngine.Random.Range(screenRadius + .1f, screenRadius + 1f);
            var randomPoint = camera.transform.position +
                              new Vector3(randomDirection.x, randomDirection.y, 0) * randomDistance;

            return randomPoint;
        }

        //Hàm lấy 1 điểm bên trong 1 hình tròn
        public static Vector3 RandomPositionInCircle(Vector3 circleCenter, float radius)
        {
            // Tạo điểm ngẫu nhiên trong hình tròn 2D (mặt phẳng XY)
            var randomPoint2D = UnityEngine.Random.insideUnitCircle * radius;

            // Đổi từ Vector2 thành Vector3 (giữ nguyên giá trị Z của vị trí gốc)
            return new Vector3(circleCenter.x + randomPoint2D.x, circleCenter.y + randomPoint2D.y, circleCenter.z);
        }

        //Hàm để 1 vật đi xung quanh vật khác
        public static void AGoCircleAroundB(Transform objectA, Vector3 centerPoint, float duration)
        {
            var radius = Vector2.Distance(objectA.position, centerPoint);

            DOTween.To
                (
                    () => 0f, // góc ban đầu
                    UpdatePosition,
                    Mathf.PI * 2, // Góc 360 độ (2π radian)
                    duration
                )
                .SetEase(Ease.Linear) // Quay đều
                .SetLoops(-1, LoopType.Restart); // Quay vòng lặp vô hạn
            return;

            void UpdatePosition(float angle)
            {
                var x = Mathf.Cos(angle) * radius;
                var y = Mathf.Sin(angle) * radius;

                objectA.position = new Vector3(x, y, 0) + centerPoint; // Gán vị trí mới cho objectA
            }
        }
    }
}
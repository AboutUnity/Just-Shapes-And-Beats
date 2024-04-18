using UnityEngine;

namespace YNL.Extension.Method
{
    // Virtual User Interface
    public static class MVUI
    {
        /// <summary>
        /// Draws just the box at where it is currently hitting.
        /// </summary>
        public static void DrawBoxCastOnHit(Vector3 origin, Vector3 halfExtents, Quaternion orientation, Vector3 direction, float hitInfoDistance, Color color)
        {
            origin = CastCenterOnCollision(origin, direction, hitInfoDistance);
            DrawBox(origin, halfExtents, orientation, color);
        }

        /// <summary>
        /// Draws the full box from start of cast to its end distance. Can also pass in hitInfoDistance instead of full distance.
        /// </summary>
        public static void DrawBoxCast(Vector3 origin, Vector3 halfExtents, Quaternion orientation, Vector3 direction, float distance, Color color)
        {
            direction.Normalize();
            MBox bottomBox = new MBox(origin, halfExtents, orientation);
            MBox topBox = new MBox(origin + (direction * distance), halfExtents, orientation);

            Debug.DrawLine(bottomBox.BackBottomLeft, topBox.BackBottomLeft, color);
            Debug.DrawLine(bottomBox.BackBottomRight, topBox.BackBottomRight, color);
            Debug.DrawLine(bottomBox.BackTopLeft, topBox.BackTopLeft, color);
            Debug.DrawLine(bottomBox.BackTopRight, topBox.BackTopRight, color);
            Debug.DrawLine(bottomBox.FrontTopLeft, topBox.FrontTopLeft, color);
            Debug.DrawLine(bottomBox.FrontTopRight, topBox.FrontTopRight, color);
            Debug.DrawLine(bottomBox.FrontBottomLeft, topBox.FrontBottomLeft, color);
            Debug.DrawLine(bottomBox.FrontBottomRight, topBox.FrontBottomRight, color);

            DrawBox(bottomBox, color);
            DrawBox(topBox, color);
        }

        #region ▶ BoxCast Visualizer Utilities
        public static void DrawBox(Vector3 origin, Vector3 halfExtents, Quaternion orientation, Color color)
        {
            DrawBox(new MBox(origin, halfExtents, orientation), color);
        }
        public static void DrawBox(MBox box, Color color)
        {
            Debug.DrawLine(box.FrontTopLeft, box.FrontTopRight, color);
            Debug.DrawLine(box.FrontTopRight, box.FrontBottomRight, color);
            Debug.DrawLine(box.FrontBottomRight, box.FrontBottomLeft, color);
            Debug.DrawLine(box.FrontBottomLeft, box.FrontTopLeft, color);

            Debug.DrawLine(box.BackTopLeft, box.BackTopRight, color);
            Debug.DrawLine(box.BackTopRight, box.BackBottomRight, color);
            Debug.DrawLine(box.BackBottomRight, box.BackBottomLeft, color);
            Debug.DrawLine(box.BackBottomLeft, box.BackTopLeft, color);

            Debug.DrawLine(box.FrontTopLeft, box.BackTopLeft, color);
            Debug.DrawLine(box.FrontTopRight, box.BackTopRight, color);
            Debug.DrawLine(box.FrontBottomRight, box.BackBottomRight, color);
            Debug.DrawLine(box.FrontBottomLeft, box.BackBottomLeft, color);
        }
        public static Vector3 CastCenterOnCollision(Vector3 origin, Vector3 direction, float hitInfoDistance)
        {
            return origin + (direction.normalized * hitInfoDistance);
        }
        public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
        {
            Vector3 direction = point - pivot;
            return pivot + rotation * direction;
        }
        #endregion
    }

    public static class MVUIG
    {
        public static void DrawBoxCastOnGame(this Transform parent, Vector3 origin, Vector3 halfExtents, Quaternion orientation, Vector3 direction, float distance, Color color)
        {
            direction.Normalize();
            MBox bottomBox = new MBox(origin, halfExtents, orientation);
            MBox topBox = new MBox(origin + (direction * distance), halfExtents, orientation);

            GameObject gameObject;

            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), bottomBox.BackBottomLeft, topBox.BackBottomLeft);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), bottomBox.BackBottomRight, topBox.BackBottomRight);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), bottomBox.BackTopLeft, topBox.BackTopLeft);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), bottomBox.BackTopRight, topBox.BackTopRight);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), bottomBox.FrontTopLeft, topBox.FrontTopLeft);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), bottomBox.FrontTopRight, topBox.FrontTopRight);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), bottomBox.FrontBottomLeft, topBox.FrontBottomLeft);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), bottomBox.FrontBottomRight, topBox.FrontBottomRight);

            parent.DrawBoxOnGame(bottomBox, Color.green);
            parent.DrawBoxOnGame(topBox, Color.green);
        }

        public static void DrawBoxOnGame(this Transform parent, MBox box, Color color)
        {
            GameObject gameObject;

            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.FrontTopLeft, box.FrontTopRight);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.FrontTopRight, box.FrontBottomRight);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.FrontBottomRight, box.FrontBottomLeft);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.FrontBottomLeft, box.FrontTopLeft);

            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.BackTopLeft, box.BackTopRight);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.BackTopRight, box.BackBottomRight);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.BackBottomRight, box.BackBottomLeft);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.BackBottomLeft, box.BackTopLeft);

            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.FrontTopLeft, box.BackTopLeft);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.FrontTopRight, box.BackTopRight);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.FrontBottomRight, box.BackBottomRight);
            gameObject = parent.CreateGameObject("Line", typeof(LineRenderer));
            SetLineRendererValue(gameObject.GetComponent<LineRenderer>(), box.FrontBottomLeft, box.BackBottomLeft);
        }

        public static void SetLineRendererValue(LineRenderer renderer, Vector3 start, Vector3 end)
        {
            renderer.useWorldSpace = false;
            renderer.startWidth = 0.1f;
            renderer.endWidth = 0.1f;
            renderer.startColor = Color.green;
            renderer.endColor = Color.green;
            renderer.SetPosition(0, start);
            renderer.SetPosition(1, end);
        }
    }

    public struct MBox
    {
        public Vector3 LocalFrontTopLeft { get; private set; }
        public Vector3 LocalFrontTopRight { get; private set; }
        public Vector3 LocalFrontBottomLeft { get; private set; }
        public Vector3 LocalFrontBottomRight { get; private set; }
        public Vector3 LocalBackTopLeft { get { return -LocalFrontBottomRight; } }
        public Vector3 LocalBackTopRight { get { return -LocalFrontBottomLeft; } }
        public Vector3 LocalBackBottomLeft { get { return -LocalFrontTopRight; } }
        public Vector3 LocalBackBottomRight { get { return -LocalFrontTopLeft; } }

        public Vector3 FrontTopLeft { get { return LocalFrontTopLeft + Origin; } }
        public Vector3 FrontTopRight { get { return LocalFrontTopRight + Origin; } }
        public Vector3 FrontBottomLeft { get { return LocalFrontBottomLeft + Origin; } }
        public Vector3 FrontBottomRight { get { return LocalFrontBottomRight + Origin; } }
        public Vector3 BackTopLeft { get { return LocalBackTopLeft + Origin; } }
        public Vector3 BackTopRight { get { return LocalBackTopRight + Origin; } }
        public Vector3 BackBottomLeft { get { return LocalBackBottomLeft + Origin; } }
        public Vector3 BackBottomRight { get { return LocalBackBottomRight + Origin; } }

        public Vector3 Origin { get; private set; }

        public MBox(Vector3 origin, Vector3 halfExtents, Quaternion orientation) : this(origin, halfExtents)
        {
            Rotate(orientation);
        }
        public MBox(Vector3 origin, Vector3 halfExtents)
        {
            this.LocalFrontTopLeft = new Vector3(-halfExtents.x, halfExtents.y, -halfExtents.z);
            this.LocalFrontTopRight = new Vector3(halfExtents.x, halfExtents.y, -halfExtents.z);
            this.LocalFrontBottomLeft = new Vector3(-halfExtents.x, -halfExtents.y, -halfExtents.z);
            this.LocalFrontBottomRight = new Vector3(halfExtents.x, -halfExtents.y, -halfExtents.z);

            this.Origin = origin;
        }


        public void Rotate(Quaternion orientation)
        {
            LocalFrontTopLeft = MVUI.RotatePointAroundPivot(LocalFrontTopLeft, Vector3.zero, orientation);
            LocalFrontTopRight = MVUI.RotatePointAroundPivot(LocalFrontTopRight, Vector3.zero, orientation);
            LocalFrontBottomLeft = MVUI.RotatePointAroundPivot(LocalFrontBottomLeft, Vector3.zero, orientation);
            LocalFrontBottomRight = MVUI.RotatePointAroundPivot(LocalFrontBottomRight, Vector3.zero, orientation);
        }
    }
}
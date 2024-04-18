using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YNL.Extension.Objects;

namespace YNL.Extension.Method
{
    public static class MMath
    {
        /// <summary>
        /// Convert a numeric string into decimal number.
        /// </summary>
        public static int ToInt(this string input)
        {
            try
            {
                return input.IsNullOrEmpty() ? 0 : int.Parse(input);
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        /// <summary> 
        /// Returns the value with FPS's change 
        /// </summary>
        public static float Oscillate(this float value, float scale = 60)
            => (float)value * scale * Time.deltaTime;

        /// <summary>
        /// Normalize a <b><i>Value</i></b> to scale of <b><i>Range</i></b>.
        /// </summary>
        public static float Normalize(this float value, float range)
            => value / range;

        /// <summary>
        /// Percentization a <b><i>Value</i></b> to scale of <b><i>Range</i></b>. 
        /// </summary>
        public static float Percent(this float value, float range)
            => value / range;
        public static float Percent(this float value)
            => value / 100;

        /// <summary> 
        /// Round float into custom amount of digit 
        /// </summary>
        public static float RoundToDigit(this float input, int digit)
            => (float)Math.Round(input, digit);

        /// <summary> 
        /// Check if input float is between (compare - gap) and (compare + gap). 
        /// </summary>
        public static bool CompareGap(this float input, float compare, float gap)
            => input >= compare - gap && input <= compare + gap ? true : false;

        /// <summary> 
        /// Check if input value if between 2 comparing value. 
        /// </summary>
        public static bool IsBetween(this float input, float lower, float higher)
            => input >= lower && input <= higher ? true : false;

        /// <summary>
        /// Convert Hex into Integer.
        /// </summary>
        public static int HexToInt(this string hex)
        {
            int output = 0;
            try
            {
                output = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Format Exception: Invalid HEX Format.");
            }
            return output;
        }

        /// <summary>
        /// Rescale a float number.
        /// </summary>
        public static float Rescale(this float number, float scale)
            => number * scale;

        /// <summary>
        /// Map a range into another range.
        /// </summary>
        public static float Map(this float value, MinMax origin, MinMax target)
        {
            float originRate = 100 / (origin.Max - origin.Min);
            float currentPercent = value * originRate;
            return target.Min + (target.Max - target.Min) * currentPercent.Percent();
        }

        /// <summary>
        /// Lock a value in range of min and max.
        /// </summary>
        public static float Lock(this ref float value, float min, float max)
        {
            if (value < min) value = min;
            else if (value > max) value = max;
            return value;
        }
        public static int Lock(this ref int value, int min, int max)
        {
            if (value < min) value = min;
            else if (value > max) value = max;
            return value;
        }

        /// <summary>
        /// Limit a value in range of min and max.
        /// </summary>
        public static float GetMin(this float value, float min)
        {
            if (value < min) value = min;
            return value;
        }
        public static int GetMin(this int value, int min)
        {
            if (value < min) value = min;
            return value;
        }

        /// <summary>
        /// Map the index into another scale. <br></br>
        /// Ex: { 0, 1, 2, 3, 4 } => { 0, 1.25, 2.5, 3.75, 5 } <br></br>
        /// <i>Just give it this name because I don't have better name.</i>
        /// </summary>
        public static float Ruler(this int index, int amount)
        {
            if (amount <= 0)
            {
                MDebug.Error("Amount should greater than 0");
                return 0;
            }

            return index * ((float)amount / (amount - 1));
        }
        public static float RulerReverse(this int index, int amount)
        {
            if (amount <= 0)
            {
                MDebug.Error("Amount should greater than 0");
                return 0;
            }

            return (amount - index) * ((float)amount / (amount - 1));
        }
    }

    public static class MTime
    {
        /// <summary>
        /// Start countdown coroutine.
        /// </summary>
        public static Coroutine Countdown(this MonoBehaviour mono, float duration, Action<int> remainTick, Action onEnd)
            => mono.StartCoroutine(CountdownCoroutine(duration, remainTick, onEnd));

        /// <summary>
        /// An IEnumerator used for countdown time. <br></br> <br></br>
        /// <i>duration:</i> amount of time by second. <br></br>
        /// <i>remainTick (Action):</i> return remaining amount of time by second (use with TimeFormat()). <br></br>
        /// <i>onEnd (Action):</i> invoked at the end of counting time.
        /// </summary>
        public static IEnumerator CountdownCoroutine(float duration, Action<int> remainTick, Action onEnd)
        {
            int remainingTime = (int)duration;

            while (remainingTime > 0)
            {
                remainTick?.Invoke(remainingTime);
                yield return new WaitForSeconds(1.0f);
                remainingTime--;

                if (remainingTime <= 0) remainTick?.Invoke(remainingTime);
            }

            onEnd?.Invoke();
        }
    }

    public static class MVector
    {
        #region 🔁 Converting Vector
        /// <summary> 
        /// Convert from Vector3 into Vector2 
        /// </summary>
        public static Vector2 ToVector2(this Vector3 input)
            => new Vector2(input.x, input.y);

        /// <summary> 
        /// Convert from Vector2 float into Vector2 integer. 
        /// </summary>
        public static Vector2Int ToVector2Int(this Vector2 input)
            => new Vector2Int((int)input.x, (int)input.y);

        /// <summary> 
        /// Convert from Vector3 float into Vector3 integer. 
        /// </summary>
        public static Vector3Int ToVector3Int(this Vector3 input)
            => new Vector3Int((int)input.x, (int)input.y, (int)input.z);
        #endregion

        #region 📠 Calculating Vector

        /// <summary> 
        /// Make a vector3 with random value betwwen <b><i> x </i></b> and <b><i> y </i></b>. 
        /// </summary>
        public static Vector3 Vector3Random(this Vector3 point, float x, float y)
            => new Vector3(point.x + UnityEngine.Random.Range(x, y), point.y + UnityEngine.Random.Range(x, y), point.z + UnityEngine.Random.Range(x, y));

        /// <summary>
        /// Make a division of two Vector3s.
        /// </summary>
        public static Vector3 DividedBy(this Vector3 vector1, Vector3 vector2)
            => new(vector1.x / vector2.x, vector1.y / vector2.y, vector1.z / vector2.z);

        /// <summary> 
        /// Returns the vector2 with FPS's change with default scale of 120 
        /// </summary>
        public static Vector2 Oscillate(this Vector2 vector)
            => new(vector.x.Oscillate(), vector.y.Oscillate());

        /// <summary> 
        /// Returns the vector2 with FPS's change with scale of 'target'.
        /// </summary>
        public static Vector2 Oscillate(this Vector2 vector, float target)
            => new(vector.x.Oscillate(target), vector.y.Oscillate(target));

        /// <summary> 
        /// Returns the vector3 with FPS's change with default scale of 120 
        /// </summary>
        public static Vector3 Oscillate(this Vector3 vector)
            => new(vector.x.Oscillate(), vector.y.Oscillate(), vector.z.Oscillate());

        /// <summary> 
        /// Returns the vector3 with FPS's change with scale of 'target'.
        /// </summary>
        public static Vector3 Oscillate(this Vector3 vector, float target)
            => new(vector.x.Oscillate(target), vector.y.Oscillate(target), vector.z.Oscillate(target));

        /// <summary> 
        /// Returns the vector4 with FPS's change with default scale of 120 
        /// </summary>
        public static Vector4 Oscillate(this Vector4 vector)
            => new(vector.x.Oscillate(), vector.y.Oscillate(), vector.z.Oscillate(), vector.w.Oscillate());

        /// <summary> 
        /// Returns the vector4 with FPS's change with scale of 'target'.
        /// </summary>
        public static Vector4 Oscillate(this Vector4 vector, float target)
            => new(vector.x.Oscillate(target), vector.y.Oscillate(target), vector.z.Oscillate(target), vector.w.Oscillate(target));

        #endregion

        #region 📐 Set / Add Vector
        /// <summary>
        /// Set X axis of Vector2.
        /// </summary>
        public static Vector2 SetX(this Vector2 vector, float x)
            => new Vector2(x, vector.y);

        /// <summary>
        /// Set Y axis of Vector2.
        /// </summary>
        public static Vector2 SetY(this Vector2 vector, float y)
            => new Vector2(vector.x, y);

        /// <summary>
        /// Add into X axis of Vector2.
        /// </summary>
        public static Vector2 AddX(this Vector2 vector, float x)
            => new Vector2(vector.x + x, vector.y);

        /// <summary>
        /// Add into Y axis of Vector2.
        /// </summary>
        public static Vector2 AddY(this Vector2 vector, float y)
            => new Vector2(vector.x, vector.y + y);

        /// <summary>
        /// Set X axis of Vector3.
        /// </summary>
        public static Vector3 SetX(this Vector3 vector, float x)
            => new Vector3(x, vector.y, vector.z);

        /// <summary>
        /// Set Y axis of Vector3.
        /// </summary>
        public static Vector3 SetY(this Vector3 vector, float y)
            => new Vector3(vector.x, y, vector.z);

        /// <summary>
        /// Set Z axis of Vector3.
        /// </summary>
        public static Vector3 SetZ(this Vector3 vector, float z)
            => new Vector3(vector.x, vector.y, z);

        /// <summary>
        /// Add into X axis of Vector3.
        /// </summary>
        public static Vector3 AddX(this Vector3 vector, float x)
            => new Vector3(vector.x + x, vector.y, vector.z);

        /// <summary>
        /// Add into Y axis of Vector3.
        /// </summary>
        public static Vector3 AddY(this Vector3 vector, float y)
            => new Vector3(vector.x, vector.y + y, vector.z);

        /// <summary>
        /// Add into Z axis of Vector3.
        /// </summary>
        public static Vector3 AddZ(this Vector3 vector, float z)
            => new Vector3(vector.x, vector.y, vector.z + z);
        #endregion

        #region 📝 Get Closest / Farthest Vector
        /// <summary>
        /// Get the closest Vector2 from an array to the original Vector2.
        /// </summary>
        public static Vector2 GetClosestVector2From(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The array of other vectors is empty");
            var minDistance = Vector2.Distance(vector, otherVectors[0]);
            var minVector = otherVectors[0];
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }
            return minVector;
        }

        /// <summary>
        /// Get the closest Vector2 from a list to the original Vector2.
        /// </summary>
        public static Vector2 GetClosestVector2From(this Vector2 vector, List<Vector2> otherVectors)
        {
            if (otherVectors.Count == 0) throw new Exception("The list of other vectors is empty");
            var minDistance = Vector2.Distance(vector, otherVectors[0]);
            var minVector = otherVectors[0];
            for (var i = otherVectors.Count - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }
            return minVector;
        }

        /// <summary>
        /// Get the farthest Vector2 from an array to the original Vector2.
        /// </summary>
        public static Vector2 GetFarthestVector2From(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The array of other vectors is empty");
            var maxDistance = Vector2.Distance(vector, otherVectors[0]);
            var maxVector = otherVectors[0];
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                    maxVector = otherVectors[i];
                }
            }
            return maxVector;
        }

        /// <summary>
        /// Get the farthest Vector2 from a list to the original Vector2.
        /// </summary>
        public static Vector2 GetFarthestVector2From(this Vector2 vector, List<Vector2> otherVectors)
        {
            if (otherVectors.Count == 0) throw new Exception("The list of other vectors is empty");
            var maxDistance = Vector2.Distance(vector, otherVectors[0]);
            var maxVector = otherVectors[0];
            for (var i = otherVectors.Count - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                    maxVector = otherVectors[i];
                }
            }
            return maxVector;
        }

        /// <summary>
        /// Get the closest Vector3 from an array to the original Vector3.
        /// </summary>
        public static Vector3 GetClosestVector3From(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var minDistance = Vector3.Distance(vector, otherVectors[0]);
            var minVector = otherVectors[0];
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }
            return minVector;
        }

        /// <summary>
        /// Get the closest Vector3 from a list to the original Vector3.
        /// </summary>
        public static Vector3 GetClosestVector3From(this Vector3 vector, List<Vector3> otherVectors)
        {
            if (otherVectors.Count == 0) throw new Exception("The list of other vectors is empty");
            var minDistance = Vector3.Distance(vector, otherVectors[0]);
            var minVector = otherVectors[0];
            for (var i = otherVectors.Count - 1; i > 0; i--)
            {
                var newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }
            return minVector;
        }

        /// <summary>
        /// Get the farthest Vector3 from an array to the original Vector3.
        /// </summary>
        public static Vector3 GetFarthestVector3From(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The array of other vectors is empty");
            var maxDistance = Vector3.Distance(vector, otherVectors[0]);
            var maxVector = otherVectors[0];
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                    maxVector = otherVectors[i];
                }
            }
            return maxVector;
        }

        /// <summary>
        /// Get the farthest Vector3 from an list to the original Vector3.
        /// </summary>
        public static Vector3 GetFarthestVector3From(this Vector3 vector, List<Vector3> otherVectors)
        {
            if (otherVectors.Count == 0) throw new Exception("The array of other vectors is empty");
            var maxDistance = Vector3.Distance(vector, otherVectors[0]);
            var maxVector = otherVectors[0];
            for (var i = otherVectors.Count - 1; i > 0; i--)
            {
                var newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                    maxVector = otherVectors[i];
                }
            }
            return maxVector;
        }
        #endregion

        #region Others
        /// <summary>
        /// Get distance between two vector3s.
        /// </summary>
        public static float Distance(this Vector3 from, Vector3 to)
            => (from - to).magnitude;
        #endregion
    }

    public static class MQuaternion
    {
        /// <summary>
        /// Convert a Vector3 into Quaternion.
        /// </summary>
        public static Quaternion ToQuaternion(this Vector3 vector3)
            => Quaternion.Euler(vector3.x, vector3.y, vector3.z);
    }
}
using UnityEngine;

namespace YNL.Extension.Method
{
    public static class MCharacterController
    {
        /// <summary>
        /// Set position of CharacterController object.
        /// </summary>
        public static void SetPosition(this CharacterController controller, Vector3 position)
        {
            controller.enabled = false;
            controller.transform.position = position;
            controller.enabled = true;
        }
    }
}
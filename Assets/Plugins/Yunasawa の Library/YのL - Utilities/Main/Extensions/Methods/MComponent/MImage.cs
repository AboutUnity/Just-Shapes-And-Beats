using UnityEngine;
using UnityEngine.UI;

namespace YNL.Extension.Method
{
    public static class MImage
    {
        /// <summary>
        /// Change <b>sprite</b> and <b>color</b> of an <b>Image</b>.
        /// </summary>
        public static Image ChangeImage(this Image image, Sprite sprite, Color color)
        {
            image.sprite = sprite;
            image.color = color;
            return image;
        }
    }
}
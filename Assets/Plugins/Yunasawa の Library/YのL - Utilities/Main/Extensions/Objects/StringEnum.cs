using System.Collections.Generic;

namespace YNL.Extension.Objects
{
    [System.Serializable]
    public class StringEnum
    {
        public string[] Array = new string[0];
        public string Label;
        public int Index;

        public StringEnum() { }

        public void Initial(string[] array) => Array = array;
    }
}
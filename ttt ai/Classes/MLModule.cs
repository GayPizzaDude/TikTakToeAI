using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttt_ai.Classes
{
    class MLModule
    {
        // ---  PROPERTIES ---

        private List<int> sequence = new List<int>();
        public enum ClickType
        {
            Cross,
            Circle
        }





        // --- CONSTRUCTORS ---

        public MLModule() 
        {
            sequence = new List<int> { 0 };
        }





        // --- PUBLIC METHODS ---

        public void PassValue(int value, ClickType type)
        {
            if (type == ClickType.Cross)
            {
                sequence.Add(value);
            }
            else if (type == ClickType.Circle)
            {
                sequence.Add(value + 9);
            }
        }

        public int ModelAnswer()
        {
            //return GetAnswer();
            return 0;
        }

        public void Reset()
        {
            sequence.Clear();
            sequence.Add(0);
        }





        // --- PRIVATE METHODS ---
    }
}

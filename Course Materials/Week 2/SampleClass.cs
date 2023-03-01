using System;
using System.Collections.Generic;
using System.Text;

namespace Week2
{
    class SampleClass
    {
        /// global variable with public access
        public int sampleGlobalVarA;
        
        /// code shortcut to add get() and set() methods
        /// for a member. In this case, sampleGlobalVarB.
        public int sampleGlobalVarB 
        {
            /// returns the value
            get { return sampleGlobalVarB; }

            /// checks if the attempted value is valid before setting.
            /// E.G.: condition ? ifTrue : ifFalse;
            /// if you try this: sampleGlobalVarB = 2
            /// it will check that 2 is greater than 0 before setting
            /// it to the var. If not, it will set it to 1
            set { sampleGlobalVarB = (value > 0 ? value : 1); }
        }


        /// a global variable, like sampleGlobalVar,
        /// however, it has no access modifier.
        /// By default it will have a private access modifier.
        int samplePrivateGlobalVar;

        /// <summary>
        /// Basic constructor. Initialise globals here.
        /// </summary>
        public SampleClass()
        {
            sampleGlobalVarA = 0;
            sampleGlobalVarB = 1;
            samplePrivateGlobalVar = 2;
        }

        /// <summary>
        /// overloaded constructor. If this class is initialised
        /// with an integer parameter, this constructor will be used
        /// instead of the basic one above.
        /// </summary>
        /// <param name="value"></param>
        public SampleClass(int value)
        {
            /// do something with the passed value
            samplePrivateGlobalVar = value;
        }

        /// <summary>
        /// Override the default ToString() method to ouput
        /// our choice of data. Return value must be string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Sample Class: " + sampleGlobalVarB.ToString() + 
                ", " + samplePrivateGlobalVar.ToString();
        }

        /// <summary>
        /// A simple method that takes no parameters and returns no values.
        /// </summary>
        public void SampleMethod()
        {
            Console.WriteLine("You have successfully called a class method!");
        }
    }
}

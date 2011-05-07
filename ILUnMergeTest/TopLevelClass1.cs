using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ClassesAsData
{
    public class TopLevelClass1
    {
        public void AMethod()
        {
            AUsedClass2 auc2;
            (new P1()).ToString();
            P3.StaticMethod();
            P4 p4 = new P4();
            p4.GetP2.MethodName();
            auc2 = null;
            if (auc2!= null)
                Debug.WriteLine("");
        }

        private AUsedClass uc = new AUsedClass();

        public class NestedClass1
        {
            public void MethodName()
            {
                
            }
            public class NestedClass2Deep {

                public void MethodName()
                {
                    
                }
            }
        }
    }
}

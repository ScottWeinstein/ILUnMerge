using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ClassesAsData
{
    public class P1
    {
        P1 p1;
        P2 p2;
        P3 p3;
        P4 p4;
        Dictionary<String, int> l = new Dictionary<string, int>();
        System.Xml.XmlDocument xdoc=null;
        public void MethodName()
        {
           
            p1 = null;
            p2 = null;
            p3 = null;
            p4 = null;
            if (p1 != null)
                Debug.WriteLine("");

            if (p2 != null)
                Debug.WriteLine("");
            if (p3 != null)
                Debug.WriteLine("");
            if (p4 != null)
                Debug.WriteLine("");
            if (xdoc !=null)
                Debug.WriteLine("");

        }

    }
}

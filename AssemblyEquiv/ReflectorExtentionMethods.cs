using System;
using System.Collections;
using Reflector.CodeModel;

namespace ACATool.Tasks
{
    internal static partial class ReflectorExtentionMethods
    {

        public static bool CompareITypeReference(this ITypeReference oTypeRef, ITypeReference nTypeRef)
        {
            if (oTypeRef == null && nTypeRef == null)
                return true;
            if (oTypeRef == null || nTypeRef == null)
                return false;

            if ((oTypeRef.Name == nTypeRef.Name) &&
                (oTypeRef.Namespace == nTypeRef.Namespace) &&
                ((oTypeRef.Owner ?? "").ToString() == (nTypeRef.Owner ?? "").ToString()))
                return true;

            return false;
        }


        private static Action<string, string> _NullErrorHandler = (a, b) => { };
        public static bool Compare<Titem>(this ICollection source, ICollection comp, Func<Titem, Titem, Action<string, string>, bool> checkitem, Action<string, string> errAct)
        {
            if (source == null && comp == null)
                return true;
            if (source == null || comp == null)
                return true;

            int ocount = source.Count;
            if (ocount != comp.Count)
                return false;

            // have to do this b/c reflector collections don't implement IList
            Titem[] oarr = new Titem[ocount];
            Titem[] narr = new Titem[ocount];
            source.CopyTo(oarr, 0);
            comp.CopyTo(narr, 0);
            for (int ii = 0; ii < ocount; ii++)
            {
                if (checkitem == null)
                {
                    if (oarr[ii].ToString() != narr[ii].ToString())
                        return false;
                }
                else
                {
                    if (!checkitem(oarr[ii], narr[ii], errAct))
                        return false;
                }
            }
            return true;
        }
        public static bool Compare<Titem>(this ICollection o, ICollection n, Func<Titem, Titem, bool> checkitem)
        {
            Func<Titem, Titem, Action<string, string>, bool> checkitemE = (a, b, e) => checkitem(a, b);
            return Compare(o, n, checkitemE, _NullErrorHandler);
        }
        public static bool Compare<Titem>(this ICollection o, ICollection n)
        {
            return Compare<Titem>(o, n, (a,b)=> a.ToString() == b.ToString());
        }

    }
}

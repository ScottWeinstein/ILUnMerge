using Mono.Cecil;
namespace ACATool
{
    public class UsedClass
    {
        private TypeReference _Type;
        public TypeReference Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        private ClassUse _Use;
        public ClassUse Use
        {
            get
            {
                return _Use;
            }
            set
            {
                _Use = value;
            }
        }

        public UsedClass(TypeReference t, ClassUse u)
        {
            Use = u;
            Type = t;
        }

        public override bool Equals(object obj)
        {
            UsedClass operand = obj as UsedClass;
            if (operand == null) return false;
            if (operand.Type == Type && operand.Use == Use) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }


    }

}
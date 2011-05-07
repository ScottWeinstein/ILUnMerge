namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;

    [Flags, CLSCompliant(true)]
    public enum CorElementType
    {
        ELEMENT_TYPE_ARRAY = 20,
        ELEMENT_TYPE_BOOLEAN = 2,
        ELEMENT_TYPE_BYREF = 0x10,
        ELEMENT_TYPE_CHAR = 3,
        ELEMENT_TYPE_CLASS = 0x12,
        ELEMENT_TYPE_CMOD_OPT = 0x20,
        ELEMENT_TYPE_CMOD_REQD = 0x1f,
        ELEMENT_TYPE_END = 0,
        ELEMENT_TYPE_FNPTR = 0x1b,
        ELEMENT_TYPE_I = 0x18,
        ELEMENT_TYPE_I1 = 4,
        ELEMENT_TYPE_I2 = 6,
        ELEMENT_TYPE_I4 = 8,
        ELEMENT_TYPE_I8 = 10,
        ELEMENT_TYPE_INTERNAL = 0x21,
        ELEMENT_TYPE_MAX = 0x22,
        ELEMENT_TYPE_MODIFIER = 0x40,
        ELEMENT_TYPE_OBJECT = 0x1c,
        ELEMENT_TYPE_PINNED = 0x45,
        ELEMENT_TYPE_PTR = 15,
        ELEMENT_TYPE_R4 = 12,
        ELEMENT_TYPE_R8 = 13,
        ELEMENT_TYPE_SENTINEL = 0x41,
        ELEMENT_TYPE_STRING = 14,
        ELEMENT_TYPE_SZARRAY = 0x1d,
        ELEMENT_TYPE_TYPEDBYREF = 0x16,
        ELEMENT_TYPE_U = 0x19,
        ELEMENT_TYPE_U1 = 5,
        ELEMENT_TYPE_U2 = 7,
        ELEMENT_TYPE_U4 = 9,
        ELEMENT_TYPE_U8 = 11,
        ELEMENT_TYPE_VALUETYPE = 0x11,
        ELEMENT_TYPE_VOID = 1
    }
}

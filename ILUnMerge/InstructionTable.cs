// ---------------------------------------------------------
// .NET Reflector Code Model Library
// Copyright (c) 2000-2006 Lutz Roeder.	All rights reserved.
// http://www.aisto.com/roeder
// ---------------------------------------------------------
namespace Reflector
{
	using System;
	using System.Globalization;

	internal sealed class InstructionTable
	{
		private InstructionTable()
		{
		}

		public static string GetInstructionName(int code)
		{
			switch (code)
			{
				case 0x00: return "nop";
				case 0x01: return "break";
				case 0x02: return "ldarg.0";
				case 0x03: return "ldarg.1";
				case 0x04: return "ldarg.2";
				case 0x05: return "ldarg.3";
				case 0x06: return "ldloc.0";
				case 0x07: return "ldloc.1";
				case 0x08: return "ldloc.2";
				case 0x09: return "ldloc.3";
				case 0x0a: return "stloc.0";
				case 0x0b: return "stloc.1";
				case 0x0c: return "stloc.2";
				case 0x0d: return "stloc.3";
				case 0x0e: return "ldarg.s";
				case 0x0f: return "ldarga.s";
				case 0x10: return "starg.s";
				case 0x11: return "ldloc.s";
				case 0x12: return "ldloca.s";
				case 0x13: return "stloc.s";
				case 0x14: return "ldnull";
				case 0x15: return "ldc.i4.m1";
				case 0x16: return "ldc.i4.0";
				case 0x17: return "ldc.i4.1";
				case 0x18: return "ldc.i4.2";
				case 0x19: return "ldc.i4.3";
				case 0x1a: return "ldc.i4.4";
				case 0x1b: return "ldc.i4.5";
				case 0x1c: return "ldc.i4.6";
				case 0x1d: return "ldc.i4.7";
				case 0x1e: return "ldc.i4.8";
				case 0x1f: return "ldc.i4.s";
				case 0x20: return "ldc.i4";
				case 0x21: return "ldc.i8";
				case 0x22: return "ldc.r4";
				case 0x23: return "ldc.r8";
				case 0x25: return "dup";
				case 0x26: return "pop";
				case 0x27: return "jmp";
				case 0x28: return "call";
				case 0x29: return "calli";
				case 0x2a: return "ret";
				case 0x2b: return "br.s";
				case 0x2c: return "brfalse.s";
				case 0x2d: return "brtrue.s";
				case 0x2e: return "beq.s";
				case 0x2f: return "bge.s";
				case 0x30: return "bgt.s";
				case 0x31: return "ble.s";
				case 0x32: return "blt.s";
				case 0x33: return "bne.un.s";
				case 0x34: return "bge.un.s";
				case 0x35: return "bgt.un.s";
				case 0x36: return "ble.un.s";
				case 0x37: return "blt.un.s";
				case 0x38: return "br";
				case 0x39: return "brfalse";
				case 0x3a: return "brtrue";
				case 0x3b: return "beq";
				case 0x3c: return "bge";
				case 0x3d: return "bgt";
				case 0x3e: return "ble";
				case 0x3f: return "blt";
				case 0x40: return "bne.un";
				case 0x41: return "bge.un";
				case 0x42: return "bgt.un";
				case 0x43: return "ble.un";
				case 0x44: return "blt.un";
				case 0x45: return "switch";
				case 0x46: return "ldind.i1";
				case 0x47: return "ldind.u1";
				case 0x48: return "ldind.i2";
				case 0x49: return "ldind.u2";
				case 0x4a: return "ldind.i4";
				case 0x4b: return "ldind.u4";
				case 0x4c: return "ldind.i8";
				case 0x4d: return "ldind.i";
				case 0x4e: return "ldind.r4";
				case 0x4f: return "ldind.r8";
				case 0x50: return "ldind.ref";
				case 0x51: return "stind.ref";
				case 0x52: return "stind.i1";
				case 0x53: return "stind.i2";
				case 0x54: return "stind.i4";
				case 0x55: return "stind.i8";
				case 0x56: return "stind.r4";
				case 0x57: return "stind.r8";
				case 0x58: return "add";
				case 0x59: return "sub";
				case 0x5a: return "mul";
				case 0x5b: return "div";
				case 0x5c: return "div.un";
				case 0x5d: return "rem";
				case 0x5e: return "rem.un";
				case 0x5f: return "and";
				case 0x60: return "or";
				case 0x61: return "xor";
				case 0x62: return "shl";
				case 0x63: return "shr";
				case 0x64: return "shr.un";
				case 0x65: return "neg";
				case 0x66: return "not";
				case 0x67: return "conv.i1";
				case 0x68: return "conv.i2";
				case 0x69: return "conv.i4";
				case 0x6a: return "conv.i8";
				case 0x6b: return "conv.r4";
				case 0x6c: return "conv.r8";
				case 0x6d: return "conv.u4";
				case 0x6e: return "conv.u8";
				case 0x6f: return "callvirt";
				case 0x70: return "cpobj";
				case 0x71: return "ldobj";
				case 0x72: return "ldstr";
				case 0x73: return "newobj";
				case 0x74: return "castclass";
				case 0x75: return "isinst";
				case 0x76: return "conv.r.un";
				case 0x79: return "unbox";
				case 0x7a: return "throw";
				case 0x7b: return "ldfld";
				case 0x7c: return "ldflda";
				case 0x7d: return "stfld";
				case 0x7e: return "ldsfld";
				case 0x7f: return "ldsflda";
				case 0x80: return "stsfld";
				case 0x81: return "stobj";
				case 0x82: return "conv.ovf.i1.un";
				case 0x83: return "conv.ovf.i2.un";
				case 0x84: return "conv.ovf.i4.un";
				case 0x85: return "conv.ovf.i8.un";
				case 0x86: return "conv.ovf.u1.un";
				case 0x87: return "conv.ovf.u2.un";
				case 0x88: return "conv.ovf.u4.un";
				case 0x89: return "conv.ovf.u8.un";
				case 0x8a: return "conv.ovf.i.un";
				case 0x8b: return "conv.ovf.u.un";
				case 0x8c: return "box";
				case 0x8d: return "newarr";
				case 0x8e: return "ldlen";
				case 0x8f: return "ldelema";
				case 0x90: return "ldelem.i1";
				case 0x91: return "ldelem.u1";
				case 0x92: return "ldelem.i2";
				case 0x93: return "ldelem.u2";
				case 0x94: return "ldelem.i4";
				case 0x95: return "ldelem.u4";
				case 0x96: return "ldelem.i8";
				case 0x97: return "ldelem.i";
				case 0x98: return "ldelem.r4";
				case 0x99: return "ldelem.r8";
				case 0x9a: return "ldelem.ref";
				case 0x9b: return "stelem.i";
				case 0x9c: return "stelem.i1";
				case 0x9d: return "stelem.i2";
				case 0x9e: return "stelem.i4";
				case 0x9f: return "stelem.i8";
				case 0xa0: return "stelem.r4";
				case 0xa1: return "stelem.r8";
				case 0xa2: return "stelem.ref";
				case 0xa3: return "ldelem.any";
				case 0xa4: return "stelem.any";
				case 0xa5: return "unbox.any";
				case 0xb3: return "conv.ovf.i1";
				case 0xb4: return "conv.ovf.u1";
				case 0xb5: return "conv.ovf.i2";
				case 0xb6: return "conv.ovf.u2";
				case 0xb7: return "conv.ovf.i4";
				case 0xb8: return "conv.ovf.u4";
				case 0xb9: return "conv.ovf.i8";
				case 0xba: return "conv.ovf.u8";
				case 0xc2: return "refanyval";
				case 0xc3: return "ckfinite";
				case 0xc6: return "mkrefany";
				case 0xd0: return "ldtoken";
				case 0xd1: return "conv.u2";
				case 0xd2: return "conv.u1";
				case 0xd3: return "conv.i";
				case 0xd4: return "conv.ovf.i";
				case 0xd5: return "conv.ovf.u";
				case 0xd6: return "add.ovf";
				case 0xd7: return "add.ovf.un";
				case 0xd8: return "mul.ovf";
				case 0xd9: return "mul.ovf.un";
				case 0xda: return "sub.ovf";
				case 0xdb: return "sub.ovf.un";
				case 0xdc: return "endfinally";
				case 0xdd: return "leave";
				case 0xde: return "leave.s";
				case 0xdf: return "stind.i";
				case 0xe0: return "conv.u";
				case 0xf8: return "prefix7";
				case 0xf9: return "prefix6";
				case 0xfa: return "prefix5";
				case 0xfb: return "prefix4";
				case 0xfc: return "prefix3";
				case 0xfd: return "prefix2";
				case 0xfe: return "prefix1";
				case 0xff: return "prefixref";
			}

			switch (code)
			{
				case 0xfe00: return "arglist";
				case 0xfe01: return "ceq";
				case 0xfe02: return "cgt";
				case 0xfe03: return "cgt.un";
				case 0xfe04: return "clt";
				case 0xfe05: return "clt.un";
				case 0xfe06: return "ldftn";
				case 0xfe07: return "ldvirtftn";
				case 0xfe09: return "ldarg";
				case 0xfe0a: return "ldarga";
				case 0xfe0b: return "starg";
				case 0xfe0c: return "ldloc";
				case 0xfe0d: return "ldloca";
				case 0xfe0e: return "stloc";
				case 0xfe0f: return "localloc";
				case 0xfe11: return "endfilter";
				case 0xfe12: return "unaligned";
				case 0xfe13: return "volatile";
				case 0xfe14: return "tail";
				case 0xfe15: return "initobj";
				case 0xfe16: return "constrained";
				case 0xfe17: return "cpblk";
				case 0xfe18: return "initblk";
				case 0xfe1a: return "rethrow";
				case 0xfe1c: return "sizeof";
				case 0xfe1d: return "refanytype";
				case 0xfe1e: return "readonly";
			}

			throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "Unknown IL instruction '{0}'.", code.ToString("X4", CultureInfo.InvariantCulture)));
		}
	}
}

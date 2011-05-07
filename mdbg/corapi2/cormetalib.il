// =============== CLASS MEMBERS DECLARATION ===================

.class interface public abstract auto ansi Microsoft.Samples.Debugging.CorMetadata.NativeApi.IMetadataImport
{
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 37 44 41 43 38 32 30 37 2D 44 33 41 45   // ..$7DAC8207-D3AE
                                                                                                  2D 34 63 37 35 2D 39 42 36 37 2D 39 32 38 30 31   // -4c75-9B67-92801
                                                                                                  41 34 39 37 44 34 34 00 00 )                      // A497D44..
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  CloseEnum(native int hEnum) cil managed preservesig
  {
  } // end of method IMetadataImport::CloseEnum

  .method public hidebysig newslot abstract virtual 
          instance void  CountEnum(native int hEnum,
                                   [out] int32& pulCount) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::CountEnum

  .method public hidebysig newslot abstract virtual 
          instance void  ResetEnum(native int hEnum,
                                   int32 ulPos) cil managed
  {
  } // end of method IMetadataImport::ResetEnum

  .method public hidebysig newslot abstract virtual 
          instance void  EnumTypeDefs(native int& phEnum,
                                      [out] int32& rTypeDefs,
                                      uint32 cMax,
                                      [out] uint32& pcTypeDefs) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::EnumTypeDefs

  .method public hidebysig newslot abstract virtual 
          instance void  EnumInterfaceImpls_(native int phEnum,
                                             int32 td) cil managed
  {
  } // end of method IMetadataImport::EnumInterfaceImpls_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumTypeRefs_() cil managed
  {
  } // end of method IMetadataImport::EnumTypeRefs_

  .method public hidebysig newslot abstract virtual 
          instance void  FindTypeDefByName([in] string  marshal( lpwstr) szTypeDef,
                                           [in] int32 tkEnclosingClass,
                                           [out] int32& token) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
  } // end of method IMetadataImport::FindTypeDefByName

  .method public hidebysig newslot abstract virtual 
          instance void  GetScopeProps([out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szName,
                                       [in] int32 cchName,
                                       [out] int32& pchName,
                                       [out] valuetype [mscorlib]System.Guid& mvid) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::GetScopeProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetModuleFromScope_() cil managed
  {
  } // end of method IMetadataImport::GetModuleFromScope_

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeDefProps([in] int32 td,
                                         [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szTypeDef,
                                         [in] int32 cchTypeDef,
                                         [out] int32& pchTypeDef,
                                         [out] valuetype [mscorlib]System.Reflection.TypeAttributes&  marshal( unsigned int32) pdwTypeDefFlags,
                                         [out] int32& ptkExtends) cil managed
  {
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 08 6D 64 54 6F 6B 65 6E 2A 00 00 )          // ...mdToken*..
  } // end of method IMetadataImport::GetTypeDefProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetInterfaceImplProps_() cil managed
  {
  } // end of method IMetadataImport::GetInterfaceImplProps_

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeRefProps(int32 tr,
                                         [out] int32& ptkResolutionScope,
                                         [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szName,
                                         [in] int32 cchName,
                                         [out] int32& pchName) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 08 6D 64 54 6F 6B 65 6E 2A 00 00 )          // ...mdToken*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::GetTypeRefProps

  .method public hidebysig newslot abstract virtual 
          instance void  ResolveTypeRef_() cil managed
  {
  } // end of method IMetadataImport::ResolveTypeRef_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMembers_() cil managed
  {
  } // end of method IMetadataImport::EnumMembers_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMembersWithName_() cil managed
  {
  } // end of method IMetadataImport::EnumMembersWithName_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMethods(native int& phEnum,
                                     int32 cl,
                                     [out] int32& mdMethodDef,
                                     int32 cMax,
                                     [out] int32& pcTokens) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0C 6D 64 4D 65 74 68 6F 64 44 65 66 2A 00   // ...mdMethodDef*.
                                                                                                            00 ) 
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::EnumMethods

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMethodsWithName_() cil managed
  {
  } // end of method IMetadataImport::EnumMethodsWithName_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumFields(native int& phEnum,
                                    int32 cl,
                                    [out] int32& mdFieldDef,
                                    int32 cMax,
                                    [out] uint32& pcTokens) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0B 6D 64 46 69 65 6C 64 44 65 66 2A 00 00 ) // ...mdFieldDef*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::EnumFields

  .method public hidebysig newslot abstract virtual 
          instance void  EnumFieldsWithName_() cil managed
  {
  } // end of method IMetadataImport::EnumFieldsWithName_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumParams(native int& phEnum,
                                    int32 mdMethodDef,
                                    [out] int32& mdParamDef,
                                    int32 cMax,
                                    [out] uint32& pcTokens) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0B 6D 64 50 61 72 61 6D 44 65 66 2A 00 00 ) // ...mdParamDef*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::EnumParams

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMemberRefs_() cil managed
  {
  } // end of method IMetadataImport::EnumMemberRefs_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMethodImpls_() cil managed
  {
  } // end of method IMetadataImport::EnumMethodImpls_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumPermissionSets_() cil managed
  {
  } // end of method IMetadataImport::EnumPermissionSets_

  .method public hidebysig newslot abstract virtual 
          instance void  FindMember_() cil managed
  {
  } // end of method IMetadataImport::FindMember_

  .method public hidebysig newslot abstract virtual 
          instance void  FindMethod_() cil managed
  {
  } // end of method IMetadataImport::FindMethod_

  .method public hidebysig newslot abstract virtual 
          instance void  FindField_() cil managed
  {
  } // end of method IMetadataImport::FindField_

  .method public hidebysig newslot abstract virtual 
          instance void  FindMemberRef_() cil managed
  {
  } // end of method IMetadataImport::FindMemberRef_

  .method public hidebysig newslot abstract virtual 
          instance void  GetMethodProps([in] uint32 md,
                                        [out] int32& pClass,
                                        [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szMethod,
                                        [in] int32 cchMethod,
                                        [out] int32& pchMethod,
                                        [out] uint32& pdwAttr,
                                        [out] native int& ppvSigBlob,
                                        [out] uint32& pcbSigBlob,
                                        [out] uint32& pulCodeRVA,
                                        [out] uint32& pdwImplFlags) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [7]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 10 50 43 43 4F 52 5F 53 49 47 4E 41 54 55   // ...PCCOR_SIGNATU
                                                                                                            52 45 2A 00 00 )                                  // RE*..
    .param [8]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [9]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [10]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
  } // end of method IMetadataImport::GetMethodProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetMemberRefProps([in] uint32 mr,
                                           [out] int32& ptk,
                                           [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szMember,
                                           [in] int32 cchMember,
                                           [out] uint32& pchMember,
                                           [out] native int& ppvSigBlob,
                                           [out] int32& pbSig) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0C 6D 64 4D 65 6D 62 65 72 52 65 66 2A 00   // ...mdMemberRef*.
                                                                                                            00 ) 
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 10 50 43 43 4F 52 5F 53 49 47 4E 41 54 55   // ...PCCOR_SIGNATU
                                                                                                            52 45 2A 00 00 )                                  // RE*..
    .param [7]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::GetMemberRefProps

  .method public hidebysig newslot abstract virtual 
          instance void  EnumProperties_() cil managed
  {
  } // end of method IMetadataImport::EnumProperties_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumEvents_() cil managed
  {
  } // end of method IMetadataImport::EnumEvents_

  .method public hidebysig newslot abstract virtual 
          instance void  GetEventProps_() cil managed
  {
  } // end of method IMetadataImport::GetEventProps_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMethodSemantics_() cil managed
  {
  } // end of method IMetadataImport::EnumMethodSemantics_

  .method public hidebysig newslot abstract virtual 
          instance void  GetMethodSemantics_() cil managed
  {
  } // end of method IMetadataImport::GetMethodSemantics_

  .method public hidebysig newslot abstract virtual 
          instance void  GetClassLayout_() cil managed
  {
  } // end of method IMetadataImport::GetClassLayout_

  .method public hidebysig newslot abstract virtual 
          instance void  GetFieldMarshal_() cil managed
  {
  } // end of method IMetadataImport::GetFieldMarshal_

  .method public hidebysig newslot abstract virtual 
          instance void  GetRVA_() cil managed
  {
  } // end of method IMetadataImport::GetRVA_

  .method public hidebysig newslot abstract virtual 
          instance void  GetPermissionSetProps_() cil managed
  {
  } // end of method IMetadataImport::GetPermissionSetProps_

  .method public hidebysig newslot abstract virtual 
          instance void  GetSigFromToken_() cil managed
  {
  } // end of method IMetadataImport::GetSigFromToken_

  .method public hidebysig newslot abstract virtual 
          instance void  GetModuleRefProps_() cil managed
  {
  } // end of method IMetadataImport::GetModuleRefProps_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumModuleRefs_() cil managed
  {
  } // end of method IMetadataImport::EnumModuleRefs_

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeSpecFromToken_() cil managed
  {
  } // end of method IMetadataImport::GetTypeSpecFromToken_

  .method public hidebysig newslot abstract virtual 
          instance void  GetNameFromToken_() cil managed
  {
  } // end of method IMetadataImport::GetNameFromToken_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumUnresolvedMethods_() cil managed
  {
  } // end of method IMetadataImport::EnumUnresolvedMethods_

  .method public hidebysig newslot abstract virtual 
          instance void  GetUserString([in] int32 stk,
                                       [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szString,
                                       [in] int32 cchString,
                                       [out] int32& pchString) cil managed
  {
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::GetUserString

  .method public hidebysig newslot abstract virtual 
          instance void  GetPinvokeMap_() cil managed
  {
  } // end of method IMetadataImport::GetPinvokeMap_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumSignatures_() cil managed
  {
  } // end of method IMetadataImport::EnumSignatures_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumTypeSpecs_() cil managed
  {
  } // end of method IMetadataImport::EnumTypeSpecs_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumUserStrings_() cil managed
  {
  } // end of method IMetadataImport::EnumUserStrings_

  .method public hidebysig newslot abstract virtual 
          instance void  GetParamForMethodIndex_() cil managed
  {
  } // end of method IMetadataImport::GetParamForMethodIndex_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumCustomAttributes(native int& phEnum,
                                              int32 tk,
                                              int32 tkType,
                                              [out] int32& mdCustomAttribute,
                                              uint32 cMax,
                                              [out] uint32& pcTokens) cil managed
  {
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 12 6D 64 43 75 73 74 6F 6D 41 74 74 72 69   // ...mdCustomAttri
                                                                                                            62 75 74 65 2A 00 00 )                            // bute*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::EnumCustomAttributes

  .method public hidebysig newslot abstract virtual 
          instance void  GetCustomAttributeProps_() cil managed
  {
  } // end of method IMetadataImport::GetCustomAttributeProps_

  .method public hidebysig newslot abstract virtual 
          instance void  FindTypeRef_() cil managed
  {
  } // end of method IMetadataImport::FindTypeRef_

  .method public hidebysig newslot abstract virtual 
          instance void  GetMemberProps_() cil managed
  {
  } // end of method IMetadataImport::GetMemberProps_

  .method public hidebysig newslot abstract virtual 
          instance void  GetFieldProps(int32 mb,
                                       [out] int32& mdTypeDef,
                                       [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szField,
                                       int32 cchField,
                                       [out] int32& pchField,
                                       [out] int32& pdwAttr,
                                       [out] native int& ppvSigBlob,
                                       [out] int32& pcbSigBlob,
                                       [out] int32& pdwCPlusTypeFlab,
                                       [out] native int& ppValue,
                                       [out] int32& pcchValue) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [7]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 10 50 43 43 4F 52 5F 53 49 47 4E 41 54 55   // ...PCCOR_SIGNATU
                                                                                                            52 45 2A 00 00 )                                  // RE*..
    .param [8]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [9]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [10]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0E 55 56 43 50 5F 43 4F 4E 53 54 41 4E 54   // ...UVCP_CONSTANT
                                                                                                            2A 00 00 )                                        // *..
    .param [11]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::GetFieldProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetPropertyProps_() cil managed
  {
  } // end of method IMetadataImport::GetPropertyProps_

  .method public hidebysig newslot abstract virtual 
          instance void  GetParamProps(int32 tk,
                                       [out] int32& pmd,
                                       [out] uint32& pulSequence,
                                       [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szName,
                                       uint32 cchName,
                                       [out] uint32& pchName,
                                       [out] uint32& pdwAttr,
                                       [out] uint32& pdwCPlusTypeFlag,
                                       [out] native int& ppValue,
                                       [out] uint32& pcchValue) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0C 6D 64 4D 65 74 68 6F 64 44 65 66 2A 00   // ...mdMethodDef*.
                                                                                                            00 ) 
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [7]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [8]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [9]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0E 55 56 43 50 5F 43 4F 4E 53 54 41 4E 54   // ...UVCP_CONSTANT
                                                                                                            2A 00 00 )                                        // *..
    .param [10]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport::GetParamProps

  .method public hidebysig newslot abstract virtual 
          instance int32  GetCustomAttributeByName(int32 tkObj,
                                                   string  marshal( lpwstr) szName,
                                                   [out] native int& ppData,
                                                   [out] uint32& pcbData) cil managed preservesig
  {
  } // end of method IMetadataImport::GetCustomAttributeByName

  .method public hidebysig newslot abstract virtual 
          instance bool  IsValidToken([in] uint32  marshal( unsigned int32) tk) cil managed preservesig
  {
  } // end of method IMetadataImport::IsValidToken

  .method public hidebysig newslot abstract virtual 
          instance void  GetNestedClassProps(int32 tdNestedClass,
                                             [out] int32& tdEnclosingClass) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
  } // end of method IMetadataImport::GetNestedClassProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetNativeCallConvFromSig_() cil managed
  {
  } // end of method IMetadataImport::GetNativeCallConvFromSig_

  .method public hidebysig newslot abstract virtual 
          instance void  IsGlobal_() cil managed
  {
  } // end of method IMetadataImport::IsGlobal_

} // end of class Microsoft.Samples.Debugging.CorMetadata.NativeApi.IMetadataImport

.class interface public abstract auto ansi Microsoft.Samples.Debugging.CorMetadata.NativeApi.IMetadataImport2
       implements Microsoft.Samples.Debugging.CorMetadata.NativeApi.IMetadataImport
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 46 43 45 35 45 46 41 30 2D 38 42 42 41   // ..$FCE5EFA0-8BBA
                                                                                                  2D 34 66 38 65 2D 41 30 33 36 2D 38 46 32 30 32   // -4f8e-A036-8F202
                                                                                                  32 42 30 38 34 36 36 00 00 )                      // 2B08466..
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  CloseEnum(native int hEnum) cil managed preservesig
  {
  } // end of method IMetadataImport2::CloseEnum

  .method public hidebysig newslot abstract virtual 
          instance void  CountEnum(native int hEnum,
                                   [out] int32& pulCount) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::CountEnum

  .method public hidebysig newslot abstract virtual 
          instance void  ResetEnum(native int hEnum,
                                   int32 ulPos) cil managed
  {
  } // end of method IMetadataImport2::ResetEnum

  .method public hidebysig newslot abstract virtual 
          instance void  EnumTypeDefs(native int& phEnum,
                                      [out] int32& rTypeDefs,
                                      uint32 cMax,
                                      [out] uint32& pcTypeDefs) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::EnumTypeDefs

  .method public hidebysig newslot abstract virtual 
          instance void  EnumInterfaceImpls_(native int phEnum,
                                             int32 td) cil managed
  {
  } // end of method IMetadataImport2::EnumInterfaceImpls_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumTypeRefs_() cil managed
  {
  } // end of method IMetadataImport2::EnumTypeRefs_

  .method public hidebysig newslot abstract virtual 
          instance void  FindTypeDefByName([in] string  marshal( lpwstr) szTypeDef,
                                           [in] int32 tkEnclosingClass,
                                           [out] int32& token) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
  } // end of method IMetadataImport2::FindTypeDefByName

  .method public hidebysig newslot abstract virtual 
          instance void  GetScopeProps([out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szName,
                                       [in] int32 cchName,
                                       [out] int32& pchName,
                                       [out] valuetype [mscorlib]System.Guid& mvid) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::GetScopeProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetModuleFromScope_() cil managed
  {
  } // end of method IMetadataImport2::GetModuleFromScope_

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeDefProps([in] int32 td,
                                         [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szTypeDef,
                                         [in] int32 cchTypeDef,
                                         [out] int32& pchTypeDef,
                                         [out] valuetype [mscorlib]System.Reflection.TypeAttributes&  marshal( unsigned int32) pdwTypeDefFlags,
                                         [out] int32& ptkExtends) cil managed
  {
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 08 6D 64 54 6F 6B 65 6E 2A 00 00 )          // ...mdToken*..
  } // end of method IMetadataImport2::GetTypeDefProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetInterfaceImplProps_() cil managed
  {
  } // end of method IMetadataImport2::GetInterfaceImplProps_

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeRefProps(int32 tr,
                                         [out] int32& ptkResolutionScope,
                                         [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szName,
                                         [in] int32 cchName,
                                         [out] int32& pchName) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 08 6D 64 54 6F 6B 65 6E 2A 00 00 )          // ...mdToken*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::GetTypeRefProps

  .method public hidebysig newslot abstract virtual 
          instance void  ResolveTypeRef_() cil managed
  {
  } // end of method IMetadataImport2::ResolveTypeRef_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMembers_() cil managed
  {
  } // end of method IMetadataImport2::EnumMembers_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMembersWithName_() cil managed
  {
  } // end of method IMetadataImport2::EnumMembersWithName_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMethods(native int& phEnum,
                                     int32 cl,
                                     [out] int32& mdMethodDef,
                                     int32 cMax,
                                     [out] int32& pcTokens) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0C 6D 64 4D 65 74 68 6F 64 44 65 66 2A 00   // ...mdMethodDef*.
                                                                                                            00 ) 
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::EnumMethods

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMethodsWithName_() cil managed
  {
  } // end of method IMetadataImport2::EnumMethodsWithName_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumFields(native int& phEnum,
                                    int32 cl,
                                    [out] int32& mdFieldDef,
                                    int32 cMax,
                                    [out] uint32& pcTokens) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0B 6D 64 46 69 65 6C 64 44 65 66 2A 00 00 ) // ...mdFieldDef*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::EnumFields

  .method public hidebysig newslot abstract virtual 
          instance void  EnumFieldsWithName_() cil managed
  {
  } // end of method IMetadataImport2::EnumFieldsWithName_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumParams(native int& phEnum,
                                    int32 mdMethodDef,
                                    [out] int32& mdParamDef,
                                    int32 cMax,
                                    [out] uint32& pcTokens) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0B 6D 64 50 61 72 61 6D 44 65 66 2A 00 00 ) // ...mdParamDef*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::EnumParams

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMemberRefs_() cil managed
  {
  } // end of method IMetadataImport2::EnumMemberRefs_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMethodImpls_() cil managed
  {
  } // end of method IMetadataImport2::EnumMethodImpls_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumPermissionSets_() cil managed
  {
  } // end of method IMetadataImport2::EnumPermissionSets_

  .method public hidebysig newslot abstract virtual 
          instance void  FindMember_() cil managed
  {
  } // end of method IMetadataImport2::FindMember_

  .method public hidebysig newslot abstract virtual 
          instance void  FindMethod_() cil managed
  {
  } // end of method IMetadataImport2::FindMethod_

  .method public hidebysig newslot abstract virtual 
          instance void  FindField_() cil managed
  {
  } // end of method IMetadataImport2::FindField_

  .method public hidebysig newslot abstract virtual 
          instance void  FindMemberRef_() cil managed
  {
  } // end of method IMetadataImport2::FindMemberRef_

  .method public hidebysig newslot abstract virtual 
          instance void  GetMethodProps([in] uint32 md,
                                        [out] int32& pClass,
                                        [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szMethod,
                                        [in] int32 cchMethod,
                                        [out] int32& pchMethod,
                                        [out] uint32& pdwAttr,
                                        [out] native int& ppvSigBlob,
                                        [out] uint32& pcbSigBlob,
                                        [out] uint32& pulCodeRVA,
                                        [out] uint32& pdwImplFlags) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [7]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 10 50 43 43 4F 52 5F 53 49 47 4E 41 54 55   // ...PCCOR_SIGNATU
                                                                                                            52 45 2A 00 00 )                                  // RE*..
    .param [8]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [9]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [10]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
  } // end of method IMetadataImport2::GetMethodProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetMemberRefProps([in] uint32 mr,
                                           [out] int32& ptk,
                                           [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szMember,
                                           [in] int32 cchMember,
                                           [out] uint32& pchMember,
                                           [out] native int& ppvSigBlob,
                                           [out] int32& pbSig) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0C 6D 64 4D 65 6D 62 65 72 52 65 66 2A 00   // ...mdMemberRef*.
                                                                                                            00 ) 
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 10 50 43 43 4F 52 5F 53 49 47 4E 41 54 55   // ...PCCOR_SIGNATU
                                                                                                            52 45 2A 00 00 )                                  // RE*..
    .param [7]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::GetMemberRefProps

  .method public hidebysig newslot abstract virtual 
          instance void  EnumProperties_() cil managed
  {
  } // end of method IMetadataImport2::EnumProperties_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumEvents_() cil managed
  {
  } // end of method IMetadataImport2::EnumEvents_

  .method public hidebysig newslot abstract virtual 
          instance void  GetEventProps_() cil managed
  {
  } // end of method IMetadataImport2::GetEventProps_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMethodSemantics_() cil managed
  {
  } // end of method IMetadataImport2::EnumMethodSemantics_

  .method public hidebysig newslot abstract virtual 
          instance void  GetMethodSemantics_() cil managed
  {
  } // end of method IMetadataImport2::GetMethodSemantics_

  .method public hidebysig newslot abstract virtual 
          instance void  GetClassLayout_() cil managed
  {
  } // end of method IMetadataImport2::GetClassLayout_

  .method public hidebysig newslot abstract virtual 
          instance void  GetFieldMarshal_() cil managed
  {
  } // end of method IMetadataImport2::GetFieldMarshal_

  .method public hidebysig newslot abstract virtual 
          instance void  GetRVA_() cil managed
  {
  } // end of method IMetadataImport2::GetRVA_

  .method public hidebysig newslot abstract virtual 
          instance void  GetPermissionSetProps_() cil managed
  {
  } // end of method IMetadataImport2::GetPermissionSetProps_

  .method public hidebysig newslot abstract virtual 
          instance void  GetSigFromToken_() cil managed
  {
  } // end of method IMetadataImport2::GetSigFromToken_

  .method public hidebysig newslot abstract virtual 
          instance void  GetModuleRefProps_() cil managed
  {
  } // end of method IMetadataImport2::GetModuleRefProps_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumModuleRefs_() cil managed
  {
  } // end of method IMetadataImport2::EnumModuleRefs_

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeSpecFromToken_() cil managed
  {
  } // end of method IMetadataImport2::GetTypeSpecFromToken_

  .method public hidebysig newslot abstract virtual 
          instance void  GetNameFromToken_() cil managed
  {
  } // end of method IMetadataImport2::GetNameFromToken_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumUnresolvedMethods_() cil managed
  {
  } // end of method IMetadataImport2::EnumUnresolvedMethods_

  .method public hidebysig newslot abstract virtual 
          instance void  GetUserString([in] int32 stk,
                                       [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szString,
                                       [in] int32 cchString,
                                       [out] int32& pchString) cil managed
  {
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::GetUserString

  .method public hidebysig newslot abstract virtual 
          instance void  GetPinvokeMap_() cil managed
  {
  } // end of method IMetadataImport2::GetPinvokeMap_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumSignatures_() cil managed
  {
  } // end of method IMetadataImport2::EnumSignatures_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumTypeSpecs_() cil managed
  {
  } // end of method IMetadataImport2::EnumTypeSpecs_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumUserStrings_() cil managed
  {
  } // end of method IMetadataImport2::EnumUserStrings_

  .method public hidebysig newslot abstract virtual 
          instance void  GetParamForMethodIndex_() cil managed
  {
  } // end of method IMetadataImport2::GetParamForMethodIndex_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumCustomAttributes(native int& phEnum,
                                              int32 tk,
                                              int32 tkType,
                                              [out] int32& mdCustomAttribute,
                                              uint32 cMax,
                                              [out] uint32& pcTokens) cil managed
  {
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 12 6D 64 43 75 73 74 6F 6D 41 74 74 72 69   // ...mdCustomAttri
                                                                                                            62 75 74 65 2A 00 00 )                            // bute*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::EnumCustomAttributes

  .method public hidebysig newslot abstract virtual 
          instance void  GetCustomAttributeProps_() cil managed
  {
  } // end of method IMetadataImport2::GetCustomAttributeProps_

  .method public hidebysig newslot abstract virtual 
          instance void  FindTypeRef_() cil managed
  {
  } // end of method IMetadataImport2::FindTypeRef_

  .method public hidebysig newslot abstract virtual 
          instance void  GetMemberProps_() cil managed
  {
  } // end of method IMetadataImport2::GetMemberProps_

  .method public hidebysig newslot abstract virtual 
          instance void  GetFieldProps(int32 mb,
                                       [out] int32& mdTypeDef,
                                       [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szField,
                                       int32 cchField,
                                       [out] int32& pchField,
                                       [out] int32& pdwAttr,
                                       [out] native int& ppvSigBlob,
                                       [out] int32& pcbSigBlob,
                                       [out] int32& pdwCPlusTypeFlab,
                                       [out] native int& ppValue,
                                       [out] int32& pcchValue) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [7]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 10 50 43 43 4F 52 5F 53 49 47 4E 41 54 55   // ...PCCOR_SIGNATU
                                                                                                            52 45 2A 00 00 )                                  // RE*..
    .param [8]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [9]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [10]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0E 55 56 43 50 5F 43 4F 4E 53 54 41 4E 54   // ...UVCP_CONSTANT
                                                                                                            2A 00 00 )                                        // *..
    .param [11]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::GetFieldProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetPropertyProps_() cil managed
  {
  } // end of method IMetadataImport2::GetPropertyProps_

  .method public hidebysig newslot abstract virtual 
          instance void  GetParamProps(int32 tk,
                                       [out] int32& pmd,
                                       [out] uint32& pulSequence,
                                       [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) szName,
                                       uint32 cchName,
                                       [out] uint32& pchName,
                                       [out] uint32& pdwAttr,
                                       [out] uint32& pdwCPlusTypeFlag,
                                       [out] native int& ppValue,
                                       [out] uint32& pcchValue) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0C 6D 64 4D 65 74 68 6F 64 44 65 66 2A 00   // ...mdMethodDef*.
                                                                                                            00 ) 
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [6]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [7]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [8]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [9]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0E 55 56 43 50 5F 43 4F 4E 53 54 41 4E 54   // ...UVCP_CONSTANT
                                                                                                            2A 00 00 )                                        // *..
    .param [10]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::GetParamProps

  .method public hidebysig newslot abstract virtual 
          instance int32  GetCustomAttributeByName(int32 tkObj,
                                                   string  marshal( lpwstr) szName,
                                                   [out] native int& ppData,
                                                   [out] uint32& pcbData) cil managed preservesig
  {
  } // end of method IMetadataImport2::GetCustomAttributeByName

  .method public hidebysig newslot abstract virtual 
          instance bool  IsValidToken([in] uint32  marshal( unsigned int32) tk) cil managed preservesig
  {
  } // end of method IMetadataImport2::IsValidToken

  .method public hidebysig newslot abstract virtual 
          instance void  GetNestedClassProps(int32 tdNestedClass,
                                             [out] int32& tdEnclosingClass) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0A 6D 64 54 79 70 65 44 65 66 2A 00 00 )    // ...mdTypeDef*..
  } // end of method IMetadataImport2::GetNestedClassProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetNativeCallConvFromSig_() cil managed
  {
  } // end of method IMetadataImport2::GetNativeCallConvFromSig_

  .method public hidebysig newslot abstract virtual 
          instance void  IsGlobal_() cil managed
  {
  } // end of method IMetadataImport2::IsGlobal_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumGenericParams(native int& hEnum,
                                           int32 tk,
                                           [out] int32& rGenericParams,
                                           uint32 cMax,
                                           [out] uint32& pcGenericParams) cil managed
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0F 6D 64 47 65 6E 65 72 69 63 50 61 72 61   // ...mdGenericPara
                                                                                                            6D 2A 00 00 )                                     // m*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::EnumGenericParams

  .method public hidebysig newslot abstract virtual 
          instance void  GetGenericParamProps(int32 gp,
                                              [out] uint32& pulParamSeq,
                                              [out] int32& pdwParamFlags,
                                              [out] int32& ptOwner,
                                              [out] int32& ptkKind,
                                              [out] class [mscorlib]System.Text.StringBuilder  marshal( lpwstr) wzName,
                                              uint64 cchName,
                                              [out] uint64& pchName) cil managed
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 44 57 4F 52 44 2A 00 00 )                // ...DWORD*..
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 08 6D 64 54 6F 6B 65 6E 2A 00 00 )          // ...mdToken*..
    .param [5]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 08 6D 64 54 6F 6B 65 6E 2A 00 00 )          // ...mdToken*..
    .param [8]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::GetGenericParamProps

  .method public hidebysig newslot abstract virtual 
          instance void  GetMethodSpecProps(int32 mi,
                                            [out] int32& tkParent,
                                            [out] native int& ppvSigBlob,
                                            [out] int32& pcbSigBlob) cil managed
  {
    .param [1]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 0C 6D 64 4D 65 74 68 6F 64 53 70 65 63 00   // ...mdMethodSpec.
                                                                                                            00 ) 
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 08 6D 64 54 6F 6B 65 6E 2A 00 00 )          // ...mdToken*..
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 10 50 43 43 4F 52 5F 53 49 47 4E 41 54 55   // ...PCCOR_SIGNATU
                                                                                                            52 45 2A 00 00 )                                  // RE*..
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 06 55 4C 4F 4E 47 2A 00 00 )                // ...ULONG*..
  } // end of method IMetadataImport2::GetMethodSpecProps

  .method public hidebysig newslot abstract virtual 
          instance void  EnumGenericParamConstraints_() cil managed
  {
  } // end of method IMetadataImport2::EnumGenericParamConstraints_

  .method public hidebysig newslot abstract virtual 
          instance void  GetGenericParamConstraintProps_() cil managed
  {
  } // end of method IMetadataImport2::GetGenericParamConstraintProps_

  .method public hidebysig newslot abstract virtual 
          instance void  GetPEKind_() cil managed
  {
  } // end of method IMetadataImport2::GetPEKind_

  .method public hidebysig newslot abstract virtual 
          instance void  GetVersionString_() cil managed
  {
  } // end of method IMetadataImport2::GetVersionString_

  .method public hidebysig newslot abstract virtual 
          instance void  EnumMethodSpecs_() cil managed
  {
  } // end of method IMetadataImport2::EnumMethodSpecs_

} // end of class Microsoft.Samples.Debugging.CorMetadata.NativeApi.IMetadataImport2

.class interface public abstract auto ansi Microsoft.Samples.Debugging.CorMetadata.NativeApi.IMetadataAssemblyImport
{
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 45 45 36 32 34 37 30 42 2D 45 39 34 42   // ..$EE62470B-E94B
                                                                                                  2D 34 32 34 65 2D 39 42 37 43 2D 32 46 30 30 43   // -424e-9B7C-2F00C
                                                                                                  39 32 34 39 46 39 33 00 00 )                      // 9249F93..
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(valuetype [mscorlib]System.Runtime.InteropServices.ComInterfaceType) = ( 01 00 01 00 00 00 00 00 ) 
} // end of class Microsoft.Samples.Debugging.CorMetadata.NativeApi.IMetadataAssemblyImport


// =============================================================

.custom ([mscorlib]System.Runtime.CompilerServices.AssemblyAttributesGoHere) instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                                                                                63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
// *********** DISASSEMBLY COMPLETE ***********************

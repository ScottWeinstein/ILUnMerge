//---------------------------------------------------------------------
//  This file is part of the CLR Managed Debugger (mdbg) Sample.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//---------------------------------------------------------------------

ReadMe.txt for corapi2 project.

Visual Studio does not support Intermediate Language (IL) projects, so this is 
a project that just runs ilasm.

The IL files in this project should not be modified.  They represent a COM marshaling code used by the sample. COM marshaling code is used to call 
native Managed Debugging API functions.

The functions available in this dll should primarily be called from the corapi Managed Wrappers.  See that ReadMe for details.

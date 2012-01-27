// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::IO;
using namespace System::Threading;

namespace imageshrinker
{
	ref class CWorkerThreadStartInfo
	{
	public:
		String ^ sSrc;
		String ^ sDest;
		int iW;
		int iH;
	};

	delegate void delVoidVoid (void);
	delegate void delVoidString (String ^);
};

// TODO: reference additional headers your program requires here
//using namespace imageshrinker;

#include "SyncBuffer.h"
#include "Form1.h"

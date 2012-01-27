#pragma once
#include "stdafx.h"

namespace imageshrinker
{
	using namespace System::Collections;
	public ref class SyncBuffer
	{
	private:
		Queue ^ queue;

	public:
		SyncBuffer ()
		{
			queue = gcnew Queue;
		}
		~SyncBuffer ()
		{
			for each (FileInfo ^ file in queue)
				delete file;
			delete queue;
		}
		property FileInfo ^ Buffer
		{
			FileInfo ^ get ()
			{
				Monitor::Enter (this);

				if (this->queue->Count == 0)
				{
					Monitor::Wait (this);
				}
				Monitor::Pulse (this);

				FileInfo ^ buffCpy = (FileInfo ^)this->queue->Peek ();
				this->queue->Dequeue ();

				Monitor::Exit (this);
				return buffCpy;
			}

			void set (FileInfo ^ newFile)
			{
				Monitor::Enter (this);
				queue->Enqueue (newFile);
				Monitor::Pulse (this);
				Monitor::Exit (this);
			}
		}
	};
};
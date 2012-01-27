using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Threading;

namespace BattleOfLunchClient
{
	public class SafeBuffer
	{
		private Queue buffer;

		public SafeBuffer ()
		{
			buffer = new Queue ();
		}

		public Object Buffer
		{
			get
			{
				Monitor.Enter (this);
				while (buffer.Count == 0)
				{
					Monitor.Wait (this);
					Monitor.Pulse (this);
				}
				Object ret = (Object)buffer.Peek ();
				buffer.Dequeue ();
				Monitor.Exit (this);
				return ret;
			}
			set
			{
				Monitor.Enter (this);
				//				if (value == null)
				//					buffer.Clear();
				/*				while (buffer.Count >= 20)
								{
									Monitor.Wait (this);
									Monitor.Pulse (this);
								}
				*/
				buffer.Enqueue (value);
				Monitor.Pulse (this);
				Monitor.Exit (this);
			}
		}

		public void Clear ()
		{
			Monitor.Enter (this);
			buffer.Clear ();
			Monitor.Pulse (this);
			Monitor.Exit (this);
		}

		public int Size ()
		{
			Monitor.Enter (this);
			int count = buffer.Count;
			Monitor.Pulse (this);
			Monitor.Exit (this);
			return count;
		}
	}
}

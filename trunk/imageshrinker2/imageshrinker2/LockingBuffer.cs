using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ImageManipulator2
{
	public class LockingBuffer<T>
	{
		private Queue<T> buffer;

		public LockingBuffer()
		{
			buffer = new Queue<T> ();
		}

		public T Buffer
		{
			get
			{
				T ret = default(T);

				lock (this)
				{
					if (buffer.Count > 0)
						ret = buffer.Dequeue();
				}
				return ret;
			}
			set
			{
				lock (this)
				{
					buffer.Enqueue(value);
				}
			}
		}

		public void Clear ()
		{
			lock (this)
			{
				buffer.Clear();
			}
		}
	}
}

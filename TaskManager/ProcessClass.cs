using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
	public class ProcessClass
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Priority { get; internal set; }
		public long CurrentMemoryUsage { get; internal set; }
		public long PeakMemoryUsage { get; internal set; }

		public override string ToString()
		{
			return Id.ToString();
		}
	}
}

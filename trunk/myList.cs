/*
 *HamExamHelper, the little helper to help you pass your ham exams!
 *Copyright (C) 2006 Markus Schulz
 * 
 *This program is free software; you can redistribute it and/or
 *modify it under the terms of the GNU General Public License
 *as published by the Free Software Foundation; either version 2
 *of the License, or (at your option) any later version.
 *
 *This program is distributed in the hope that it will be useful,
 *but WITHOUT ANY WARRANTY; without even the implied warranty of
 *MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *GNU General Public License for more details.
 *
 *You should have received a copy of the GNU General Public License
 *along with this program; if not, write to the Free Software
 *Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 *
 * Created by Markus Schulz with the help of SharpDevelop and Visual C# express.
 * User: $Author$
 * Date: $LastChangedDate$
 * Rev : $Rev$
 * 
 * ID: $Id$
 */

using System.Collections.Generic;
using System;

namespace HamExamHelper
{
	/// <summary>
	/// Description of myList.
	/// </summary>
	public class MyList<T>:List<T>
	{
		private Random random;
		public T ReturnRandom()
		{
			if (this.Count==0)return default(T);
			else{
			return this[random.Next(this.Count)];
			}
		}
		
		public MyList()
		{
			random = new Random();
		}
	}
}

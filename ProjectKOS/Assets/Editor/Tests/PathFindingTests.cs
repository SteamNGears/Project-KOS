/**
 * Filename: DatabaseTests.cs
 * Author: Jakob Wilson
 * Created: 5/11/2015
 * Revision:
 * Rev. Date: 
 * Rev. Author: 
 * */


using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using Database;

namespace KOSTests
{
	/**
	 * Tests that pathfinding between rooms works
	 * */
	[TestFixture]
	[Category("Project KOS Tests")]
	internal class PathFindingTests
	{
		[Datapoint]
		GameObject go; 
		PathFinding p;

		[TestFixtureSetUp]
		public void Init()
		{
			go = GameObject.Find ("PathFinding");
			p = go.GetComponent<PathFinding> ();
		}
		
		[TestFixtureTearDown]
		public void Dispose()
		{

		}

		/**
		 * tests that when the door is not locked, a valid path is present
		 * */
		[Test]
		public void UnlockedDoorWorks_RunTime ()
		{
			if (p.ExitIsReachable ())
				Assert.Pass ();
			else
				Assert.Fail ();
		}

	}
}
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest
{
	[TestFixture]
	[Category("NPC State Manager")]
	internal class TestStates
	{
		
		[Test]
		public void TestOneEqualsOne()
		{
			int expectedResult = 1;
			int actualResult = 1;
			Assert.AreEqual(expectedResult, actualResult);
		}
		
		[Test]
		public void AddStateToManager()
		{
			RoutineState routine = new RoutineState();
			NPCStateManager stateManager = new NPCStateManager();
			stateManager.AddState(routine);
			bool success = stateManager.CheckForState(routine);
			Assert.IsTrue(success);
		}

		[Test]
		public void AddExistingStateToManager()
		{
			RoutineState routine = new RoutineState();
			NPCStateManager stateManager = new NPCStateManager();
			stateManager.AddState(routine);
			stateManager.AddState(routine);
			int success = 1;
			int check = stateManager.CurrentManagerStates().Count;
			Assert.AreEqual(success, check);
		}
	}
}

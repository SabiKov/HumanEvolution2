
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;


namespace UnityTest
{
	[TestFixture]
	[Category("Population Manager")]
	internal class TestPopulationManager
	{
		int MAX_POPULATION = 5;

		//test the tester
		[Test]
		public void TestOneEqualsOne()
		{
			int expectedResult = 1;
			int actualResult = 1;
			Assert.AreEqual(expectedResult, actualResult);
		}

		[Test]
		public void TestPopulationManagerCreation()
		{
			PopulationManager popManager = null;
			popManager = PopulationManager.createPopulationManager();
			Assert.IsNotNull (popManager);
		}

		[Test]
		public void TestPopulationManagersMinPopulation()
		{
			//Note max population is set to 5 for testing
			//population always set to zero on singleton creation
			PopulationManager popManager = null;
			popManager = PopulationManager.createPopulationManager();

			//As we are dealing with a singleton we need to reset
			//headcount variable, if running test suite numerous times
			for(int i = 0; i < MAX_POPULATION; i++){
				popManager.decreaseHeadCount();
			}
			
			bool expectedReply = false;			
			bool managerReply = popManager.decreaseHeadCount ();
			
			Assert.AreEqual (expectedReply, managerReply);
		}

		[Test]
		public void TestPopulationManagersMaxPopulation()
		{
			//Note max population is set to 5 for testing
			//population always set to zero on singleton creation
			PopulationManager popManager = null;
			popManager = PopulationManager.createPopulationManager();

			//As we are dealing with a singleton we need to reset
			//headcount variable, if running test suite numerous times
			for(int i = 0; i < MAX_POPULATION; i++){
				popManager.decreaseHeadCount();
			}

			bool requestNewNPC;

			for(int i = 0; i < MAX_POPULATION; i++){
				requestNewNPC = popManager.roomForMore();
				Assert.IsTrue ( requestNewNPC );
			}
		
			bool managerReply = popManager.roomForMore ();
			
			Assert.IsFalse ( managerReply );
		}

		[Test]
		public void TestPopulationManagersMaxPopulationPlusOne()
		{
			//Note max population is set to 5 for testing
			//population always set to zero on singleton creation
			PopulationManager popManager = null;
			popManager = PopulationManager.createPopulationManager();

			//As we are dealing with a singleton we need to reset
			//headcount variable, if running test suite numerous times
			for(int i = 0; i < MAX_POPULATION; i++){
				popManager.decreaseHeadCount();
			}
			
			for(int i = 0; i < MAX_POPULATION; i++){
				Assert.IsTrue ( popManager.roomForMore() );
			}
			
			Assert.IsFalse ( popManager.roomForMore() );
		}

		[Test]
		public void TestPopulationManagersAreSameObject()
		{
			PopulationManager popManager, popManager2 = null;
			popManager = PopulationManager.createPopulationManager();
			popManager2 = PopulationManager.createPopulationManager();

			Assert.AreSame (popManager, popManager2);
		}

		//Test two instances of pop manager cannot violate max population
		[Test]
		public void TestTwoManagersObeyMAX_POPULATION()
		{
			PopulationManager popManager = null;
			PopulationManager popManager2 = null;

			popManager = PopulationManager.createPopulationManager();
			popManager2 = PopulationManager.createPopulationManager();

			// Resetting population to 0
			for (int i = 0; i < MAX_POPULATION; i++) {
				popManager.decreaseHeadCount ();
			}

			Assert.IsTrue ( popManager.roomForMore() );
			Assert.IsTrue ( popManager.roomForMore() );
			Assert.IsTrue ( popManager2.roomForMore() );
			Assert.IsTrue ( popManager2.roomForMore() );
			Assert.IsTrue ( popManager2.roomForMore() );
			
			Assert.IsFalse ( popManager.roomForMore() );
			Assert.IsFalse ( popManager2.roomForMore() );
		}

		//Test two instances of pop manager cannot decrease MaxPopulation
		//to a value below zero
		[Test]
		public void TestTwoManagersObeyMIN_POPULATION()
		{
			PopulationManager popManager = null;
			PopulationManager popManager2 = null;

			popManager = PopulationManager.createPopulationManager();
			popManager2 = PopulationManager.createPopulationManager();

			// Resetting population to Max
			for (int i = 0; i < MAX_POPULATION; i++) {
				popManager.roomForMore ();
				popManager2.roomForMore ();
			}

			Assert.IsTrue ( popManager.decreaseHeadCount() );
			Assert.IsTrue ( popManager.decreaseHeadCount() );
			Assert.IsTrue ( popManager2.decreaseHeadCount() );
			Assert.IsTrue ( popManager2.decreaseHeadCount() );
			Assert.IsTrue ( popManager2.decreaseHeadCount() );
			
			Assert.IsFalse ( popManager.decreaseHeadCount() );
			Assert.IsFalse ( popManager2.decreaseHeadCount() );
		}
		

	}
}

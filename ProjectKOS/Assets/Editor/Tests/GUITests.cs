/**
 * Filename: GUIInteraces.cs
 * Author: Jakob Wilson
 * Created: 5/10/2015
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

namespace KOSTests
{
	/**
	 * Tests all the GUI interfaces to ensure that the correct elements can be accessed
	 * */
	[TestFixture]
	[Category("Project KOS Tests")]
	internal class GUITests
	{
		[Datapoint]
		GameObject mcCvs;
		[Datapoint]
		GameObject tfCvs;
		[Datapoint]
		GameObject saCvs;
		
		[TestFixtureSetUp]
		public void Init()
		{
			mcCvs = (GameObject)GameObject.Instantiate(Resources.Load("QCanvas/McCvs"));
			tfCvs = (GameObject)GameObject.Instantiate(Resources.Load("QCanvas/TFCvs"));
			saCvs = (GameObject)GameObject.Instantiate(Resources.Load("QCanvas/TFCvs"));
		}

		[TestFixtureTearDown]
		public void Dispose()
		{
			GameObject.DestroyImmediate (mcCvs);
			GameObject.DestroyImmediate(tfCvs);
			GameObject.DestroyImmediate (saCvs);
		}

		/**-----------------------TEST Multiple Choice-----------------------------------*/

		[Test]
		public void CreateMCCanvas()
		{
			if (mcCvs != null)
				Assert.Pass ();
			else 
				Assert.Fail ();
				
		}


		[Test]
		public void MCCanvasHasElements()
		{
			Button[] buttons = mcCvs.GetComponentsInChildren<Button> ();
			UnityEngine.UI.Text[] txt = mcCvs.GetComponentsInChildren<UnityEngine.UI.Text> ();

			if (buttons.Length != 4)
				Assert.Fail ("Incorrect number of buttons");
			else
				Assert.Pass ();


			if (txt.Length < 1)
				Assert.Fail ("Incorrect number of text fields");
			else
				Assert.Pass ();

			
		}

		/**---------------------------TEST True/False-----------------------------------*/

		[Test]
		public void CreateTFCanvas()
		{
			if (tfCvs != null)
				Assert.Pass ();
			else 
				Assert.Fail ();
			
		}
		
		
		[Test]
		public void TFCanvasHasElements()
		{
			Button[] buttons = tfCvs.GetComponentsInChildren<Button> ();
			UnityEngine.UI.Text[] txt = tfCvs.GetComponentsInChildren<UnityEngine.UI.Text> ();
			UnityEngine.UI.Toggle[] toggles = tfCvs.GetComponentsInChildren<UnityEngine.UI.Toggle> ();

			if (buttons.Length != 1)
				Assert.Fail ("Incorrect number of buttons");
			else
				Assert.Pass ();
			
			
			if (txt.Length < 1)
				Assert.Fail ("Incorrect number of text fields");
			else
				Assert.Pass ();

			if (toggles.Length < 2)
				Assert.Fail ("Incorrect number of toggles");
			else
				Assert.Pass ();
			
			
		}

		/**---------------------------TEST Short Answer-----------------------------------*/
		[Test]
		public void CreateSACanvas()
		{
			if (saCvs != null)
				Assert.Pass ();
			else 
				Assert.Fail ();
			
		}
		
		
		[Test]
		public void SACanvasHasElements()
		{
			Button[] buttons = saCvs.GetComponentsInChildren<Button> ();
			UnityEngine.UI.Text[] txt = saCvs.GetComponentsInChildren<UnityEngine.UI.Text> ();
			UnityEngine.UI.InputField[] inputs = saCvs.GetComponentsInChildren<UnityEngine.UI.InputField> ();
			
			if (buttons.Length != 1)
				Assert.Fail ("Incorrect number of buttons");
			else
				Assert.Pass ();
			
			
			if (txt.Length < 1)
				Assert.Fail ("Incorrect number of text fields");
			else
				Assert.Pass ();
			
			if (inputs.Length != 1)
				Assert.Fail ("Incorrect number of input fields");
			else
				Assert.Pass ();
			
			
		}






/*

		
		[Datapoint]
		public double zero = 0;
		[Datapoint]
		public double positive = 1;
		[Datapoint]
		public double negative = -1;
		[Datapoint]
		public double max = double.MaxValue;
		[Datapoint]
		public double infinity = double.PositiveInfinity;
		
		[Theory]
		public void SquareRootDefinition(double num)
		{
			Assume.That(num >= 0.0 && num < double.MaxValue);
			
			var sqrt = Math.Sqrt(num);
			
			Assert.That(sqrt >= 0.0);
			Assert.That(sqrt * sqrt, Is.EqualTo(num).Within(0.000001));
		}*/
	}
}

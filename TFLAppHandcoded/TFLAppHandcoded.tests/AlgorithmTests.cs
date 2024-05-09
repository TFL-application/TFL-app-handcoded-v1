using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFLAppHandcoded.tests
{

    [TestClass]
    [TestSubject(typeof(FastestPathAlgorithm))]
    public class AlgorithmTests
    {
        [TestMethod]
        public void AlgorithNodeDeclarationtTest()
        {
            // Create a model and test if the budget is equal to 0 at the start
            var algorithmNode = new FastestPathAlgorithm.AlgorithmNode();

            Assert.AreEqual(0, budgetModel.GetTotalBudget());

            // Set a new budget and test if it is equal to the new value
            budgetModel.SetTotalBudget(1000);
            Assert.AreEqual(1000, budgetModel.GetTotalBudget());
        }
    }
}


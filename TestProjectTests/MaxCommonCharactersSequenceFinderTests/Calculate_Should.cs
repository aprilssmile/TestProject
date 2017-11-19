using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Results;
using TestProject.TasksSolvers;

namespace TestProjectTests.MaxCommonCharactersSequenceFinderTests
{
    [TestClass]
    public class Calculate_Should
    {
        [TestMethod]
        public void ReturnEmptyResultWhenNoCommonSubstring()
        {
            var generator = new GuidGeneratorTest(new List<Guid>
            {
                new Guid("00000000-0000-0000-0000-000000000000"),
                new Guid("11111111-1111-1111-1111-111111111111"),
                new Guid("22222222-2222-2222-2222-222222222222")
            });

            var taskSolver = new MaxCommonCharactersSequenceFinder(generator, 2);
            var result = (FindMaxCommonSequenceResult)taskSolver.Calculate(new CancellationToken());

            Assert.AreEqual(0, result.CommonSequences.Count);
        }

        [TestMethod]
        public void ReturnEmptyResultWhenLessThanThreeGuid()
        {
            var generator = new GuidGeneratorTest(new List<Guid>
            {
                new Guid("01010101-0100-1234-0000-010101010101"),
                new Guid("02020202-0200-0000-1234-020202020202")
            });

            var taskSolver = new MaxCommonCharactersSequenceFinder(generator, 2);
            var result = (FindMaxCommonSequenceResult)taskSolver.Calculate(new CancellationToken());

            Assert.AreEqual(0, result.CommonSequences.Count);
        }

        [TestMethod]
        public void ReturnSeveralCommonSequences()
        {
            var generator = new GuidGeneratorTest(new List<Guid>
            {
                new Guid("11111111-3333-1111-4444-111111111111"),
                new Guid("22222222-4444-2222-3333-222222222222"),
                new Guid("22222222-4444-2222-0000-333322222222")
            });

            var taskSolver = new MaxCommonCharactersSequenceFinder(generator, 2);
            var result = (FindMaxCommonSequenceResult)taskSolver.Calculate(new CancellationToken());

            Assert.AreEqual(2, result.CommonSequences.Count);
            CollectionAssert.AreEquivalent(new List<string> { "3333", "4444" }, result.CommonSequences);
        }

        [TestMethod]
        public void ReturnCommonSequencesExclusiveDashs()
        {
            var generator = new GuidGeneratorTest(new List<Guid>
            {
                new Guid("11111111-3333-3311-4444-111111111111"),
                new Guid("22222222-4444-2222-3333-332222222222"),
                new Guid("22222222-4444-2222-3333-332222222222")
            });

            var taskSolver = new MaxCommonCharactersSequenceFinder(generator, 2);
            var result = (FindMaxCommonSequenceResult)taskSolver.Calculate(new CancellationToken());

            Assert.AreEqual(1, result.CommonSequences.Count);
            Assert.AreEqual("333333", result.CommonSequences.First());
        }

        [TestMethod]
        public void ReturnCommonSequencesForThreeGuids()
        {
            var generator = new GuidGeneratorTest(new List<Guid>
            {
                new Guid("11111111-3333-3311-4444-111111111111"),
                new Guid("22222222-4444-2222-3333-332222222222"),
                new Guid("22222222-4444-2222-3333-332222222222"),
                new Guid("00000000-0000-0000-0000-000000000000")
            });

            var taskSolver = new MaxCommonCharactersSequenceFinder(generator, 2);
            var result = (FindMaxCommonSequenceResult)taskSolver.Calculate(new CancellationToken());

            Assert.AreEqual(1, result.CommonSequences.Count);
            Assert.AreEqual("333333", result.CommonSequences.First());
        }

        [TestMethod]
        public void ReturnCommonSequencesForMoreThanThreeGuids()
        {
            var generator = new GuidGeneratorTest(new List<Guid>
            {
                new Guid("11111111-3333-3311-4444-111111111111"),
                new Guid("22222222-4444-2222-3333-332222222222"),
                new Guid("22222222-4444-2222-3333-332222222222"),
                new Guid("33333300-0000-0000-0000-000000333333")
            });

            var taskSolver = new MaxCommonCharactersSequenceFinder(generator, 2);
            var result = (FindMaxCommonSequenceResult)taskSolver.Calculate(new CancellationToken());

            Assert.AreEqual(1, result.CommonSequences.Count);
            Assert.AreEqual("333333", result.CommonSequences.First());
        }

        [TestMethod]
        public void ReturnMaxCommonSequence()
        {
            var generator = new GuidGeneratorTest(new List<Guid>
            {
                new Guid("11111111-3333-3311-4444-111111111111"),
                new Guid("22222222-4444-2222-3333-332222222222"),
                new Guid("22222222-4444-2222-3333-332222222222"),
                new Guid("66666666-6666-6666-6666-666666666666"),
                new Guid("01010101-0010-0010-0010-000077777777"),
                new Guid("77777777-0200-0020-0002-020202020202"),
                new Guid("00000000-0000-0000-0000-777777770000")
            });

            var taskSolver = new MaxCommonCharactersSequenceFinder(generator, 2);
            var result = (FindMaxCommonSequenceResult)taskSolver.Calculate(new CancellationToken());

            Assert.AreEqual(1, result.CommonSequences.Count);
            Assert.AreEqual("77777777", result.CommonSequences.First());
        }

        [TestMethod]
        public void ReturnEmptyResultWhenGuidCountArgumentNegative()
        {
            var generator = new GuidGeneratorTest(new List<Guid>());

            var taskSolver = new MaxCommonCharactersSequenceFinder(generator, -1);
            var result = (FindMaxCommonSequenceResult)taskSolver.Calculate(new CancellationToken());

            Assert.AreEqual(0, result.CommonSequences.Count);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day7AssemblyInstructions
    {
        public string SortInstructionSteps(IEnumerable<string> instructionStrings)
        {
            var sortedSteps = "";
            var dependencies = ParseStepDependencies(instructionStrings);
            var remainingSteps = ParseSteps(dependencies);

            while (remainingSteps.Count > 0)
            {
                var remainingDependencies = GetRemainingDependencies(dependencies, remainingSteps);

                var possibleNextSteps = new List<char>();
                foreach (var dependency in remainingDependencies)
                {
                    if (IsNotADependent(dependency.Parent, remainingDependencies))
                    {
                        possibleNextSteps.Add(dependency.Parent);
                    }
                }

                if (possibleNextSteps.Count > 0)
                {
                    var nextStep = possibleNextSteps.Min();
                    sortedSteps =  sortedSteps + nextStep;
                    remainingSteps.Remove(nextStep);
                }
                else
                {
                    sortedSteps = sortedSteps + Alphabetize(remainingSteps);
                    remainingSteps.Clear();
                }
            }

            return sortedSteps;
        }

        private List<StepDependency> ParseStepDependencies(IEnumerable<string> instructionStrings)
        {
            return instructionStrings
                .Select(instruction => new StepDependency
                {
                    Parent = instruction[5],
                    Child = instruction[instruction.Length - 12]
                }).ToList();
        }

        private static HashSet<char> ParseSteps(List<StepDependency> dependencies)
        {
            return dependencies.Aggregate(new HashSet<char>(),
                (allSteps, dependency) => new HashSet<char>(allSteps.Union(new[] {dependency.Parent, dependency.Child})));
        }


        private List<StepDependency> GetRemainingDependencies(List<StepDependency> dependencies, HashSet<char> remainingSteps)
        {
            return dependencies
                .Where(dependency => remainingSteps.Contains(dependency.Parent))
                .ToList();
        }
        private static bool IsNotADependent(char step, List<StepDependency> dependencies)
        {
            return dependencies.All(dependency => step != dependency.Child);
        }

        private string Alphabetize(IEnumerable<char> steps)
        {
            return String.Concat(steps.OrderBy(character => character));
        }

        internal struct StepDependency
        {
            internal char Parent, Child;
        }
    }
}

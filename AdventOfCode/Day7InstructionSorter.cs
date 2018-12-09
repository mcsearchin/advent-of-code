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
                var nextStep = GetPossibleNextSteps(dependencies, remainingSteps).Min();
                sortedSteps =  sortedSteps + nextStep;
                remainingSteps.Remove(nextStep);
            }

            return sortedSteps;
        }

        public int CalculateTimeToComplete(IEnumerable<string> instructionStrings, int baseStepDuration = 60, int numberOfWorkers = 5)
        {
            var dependencies = ParseStepDependencies(instructionStrings);
            var remainingSteps = ParseSteps(dependencies);
            var workers = Enumerable.Repeat(new Worker(), numberOfWorkers).ToArray();

            var elapsedSeconds = 0;
            do
            {
                for (var index = 0; index < workers.Length; index++)
                {
                    if (!workers[index].CurrentStep.HasValue)
                    {
                        var possibleNextSteps = GetPossibleNextSteps(dependencies, remainingSteps);

                        var stepsInProgress = GetStepsInProgress(workers);
                        var availableNextSteps = possibleNextSteps.Where(step => !stepsInProgress.Contains(step)).ToList();

                        if (availableNextSteps.Any())
                        {
                            workers[index].CurrentStep = availableNextSteps.First();
                            workers[index].Remaining = GetStepDuration(availableNextSteps.First(), baseStepDuration);
                        }
                    }
                }

                for (var index = 0; index < workers.Length; index++)
                {
                    if (workers[index].Remaining > 0)
                    {
                        workers[index].Remaining -= 1;
                    }

                    if (workers[index].CurrentStep.HasValue && workers[index].Remaining < 1)
                    {
                        remainingSteps.Remove(workers[index].CurrentStep.Value);
                        workers[index].CurrentStep = null;
                    }
                }

                elapsedSeconds++;

            } while (remainingSteps.Count > 0);


            return elapsedSeconds;
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

        private IEnumerable<char> GetPossibleNextSteps(List<StepDependency> dependencies, HashSet<char> remainingSteps)
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

            if (possibleNextSteps.Count < 1)
            {
                possibleNextSteps = remainingSteps.ToList();
            }

            return possibleNextSteps.OrderBy(step => step);
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

        private static List<char> GetStepsInProgress(Worker[] workers)
        {
            return workers
                .Where(worker => worker.CurrentStep.HasValue)
                .Select(worker => worker.CurrentStep.Value)
                .ToList();
        }

        private int GetStepDuration(char step, int baseStepDuration)
        {
            return step - 'A' + 1 + baseStepDuration;
        }

        internal struct StepDependency
        {
            internal char Parent, Child;
        }

        internal struct Worker
        {
            internal char? CurrentStep;
            internal int Remaining;
        }
    }
}

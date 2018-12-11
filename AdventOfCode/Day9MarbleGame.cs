using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day9MarbleGame
    {
        private const int MagicMultipleValue = 23;

        public long GetWinningScore(string gameSetup)
        {
            var numberOfPlayers = ParseNumberOfPlayers(gameSetup);
            var highestMarbleValue = ParseHighestMarbleValue(gameSetup);

            long currentMarbleValue = 0;
            var currentPlayer = 0;
            var marbleCircle = new LinkedList<long>(new[] {currentMarbleValue});
            var currentMarbleNode = marbleCircle.First;

            const long initialScore = 0;
            var scores = Enumerable.Repeat(initialScore, numberOfPlayers).ToArray();

            while (currentMarbleValue < highestMarbleValue)
            {
                currentMarbleValue++;
                if (currentMarbleValue % MagicMultipleValue == 0)
                {
                    scores[currentPlayer] += currentMarbleValue;
                    currentMarbleNode = GetRelativeNode(-7, currentMarbleNode);
                    scores[currentPlayer] += currentMarbleNode.Value;
                    currentMarbleNode = GetRelativeNode(1, currentMarbleNode);
                    marbleCircle.Remove(GetRelativeNode(-1, currentMarbleNode));
                }
                else
                {
                    currentMarbleNode = GetRelativeNode(1, currentMarbleNode);
                    marbleCircle.AddAfter(currentMarbleNode, currentMarbleValue);
                    currentMarbleNode = GetRelativeNode(1, currentMarbleNode);
                }

                currentPlayer = (currentPlayer + 1) % numberOfPlayers;
            }

            return scores.Max();
        }

        private LinkedListNode<T> GetRelativeNode<T>(int number, LinkedListNode<T> node)
        {
            var newNode = node;
            if (number >= 0)
            {
                for (var index = 0; index < number; index++)
                {
                    newNode = newNode.Next ?? newNode.List.First;
                }
            }
            else
            {
                for (var index = 0; index > number; index--)
                {
                    newNode = newNode.Previous ?? newNode.List.Last;
                }
            }

            return newNode;
        }

        private int ParseHighestMarbleValue(string gameSetup)
        {
            return int.Parse(Regex.Match(gameSetup, "[0-9]+(?= points)").Value);
        }

        private int ParseNumberOfPlayers(string gameSetup)
        {
            return int.Parse(Regex.Match(gameSetup, "[0-9]+(?= players)").Value);
        }
    }
}

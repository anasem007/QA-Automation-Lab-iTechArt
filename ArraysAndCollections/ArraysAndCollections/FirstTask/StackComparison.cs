using System.Collections.Generic;

namespace ArraysAndCollections.FirstTask
{
    public static class StackComparison
    {
        public static Stack<int> CompareStacks(Stack<int> firstStack, Stack<int> secondStack)
        {
            var stack = new Stack<int>();
            foreach (var stackElement in firstStack)
            {
                if(secondStack.Contains(stackElement) && !stack.Contains(stackElement)) 
                    stack.Push(stackElement);
            }
            return stack;
        }
    }
}
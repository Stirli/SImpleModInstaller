using System;
using Xunit;
using NumberQueue;

namespace NumberQueue.Tests
{
    public class QueueTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Constructor1ThrowsIfSizeBelowOne(int size)
        {
            //Arrange
            Action createBad1 = () =>
            {
                var queue = new Queue<int>(size);
            };

            //Act
            bool isNormalCreationNotFailed;
            try
            {
                var queue = new Queue<int>(8);
                isNormalCreationNotFailed = true;
            }
            catch
            {
                isNormalCreationNotFailed = false;
            }

            //Assert
            Assert.Throws<ArgumentException>(createBad1);
            Assert.True(isNormalCreationNotFailed);


        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Constructor2ThrowsIfSizeBelowOne(int size)
        {
            //Arrange
            Action createBad2 = () =>
            {
                var queue = new Queue<int>(new int[2], size);
            };

            //Act
            bool isNormalCreationNotFailed;
            try
            {
                var queue = new Queue<int>(new int[8], 8);
                isNormalCreationNotFailed = true;
            }
            catch
            {
                isNormalCreationNotFailed = false;
            }

            //Assert
            Assert.Throws<ArgumentException>(createBad2);
            Assert.True(isNormalCreationNotFailed);


        }

        [Fact]
        public void ConstructorThrowsIfDataIsNull()
        {
            //Arrange
            Action createBad = () =>
            {
                var queue = new Queue<int>(null);
            };


            //Assert
            Assert.Throws<ArgumentNullException>(createBad);
        }

        [Theory]
        [InlineData(new int[0], 8)]
        [InlineData(new int[] { 1 }, 8)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 8)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 2)]
        public void CountMustReflectQueueLength(int[] data, int bufferSize)
        {
            var queue = new Queue<int>(bufferSize);
            foreach (var item in data)
            {
                queue.Enqueue(item);
            }

            Assert.Equal(data.Length, queue.Count);
        }

        [Fact]
        public void DequeueMustRemoveElement()
        {
            //Arrange
            var firstItem = 8;
            var data = new[] { firstItem, 2, 3, 4 };
            var queue = new Queue<int>(data);

            //Act
            var dequeuedElement = queue.Dequeue();
            var contains = queue.Contains(dequeuedElement);

            //Assert
            Assert.Equal(firstItem, dequeuedElement);
            Assert.False(contains);
        }

        [Fact]
        public void PeekMustKeepElement()
        {
            //Arrange
            var firstItem = 8;
            var data = new[] { firstItem, 2, 3, 4 };
            var queue = new Queue<int>(data);

            //Act
            var peekedElement = queue.Peek();
            var contains = queue.Contains(peekedElement);

            //Assert
            Assert.Equal(firstItem, peekedElement);
            Assert.True(contains);
        }

        [Fact]
        public void DequeueMustThrowIfEmpty()
        {
            var queue = new Queue<int>();
            var badAction = new Action(() => queue.Dequeue());
            Assert.Throws<InvalidOperationException>(badAction);
        }
    }
}

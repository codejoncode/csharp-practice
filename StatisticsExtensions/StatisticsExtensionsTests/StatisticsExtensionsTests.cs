using StatisticsExtensions;
using System;
using Xunit;

namespace StatisticsExtensionsTests
{
    public class StatisticsExtensionsTests
    {
        [Fact]
        public void Test()
        {
            //Arrange 
            //Act 
            //Assert

        }

        [Fact]
        public void DataIsSorted()
        {
            //Arrange 
            int[] unsorted = new int[] { 9, 7, 1, 3, 1, 7, 5, 7 };
            Statistics statistics = new Statistics();
            //Act 
            int[] sortedData = statistics.SortData(unsorted);
            //Assert
            int previous = 0;
            bool set = false;
            bool isSorted = true; 
            foreach(var num in sortedData)
            {
                if (set == false)
                {
                    set = true;
                    previous = num; 
                }
                else
                {
                    if (previous <= num)
                    {
                        isSorted = false;
                        break;
                    }
                    else
                    {
                        previous = num; 
                    }
                }
            }
            Assert.True(isSorted == true);

        }

        [Fact]
        public void TruncatedMean_Average_Test()
        {
            //Arrange 
            int[] data = new int[] { 1, 1, 3, 5, 7, 7, 9 };

            Statistics statistics = new Statistics();
            //Act 
            double actual = statistics.TruncatedMean(data, 2);
            double expected = 5.0;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TruncatedMean_RemoveSpecificNumber_Test()
        {
            //Arrange 
            int[] data = new int[] { 1, 1, 3, 5, 7, 7, 9 };

            Statistics statistics = new Statistics();
            //Act 
            int[] newData = statistics.RemoveFromArray(data, 2);
            var expectedLength = 3;
            var actualLength = newData.Length;
            int expectedOne = 3;
            int expectedTwo = 5;
            int expectedThree = 7;
            int actualOne = newData[0];
            int actualTwo = newData[1];
            int actualThree = newData[2];
            //Assert
            Assert.Equal(expectedLength, actualLength);
            Assert.Equal(expectedOne, actualOne);
            Assert.Equal(expectedTwo, actualTwo);
            Assert.Equal(expectedThree, actualThree);

             

        }
    }
}

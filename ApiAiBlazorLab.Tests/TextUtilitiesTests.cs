using ApiAiBlazorLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiAiBlazorLab.Tests
{
    public class TextUtilitiesTests
    {
        [Fact]
        public void NullInput()
        {
            //Arange

            string input = null;

            //Act

            string result = TextUtilities.NormalizeFact(input);

            //Assert

            Assert.Equal("No fact available.", result);
        }

        [Fact]
        public void EmptyInput()
        {
            //Arrange

            string input = "";

            //Act

            string result = TextUtilities.NormalizeFact(input);

            //Assert

            Assert.Equal("No fact available.", result);
        }

        [Fact]
        public void MissingPeriod()
        {
            //Arrange

            string input = "Cats have 9 lives";

            //Act

            string result = TextUtilities.NormalizeFact(input);

            //Assert

            Assert.Equal("Cats have 9 lives.", result);
        }

        [Fact]
        public void HasPeriod()
        {
            //Arrange

            string input = "Cats have 9 lives.";

            //Act

            string result = TextUtilities.NormalizeFact(input);

            //Assert

            Assert.Equal("Cats have 9 lives.", result);
        }

        [Fact]
        public void HasWhitespace()
        {
            //Arrange

            string input = "Cats have 9 lives  ";

            //Act

            string result = TextUtilities.NormalizeFact(input);

            //Assert

            Assert.Equal("Cats have 9 lives.", result);
        }
    }
}

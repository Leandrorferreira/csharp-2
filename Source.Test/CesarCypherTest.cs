using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CesarCypherTest
    {
        #region Crypt Tests
        [Fact]
        public void Should_Not_Accept_Null_When_Crypt()
        {            
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentNullException>(() => cypher.Crypt(null));
        }

        [Fact]
        public void Should_Return_Empty_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Empty(cypher.Crypt(string.Empty));
        }

        [Fact]
        public void Should_Keep_Numbers_Out_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("123", cypher.Crypt("123"));
        }

        [Fact]
        public void Should_Retun_Numbers_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("def", cypher.Crypt("ABC"));
        }

        [Fact]
        public void Should_Not_Accept_Argument_Out_Range_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Crypt("a 12ç"));
        }

        [Fact]
        public void Should_Keep_White_Space_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("d 1e2f3g4h5i6j7k8l9m0abc", cypher.Crypt("a 1b2c3d4e5f6g7h8i9j0xyz"));
        }

        #endregion

        #region Decrypt Test

        [Fact]
        public void Should_Not_Accept_Null_When_Decrypt()
        {
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentNullException>(() => cypher.Decrypt(null));
        }

        [Fact]
        public void Should_Return_Empty_When_Decrypt()
        {
            var cypher = new CesarCypher();
            Assert.Empty(cypher.Decrypt(string.Empty));
        }

        [Fact]
        public void Should_Keep_Numbers_Out_When_Decrypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("123", cypher.Decrypt("123"));
        }

        [Fact]
        public void Should_Retun_Numbers_When_Decrypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("xyz", cypher.Decrypt("ABC"));
        }

        [Fact]
        public void Should_Not_Accept_Argument_Out_Range_When_Decrypt()
        {
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Decrypt("ç"));
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Decrypt("é"));
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Decrypt("&"));
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Decrypt("*"));
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Decrypt("%"));
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Decrypt(";"));
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Decrypt("ª"));
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Decrypt("º"));
        }

        [Fact]
        public void Should_Keep_White_Space_When_Decrypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("a 1b2c3d4e5f6g7h8i9j0xyz", cypher.Decrypt("d 1e2f3g4h5i6j7k8l9m0abc"));
        }

        #endregion
    }
}

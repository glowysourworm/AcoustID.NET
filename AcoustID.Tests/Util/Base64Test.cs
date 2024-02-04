﻿
namespace AcoustID.Tests.Util
{
    using AcoustID.Util;
    using NUnit.Framework;

    public class Base64Test
    {
        [Test]
        public void TestBase64Encode()
        {
            Assert.That(Base64.Encode("x"), Is.EqualTo("eA"));
            Assert.That(Base64.Encode("xx"), Is.EqualTo("eHg"));
            Assert.That(Base64.Encode("xxx"), Is.EqualTo("eHh4"));
            Assert.That(Base64.Encode("xxxx"), Is.EqualTo("eHh4eA"));
            Assert.That(Base64.Encode("xxxxx"), Is.EqualTo("eHh4eHg"));
            Assert.That(Base64.Encode("xxxxxx"), Is.EqualTo("eHh4eHh4"));
            Assert.That(Base64.Encode("\xff\xee"), Is.EqualTo("_-4"));
        }

        [Test]
        public void TestBase64Decode()
        {
            Assert.That(Base64.Decode("eA"), Is.EqualTo("x"));
            Assert.That(Base64.Decode("eHg"), Is.EqualTo("xx"));
            Assert.That(Base64.Decode("eHh4"), Is.EqualTo("xxx"));
            Assert.That(Base64.Decode("eHh4eA"), Is.EqualTo("xxxx"));
            Assert.That(Base64.Decode("eHh4eHg"), Is.EqualTo("xxxxx"));
            Assert.That(Base64.Decode("eHh4eHh4"), Is.EqualTo("xxxxxx"));
            Assert.That(Base64.Decode("_-4"), Is.EqualTo("\xff\xee"));
        }

        [Test]
        public void TestBase64EncodeLong()
        {
            byte[] original = {
		        1, 0, 1, 207, 17, 181, 36, 18, 19, 37, 65, 15, 31, 197, 149, 161, 63, 33, 22,
		        60, 141, 27, 202, 35, 184, 47, 254, 227, 135, 135, 11, 58, 139, 208, 65, 127,
		        52, 167, 241, 31, 99, 182, 25, 159, 96, 70, 71, 160, 251, 168, 75, 132, 185,
		        112, 230, 193, 133, 252, 42, 126, 66, 91, 121, 60, 135, 79, 24, 185, 210, 28,
		        199, 133, 255, 240, 113, 101, 67, 199, 23, 225, 181, 160, 121, 140, 67, 123,
		        161, 229, 184, 137, 30, 205, 135, 119, 70, 94, 252, 71, 120, 150
	        };
            string encoded = "AQABzxG1JBITJUEPH8WVoT8hFjyNG8ojuC_-44eHCzqL0EF_NKfxH2O2GZ9gRkeg-6hLhLlw5sGF_Cp-Qlt5PIdPGLnSHMeF__BxZUPHF-G1oHmMQ3uh5biJHs2Hd0Ze_Ed4lg";
            Assert.That(Base64.Encode(Base64.ByteEncoding.GetString(original)), Is.EqualTo(encoded));
        }

        [Test]
        public void TestBase64DecodeLong()
        {
            byte[] original = {
		        1, 0, 1, 207, 17, 181, 36, 18, 19, 37, 65, 15, 31, 197, 149, 161, 63, 33, 22,
		        60, 141, 27, 202, 35, 184, 47, 254, 227, 135, 135, 11, 58, 139, 208, 65, 127,
		        52, 167, 241, 31, 99, 182, 25, 159, 96, 70, 71, 160, 251, 168, 75, 132, 185,
		        112, 230, 193, 133, 252, 42, 126, 66, 91, 121, 60, 135, 79, 24, 185, 210, 28,
		        199, 133, 255, 240, 113, 101, 67, 199, 23, 225, 181, 160, 121, 140, 67, 123,
		        161, 229, 184, 137, 30, 205, 135, 119, 70, 94, 252, 71, 120, 150
	        };
            string encoded = "AQABzxG1JBITJUEPH8WVoT8hFjyNG8ojuC_-44eHCzqL0EF_NKfxH2O2GZ9gRkeg-6hLhLlw5sGF_Cp-Qlt5PIdPGLnSHMeF__BxZUPHF-G1oHmMQ3uh5biJHs2Hd0Ze_Ed4lg";
            Assert.That(Base64.Decode(encoded), Is.EqualTo(Base64.ByteEncoding.GetString(original)));
        }
    }
}

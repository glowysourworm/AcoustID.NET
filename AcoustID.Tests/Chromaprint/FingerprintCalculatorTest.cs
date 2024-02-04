﻿
namespace AcoustID.Tests.Chromaprint
{
    using AcoustID.Chromaprint;
    using NUnit.Framework;

    public class FingerprintCalculatorTest
    {
        [Test]
        public void TestCalculateSubfingerprint()
        {
            Image image = new Image(2, 2);
            image[0, 0] = 0.0;
            image[0, 1] = 1.0;
            image[1, 0] = 2.0;
            image[1, 1] = 3.0;

            Classifier[] classifiers = {
		        new Classifier(new Filter(0, 0, 1, 1), new Quantizer(0.01, 1.01, 1.5)),	
	        };
            FingerprintCalculator calculator = new FingerprintCalculator(classifiers);
            
            IntegralImage integral_image = new IntegralImage(image);
            Assert.That(calculator.CalculateSubfingerprint(integral_image, 0), Is.EqualTo(TestsHelper.GrayCode(0)));
            Assert.That(calculator.CalculateSubfingerprint(integral_image, 1), Is.EqualTo(TestsHelper.GrayCode(2)));
        }

        [Test]
        public void TestCalculate()
        {
            Image image = new Image(2, 3);
            image[0, 0] = 0.0;
            image[0, 1] = 1.0;
            image[1, 0] = 2.0;
            image[1, 1] = 3.0;
            image[2, 0] = 4.0;
            image[2, 1] = 5.0;

            Classifier[] classifiers = {
		        new Classifier(new Filter(0, 0, 1, 1), new Quantizer(0.01, 1.01, 1.5)),	
	        };
            FingerprintCalculator calculator = new FingerprintCalculator(classifiers);

            int[] fp = calculator.Calculate(image);
            Assert.That(fp.Length, Is.EqualTo(3));
            Assert.That(fp[0], Is.EqualTo(TestsHelper.GrayCode(0)));
            Assert.That(fp[1], Is.EqualTo(TestsHelper.GrayCode(2)));
            Assert.That(fp[2], Is.EqualTo(TestsHelper.GrayCode(3)));
        }
    }
}

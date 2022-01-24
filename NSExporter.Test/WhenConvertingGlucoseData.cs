using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace NSExporter.Test
{
    internal class WhenConvertingGlucoseData
    {
        [Test]
        public void ValueShouldBeConvertedProperly()
        {
            double mgdl = 200;
            mgdl.ToMmolL().Should().BeApproximately(11.1, 2);
        }

        [Test]
        public void ValueShouldBeConvertedMmolLToMgDl()
        {
            double mmol = 4;
            mmol.ToMgDl().Should().Be(72);
        }
    }
}

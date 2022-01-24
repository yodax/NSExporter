using System;
using FluentAssertions;
using NUnit.Framework;

namespace NSExporter.Test;

class WhenParsingSgvEntries
{
    [Test]
    public void TheDataShouldBeImported()
    {
        var glucoseEntries = GlucoseEntry.FromJson(_sgvJsonResult);
        glucoseEntries.Length.Should().Be(2);
        glucoseEntries[0].EntryTime.Should().Be(new DateTime(2022,1,1,22,8,37));
        glucoseEntries[0].GlucoseValue.Should().Be(270);
        glucoseEntries[0].SerialNumber.Should().Be("share2");
        
        glucoseEntries[0].ToString().Should().Be("share2,20220101220837,15.0,");

        glucoseEntries[1].EntryTime.Should().Be(new DateTime(2022,1,1,22,3,37));
        glucoseEntries[1].GlucoseValue.Should().Be(273);
        glucoseEntries[1].SerialNumber.Should().Be("CGMBLEKit Dexcom G6 21.0");

        glucoseEntries[1].ToString().Should().Be("CGMBLEKit Dexcom G6 21.0,20220101220337,15.2,");
    }

    private string _sgvJsonResult = "[{\"_id\":\"61d0d0f28479bbe4fb4d1d06\",\"sgv\":270,\"date\":1641074917000,\"dateString\":\"2022-01-01T22:08:37.000Z\",\"trend\":4,\"direction\":\"Flat\",\"device\":\"share2\",\"type\":\"sgv\",\"utcOffset\":0,\"sysTime\":\"2022-01-01T22:08:37.000Z\"},{\"_id\":\"61d0cfc48479bbe4fb4d1bc1\",\"device\":\"CGMBLEKit Dexcom G6 21.0\",\"dateString\":\"2022-01-01T22:03:37.000Z\",\"type\":\"sgv\",\"direction\":\"Flat\",\"sgv\":273,\"date\":1641074617004.6548,\"utcOffset\":0,\"sysTime\":\"2022-01-01T22:03:37.000Z\"}]";
}
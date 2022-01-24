using System;
using FluentAssertions;
using NUnit.Framework;

namespace NSExporter.Test;

internal class WhenExportingGlucoseData
{
    private readonly string[] _emptyExport = ExporterBuilder.NewExport()
        .Build()
        .Export();

    [Test]
    public void TheFixedHeaderShouldBeWritten()
    {
        _emptyExport.Length.Should().BeGreaterThanOrEqualTo(5);
    }

    [Test]
    public void TheFileVersionShouldBeWritten()
    {
        _emptyExport[0].Should().Be("#Version");
        _emptyExport[1].Should().Be("NL2.2");
        _emptyExport[2].Should().Be("#MeterFamilie");
    }

    [Test]
    public void TheFileShouldBeMarkedAsNightscout()
    {
        _emptyExport[3].Should().StartWith("NightScout,");
    }

    [Test]
    public void TheGlucoseHeaderShouldBeWritten()
    {
        _emptyExport[4].Should().Be("#Glucose");
    }

    [Test]
    public void TheNightscoutVersionShouldBeWritten()
    {
        ExporterBuilder.NewExport()
            .WithVersion("14.2.6")
            .Build()
            .Export()[3]
            .Should().Be("NightScout,14.2.6");
    }

    [Test]
    public void TheGlucoseDataShouldBeWritten()
    {
        var export = ExporterBuilder.NewExport()
            .WithPatientIdentifier("3002167")
            .WithDateOfBirth(new DateTime(2005, 7, 5))
            .WithGlucoseEntry(new DateTime(2020, 2, 3, 8, 9, 10), 4.5, "SN")
            .WithGlucoseEntry(new DateTime(2020, 2, 3, 14, 14, 11), 5.5, "SN")
            .Build()
            .Export();

        export[5].Should().Be("3002167,05072005,SN,20200203080910,4.5,");
        export[6].Should().Be("3002167,05072005,SN,20200203141411,5.5,");
    }
}
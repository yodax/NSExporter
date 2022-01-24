using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NSExporter.Test;

internal class ExporterBuilder
{
    private readonly Exporter _exporter;
    private readonly List<GlucoseEntry> _entries;

    private ExporterBuilder(Exporter exporter)
    {
        _entries = new List<GlucoseEntry>();
        _exporter = exporter;
    }

    public static ExporterBuilder NewExport()
    {
        return new ExporterBuilder(new Exporter());
    }

    public ExporterBuilder WithVersion(string? version)
    {
        _exporter.Version = version;
        return this;
    }

    public Exporter Build()
    {
        _exporter.AddEntries(_entries.ToArray());
        return _exporter;
    }

    public ExporterBuilder WithPatientIdentifier(string? identifier)
    {
        _exporter.Identifier = identifier;
        return this;
    }

    public ExporterBuilder WithDateOfBirth(DateTime birthDate)
    {
        _exporter.DateOfBirth = birthDate;
        return this;
    }

    public ExporterBuilder WithGlucoseEntry(DateTime entryTime, double glucoseValue, string serialNumber)
    {
        _entries.Add(new GlucoseEntry(entryTime, glucoseValue.ToMgDl(), serialNumber));
        return this;
    }
}
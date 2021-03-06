﻿using NUnit.Framework;
using System.Collections.Generic;

public class VersionFormatterTest
{
    private readonly Dictionary<string, string> expectedByInput = new Dictionary<string, string>()
    {
        ["#157-gitignore-csproj"] = "Alpha-Issue157",
        ["#164-cursor-overhaul"] = "Alpha-Issue164",
        ["#176-editorconfig"] = "Alpha-Issue176",
        ["#75-cannons"] = "Alpha-Issue75",
        ["development"] = "development",
        ["master"] = "master",
        ["titan-fix"] = "titan-fix",
        ["version-manager"] = "version-manager"
    };

    /// <summary>
    /// This relies on the defaults of <see cref="VersionFormatter"/>,
    /// so it may break when that changes.
    /// </summary>
    [Test]
    public void DefaultFormatterHandlesDictionary()
    {
        var formatter = new VersionFormatter();
        RunDictionaryTest(formatter);
    }

    /// <summary>
    /// Dictionary was designed to handle this.
    /// It shouldn't break, unless the dictionary is modified.
    /// </summary>
    [Test]
    public void DictionaryTestBenchmark()
    {
        var formatter = new VersionFormatter("#(?<issue>\\d+)", "Alpha-Issue<issue>");
        RunDictionaryTest(formatter);
    }

    private void RunDictionaryTest(VersionFormatter formatter)
    {
        foreach (var pair in expectedByInput)
        {
            var branchName = pair.Key;
            var expected = pair.Value;
            var actual = formatter.FormatBranchName(branchName);

            Assert.AreEqual(expected, actual);
        }
    }
}
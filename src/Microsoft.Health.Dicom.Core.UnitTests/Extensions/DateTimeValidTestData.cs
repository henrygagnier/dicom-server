﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Health.Dicom.Core.UnitTests.Extensions
{
    public class DateTimeValidTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "20200301010203.123+0500", 2020, 03, 01, 01, 02, 03, 123, TimeSpan.FromHours(5) };
            yield return new object[] { "20200301010203.123-0500", 2020, 03, 01, 01, 02, 03, 123, TimeSpan.FromHours(-5) };
            yield return new object[] { "20200301010203-0500", 2020, 03, 01, 01, 02, 03, 0, TimeSpan.FromHours(-5) };
            yield return new object[] { "202003010102-0500", 2020, 03, 01, 01, 02, 0, 0, TimeSpan.FromHours(-5) };
            yield return new object[] { "2020030101-0500", 2020, 03, 01, 01, 0, 0, 0, TimeSpan.FromHours(-5) };
            yield return new object[] { "20200301-0500", 2020, 03, 01, 0, 0, 0, 0, TimeSpan.FromHours(-5) };
            yield return new object[] { "202003-0500", 2020, 03, 01, 0, 0, 0, 0, TimeSpan.FromHours(-5) };
            yield return new object[] { "2020-0500", 2020, 01, 01, 0, 0, 0, 0, TimeSpan.FromHours(-5) };
            yield return new object[] { "20200301010203.123", 2020, 03, 01, 01, 02, 03, 123, null };
            yield return new object[] { "20200301010203", 2020, 03, 01, 01, 02, 03, 0, null };
            yield return new object[] { "202003010102", 2020, 03, 01, 01, 02, 0, 0, null };
            yield return new object[] { "2020030101", 2020, 03, 01, 01, 0, 0, 0, null };
            yield return new object[] { "20200301", 2020, 03, 01, 0, 0, 0, 0, null };
            yield return new object[] { "202003", 2020, 03, 01, 0, 0, 0, 0, null };
            yield return new object[] { "2020", 2020, 01, 01, 0, 0, 0, 0, null };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
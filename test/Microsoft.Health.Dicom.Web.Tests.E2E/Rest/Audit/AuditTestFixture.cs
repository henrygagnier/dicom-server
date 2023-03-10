// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Health.Dicom.Core.Features.Diagnostic;

namespace Microsoft.Health.Dicom.Web.Tests.E2E.Rest.Audit;

public class AuditTestFixture : HttpIntegrationTestFixture<StartupWithTraceAuditLogger>
{
    private TraceDicomLogger _dicomLogger;

    public AuditTestFixture()
        : base()
    {
    }

    public TraceDicomLogger DicomLogger
    {
        get => _dicomLogger ?? (_dicomLogger = (TraceDicomLogger)(TestDicomWebServer as InProcTestDicomWebServer)?.Server.Host.Services.GetRequiredService<IDicomLogger>());
    }
}

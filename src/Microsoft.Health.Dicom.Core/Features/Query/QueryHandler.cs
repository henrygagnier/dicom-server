﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Health.Core.Features.Security.Authorization;
using Microsoft.Health.Dicom.Core.Exceptions;
using Microsoft.Health.Dicom.Core.Features.Common;
using Microsoft.Health.Dicom.Core.Features.Security;
using Microsoft.Health.Dicom.Core.Messages.Query;

namespace Microsoft.Health.Dicom.Core.Features.Query;

public class QueryHandler : BaseHandler, IRequestHandler<QueryResourceRequest, QueryResourceResponse>
{
    private readonly IQueryService _queryService;
    private readonly ILogger<QueryHandler> _logger;

    public QueryHandler(IAuthorizationService<DataActions> authorizationService, IQueryService queryService, ILogger<QueryHandler> logger)
        : base(authorizationService)
    {
        _queryService = EnsureArg.IsNotNull(queryService, nameof(queryService));
        _logger = EnsureArg.IsNotNull(logger, nameof(logger));
    }

    public async Task<QueryResourceResponse> Handle(QueryResourceRequest request, CancellationToken cancellationToken)
    {
        EnsureArg.IsNotNull(request, nameof(request));

        _logger.LogInformation("CodeChange - 1 in QueryHandler.Handler");

        if (await AuthorizationService.CheckAccess(DataActions.Read, cancellationToken) != DataActions.Read)
        {
            throw new UnauthorizedDicomActionException(DataActions.Read);
        }

        return await _queryService.QueryAsync(request.Parameters, cancellationToken);
    }
}

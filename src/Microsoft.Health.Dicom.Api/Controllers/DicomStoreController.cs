﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Threading.Tasks;
using Dicom;
using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Health.Dicom.Api.Features.Filters;
using Microsoft.Health.Dicom.Api.Features.Routing;
using Microsoft.Health.Dicom.Core.Extensions;
using Microsoft.Health.Dicom.Core.Messages.Store;
using Microsoft.Health.Dicom.Core.Web;

namespace Microsoft.Health.Dicom.Api.Controllers
{
    [Authorize]
    public class DicomStoreController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DicomStoreController> _logger;

        public DicomStoreController(IMediator mediator, ILogger<DicomStoreController> logger)
        {
            EnsureArg.IsNotNull(mediator, nameof(mediator));
            EnsureArg.IsNotNull(logger, nameof(logger));

            _mediator = mediator;
            _logger = logger;
        }

        [DisableRequestSizeLimit]
        [AcceptContentFilter(KnownContentTypes.ApplicationDicomJson)]
        [ProducesResponseType(typeof(DicomDataset), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(DicomDataset), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotAcceptable)]
        [ProducesResponseType(typeof(DicomDataset), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.UnsupportedMediaType)]
        [HttpPost]
        [Route(KnownRoutes.StoreRoute)]
        public async Task<IActionResult> PostAsync(string studyInstanceUid = null)
        {
            _logger.LogInformation($"DICOM Web Store Transaction request received, with study instance UID '{studyInstanceUid}'.");

            StoreDicomResponse storeResponse = await _mediator.StoreDicomResourcesAsync(
                Request.Body,
                Request.ContentType,
                studyInstanceUid,
                HttpContext.RequestAborted);

            return StatusCode(storeResponse.StatusCode, storeResponse.Dataset);
        }
    }
}

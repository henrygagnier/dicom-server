﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using EnsureThat;

namespace Microsoft.Health.Dicom.Core.Features.Partition
{
    public class DataPartition
    {
        public string PartitionId { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DataPartition(string partitionId, DateTimeOffset createdDate)
        {
            PartitionId = EnsureArg.IsNotNull(partitionId, nameof(partitionId));
            CreatedDate = createdDate;
        }
    }
}
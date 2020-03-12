﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------
namespace Microsoft.Health.Dicom.Core.Features.Query
{
    public abstract class QueryFilterConditionVisitor
    {
        public abstract void Visit(StringSingleValueMatchCondition stringSingleValueMatchCondition);

        public abstract void Visit(DateRangeValueMatchCondition rangeValueMatchCondition);

        public abstract void Visit(DateSingleValueMatchCondition dateSingleValueMatchCondition);
    }
}

﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.CoreWf;
using Microsoft.CoreWf.Expressions;
using Test.Common.TestObjects.Activities.Collections;

namespace Test.Common.TestObjects.Activities.Expressions
{
    public class TestIndexerReference<TOperand, TResult> : TestActivity
    {
        private MemberCollection<TestArgument> _indices;

        public TestIndexerReference()
        {
            this.ProductActivity = new IndexerReference<TOperand, TResult>();
            _indices = new MemberCollection<TestArgument>(AddArgument);
        }

        public TOperand Operand
        {
            set
            {
                this.ProductIndexerReference.Operand = value;
            }
        }

        public Variable<TOperand> OperandVariable
        {
            set
            {
                this.ProductIndexerReference.Operand = value;
            }
        }

        public MemberCollection<TestArgument> Indices
        {
            get
            {
                return _indices;
            }
        }

        public Variable<Location<TResult>> Result
        {
            set
            {
                this.ProductIndexerReference.Result = value;
            }
        }

        private IndexerReference<TOperand, TResult> ProductIndexerReference
        {
            get
            {
                return (IndexerReference<TOperand, TResult>)this.ProductActivity;
            }
        }

        private void AddArgument(TestArgument item)
        {
            this.ProductIndexerReference.Indices.Add((InArgument)item.ProductArgument);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Domain.UnaryOperation;

namespace WebCalc.Domain.BinaryOperation
{
    public interface IBinaryOperationManager
    {
        public BinaryOperation BinaryOperation { get; }

        public UnaryOperation.UnaryOperation NegationOperation { get; }

        public float GetMemoryAddResult(float operand);

        public void ClearMemory();
    }
}
﻿using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Domain.BinaryOperation;

namespace WebCalc.Domain.BinaryOperation
{
    public class BinaryOperationManager : IBinaryOperationManager
    {
        private readonly BinaryOperation memoryOperation;

        public BinaryOperation BinaryOperation { get; }
        public UnaryOperation.UnaryOperation NegationOperation { get; }

        public BinaryOperationManager()
        {
            BinaryOperation = new();
            memoryOperation = new();
            NegationOperation = new(OperationType.Multiplication, -1);
        }

        public float GetMemoryAddResult(float operand)
        {
            if (memoryOperation.OperationState is not OperationState.ResultSetted) memoryOperation.SetOperand(0);
            else memoryOperation.SetOperand(memoryOperation.Result);

            memoryOperation.SetOperationType(OperationType.Addition);
            memoryOperation.SetOperand(operand);
            memoryOperation.SetResult();

            return memoryOperation.Result!.Value;
        }

        public void ClearMemory()
        {
            memoryOperation.ClearOperation();
        }
    }
}

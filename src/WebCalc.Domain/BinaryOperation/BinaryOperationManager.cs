﻿using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalc.Domain.BinaryOperation;
using WebCalc.Domain.Shared;

namespace WebCalc.Domain.BinaryOperation
{
    public class BinaryOperationManager : IBinaryOperationManager
    {
        private readonly BinaryOperation memoryOperation;
        private UnaryOperation.UnaryOperation negationOperation;

        public BinaryOperation MainOperation { get; }

        public BinaryOperationManager()
        {
            MainOperation = new();
            memoryOperation = new();
            negationOperation = new(OperationType.Multiplication, -1);
        }

        public float GetNegateOperand()
        {
            if (MainOperation.OperationState is BinaryOperationState.SettingOperand1)
            {
                negationOperation.SetOperand(MainOperation.Operand1!.Value);
            }
            else
            {
                negationOperation.SetOperand(MainOperation.Operand2!.Value);
            }

            negationOperation.SetResult();
            MainOperation.SetOperand(negationOperation.Result);
            return negationOperation.Result!.Value;
        }

        public float GetMemoryAddResult(float operand)
        {
            if (memoryOperation.OperationState is not BinaryOperationState.ResultSetted) memoryOperation.SetOperand(0);
            else memoryOperation.SetOperand(memoryOperation.Result);

            memoryOperation.SetOperationType(OperationType.Addition);
            memoryOperation.SetOperand(operand);
            memoryOperation.SetResult();

            return memoryOperation.Result!.Value;
        }

        public void ClearMemory()
        {
            memoryOperation.Clear();
        }

        public float? ReadMemory() 
        {
            MainOperation.SetOperand(memoryOperation.Result);
            return memoryOperation.Result.HasValue? memoryOperation.Result.Value : null; 
        }
    }
}

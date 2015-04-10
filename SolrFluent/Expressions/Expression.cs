using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrFluent.Expressions
{
    //public interface IExpression
    //{
    //    IExpression And(IParameter expression);
    //    IExpression Or(IParameter expression);
    //}

    public enum ExpressionType
    {
        Or,
        And
    }

    //public class Expression : IExpression
    //{
    //    public ExpressionType ExpressionType { get; set; }
    //    public IParameter Left { get; set; }
    //    public IParameter Right { get; set; }

    //    public Expression(IParameter paramerter)
    //    {
    //        Left = paramerter;
    //    }

    //    public IExpression And(IParameter parameter)
    //    {
    //        ExpressionType = Expressions.ExpressionType.And;
    //        Right = parameter;
    //        return this;
    //    }

    //    public IExpression Or(IParameter parameter)
    //    {
    //        ExpressionType = Expressions.ExpressionType.Or;
    //        Right = parameter;
    //        return this;
    //    }
    //}

    public interface IParameter
    {
        IParameter And(IParameter parameter);
        IParameter Or(IParameter parameter);
    }

    public abstract class ParameterBase : IParameter
    {
        public ExpressionType ExpressionType { get; set; }
        public IParameter Left { get; set; }
        public IParameter Right { get; set; }

        public IParameter And(IParameter parameter)
        {
            ExpressionType = Expressions.ExpressionType.And;
            Right = parameter;
            return this;
        }

        public IParameter Or(IParameter parameter)
        {
            ExpressionType = Expressions.ExpressionType.Or;
            Right = parameter;
            return this;
        }
    }

    public interface ISimpleParameter : IParameter
    {
        string Field { get; }
        string Value { get; }
    }

    //public interface IComplexParameter : IParameter
    //{
    //    IExpression Expression { get; }
    //}

    //public class ComplexParameter : ParameterBase, IComplexParameter
    //{
    //    public ComplexParameter(IExpression expression)
    //    {
    //        Expression = expression;
    //    }

    //    public IExpression Expression
    //    {
    //        get;
    //        internal set;
    //    }
    //}


    public class SearchParameter : ParameterBase
    {
        public SearchParameter(string fieldName, string value)
        {
            Field = fieldName;
            Value = value;

            Left = this;
        }

        public string Field { get; protected set; }

        public string Value { get; protected set; }
    }
}

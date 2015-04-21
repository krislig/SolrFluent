using SolrFluent.Visitors;
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

    public interface IParameter : IVisitable
    {
        IParameter Left { get; }
        IParameter Right { get; }
        ExpressionType ExpressionType { get; }

        
    }

    public interface ISearchParameter : IParameter
    {
        string Field { get; }
        string Value { get; }

        ISearchParameter And(ISearchParameter parameter);
        ISearchParameter Or(ISearchParameter parameter);
    }
    
    public class Parameter : IParameter
    {
        public ExpressionType ExpressionType { get; set; }
        public IParameter Left { get; set; }
        public IParameter Right { get; set; }

        

        

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
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


    public class SearchParameter : Parameter, ISearchParameter
    {
        public SearchParameter(ISearchParameter parameter)
        {
            ExpressionType = parameter.ExpressionType;
            Field = parameter.Field;
            Value = parameter.Value;

            Left = parameter.Left;
            Right = parameter.Right;
        }

        public SearchParameter(string fieldName, string value)
        {
            Field = fieldName;
            Value = value;

            //Left = this;
        }

        public ISearchParameter And(ISearchParameter parameter)
        {
            ExpressionType = Expressions.ExpressionType.And;

            if (Right == null)
                Right = parameter;
            else
            {
                Left = new SearchParameter(this);
                Right = parameter;
            }
            return this;
        }

        public ISearchParameter Or(ISearchParameter parameter)
        {
            ExpressionType = Expressions.ExpressionType.Or;
            
            if (Right == null)
                Right = parameter;
            else
            {
                Left = new SearchParameter(this);
                Right = parameter;
            }
            return this;
        }

        public string Field { get; protected set; }

        public string Value { get; protected set; }
    }
}

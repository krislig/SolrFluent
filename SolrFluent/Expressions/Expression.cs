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
        IParameter LeftExpression { get; }
        IParameter RightExpression { get; }
        ExpressionType ExpressionType { get; }

        
    }

    public class SearchParameter
    {
        public string FieldName { get; set; }
        public string Value { get; set; }
    }

    public interface ISearchExpression : IParameter
    {
        ISearchExpression Left { get; set; }
        ISearchExpression Right { get; set; }

        string FieldName { get; set; }
        string Value { get; set; }

        ISearchExpression And(ISearchExpression parameter);
        ISearchExpression Or(ISearchExpression parameter);
    }
    
    public class Parameter : IParameter
    {
        public ExpressionType ExpressionType { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }

        public IParameter LeftExpression { get; set; }
        public IParameter RightExpression { get; set; }

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


    public class SearchExpression : Parameter, ISearchExpression
    {
        public SearchExpression(string fieldName, string value)
        {
             FieldName = fieldName; 
             Value = value;
        }

        internal SearchExpression(string fieldName, string value, ISearchExpression left, ISearchExpression right, ExpressionType expressionType) : this (fieldName, value)
        {
            Left = left;
            Right = right;
            ExpressionType = expressionType;
        }

        public ISearchExpression And(ISearchExpression expression)
        {
            this.Left = new SearchExpression(this.FieldName, this.Value, this.Left, this.Right, this.ExpressionType);
            this.Right = expression;
            this.ExpressionType = ExpressionType.And;

            return this;
        }

        public ISearchExpression Or(ISearchExpression expression)
        {
            this.Left = new SearchExpression(this.FieldName, this.Value, this.Left, this.Right, this.ExpressionType);
            this.Right = expression;
            this.ExpressionType = ExpressionType.Or;

            return this;
        }

        public ISearchExpression Left
        {
            get;
            set;
        }

        public ISearchExpression Right
        {
            get;
            set;
        }
    }
}

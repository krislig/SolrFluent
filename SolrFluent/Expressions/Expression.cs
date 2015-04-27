using SolrFluent.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrFluent.Expressions
{
    public enum ExpressionType
    {
        Or,
        And
    }

    public interface IExpression
    {

    }

    public interface ISearchExpression : IExpression, IVisitable 
    {
        ISearchExpression Left { get; }
        ISearchExpression Right { get; }
        ExpressionType ExpressionType { get; }

        string FieldName { get; }
        string Value { get; }

        ISearchExpression Or(ISearchExpression expression);
        ISearchExpression And(ISearchExpression expression);
    }

    public class SearchExpression : ISearchExpression
    {
        public string FieldName { get; set; }
        public string Value { get; set; }
        public ExpressionType ExpressionType { get; set; }
        public ISearchExpression Left { get; set; }
        public ISearchExpression Right { get; set; }
        
        
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
            this.FieldName = null;
            this.Value = null;

            return this;
        }

        public ISearchExpression Or(ISearchExpression expression)
        {
            this.Left = new SearchExpression(this.FieldName, this.Value, this.Left, this.Right, this.ExpressionType);
            this.Right = expression;
            this.ExpressionType = ExpressionType.Or;
            this.FieldName = null;
            this.Value = null;

            return this;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

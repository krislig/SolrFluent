using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrFluent.Expressions
{
    public interface IExpression
    {
        IExpression And(IExpression expression);
        IExpression Or(IExpression expression);
    }

    public enum ExpressionType
    {
        And,
        Or
    }

    public class Expression : IExpression
    {
        public ExpressionType ExpressionType { get; set; }
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        protected Expression()
        {

        }

        public Expression(IExpression expression)
        {
            Left = expression;
        }

        public IExpression And(IExpression expression)
        {
            ExpressionType = Expressions.ExpressionType.And;
            Right = expression;
            return this;
        }

        public IExpression Or(IExpression expression)
        {
            ExpressionType = Expressions.ExpressionType.Or;
            Right = expression;
            return this;
        }
    }

    public class SearchExpression : Expression
    {
        public string Field { get; set; }
        public string Value { get; set; }

        public SearchExpression(string fieldName, string value)
        {
            Field = fieldName;
            Value = value;
        }
    }
}

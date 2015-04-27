using SolrFluent.Expressions;
using SolrFluent.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SolrFluent.Tests
{
    public class ExpressionsTests
    {
        [Fact]
        public void SearchExpression_Simple_Ok()
        {
            var expression = new SearchExpression("inStock", "true");

            Assert.Null(expression.Left);
            Assert.Null(expression.Right);

            Assert.Equal(expression.FieldName, "inStock");
            Assert.Equal(expression.Value, "true");
        }
            
        [Fact]
        public void Search_SimpleTwoOrExpressions_Ok()
        {
            var expression1 = Search.CreateSearchParameter("inStock", "true").Or(Search.CreateSearchParameter("id", "1234"));
            var expression2 = Search.CreateSearchParameter("productName", "Monitor").Or(Search.CreateSearchParameter("brand", "dell"));

            var resultExpression = expression1.And(expression2);

            var countVisitor = new CountVisitor();

            countVisitor.CountParameters(resultExpression);
        }
    }
}

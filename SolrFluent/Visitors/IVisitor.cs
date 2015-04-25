using SolrFluent.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrFluent.Visitors
{
    public interface IVisitor
    {
        void Visit(IParameter parameter);
    }

    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    public class CountVisitor : IVisitor
    {
        public int Count { get; set; }
        public List<string> param = new List<string>();
        public void CountParameters(IVisitable parameter)
        {
            if (parameter is ISearchExpression)
            {
                var p = parameter as ISearchExpression;

                p.Accept(this);

                if (p.Left != null)
                    CountParameters(p.Left);

                if (p.Right != null)
                    CountParameters(p.Right);
            }
        }

        public void Visit(IParameter parameter)
        {
            var p = parameter as ISearchExpression;
            string lf = "";
            string lv = "";
            string rf = "";
            string rv = "";

            if (p.Left != null || p.Right != null)
            {
                if (p.Left != null)
                {
                    lf = p.Left.FieldName;
                    lv = p.Left.Value;
                }

                if (p.Right != null)
                {
                    rf = p.Right.FieldName;
                    rv = p.Right.Value;
                }

                param.Add(String.Format("LEFT Field: {0} Value: {1} {2} RIGHT Field: {3} Value: {4}", lf, lv, p.ExpressionType, rf, rv));
                Count++;
            }
        }
    }

}

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
            if (parameter is ISearchParameter)
            {
                var p = parameter as ISearchParameter;

                

                p.Accept(this);

                if (p.Left != null)
                    CountParameters(p.Left);

                if (p.Right != null)
                    CountParameters(p.Right);
            }
        }

        public void Visit(IParameter parameter)
        {
            var p = parameter as ISearchParameter;

            param.Add(String.Format("Field: {0} Value {1}", p.Field, p.Value));
            Count++;
        }
    }

}

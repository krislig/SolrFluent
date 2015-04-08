using SolrFluent.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrFluent.FluentInterfaces
{
    public interface IQuery
    {
        IQuery Search(IExpression expression);
        IQuery Search(string fieldName, string phrase);
        IQuery SearchPhrase(string fieldName, string phrase);
    }

    public interface IQueryBuilder
    {
        
    }

    public interface ISearch : IQueryBuilder
    {
        IQueryBuilder And();
        IQueryBuilder Or();
    }
}

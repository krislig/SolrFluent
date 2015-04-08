﻿using System;
using Xunit;

namespace SolrFluent.Tests
{
    public class QueryBuilderTests
    {
        [Fact]
        public void Ctor_DefaultAddress_Ok()
        {
            Assert.Equal("http://localhost:8983/solr/new_core", new QueryBuilder().ToString());
        }

        [Fact]
        public void Query_Simple_Ok()
        {
            //var qb = new QueryBuilder("", "").Search.Field("id").Value("1234").ToString();

            //var qb = new QueryBuilder("", "").Search("id", "1234", SearchType.Match).ToString();

            //var qb = new QueryBuilder("", "").Search("id", "1234", SearchType.Match).ToString();

            //var qb = new QueryBuilder("", "")
            //    .Search(Expression.And(Search.Expression("id", "1234", SearchType.Match), Search.Expression("id", "1234", SearchType.Match)).ToString();

            var qb = new QueryBuilder("", "")
                .Search(Search.Expression("inStock", "true").And(Search.Expression("id", "1234")))
                .Search("id", "1234");
            
            var expression  = Search.Expression("inStock", "true").And(Search.Expression("id", "1234"));

            qb.Search(expression.Or(Search.Expression("name", "adata")));

            qb.ToString();


            
        }
    }
}